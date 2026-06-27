using Entities.DTOs;
using Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CarsDBContext : DbContext
    {
        public CarsDBContext(DbContextOptions<CarsDBContext> options) : base(options)
        {
            
        }
        public DbSet<Car> Cars { get; set; }

        public async Task<List<CarResponse>?> GetAllCars()
        {
            return await this.Cars.Select(car => car.ToCarResponse()).ToListAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            List<Car>? cars = new List<Car>();

            cars.Add(new Car()
            {
                id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                transmissionType = TransmissionType.Automatic.ToString(),
                fuelType = FuelType.Benzin.ToString(),
                model = "A4",
                manufacturer = "Audi",
                manufacturingDate = new DateTime(2020, 5, 1),
                hp = 122,
                km = 167000,
                vehicleType = VehicleType.Limousine.ToString()
            });
            cars.Add(new Car()
            {
                id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                transmissionType = TransmissionType.Automatic.ToString(),
                fuelType = FuelType.Benzin.ToString(),
                model = "Golf",
                manufacturer = "Volkswagen",
                manufacturingDate = new DateTime(2020, 5, 1),
                hp = 96,
                km = 235000,
                vehicleType = VehicleType.Compact.ToString()
            });
            cars.Add(new Car()
            {
                id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                transmissionType = TransmissionType.Automatic.ToString(),
                fuelType = FuelType.Benzin.ToString(),
                model = "Cupra",
                manufacturer = "Formentor",
                manufacturingDate = new DateTime(2020, 5, 1),
                hp = 150,
                km = 35000,
                vehicleType = VehicleType.SUV.ToString()
            });
            cars.Add(new Car()
            {
                id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                transmissionType = TransmissionType.Automatic.ToString(),
                fuelType = FuelType.Benzin.ToString(),
                model = "Skoda",
                manufacturer = "Karoq",
                manufacturingDate = new DateTime(2020, 5, 1),
                hp = 155,
                km = 27000,
                vehicleType = VehicleType.SUV.ToString()
            });
            cars.Add(new Car()
            {
                id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                transmissionType = TransmissionType.Automatic.ToString(),
                fuelType = FuelType.Benzin.ToString(),
                model = "BWM",
                manufacturer = "M4",
                manufacturingDate = new DateTime(2020, 5, 1),
                hp = 245,
                km = 123000,
                vehicleType = VehicleType.Coupé.ToString()
            });

            foreach (Car car in cars)
            {
                modelBuilder.Entity<Car>().HasData(car);
            }
        }
    }
}
