using Entities.DTOs;
using Entities.Enums;

namespace ServiceContracts
{
    public interface ICarService
    {
        Task<List<CarResponse>?> GetAllCars();
        Task<CarResponse> AddCar(AddCarRequest request);
        Task<CarResponse?> UpdateCar(UpdateCarRequest request);
        Task<bool> DeleteCar(Guid id);
        Task<CarResponse?> GetCarById(Guid id);
        Task<List<CarResponse>?> Sorter(string? sortingProperty, SortingDirection? sortingDirection, List<CarResponse?>? cars);
        Task<List<CarResponse>?> SearchingCar(string searchingParameter, string? searchingValue);
        Task<List<CarResponse>?> FilteringCars(CarFilter carFilter, List<CarResponse> cars);
    }
}
