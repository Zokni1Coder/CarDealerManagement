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
    public class CarDealerDbContext : DbContext
    {
        public CarDealerDbContext(DbContextOptions<CarDealerDbContext> options) : base(options)
        {

        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public async Task<List<CarResponse>?> GetAllCars()
        {
            return await this.Cars.Select(car => car.ToCarResponse()).ToListAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            List<Car>? cars = new List<Car>();

            List<Customer>? customers = new List<Customer>();

            customers.Add(new Customer()
            {
                id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                firstName = "Ella",
                lastName = "Nut",
                birthDate = new DateTime(2000, 09, 22),
                phoneNumber = "064581306841",
                email = "asd@gmail.com",
                address = "asd str. 8A"
            });

            customers.Add(new Customer()
            {
                id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                firstName = "Elek",
                lastName = "Mek",
                birthDate = new DateTime(2013, 09, 26),
                phoneNumber = "064581306976",
                email = "asd@gmail.at",
                address = "asd str. 10A"
            });

            customers.Add(new Customer()
            {
                id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                firstName = "Edda",
                lastName = "Kor",
                birthDate = new DateTime(1986, 06, 10),
                phoneNumber = "064581300123",
                email = "asd@gmail.eu",
                address = "asd str. 26A"
            });

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

            foreach (Customer customer in customers)
            {
                modelBuilder.Entity<Customer>().HasData(customer);
            }

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Car)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.CarId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Customer)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.CustomerId);
        }
    }
}
