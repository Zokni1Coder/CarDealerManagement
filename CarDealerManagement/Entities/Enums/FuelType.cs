using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entities.Enums
{
    public enum FuelType
    {
        Benzin, Diesel,
        [Display(Name = "Hybrid (Petrol-Electric)")]
        HybridPetrolElectric, 
        [Display(Name = "Hybrid (Diesel-Electric)")]
        HybridDieselElectric
    }
}
