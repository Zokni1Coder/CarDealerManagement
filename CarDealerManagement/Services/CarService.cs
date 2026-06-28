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

        public async Task<CarResponse> AddCar(AddCarRequest request)
        {
            Car newCar = request.ToCar();
            return await this._carRepository.AddCar(newCar);
        }

        public async Task<bool> DeleteCar(Guid id)
        {
            bool result = await this._carRepository.DeleteCar(id);
            return result;
        }

        public async Task<List<CarResponse>?> GetAllCars()
        {
            return await this._carRepository.GetAllCars();
        }

        public async Task<CarResponse?> UpdateCar(UpdateCarRequest request)
        {
           return await this._carRepository.UpdateCar(request);
        }

        public async Task<CarResponse?> GetCarById(Guid id)
        {
            return await this._carRepository.GetCarById(id);
        }
    }
}
