using AutoDispatcher.Domain.Model;
using AutoDispatcher.Domain.Services;
using AutoDispatcher.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace AutoDispatcher.Infractructure.EfCore.Services;
public class TransportVehicleEfCoreRepository(AutoDispatcherDbContext context) : IRepository<TransportVehicle, int>
{
    private readonly DbSet<TransportVehicle> _transportVehicles = context.TransportVehicles;
    public async Task<TransportVehicle> Add(TransportVehicle entity)
    {
        var result = await _transportVehicles.AddAsync(entity);
        await context.SaveChangesAsync();
        return result.Entity;
    }
    
    public async Task<bool> Delete(int key)
    {
        var entity = await _transportVehicles.FirstOrDefaultAsync(e =>e.Id == key);
        if (entity == null)
            return false;
        _transportVehicles.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<TransportVehicle?> Get(int key) =>
        await _transportVehicles.FirstOrDefaultAsync(e => e.Id == key);
    
    public async Task<IList<TransportVehicle>> GetAll() =>
        await _transportVehicles.ToListAsync();

    public async Task<TransportVehicle> Update(TransportVehicle entity)
    {
        _transportVehicles.Update(entity);
        await context.SaveChangesAsync();
        return (await Get(entity.Id))!;
    }
}
