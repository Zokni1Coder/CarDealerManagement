using Entities;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;
using System.Linq;

namespace Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarsDBContext _carsDBContext;

        public CarRepository(CarsDBContext carsDBContext)
        {
            this._carsDBContext = carsDBContext;
        }

        public async Task<CarResponse> AddCar(Car neweCar)
        {
            this._carsDBContext.Cars.Add(neweCar);
            this._carsDBContext.SaveChanges();
            return neweCar.ToCarResponse();
        }

        public async Task<bool> DeleteCar(Guid id)
        {
            int affectedRow = await this._carsDBContext.Cars.Select(car => car.id == id).ExecuteDeleteAsync();
            return affectedRow > 0;
        }

        public async Task<List<CarResponse>?> GetAllCars()
        {
            List<CarResponse>? cars = await this._carsDBContext.GetAllCars();

            return cars;
        }

        public async Task<CarResponse?> GetCarById(Guid id)
        {
            Car? searchedCar = await this._carsDBContext.Cars.FirstOrDefaultAsync(car => car.id == id);
            if (searchedCar == null) searchedCar = null as Car;

            return searchedCar?.ToCarResponse();
        }

        public async Task<CarResponse?> UpdateCar(UpdateCarRequest request)
        {
            Car? updatableCar = await this._carsDBContext.Cars.FirstOrDefaultAsync(car => car.id == request.id);

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

            return updatableCar.ToCarResponse();
        }
    }
}
