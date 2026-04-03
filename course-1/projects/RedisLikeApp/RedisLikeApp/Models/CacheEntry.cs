using System;
namespace RedisLikeApp.Models
{
	public class CacheEntry
	{
        public string? Key { get; set; }
        public string? Value { get; set; }
        public DateTime ExpiresAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

