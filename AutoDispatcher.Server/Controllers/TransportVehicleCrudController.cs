using AutoDispatcher.Application.Contracts;
using AutoDispatcher.Application.Contracts.TransportVehicle;

namespace AutoDispatcher.Server.Controllers;

/// <summary>
/// Контроллер для CRUD-операций над авто
/// </summary>
/// <param name="crudService">CRUD-служба</param>
public class TransportVehicleController(ICrudService<TransportVehicleDto, TransportVehicleCreateUpdateDto, int> crudService)
    : CrudControllerBase<TransportVehicleDto, TransportVehicleCreateUpdateDto, int>(crudService);
