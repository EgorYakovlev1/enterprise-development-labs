using AutoMapper;
using AutoDispatcher.Application.Contracts;
using AutoDispatcher.Application.Contracts.DailySchedule;
using AutoDispatcher.Domain.Model;
using AutoDispatcher.Domain.Services;

namespace AutoDispatcher.Application.Services;
/// <summary>
/// Служба слоя приложения для манипуляции над связью
/// </summary>
public class DailyScheduleCrudService(IDailyScheduleRepository repository, IMapper mapper) : ICrudService<DailyScheduleDto, DailyScheduleCreateUpdateDto, int>, IAnalyticsService
{
    public async Task<DailyScheduleDto> Create(DailyScheduleCreateUpdateDto newDto)
    {
        var newDailySchedule = mapper.Map<DailySchedule>(newDto);
        var res = await repository.Add(newDailySchedule);
        return mapper.Map<DailyScheduleDto>(res);
    }

    public async Task<bool> Delete(int id) =>
        await repository.Delete(id);
    

    public async Task<DailyScheduleDto?> GetById(int id)
    {
        var dailySchedule = await repository.Get(id);
        return mapper.Map<DailyScheduleDto>(dailySchedule);
    }

    public async Task<IList<DailyScheduleDto>> GetList() =>
        mapper.Map<List<DailyScheduleDto>>(await repository.GetAll());

    public async Task<DailyScheduleDto> Update(int key, DailyScheduleCreateUpdateDto newDto)
    {
        var newDailySchedule = mapper.Map<DailySchedule>(newDto);
        var res = await repository.Update(newDailySchedule);
        return mapper.Map<DailyScheduleDto>(res);
    }

    public async Task<string> GetFullInfoTransport(int key) =>
        await repository.GetFullInfoTransport(key);

    public async Task<IList<string>> GetDriversBetweenTime(DateTime start, DateTime end) =>
        await repository.GetDriversBetweenTime(start, end);

    public async Task<IList<string>> GetHoursForTypeAndModel() =>
        await repository.GetHoursForTypeAndModel();
    
    public async Task<IList<string>> GetTop5Drivers() =>
        await repository.GetTop5Drivers();

    public async Task<IList<string>> GetDriverMaxAndAvgTime() =>
        await repository.GetDriverMaxAndAvgTime();

    public async Task<IList<string>> GetMaxTripsInBetween(DateTime start, DateTime end) =>
        await repository.GetMaxTripsInBetween(start, end);
}
