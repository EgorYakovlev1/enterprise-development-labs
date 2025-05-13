using AutoDispatcher.Application.Contracts;
using AutoDispatcher.Application.Contracts.Driver;

namespace AutoDispatcher.Server.Controllers;

/// <summary>
/// Контроллер для CRUD-операций над водителями
/// </summary>
/// <param name="crudService">CRUD-служба</param>
public class DriverController(ICrudService<DriverDto, DriverCreateUpdateDto, int> crudService)
    : CrudControllerBase<DriverDto, DriverCreateUpdateDto, int>(crudService);
