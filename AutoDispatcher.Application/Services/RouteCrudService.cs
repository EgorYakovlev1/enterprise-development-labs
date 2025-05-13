using AutoMapper;
using AutoDispatcher.Application.Contracts;
using AutoDispatcher.Application.Contracts.Route;
using AutoDispatcher.Domain.Model;
using AutoDispatcher.Domain.Services;

namespace AutoDispatcher.Application.Services;
/// <summary>
/// Служба слоя приложения для манипуляции над маршрутами
/// </summary>
public class RouteCrudService(IRepository<Route, int> repository, IMapper mapper) : ICrudService<RouteDto, RouteCreateUpdateDto, int>
{
    public async Task<RouteDto> Create(RouteCreateUpdateDto newDto)
    {
        var newRoute = mapper.Map<Route>(newDto);
        newRoute.Id = (await repository.GetAll()).Max(x => x.Id) + 1;
        var res = await repository.Add(newRoute);
        return mapper.Map<RouteDto>(res);
    }

    public async Task<bool> Delete(int id) =>
        await repository.Delete(id);

    public async Task<RouteDto?> GetById(int id)
    {
        var route = await repository.Get(id);
        return mapper.Map<RouteDto>(route);
    }

    public async Task<IList<RouteDto>> GetList() =>
        mapper.Map<List<RouteDto>>(await repository.GetAll());

    public async Task<RouteDto> Update(int key, RouteCreateUpdateDto newDto)
    {
        var newRoute = mapper.Map<Route>(newDto);
        await repository.Update(newRoute);
        return mapper.Map<RouteDto>(newRoute);
    }
}
