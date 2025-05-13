namespace AutoDispatcher.Application.Contracts;
/// <summary>
/// Интерфейс для службы, выполняющей аналитические запросы согласно бизнес-логике приложения
/// </summary>
public interface IAnalyticsService
{
    Task<string> GetFullInfoTransport(int key);
    Task<IList<string>> GetDriversBetweenTime(DateTime start, DateTime end);
    Task<IList<string>> GetHoursForTypeAndModel();
    Task<IList<string>> GetTop5Drivers();
    Task<IList<string>> GetDriverMaxAndAvgTime();
    Task<IList<string>> GetMaxTripsInBetween(DateTime start, DateTime end);
}
