using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RangeFilter
    {
        public int From { get; set; } = 0;
        public int To { get; set; } = int.MaxValue;
    }
}
