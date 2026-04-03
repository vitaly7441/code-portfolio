using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedisLikeApp.Models;
using RedisLikeApp.Services;

namespace RedisLikeApp.Controllers
{
    [ApiController]
    [Route("api/cache")]
    public class CacheController : Controller
    {
        private readonly CacheStorage _cacheStorage;

        public CacheController(CacheStorage cacheStorage)
        {
            _cacheStorage = cacheStorage;
        }

        [HttpPost("set")]
        public IActionResult Set([FromBody] CacheSetRequest request)
        {
            if (request == null ) {
                return BadRequest("Invalid request body.");
            }

            try {
                var entry = _cacheStorage.Set(request.Key, request.Value, request.TtlSeconds);
                return CreatedAtAction(nameof(Get), new { key = entry.Key }, new { entry.Key, entry.ExpiresAt });
            } catch (ArgumentException ex) {
                return BadRequest(ex.Message);
            } catch (Exception ex) {
                return StatusCode(500, "An error occurred while setting the cache entry. " + ex.Message);
            }
        }

        [HttpGet("get/{key}")]
        public IActionResult Get(string key)
        {
            var entry = _cacheStorage.Get(key);
            return entry == null ? NotFound() : Ok(entry);
        }

        [HttpDelete("{key}")]
        public IActionResult Delete(string key)
        {
            var deleted = _cacheStorage.Delete(key);
            return !deleted ? NotFound() : NoContent();
        }

        [HttpGet("stats")]
        public IActionResult GetStats()
        {
            var stats = _cacheStorage.GetStats();
            return Ok(stats);
        }
    }
}

