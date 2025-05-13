using AutoDispatcher.Domain.Data;
using AutoDispatcher.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace AutoDispatcher.Infrastructure.EfCore;

public class AutoDispatcherDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<TransportVehicle> TransportVehicles { get; set; }
    public DbSet<Route> Routes { get; set; }
    public DbSet<DailySchedule> DailySchedules { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Driver>(builder =>
        {
            builder.ToTable("Drivers");
            builder.HasKey(b => b.Id);
            builder.HasData(DataSeeder.Drivers);
        });

        modelBuilder.Entity<TransportVehicle>(builder =>
        {
            builder.ToTable("TransportVehicles");
            builder.HasKey(a => a.Id);
            builder.HasData(DataSeeder.TransportVehicles);
        });
        
        modelBuilder.Entity<Route>(builder =>
        {
            builder.ToTable("Routes");
            builder.HasKey(a => a.Id);
            builder.HasData(DataSeeder.Routes);
        });

        modelBuilder.Entity<DailySchedule>(builder =>
        {
            builder.ToTable("DailySchedules");
            builder.HasKey(ba => ba.Id);
            builder.HasOne(ba => ba.Driver).WithMany(b => b.DailySchedules).IsRequired();
            builder.HasOne(ba => ba.TransportVehicle).WithMany(b => b.DailySchedules).IsRequired();
            builder.HasOne(ba => ba.Route).WithMany(b => b.DailySchedules).IsRequired();
            builder.HasData(DataSeeder.DailySchedules);
        });
    }
}
