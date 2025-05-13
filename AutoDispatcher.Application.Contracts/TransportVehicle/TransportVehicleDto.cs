namespace AutoDispatcher.Application.Contracts.TransportVehicle;
/// <summary>
/// Dto для просмотра сведений об авто
/// </summary>
/// <param name="Id">Идентификатор</param>
/// <param name="LicensePlate">Госномер авто</param>
/// <param name="VehicleType">Тип авто</param>
/// <param name="ModelName">Модель авто</param>
/// <param name="MaxCapacity">Максимальная посадка</param>
/// <param name="YearOfManufacture">Год выпуска авто</param>
public record TransportVehicleDto(int Id, string? LicensePlate, string? VehicleType, string? ModelName, int? MaxCapacity, int? YearOfManufacture);
