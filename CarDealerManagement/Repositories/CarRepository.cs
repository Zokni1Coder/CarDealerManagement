using Entities;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;
using System.Linq;

namespace Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarDealerDbContext _carDealerDbContext;

        public CarRepository(CarDealerDbContext carsDBContext)
        {
            this._carDealerDbContext = carsDBContext;
        }

        public async Task<CarResponse> AddCar(Car neweCar)
        {
            this._carDealerDbContext.Cars.Add(neweCar);
            this._carDealerDbContext.SaveChanges();
            return neweCar.ToCarResponse();
        }

        public async Task<bool> DeleteCar(Guid id)
        {
            int affectedRow = await this._carDealerDbContext.Cars.Where(car => car.id == id).ExecuteDeleteAsync();

            await this._carDealerDbContext.SaveChangesAsync();
            return affectedRow > 0;
        }

        public async Task<List<CarResponse>?> GetAllCars()
        {
            List<CarResponse>? cars = await this._carDealerDbContext.GetAllCars();

            return cars;
        }

        public async Task<CarResponse?> GetCarById(Guid id)
        {
            Car? searchedCar = await this._carDealerDbContext.Cars.FirstOrDefaultAsync(car => car.id == id);
            if (searchedCar == null) searchedCar = null as Car;

            return searchedCar?.ToCarResponse();
        }

        public async Task<CarResponse?> UpdateCar(UpdateCarRequest request)
        {
            Car? updatableCar = await this._carDealerDbContext.Cars.FirstOrDefaultAsync(car => car.id == request.id);

            if (updatableCar == null)
            {
                updatableCar = null as Car;                
            }

            updatableCar.model = request.model;
            updatableCar.manufacturer = request.manufacturer;
            updatableCar.manufacturingDate = request.manufacturingDate;
            updatableCar.hp = request.hp;
            updatableCar.km = request.km;
            updatableCar.fuelType = request.fuelType.ToString();
            updatableCar.vehicleType = request.vehicleType.ToString();
            updatableCar.transmissionType = request.transmissionType.ToString();

            await this._carDealerDbContext.SaveChangesAsync();

            return updatableCar.ToCarResponse();
        }
    }
}
