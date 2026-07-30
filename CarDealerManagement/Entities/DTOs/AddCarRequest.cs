using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class AddCarRequest
    {
        public DateTime manufacturingDate { get; set; }
        public TransmissionType transmissionType { get; set; }
        public int km { get; set; }
        public int hp { get; set; }
        public FuelType fuelType { get; set; }
        public VehicleType vehicleType { get; set; }
        public string? model { get; set; }
        public string? manufacturer { get; set; }
        public decimal price { get; set; }

        public Car ToCar()
        {
            return new Car
            {
                manufacturingDate = manufacturingDate,
                transmissionType = transmissionType.ToString(),
                km = km,
                hp = hp,
                fuelType = fuelType.ToString(),
                vehicleType = vehicleType.ToString(),
                model = model,
                manufacturer = manufacturer,
                id = new Guid(),
                price = price
            };
        }
    }
}
