namespace AutoDispatcher.Application.Contracts.DailySchedule;
/// <summary>
/// Dto для создания или изменения связи авто, водителя и маршрута
/// </summary>
/// <param name="TransportVehicleId">Идентификатор авто</param>
/// <param name="DriverId">Идентификатор водителя</param>
/// <param name="RouteId">Идентификатор маршрута</param>
/// <param name="StartTime">Дата и время начала поездки</param>
/// <param name="EndTime">Дата и время окончания поездки</param>
public record DailyScheduleCreateUpdateDto(int TransportVehicleId, int DriverId, int RouteId, DateTime StartTime, DateTime EndTime);
