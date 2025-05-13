using AutoDispatcher.Domain.Data;
using AutoDispatcher.Domain.Model;

namespace AutoDispatcher.Domain.Services.InMemory;
/// <summary>
/// Имплементация репозитория для водителей, которая хранит коллекцию в оперативной памяти 
/// </summary>
public class DriverInMemoryRepository : IRepository<Driver, int>
{
    private List<Driver> _drivers;

    /// <summary>
    /// Конструктор репозитория
    /// </summary>
    public DriverInMemoryRepository()
    {
        _drivers = DataSeeder.Drivers;
    }

    /// <inheritdoc/>
    public Task<Driver> Add(Driver entity)
    {
        try
        {
            _drivers.Add(entity);
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
            var driver = await Get(key);
            if (driver != null)
                _drivers.Remove(driver);
        }
        catch
        {
            return false;
        }
        return true;
    }

    /// <inheritdoc/>
    public async Task<Driver> Update(Driver entity)
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

    /// <inheritdoc/>
    public Task<Driver?> Get(int key) =>
        Task.FromResult(_drivers.FirstOrDefault(item => item.Id == key));

    /// <inheritdoc/>
    public Task<IList<Driver>> GetAll() =>
        Task.FromResult((IList<Driver>)_drivers);
}
