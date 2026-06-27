using Entities.DTOs;

namespace ServiceContracts
{
    public interface ICarService
    {
        Task<List<CarResponse>?> GetAllCars();
        Task<CarResponse> AddCar(AddCarRequest request);
        //Task<CarResponse> UpdateCar(UpdateCarRequest request);
        Task<bool> DeleteCar(Guid id);
    }
}
