using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainfallAPI.Domain.Models
{
    public class RainfallReadingResponse
    {
        public RainfallReading[] Readings { get; set; }
    }
}
