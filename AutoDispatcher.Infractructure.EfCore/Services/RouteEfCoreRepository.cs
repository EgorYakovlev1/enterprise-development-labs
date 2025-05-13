using AutoDispatcher.Domain.Model;
using AutoDispatcher.Domain.Services;
using AutoDispatcher.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace AutoDispatcher.Infractructure.EfCore.Services;
public class RouteEfCoreRepository(AutoDispatcherDbContext context) : IRepository<Route, int>
{
    private readonly DbSet<Route> _routes = context.Routes;
    public async Task<Route> Add(Route entity)
    {
        var result = await _routes.AddAsync(entity);
        await context.SaveChangesAsync();
        return result.Entity;
    }
    
    public async Task<bool> Delete(int key)
    {
        var entity = await _routes.FirstOrDefaultAsync(e =>e.Id == key);
        if (entity == null)
            return false;
        _routes.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<Route?> Get(int key) =>
        await _routes.FirstOrDefaultAsync(e => e.Id == key);
    

    public async Task<IList<Route>> GetAll() =>
        await _routes.ToListAsync();

    public async Task<Route> Update(Route entity)
    {
        _routes.Update(entity);
        await context.SaveChangesAsync();
        return (await Get(entity.Id))!;
    }
}
