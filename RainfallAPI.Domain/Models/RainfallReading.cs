using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainfallAPI.Domain.Models
{
    public class RainfallReading
    {
        public string DateMeasured { get; set; }
        public decimal AmountMeasured { get; set; }
    }
}
