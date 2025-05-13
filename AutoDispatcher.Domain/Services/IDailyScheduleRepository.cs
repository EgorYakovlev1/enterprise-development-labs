using AutoDispatcher.Domain.Model;

namespace AutoDispatcher.Domain.Services;
/// <summary>
/// Наследник обобщенного интерфейса с дополнительной функциональностью 
/// </summary>
public interface IDailyScheduleRepository : IRepository<DailySchedule, int>
{
    Task<string> GetFullInfoTransport(int key);
    Task<IList<string>> GetDriversBetweenTime(DateTime start, DateTime end);
    Task<IList<string>> GetHoursForTypeAndModel();
    Task<IList<string>> GetTop5Drivers();
    Task<IList<string>> GetDriverMaxAndAvgTime();
    Task<IList<string>> GetMaxTripsInBetween(DateTime start, DateTime end);
}
