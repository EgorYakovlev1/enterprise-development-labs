using AutoDispatcher.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AutoDispatcher.Server.Controllers;

/// <summary>
/// Контроллер для выполнения аналитических запросов
/// </summary>
/// <param name="service">Служба для выполнения аналитических запросов</param>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController(IAnalyticsService service): ControllerBase
{
    /// <summary>
    /// Вывести все сведения о конкретном транспортном средстве
    /// </summary>
    [HttpGet("GetFullInfoTransport/{id}")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<string>> GetFullInfoTransport(int id) =>
        Ok(await service.GetFullInfoTransport(id));

    /// <summary>
    /// Вывести всех водителей, совершивших поездки за заданный период
    /// </summary>
    [HttpGet("GetDriversBetweenTime/{start}&{end}")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<List<string>>> GetDriversBetweenTime(DateTime start, DateTime end) =>
        Ok(await service.GetDriversBetweenTime(start, end));

    /// <summary>
    /// Вывести суммарное время поездок транспортного средства каждого типа и модели
    /// </summary>
    [HttpGet("GetHoursForTypeAndModel")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<List<string>>> GetHoursForTypeAndModel() =>
        Ok(await service.GetHoursForTypeAndModel());

    /// <summary>
    /// Вывести топ 5 водителей по совершенному количеству поездок
    /// </summary>
    [HttpGet("GetTop5Drivers")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<List<string>>> GetTop5Drivers() =>
        Ok(await service.GetTop5Drivers());
    
    /// <summary>
    /// Вывести информацию о количестве поездок, среднем времени и максимальном времени поездки для каждого водителя
    /// </summary>
    [HttpGet("GetDriverMaxAndAvgTime")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<List<string>>> GetDriverMaxAndAvgTime() =>
        Ok(await service.GetDriverMaxAndAvgTime());

    /// <summary>
    /// Вывести информацию о транспортных средствах, совершивших максимальное число поездок за указанный период
    /// </summary>
    [HttpGet("GetMaxTripsInBetween/{start}&{end}")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<List<string>>> GetMaxTripsInBetween(DateTime start, DateTime end) =>
        Ok(await service.GetMaxTripsInBetween(start, end));
}
