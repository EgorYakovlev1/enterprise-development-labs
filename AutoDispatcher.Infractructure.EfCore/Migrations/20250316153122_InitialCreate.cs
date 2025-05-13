using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutoDispatcher.Infractructure.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    PassportNumber = table.Column<string>(type: "text", nullable: true),
                    DriverLicenseNumber = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RouteNumber = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransportVehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LicensePlate = table.Column<string>(type: "text", nullable: true),
                    VehicleType = table.Column<string>(type: "text", nullable: true),
                    ModelName = table.Column<string>(type: "text", nullable: true),
                    MaxCapacity = table.Column<int>(type: "integer", nullable: true),
                    YearOfManufacture = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportVehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DailySchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TransportVehicleId = table.Column<int>(type: "integer", nullable: false),
                    DriverId = table.Column<int>(type: "integer", nullable: false),
                    RouteId = table.Column<int>(type: "integer", nullable: false),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailySchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailySchedules_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailySchedules_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailySchedules_TransportVehicles_TransportVehicleId",
                        column: x => x.TransportVehicleId,
                        principalTable: "TransportVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "Address", "DriverLicenseNumber", "FullName", "PassportNumber", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "г. Выдумка, ул. Веселая, д. 1", "0001", "Козлов Алексей Григорьевич", "101010", "+79601010101" },
                    { 2, "г. Выдумка, ул. Хорошая, д. 10", "0002", "Петров Максим Евгеньевич", "202020", "+79601010102" },
                    { 3, "г. Выдумка, ул. Замечательная, д. 100", "0003", "Лопаткин Иван Викторович", "303030", "+79601010103" }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "Description", "RouteNumber" },
                values: new object[,]
                {
                    { 1, "Внутригородской", "A-1" },
                    { 2, "Внутригородской (расширенный)", "A-2" },
                    { 3, "Межгород (ближний)", "Б-1" },
                    { 4, "Межгород (дальний)", "Б-2" },
                    { 5, "Туристический (спецзаказ)", "В-1" }
                });

            migrationBuilder.InsertData(
                table: "TransportVehicles",
                columns: new[] { "Id", "LicensePlate", "MaxCapacity", "ModelName", "VehicleType", "YearOfManufacture" },
                values: new object[,]
                {
                    { 1, "К100КК63", 28, "Ford Transit", "Маршрутное такси", 2021 },
                    { 2, "А200АА63", 70, "MAN Lion's City", "Автобус", 2017 },
                    { 3, "У300УУ63", 10, "Lincoln Town Car", "Лимузин", 2018 }
                });

            migrationBuilder.InsertData(
                table: "DailySchedules",
                columns: new[] { "Id", "DriverId", "EndTime", "RouteId", "StartTime", "TransportVehicleId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 3, 18, 20, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 3, 18, 8, 0, 0, 0, DateTimeKind.Utc), 1 },
                    { 2, 2, new DateTime(2025, 3, 19, 8, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(2025, 3, 18, 12, 0, 0, 0, DateTimeKind.Utc), 2 },
                    { 3, 3, new DateTime(2025, 3, 18, 18, 0, 0, 0, DateTimeKind.Utc), 5, new DateTime(2025, 3, 18, 10, 0, 0, 0, DateTimeKind.Utc), 3 },
                    { 4, 1, new DateTime(2025, 3, 19, 20, 0, 0, 0, DateTimeKind.Utc), 4, new DateTime(2025, 3, 19, 10, 0, 0, 0, DateTimeKind.Utc), 1 },
                    { 5, 3, new DateTime(2025, 3, 19, 20, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(2025, 3, 19, 8, 0, 0, 0, DateTimeKind.Utc), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailySchedules_DriverId",
                table: "DailySchedules",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_DailySchedules_RouteId",
                table: "DailySchedules",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_DailySchedules_TransportVehicleId",
                table: "DailySchedules",
                column: "TransportVehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailySchedules");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "TransportVehicles");
        }
    }
}
