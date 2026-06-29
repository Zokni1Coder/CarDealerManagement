using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarResponse
    {
        public Guid id { get; set; }
        public DateTime manufacturingDate { get; set; }
        public string? transmissionType { get; set; }
        public int km { get; set; }
        public int hp { get; set; }
        public string? fuelType { get; set; }
        public string? vehicleType { get; set; }
        public string? model { get; set; }
        public string? manufacturer { get; set; }
        public double price { get; set; }
    }

    public static class CarExtension
    {

        public static CarResponse ToCarResponse(this Car car)
        {
            return new CarResponse
            {
                id = car.id,
                manufacturingDate = car.manufacturingDate,
                manufacturer = car.manufacturer,
                model = car.model,
                transmissionType = car.transmissionType,
                fuelType = car.fuelType,
                vehicleType = car.vehicleType,
                km = car.km,
                hp = car.hp,
                price = car.price
            };
        }
    }
}
