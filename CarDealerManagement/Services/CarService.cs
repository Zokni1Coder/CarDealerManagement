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
            CarResponse? car = await this._carRepository.GetCarById(id);

            //if (car is not null)
            //{
            //    await using StreamWriter sw = new StreamWriter("~/SellingHistory.txt", append: true);                
            //    await sw.WriteLineAsync(car.ToString());
            //}

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

        private Dictionary<string, Func<CarResponse, object>> carProperties = new()
            {
                { nameof(CarResponse.manufacturer), car => car.manufacturer},
                { nameof(CarResponse.model), car => car.model},
                { nameof(CarResponse.vehicleType), car => car.vehicleType},
                { nameof(CarResponse.transmissionType), car => car.transmissionType},
                { nameof(CarResponse.fuelType), car => car.fuelType},
                { nameof(CarResponse.km), car => car.km},
                { nameof(CarResponse.price), car => car.price}
            };

        public async Task<List<CarResponse>?> Sorter(string? sortingProperty, SortingDirection? sortingDirection, List<CarResponse?>? cars)
        {
            if (sortingProperty is null)
            {
                return cars.OrderBy(car => car.manufacturer).ToList();
            }

            switch (sortingDirection)
            {
                case SortingDirection.ASC:
                    return cars.OrderBy(carProperties[sortingProperty]).ToList();

                case SortingDirection.DESC:
                    return cars.OrderByDescending(carProperties[sortingProperty]).ToList();
                default:
                    throw new Exception();
            }
        }

        public async Task<List<CarResponse>?> SearchingCar(string searchingParameter, string? searchingValue)
        {
            List<CarResponse>? cars = await this.GetAllCars();
            List<CarResponse>? searchingResult = cars?.Where(car => carProperties[searchingParameter](car).ToString().Contains(searchingValue, StringComparison.OrdinalIgnoreCase)).ToList();

            return searchingResult;
        }

        public async Task<List<CarResponse>?> FilteringCars(CarFilter carFilter, List<CarResponse> cars)
        {
            List<CarResponse>? filteredCars = cars.Where(car => car.km >= carFilter.km.From && car.km <= carFilter.km.To && car.price >= carFilter.price.From && car.price <= carFilter.price.To).ToList();

            if (carFilter.vehicleType != null)
            {
                filteredCars = filteredCars.Where(car => car.vehicleType == carFilter.vehicleType).ToList();
            }

            if (carFilter.fuelType != null)
            {
                filteredCars = filteredCars.Where(car => car.fuelType == carFilter.fuelType).ToList();
            }

            if (carFilter.transmissionType != null)
            {
                filteredCars = filteredCars.Where(car => car.transmissionType == carFilter.transmissionType).ToList();
            }

            return filteredCars;
        }
    }
}
