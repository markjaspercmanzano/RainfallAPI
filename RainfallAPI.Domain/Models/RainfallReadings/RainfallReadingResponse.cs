using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainfallAPI.Domain.Models.RainfallReadings
{
    public class RainfallReadingResponse
    {
        public IList<RainfallReading> Readings { get; set; }
    }
}
