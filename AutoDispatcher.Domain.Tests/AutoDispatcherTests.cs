using AutoDispatcher.Domain.Services.InMemory;

namespace AutoDispatcher.Domain.Tests;

/// <summary>
///  Класс с юнит-тестами
/// </summary>
public class AutoDispatcherTests
{
    /// <summary>
    /// Непараметрический тест метода
    /// </summary>
    [Fact]
    public async Task GetTop5Drivers_Success()
    {
        var repo = new DailyScheduleInMemoryRepository();
        var drivers = await repo.GetTop5Drivers();
        Assert.Equal(3, drivers.Count);
    }
    /// <summary>
    /// Непараметрический тест метода
    /// </summary>
    [Fact]
    public async Task GetDriverMaxAndAvgTime_Success()
    {
        var repo = new DailyScheduleInMemoryRepository();
        var drivers = await repo.GetDriverMaxAndAvgTime();
        Assert.Equal(3, drivers.Count);
    }
}
