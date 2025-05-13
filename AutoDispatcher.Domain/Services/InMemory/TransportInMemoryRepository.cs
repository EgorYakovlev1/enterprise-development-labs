using AutoDispatcher.Domain.Data;
using AutoDispatcher.Domain.Model;
using System.Xml.Linq;

namespace AutoDispatcher.Domain.Services.InMemory;
/// <summary>
/// Имплементация репозитория для авто, которая хранит коллекцию в оперативной памяти 
/// </summary>
public class TransportInMemoryRepository : IRepository<TransportVehicle, int>
{
    private List<TransportVehicle> _transportVehicles;
    /// <summary>
    /// Конструктор репозитория
    /// </summary>
    public TransportInMemoryRepository()
    {
        _transportVehicles = DataSeeder.TransportVehicles;
    }

    /// <inheritdoc/>
    public Task<TransportVehicle> Add(TransportVehicle entity)
    {
        try
        {
            _transportVehicles.Add(entity);
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
            var book = await Get(key);
            if (book != null)
                _transportVehicles.Remove(book);
        }
        catch
        {
            return false;
        }
        return true;
    }

    /// <inheritdoc/>
    public Task<TransportVehicle?> Get(int key) =>
        Task.FromResult(_transportVehicles.FirstOrDefault(item => item.Id == key));

    /// <inheritdoc/>
    public Task<IList<TransportVehicle>> GetAll() =>
        Task.FromResult((IList<TransportVehicle>)_transportVehicles);

    /// <inheritdoc/>
    public async Task<TransportVehicle> Update(TransportVehicle entity)
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
}
