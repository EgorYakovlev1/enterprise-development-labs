using AutoMapper;
using AutoDispatcher.Application.Contracts.Driver;
using AutoDispatcher.Application.Contracts.TransportVehicle;
using AutoDispatcher.Application.Contracts.Route;
using AutoDispatcher.Application.Contracts.DailySchedule;
using AutoDispatcher.Domain.Model;

namespace AutoDispatcher.Application;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Driver, DriverDto>();
        CreateMap<DriverCreateUpdateDto, Driver>();

        CreateMap<TransportVehicle, TransportVehicleDto>();
        CreateMap<TransportVehicleCreateUpdateDto, TransportVehicle>();

        CreateMap<Route, RouteDto>();
        CreateMap<RouteCreateUpdateDto, Route>();

        CreateMap<DailySchedule, DailyScheduleDto>();
        CreateMap<DailyScheduleCreateUpdateDto, DailySchedule>();
    }
}
