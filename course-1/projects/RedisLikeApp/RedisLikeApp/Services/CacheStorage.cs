using System;
using RedisLikeApp.Models;
using System.Text.RegularExpressions;

namespace RedisLikeApp.Services
{
	public class CacheStorage
	{
        private readonly Dictionary<string, CacheEntry> _cache = new Dictionary<string, CacheEntry>();
        private readonly object _lock = new object();

        private void CleanExpiredEntries()
        {
            var now = DateTime.UtcNow;
            var keysToRemove = _cache.Where(pair => pair.Value.ExpiresAt < now).Select(pair => pair.Key).ToList();

            foreach (var key in keysToRemove) {
                _cache.Remove(key);
            }
        }

        public CacheEntry Set(string key, string value, int ttlSeconds)
        {
            if (!IsValidKey(key)) {
                throw new ArgumentException("Invalid key format.");
            }

            if (string.IsNullOrEmpty(value) || value.Length > 1000) {
                throw new ArgumentException("Invalid value format.");
            }

            if (ttlSeconds < 1 || ttlSeconds > 86400) {
                throw new ArgumentException("Invalid ttlSeconds value.");
            }

            lock (_lock) {
                CleanExpiredEntries();

                var now = DateTime.UtcNow;
                var expiresAt = now.AddSeconds(ttlSeconds);

                var entry = new CacheEntry {
                    Key = key,
                    Value = value,
                    CreatedAt = now,
                    ExpiresAt = expiresAt
                };

                _cache[key] = entry;

                return entry;
            }
        }

        public CacheEntry? Get(string key)
        {
            lock (_lock) {
                CleanExpiredEntries();

                return _cache.TryGetValue(key, out var entry)
                    ? entry
                    : null;
            }
        }

        public bool Delete(string key)
        {
            lock (_lock) {
                CleanExpiredEntries();
                return _cache.Remove(key);
            }
        }

        public CacheStats GetStats()
        {
            lock (_lock) {
                CleanExpiredEntries(); 

                var now = DateTime.UtcNow;
                var activeEntries = _cache.Values.Where(e => e.ExpiresAt >= now).ToList();
                var expiredCount = _cache.Count - activeEntries.Count;

                return new CacheStats {
                    Total = _cache.Count,
                    Active = activeEntries.Count,
                    ExpiringSoon = activeEntries.Count(e => e.ExpiresAt < now.AddMinutes(5)),
                    Expired = expiredCount
                };
            }
        }

        private bool IsValidKey(string key)
        {
            return string.IsNullOrEmpty(key) || key.Length > 100
            ? false
            : Regex.IsMatch(key, @"^[a-zA-Z0-9]+$");
        }
    }
}

