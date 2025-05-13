namespace AutoDispatcher.Application.Contracts.Driver;
/// <summary>
/// Dto для просмотра сведений о водителе
/// </summary>
/// <param name="Id">Идентификатор</param>
/// <param name="FullName">ФИО водителя</param>
/// <param name="PassportNumber">Номер паспорта</param>
/// <param name="DriverLicenseNumber">Номер водительского удостоверения</param>
/// <param name="Address">Адрес проживания</param>
/// <param name="PhoneNumber">Телефон</param>
public record DriverDto(int Id, string? FullName, string? PassportNumber, string? DriverLicenseNumber, string? Address, string? PhoneNumber);
