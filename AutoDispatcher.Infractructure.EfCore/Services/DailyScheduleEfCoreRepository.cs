using AutoDispatcher.Domain.Model;
using AutoDispatcher.Domain.Services;
using AutoDispatcher.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace AutoDispatcher.Infractructure.EfCore.Services;
public class DailyScheduleEfCoreRepository(AutoDispatcherDbContext context) : IDailyScheduleRepository
{
    private readonly DbSet<DailySchedule> _dailySchedules = context.DailySchedules;
    public async Task<DailySchedule> Add(DailySchedule entity)
    {
        var result = await _dailySchedules.AddAsync(entity);
        await context.SaveChangesAsync();
        return result.Entity;
    }
    
    public async Task<bool> Delete(int key)
    {
        var entity = await _dailySchedules.FirstOrDefaultAsync(e =>e.Id == key);
        if (entity == null)
            return false;
        _dailySchedules.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<DailySchedule?> Get(int key) =>
        await _dailySchedules.FirstOrDefaultAsync(e => e.Id == key);
    
    public async Task<IList<DailySchedule>> GetAll() =>
        await _dailySchedules.ToListAsync();

    public async Task<DailySchedule> Update(DailySchedule entity)
    {
        _dailySchedules.Update(entity);
        await context.SaveChangesAsync();
        return (await Get(entity.Id))!;
    }

    public async Task<string> GetFullInfoTransport(int key)
    {
        var dailySchedule = await Get(key);
        var transport = dailySchedule?.TransportVehicle;

        return string.Format("Тип авто: {0}\nМодель: {1}\nГосномер: {2}\nГод выпуска: {3}\nВместимость: {4}",
            transport?.VehicleType, transport?.ModelName, transport?.LicensePlate, transport?.YearOfManufacture, transport?.MaxCapacity);
    }

    public async Task<IList<string?>> GetDriversBetweenTime(DateTime start, DateTime end)
    {
        var dailySchedules = await GetAll();
        return [.. dailySchedules
            .Where(x => x.StartTime >= start && x.EndTime <= end)
            .Select(x => x.Driver?.FullName)
            .Distinct()
            .Order()];
    }

    public async Task<IList<string>> GetHoursForTypeAndModel()
    {
        var dailySchedules = await GetAll();
        return dailySchedules
            .GroupBy(a => new { a.TransportVehicle?.VehicleType, a.TransportVehicle?.ModelName })
            .Select(x => new
            {
                x.Key.VehicleType,
                x.Key.ModelName,
                TotalDuration = x.Sum(a => (a.EndTime - a.StartTime).Hours)
            })
            .Select(x => $"Тип: {x.VehicleType}, Модель: {x.ModelName}, Суммарное время поездок: {x.TotalDuration} часов")
            .ToList();
    }

    public async Task<IList<string>> GetTop5Drivers()
    {
        var dailySchedules = await GetAll();
        return dailySchedules
            .GroupBy(a => a.Driver?.FullName)
            .Select(x => new
            {
                DriverName = x.Key,
                TripCount = x.Count()
            })
            .OrderByDescending(x => x.TripCount)
            .Take(5)
            .Select(d => $"Водитель: {d.DriverName}, Количество поездок: {d.TripCount}")
            .ToList();
    }

    public async Task<IList<string>> GetDriverMaxAndAvgTime()
    {
        var dailySchedules = await GetAll();
        return dailySchedules
            .GroupBy(a => a.Driver?.FullName)
            .Select(x => new
            {
                DriverName = x.Key,
                TripCount = x.Count(),
                AverageDuration = x.Average(a => (a.EndTime - a.StartTime).TotalHours),
                MaxDuration = x.Max(a => (a.EndTime - a.StartTime).TotalHours)
            })
            .Select(x => $"Водитель: {x.DriverName}, " +
            $"Количество поездок: {x.TripCount}, " +
            $"Среднее время поездки: {x.AverageDuration} часов, " +
            $"Максимальное время поездки: {x.MaxDuration} часов")
            .ToList();
    }

    public async Task<IList<string>> GetMaxTripsInBetween(DateTime start, DateTime end)
    {
        var dailySchedules = await GetAll();
        var vehicleTripCounts = dailySchedules
            .Where(x => x.StartTime >= start && x.EndTime <= end)
            .GroupBy(a => a.TransportVehicleId)
            .Select(x => new
            {
                TransportVehicleId = x.Key,
                TripCount = x.Count()
            })
            .OrderByDescending(a => a.TripCount)
            .ToList();

        if (vehicleTripCounts.Count > 0)
        {
            var maxTripCount = vehicleTripCounts.First().TripCount;

            return vehicleTripCounts
                .Where(v => v.TripCount == maxTripCount)
                .Select(x => $"Транспортное средство: {x.TransportVehicleId}, Количество поездок: {x.TripCount}")
                .ToList();
        }
        else
        {
            return
            [
                "Нет данных о поездках за указанный период."
            ];
        }
    }
}
