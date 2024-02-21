using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RainfallAPI.Domain.Models.RainfallReadings
{
    public class RainfallReadingResponse
    {
        [JsonPropertyName("items")]
        public IList<RainfallReading> Readings { get; set; }
    }
}
