using System;
using Microsoft.AspNetCore.Mvc;
using Treasury.Dtos;
using Treasury.Services;

namespace Treasury.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ConstellationsController : ControllerBase
    {
        private readonly IConstellationService _service;

        public ConstellationsController(IConstellationService service)
        {
            _service = service;
        }

        /// <summary>
        /// Восстановить код созвездия
        /// </summary>
        /// <param name="request">Эталонный и поврежденный коды</param>
        /// <returns>Список отсутствующих символов и статус isComplete</returns>
        /// <response code="200">Алгоритм успешно отработал</response>
        /// <response code="400">Некорректные входные данные</response>
        [HttpPost("restore")]
        [ProducesResponseType(typeof(RestoreCodeResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Restore([FromBody] RestoreCodeRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = _service.RestoreCode(request);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}

