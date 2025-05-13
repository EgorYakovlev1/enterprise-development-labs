using AutoDispatcher.Application.Contracts;
using AutoDispatcher.Application.Contracts.DailySchedule;

namespace AutoDispatcher.Server.Controllers;

/// <summary>
/// Контроллер для CRUD-операций над связями
/// </summary>
/// <param name="crudService">CRUD-служба</param>
public class DailyScheduleController(ICrudService<DailyScheduleDto, DailyScheduleCreateUpdateDto, int> crudService)
    : CrudControllerBase<DailyScheduleDto, DailyScheduleCreateUpdateDto, int>(crudService);
