using System.ComponentModel.DataAnnotations;

namespace AutoDispatcher.Domain.Model;

/// <summary>
/// Транспортное средство
/// </summary>
public class TransportVehicle
{
    /// <summary>
    /// Идентификатор т/с
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    /// Госномер т/с
    /// </summary>
    public string? LicensePlate { get; set; }

    /// <summary>
    /// Тип т/с
    /// </summary>
    public string? VehicleType { get; set; }

    /// <summary>
    /// Название модели т/с
    /// </summary>
    public string? ModelName { get; set; }

    /// <summary>
    /// Максимальная посадка т/с
    /// </summary>
    public int? MaxCapacity { get; set; }

    /// <summary>
    /// Год производства т/с
    /// </summary>
    public int? YearOfManufacture { get; set; }

    /// <summary>
    /// Связь
    /// </summary>
    public virtual List<DailySchedule>? DailySchedules { get; set; }
}
