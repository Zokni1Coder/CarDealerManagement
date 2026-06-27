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

        public Task<CarResponse> AddCar(AddCarRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCar(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CarResponse>?> GetAllCars()
        {
            List<CarResponse>? cars = await this._carsDBContext.GetAllCars();
            
            return cars; 
        }
    }
}
