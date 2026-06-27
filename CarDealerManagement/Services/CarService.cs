using Entities;
using Entities.DTOs;
using Entities.Enums;
using RepositoryContracts;
using ServiceContracts;

namespace Services
{
    public class CarService : ICarService
    {
        private ICarRepository _carRepository { get; set; }
        public CarService(ICarRepository carRepository)
        {
           this._carRepository = carRepository; 
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
            return await this._carRepository.GetAllCars();
        }
    }
}
