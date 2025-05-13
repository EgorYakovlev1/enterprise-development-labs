using System.ComponentModel.DataAnnotations;

namespace AutoDispatcher.Domain.Model;
/// <summary>
/// Связь авто, водителя и маршрута
/// </summary>
public class DailySchedule
{
    /// <summary>
    /// Идентификатор связи
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    /// Идентификатор авто
    /// </summary>
    public required int TransportVehicleId { get; set; }

    /// <summary>
    /// Навигейшн авто
    /// </summary>
    public virtual TransportVehicle? TransportVehicle { get; set; }

    /// <summary>
    /// Идентификатор водителя
    /// </summary>
    public required int DriverId { get; set; }

    /// <summary>
    /// Навигейшн водителя
    /// </summary>
    public virtual Driver? Driver { get; set; }

    /// <summary>
    /// Идентификатор маршрута
    /// </summary>
    public required int RouteId { get; set; }

    /// <summary>
    /// Навигейшн маршрута
    /// </summary>
    public virtual Route? Route { get; set; }

    /// <summary>
    /// Время выхода на маршрут
    /// </summary>
    public required DateTime StartTime { get; set; }

    /// <summary>
    /// Время окончания маршрута
    /// </summary>
    public required DateTime EndTime { get; set; }
}
