using System.ComponentModel.DataAnnotations;

namespace AutoDispatcher.Domain.Model;
/// <summary>
/// Водитель
/// </summary>
public class Driver
{
    /// <summary>
    /// Идентификатор водителя
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    /// ФИО водителя
    /// </summary>
    public string? FullName { get; set; }

    /// <summary>
    /// Номер паспорта водителя
    /// </summary>
    public string? PassportNumber { get; set; }

    /// <summary>
    /// Номер водительского удостоверения водителя
    /// </summary>
    public string? DriverLicenseNumber { get; set; }

    /// <summary>
    /// Адрес проживания водителя
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// Телефон водителя
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Связь
    /// </summary>
    public virtual List<DailySchedule>? DailySchedules { get; set; }
}
