using AutoDispatcher.Domain.Data;
using AutoDispatcher.Domain.Model;

namespace AutoDispatcher.Domain.Services.InMemory;
/// <summary>
/// Имплементация репозитория для маршрута, которая хранит коллекцию в оперативной памяти 
/// </summary>
public class RouteInMemoryRepository : IRepository<Route, int>
{
    private List<Route> _routes;
    /// <summary>
    /// Конструктор репозитория
    /// </summary>
    public RouteInMemoryRepository()
    {
        _routes = DataSeeder.Routes;
    }

    /// <inheritdoc/>
    public Task<Route> Add(Route entity)
    {
        try
        {
            _routes.Add(entity);
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
                _routes.Remove(book);
        }
        catch
        {
            return false;
        }
        return true;
    }

    /// <inheritdoc/>
    public Task<Route?> Get(int key) =>
        Task.FromResult(_routes.FirstOrDefault(item => item.Id == key));

    /// <inheritdoc/>
    public Task<IList<Route>> GetAll() =>
        Task.FromResult((IList<Route>)_routes);

    /// <inheritdoc/>
    public async Task<Route> Update(Route entity)
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
