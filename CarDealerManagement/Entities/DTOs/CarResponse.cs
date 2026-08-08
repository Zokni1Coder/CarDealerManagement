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
        public TransmissionType transmissionType { get; set; }
        public int km { get; set; }
        public int hp { get; set; }
        public FuelType fuelType { get; set; }
        public VehicleType vehicleType { get; set; }
        public string? model { get; set; }
        public string? manufacturer { get; set; }
        public decimal price { get; set; }
        public Guid? ReservationId { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    = new List<Reservation>();

        public override string ToString()
        {
            return $"{this.manufacturer}(Manufacturer), {this.model}(Model), {this.vehicleType}(Vehicle Type), {this.fuelType}(Fuel Type), {this.transmissionType}(Transmission Type), {this.manufacturingDate.ToString("dd-MM-yyyy")}(Manufacturing Date), {this.km}(KM), {this.hp}(HP), {this.price}(price)";
        }
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
                transmissionType = Enum.Parse<TransmissionType>(car.transmissionType),
                fuelType = Enum.Parse<FuelType>(car.fuelType),
                vehicleType = Enum.Parse<VehicleType>(car.vehicleType),
                km = car.km,
                hp = car.hp,
                price = car.price,
                ReservationId = car.ReservationId,
                Reservations = car.Reservations
            };
        }
    }
}
