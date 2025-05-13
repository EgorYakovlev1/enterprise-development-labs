namespace AutoDispatcher.Application.Contracts.TransportVehicle;
/// <summary>
/// Dto для создания или изменения авто
/// </summary>
/// <param name="LicensePlate">Госномер авто</param>
/// <param name="VehicleType">Тип авто</param>
/// <param name="ModelName">Модель авто</param>
/// <param name="MaxCapacity">Максимальная посадка</param>
/// <param name="YearOfManufacture">Год выпуска авто</param>
public record TransportVehicleCreateUpdateDto(string? LicensePlate, string? VehicleType, string? ModelName, int? MaxCapacity, int? YearOfManufacture);
