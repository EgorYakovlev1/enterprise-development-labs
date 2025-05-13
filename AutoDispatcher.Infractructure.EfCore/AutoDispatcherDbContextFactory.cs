using AutoDispatcher.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace AutoDispatcher.Infractructure.EfCore;
public class AutoDispatcherDbContextFactory : IDesignTimeDbContextFactory<AutoDispatcherDbContext>
{
    private const string ConnectionString = "Server=localhost;Username=postgres;Password=postgres;Database=AutoDispDB;Port=5432;";
    public AutoDispatcherDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AutoDispatcherDbContext>();
        optionsBuilder.UseNpgsql(ConnectionString);
        return new AutoDispatcherDbContext(optionsBuilder.Options);
    }
}