using System;
using Keeper.Dtos;
using Keeper.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keeper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class VisitorsController : ControllerBase
    {
        private readonly IGuardianService _service;
        public VisitorsController(IGuardianService service) => _service = service;

        /// <summary>
        /// Зарегистрировать нового посетителя
        /// </summary>
        /// <returns>Данные созданного посетителя</returns>
        /// <response code="201">Посетитель успешно зарегистрирован</response>
        [HttpPost]
        [ProducesResponseType(typeof(VisitorResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateVisitor()
        {
            var result = await _service.CreateVisitorAsync();
            return StatusCode(StatusCodes.Status201Created, result);
        }

        /// <summary>
        /// Получить список всех посетителей
        /// </summary>
        /// <returns>Массив посетителей с их уровнями доверия и историей действий</returns>
        /// <response code="200">Список успешно получен</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<VisitorResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllVisitorsAsync());

        /// <summary>
        /// Получить информацию о конкретном посетителе
        /// </summary>
        /// <param name="id">Идентификатор посетителя</param>
        /// <returns>Данные посетителя</returns>
        /// <response code="200">Посетитель найден</response>
        /// <response code="404">Посетитель с указанным ID не найден</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(VisitorResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            try { return Ok(await _service.GetVisitorByIdAsync(id)); }
            catch (NotFoundException ex) { return NotFound(new { message = ex.Message }); }
        }

        /// <summary>
        /// Выполнить действие перед Хранителем
        /// </summary>
        /// <param name="id">Идентификатор посетителя</param>
        /// <param name="request">Модель запроса с названием действия (Introduce, OfferHelp, Threaten)</param>
        /// <returns>Информация о выполненном действии и актуальный уровень доверия</returns>
        /// <response code="200">Действие успешно выполнено</response>
        /// <response code="400">Некорректное действие или действие уже выполнялось</response>
        /// <response code="404">Посетитель не найден</response>
        [HttpPost("{id}/actions")]
        [ProducesResponseType(typeof(ActionResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> PerformAction(int id, [FromBody] PerformActionRequest request)
        {
            try { return Ok(await _service.PerformActionAsync(id, request)); }
            catch (NotFoundException ex) { return NotFound(new { message = ex.Message }); }
            catch (BadRequestException ex) { return BadRequest(new { message = ex.Message }); }
        }

        /// <summary>
        /// Проверить возможность прохода в замок
        /// </summary>
        /// <param name="id">Идентификатор посетителя</param>
        /// <returns>Результат проверки доступа (разрешен или запрещен)</returns>
        /// <response code="200">Проверка выполнена (смотрите поле AccessGranted в ответе)</response>
        /// <response code="404">Посетитель не найден</response>
        [HttpGet("{id}/access")]
        [ProducesResponseType(typeof(AccessResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CheckAccess(int id)
        {
            try { return Ok(await _service.CheckAccessAsync(id)); }
            catch (NotFoundException ex) { return NotFound(new { message = ex.Message }); }
        }
    }
}

