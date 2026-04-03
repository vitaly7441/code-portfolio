using System;
namespace RedisLikeApp.Models
{
	public class CacheSetRequest
	{
        public string? Key { get; set; }
        public string? Value { get; set; }
        public int TtlSeconds { get; set; }
    }
}

