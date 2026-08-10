using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarFilter
    {
        public TransmissionType? transmissionType { get; set; }
        public RangeFilter? km { get; set; } = new RangeFilter();
        public FuelType? fuelType { get; set; }
        public VehicleType? vehicleType { get; set; }
        public RangeFilter? price { get; set; } = new RangeFilter();

        public bool HasValue()
        {
            return transmissionType is not null || km.From is not 0 || km.To is not int.MaxValue || fuelType is not null || vehicleType is not null || price.From is not 0 || price.To is not int.MaxValue; 
        }
    }
}
