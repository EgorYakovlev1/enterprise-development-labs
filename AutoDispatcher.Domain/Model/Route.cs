using System.ComponentModel.DataAnnotations;

namespace AutoDispatcher.Domain.Model;
/// <summary>
/// Маршрут
/// </summary>
public class Route
{
    /// <summary>
    /// Идентификатор маршрута
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    /// Номер маршрута
    /// </summary>
    public string? RouteNumber { get; set; }

    /// <summary>
    /// Описание маршрута
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Связь
    /// </summary>
    public virtual List<DailySchedule>? DailySchedules { get; set; }
}
