using AutoMapper;
using AutoDispatcher.Application;
using AutoDispatcher.Application.Contracts;
using AutoDispatcher.Application.Contracts.Driver;
using AutoDispatcher.Application.Contracts.TransportVehicle;
using AutoDispatcher.Application.Contracts.Route;
using AutoDispatcher.Application.Contracts.DailySchedule;
using AutoDispatcher.Application.Services;
using AutoDispatcher.Domain.Model;
using AutoDispatcher.Domain.Services;
using AutoDispatcher.Infractructure.EfCore.Services;
using AutoDispatcher.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
});

var mapperConfig = new MapperConfiguration(config => config.AddProfile(new AutoMapperProfile()));
IMapper? mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddTransient<IRepository<TransportVehicle, int>, TransportVehicleEfCoreRepository>();
builder.Services.AddTransient<IRepository<Driver, int>, DriverEfCoreRepository>();
builder.Services.AddTransient<IRepository<AutoDispatcher.Domain.Model.Route, int>, RouteEfCoreRepository>();
builder.Services.AddTransient<IDailyScheduleRepository, DailyScheduleEfCoreRepository>();

builder.Services.AddScoped<ICrudService<TransportVehicleDto, TransportVehicleCreateUpdateDto, int>, TransportVehicleCrudService>();
builder.Services.AddScoped<ICrudService<DriverDto, DriverCreateUpdateDto, int>, DriverCrudService>();
builder.Services.AddScoped<ICrudService<RouteDto, RouteCreateUpdateDto, int>, RouteCrudService>();
builder.Services.AddScoped<ICrudService<DailyScheduleDto, DailyScheduleCreateUpdateDto, int>, DailyScheduleCrudService>();
builder.Services.AddScoped<IAnalyticsService, DailyScheduleCrudService>();

builder.Services.AddDbContextFactory<AutoDispatcherDbContext>(options =>
    options.UseLazyLoadingProxies().UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
