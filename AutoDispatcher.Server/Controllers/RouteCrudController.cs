using AutoDispatcher.Application.Contracts;
using AutoDispatcher.Application.Contracts.Route;

namespace AutoDispatcher.Server.Controllers;

/// <summary>
/// Контроллер для CRUD-операций над маршрутами
/// </summary>
/// <param name="crudService">CRUD-служба</param>
public class RouteController(ICrudService<RouteDto, RouteCreateUpdateDto, int> crudService)
    : CrudControllerBase<RouteDto, RouteCreateUpdateDto, int>(crudService);
