namespace AutoDispatcher.Application.Contracts.Route;
/// <summary>
/// Dto для создания или изменения маршрута
/// </summary>
/// <param name="RouteNumber">Номер маршрута</param>
/// <param name="Description">Описание маршрута</param>
public record RouteCreateUpdateDto(string? RouteNumber, string? Description);