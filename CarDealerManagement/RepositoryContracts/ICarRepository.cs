using Entities.DTOs;

namespace RepositoryContracts
{
    public interface ICarRepository
    {
        Task<List<CarResponse>?> GetAllCars();
        Task<CarResponse> AddCar(AddCarRequest request);
        //Task<CarResponse> UpdateCar(UpdateCarRequest request);
        Task<bool> DeleteCar(Guid id);
    }
}
