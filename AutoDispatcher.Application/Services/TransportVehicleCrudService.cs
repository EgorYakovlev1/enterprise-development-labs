using AutoMapper;
using AutoDispatcher.Application.Contracts;
using AutoDispatcher.Application.Contracts.TransportVehicle;
using AutoDispatcher.Domain.Model;
using AutoDispatcher.Domain.Services;
using TransportVehicle = AutoDispatcher.Domain.Model.TransportVehicle;

namespace AutoDispatcher.Application.Services;
/// <summary>
/// Служба слоя приложения для манипуляции над авто
/// </summary>
public class TransportVehicleCrudService(IRepository<TransportVehicle, int> repository, IMapper mapper) : ICrudService<TransportVehicleDto, TransportVehicleCreateUpdateDto, int>
{
    public async Task<TransportVehicleDto> Create(TransportVehicleCreateUpdateDto newDto)
    {
        var newTransportVehicle = mapper.Map<TransportVehicle>(newDto);
        newTransportVehicle.Id = (await repository.GetAll()).Max(x => x.Id) + 1;
        var res = await repository.Add(newTransportVehicle);
        return mapper.Map<TransportVehicleDto>(res);
    }

    public async Task<bool> Delete(int id) =>
        await repository.Delete(id);

    public async Task<TransportVehicleDto?> GetById(int id)
    {
        var book = await repository.Get(id);
        return mapper.Map<TransportVehicleDto>(book);
    }

    public async Task<IList<TransportVehicleDto>> GetList() =>
        mapper.Map<List<TransportVehicleDto>>(await repository.GetAll());

    public async Task<TransportVehicleDto> Update(int key, TransportVehicleCreateUpdateDto newDto)
    {
        var newTransportVehicle = mapper.Map<TransportVehicle>(newDto);
        await repository.Update(newTransportVehicle);
        return mapper.Map<TransportVehicleDto>(newTransportVehicle);
    }
}
