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
        [StringLength(10)]
        public string? fuelType { get; set; }
        [Required]
        [StringLength(10)]
        public string? vehicleType { get; set; }
        [Required]
        [StringLength(20)]
        public string? model { get; set; }
        [Required]
        [StringLength(20)]
        public string? manufacturer { get; set; }
    }
}
