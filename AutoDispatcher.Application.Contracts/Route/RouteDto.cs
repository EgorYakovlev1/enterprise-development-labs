namespace AutoDispatcher.Application.Contracts.Route;
/// <summary>
/// Dto для просмотра сведений о маршруте
/// </summary>
/// <param name="Id">Идентификатор</param>
/// <param name="RouteNumber">Номер маршрута</param>
/// <param name="Description">Описание маршрута</param>
public record RouteDto(int Id, string? RouteNumber, string? Description);
