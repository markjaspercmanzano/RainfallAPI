using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainfallAPI.Domain.Models.RainfallReadings
{
    public class RainfallReading
    {
        public required string DateMeasured { get; set; }
        public decimal AmountMeasured { get; set; }
    }
}
