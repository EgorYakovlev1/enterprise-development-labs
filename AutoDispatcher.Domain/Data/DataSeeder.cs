using AutoDispatcher.Domain.Model;

namespace AutoDispatcher.Domain.Data;

/// <summary>
/// Класс для заполнения коллекций данными
/// </summary>
public static class DataSeeder
{
    /// <summary>
    /// Коллекция водителей
    /// </summary>
    public static readonly List<Driver> Drivers =
        [
            new()
            {
                Id = 1,
                FullName = "Козлов Алексей Григорьевич",
                PassportNumber = "101010",
                Address = "г. Выдумка, ул. Веселая, д. 1",
                DriverLicenseNumber = "0001",
                PhoneNumber = "+79601010101"
            },
            new()
            {
                Id = 2,
                FullName = "Петров Максим Евгеньевич",
                PassportNumber = "202020",
                Address = "г. Выдумка, ул. Хорошая, д. 10",
                DriverLicenseNumber = "0002",
                PhoneNumber = "+79601010102"
            },
            new()
            {
                Id = 3,
                FullName = "Лопаткин Иван Викторович",
                PassportNumber = "303030",
                Address = "г. Выдумка, ул. Замечательная, д. 100",
                DriverLicenseNumber = "0003",
                PhoneNumber = "+79601010103"
            }
        ];

    /// <summary>
    /// Коллекция авто
    /// </summary>
    public static readonly List<TransportVehicle> TransportVehicles =
        [
            new()
            {
                Id = 1,
                LicensePlate = "К100КК63",
                VehicleType = "Маршрутное такси",
                ModelName = "Ford Transit",
                MaxCapacity = 28,
                YearOfManufacture = 2021
            },
            new()
            {
                Id = 2,
                LicensePlate = "А200АА63",
                VehicleType = "Автобус",
                ModelName = "MAN Lion's City",
                MaxCapacity = 70,
                YearOfManufacture = 2017
            },
            new()
            {
                Id = 3,
                LicensePlate = "У300УУ63",
                VehicleType = "Лимузин",
                ModelName = "Lincoln Town Car",
                MaxCapacity = 10,
                YearOfManufacture = 2018
            },
        ];

    /// <summary>
    /// Коллекция маршрутов
    /// </summary>
    public static readonly List<Route> Routes =
        [
            new()
            {
                Id = 1,
                RouteNumber = "A-1",
                Description = "Внутригородской"
            },
            new()
            {
                Id = 2,
                RouteNumber = "A-2",
                Description = "Внутригородской (расширенный)"
            },
            new()
            {
                Id = 3,
                RouteNumber = "Б-1",
                Description = "Межгород (ближний)"
            },
            new()
            {
                Id = 4,
                RouteNumber = "Б-2",
                Description = "Межгород (дальний)"
            },
            new()
            {
                Id = 5,
                RouteNumber = "В-1",
                Description = "Туристический (спецзаказ)"
            }
        ];

    /// <summary>
    /// Коллекция связей авто, водителя и маршрута
    /// </summary>
    public static readonly List<DailySchedule> DailySchedules =
        [
            new()
            {
                Id = 1,
                TransportVehicleId = 1,
                RouteId = 1,
                DriverId = 1,
                StartTime = new DateTime(2025, 3, 18, 8, 0, 0),
                EndTime = new DateTime(2025, 3, 18, 20, 0, 0)
            },
            new()
            {
                Id = 2,
                TransportVehicleId = 2,
                RouteId = 3,
                DriverId = 2,
                StartTime = new DateTime(2025, 3, 18, 12, 0, 0),
                EndTime = new DateTime(2025, 3, 19, 8, 0, 0)
            },
            new()
            {
                Id = 3,
                TransportVehicleId = 3,
                RouteId = 5,
                DriverId = 3,
                StartTime = new DateTime(2025, 3, 18, 10, 0, 0),
                EndTime = new DateTime(2025, 3, 18, 18, 0, 0)
            },
            new()
            {
                Id = 4,
                TransportVehicleId = 1,
                RouteId = 4,
                DriverId = 1,
                StartTime = new DateTime(2025, 3, 19, 10, 0, 0),
                EndTime = new DateTime(2025, 3, 19, 20, 0, 0)
            },
            new()
            {
                Id = 5,
                TransportVehicleId = 2,
                RouteId = 2,
                DriverId = 3,
                StartTime = new DateTime(2025, 3, 19, 8, 0, 0),
                EndTime = new DateTime(2025, 3, 19, 20, 0, 0)
            }
        ];
}
