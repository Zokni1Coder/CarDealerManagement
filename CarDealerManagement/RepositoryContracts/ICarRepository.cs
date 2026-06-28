using Entities;
using Entities.DTOs;

namespace RepositoryContracts
{
    public interface ICarRepository
    {
        Task<List<CarResponse>?> GetAllCars();
        Task<CarResponse> AddCar(Car newCar);
        Task<CarResponse?> UpdateCar(UpdateCarRequest request);
        Task<bool> DeleteCar(Guid id);
        Task<CarResponse?> GetCarById(Guid id);
    }
}
