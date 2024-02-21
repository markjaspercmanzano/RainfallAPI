using RainfallAPI.Domain.Utils;
using System.Text.Json.Serialization;

namespace RainfallAPI.Domain.Models.RainfallReadings
{
    [JsonConverter(typeof(RainfallReadingConverter))]
    public class RainfallReading
    {
        public required string DateMeasured { get; set; }
        public decimal AmountMeasured { get; set; }
    }
}
