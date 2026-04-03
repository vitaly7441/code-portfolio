using System;
namespace RedisLikeApp.Models
{
	public class CacheStats
	{
        public int Total { get; set; }
        public int Active { get; set; }
        public int ExpiringSoon { get; set; }
        public int Expired { get; set; }
	}
}

