using AutoDispatcher.Domain.Data;
using AutoDispatcher.Domain.Model;

namespace AutoDispatcher.Domain.Services.InMemory;
/// <summary>
/// Имплементация репозитория для связующей сущности, которая хранит коллекцию в оперативной памяти 
/// </summary>
public class DailyScheduleInMemoryRepository : IDailyScheduleRepository
{
    private List<Driver> _drivers;
    private List<TransportVehicle> _transportVehicles;
    private List<Route> _routes;
    private List<DailySchedule> _dailySchedules;


    /// <summary>
    /// Конструктор репозитория
    /// </summary>
    public DailyScheduleInMemoryRepository()
    {
        _drivers = DataSeeder.Drivers;
        _transportVehicles = DataSeeder.TransportVehicles;
        _routes = DataSeeder.Routes;
        _dailySchedules = DataSeeder.DailySchedules;

        foreach (var ba in _dailySchedules)
        {
            ba.Driver = _drivers.FirstOrDefault(a => a.Id == ba.DriverId);
            ba.TransportVehicle = _transportVehicles.FirstOrDefault(a => a.Id == ba.TransportVehicleId);
            ba.Route = _routes.FirstOrDefault(a => a.Id == ba.RouteId);
        }

        foreach (var b in _transportVehicles)
        {
            b.DailySchedules = [];
            b.DailySchedules?.AddRange(_dailySchedules.Where(ba => ba.TransportVehicleId == b.Id));
        }

        foreach (var a in _routes)
        {
            a.DailySchedules = [];
            a.DailySchedules?.AddRange(_dailySchedules.Where(ba => ba.RouteId == a.Id));
        }

        foreach (var a in _drivers)
        {
            a.DailySchedules = [];
            a.DailySchedules?.AddRange(_dailySchedules.Where(ba => ba.DriverId == a.Id));
        }
    }

    /// <inheritdoc/>
    public Task<DailySchedule> Add(DailySchedule entity)
    {
        try
        {
            _dailySchedules.Add(entity);
        }
        catch
        {
            return null!;
        }
        return Task.FromResult(entity);
    }

    /// <inheritdoc/>
    public async Task<bool> Delete(int key)
    {
        try
        {
            var bookAuthor = await Get(key);
            if (bookAuthor != null)
                _dailySchedules.Remove(bookAuthor);
        }
        catch
        {
            return false;
        }
        return true;
    }

    /// <inheritdoc/>
    public Task<DailySchedule?> Get(int key) =>
        Task.FromResult(_dailySchedules.FirstOrDefault(item => item.Id == key));

    /// <inheritdoc/>
    public Task<IList<DailySchedule>> GetAll() =>
        Task.FromResult((IList<DailySchedule>)_dailySchedules);

    /// <inheritdoc/>
    public async Task<DailySchedule> Update(DailySchedule entity)
    {
        try
        {
            await Delete(entity.Id);
            await Add(entity);
        }
        catch
        {
            return null!;
        }
        return entity;
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
                TotalDuration = x.Sum(a => (a.EndTime - a.StartTime).TotalHours)
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
            .DistinctBy(x => x.DriverName)
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
