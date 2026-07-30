using Entities.DTOs;
using Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Car
    {
        [Key]
        public Guid id { get; set; }
        [Required]
        public DateTime manufacturingDate { get; set; }
        [Required]
        [StringLength(9)]
        public string? transmissionType { get; set; }
        [Required]
        public int km { get; set; }
        [Required]
        public int hp { get; set; }
        [Required]
        [StringLength(25)]
        public string fuelType { get; set; } = null!;
        [Required]
        [StringLength(10)]
        public string vehicleType { get; set; } = null!;
        [Required]
        [StringLength(20)]
        public string model { get; set; } = null!;
        [Required]
        [StringLength(20)]
        public string manufacturer { get; set; } = null!;
        [Required]
        public decimal price { get; set; }
        public Guid? ReservationId { get; set; }
        public Reservation? Reservation { get; set; }

        public override bool Equals(object? obj)
        {            
            if (obj is not Car)
            {
               return false;
            }
            Car? temp = obj as Car;

            return this.id == temp?.id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"{this.manufacturer}(Manufacturer), {this.model}(Model), {this.vehicleType}(Vehicle Type), {this.fuelType}(Fuel Type), {this.transmissionType}(Transmission Type), {this.manufacturingDate.ToString("dd-MM-yyyy")}(Manufacturing Date), {this.km}(KM), {this.hp}(HP), {this.price}(price)";
        }
    }
}
