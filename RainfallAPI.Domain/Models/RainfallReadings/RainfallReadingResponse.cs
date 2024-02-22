using System.Text.Json.Serialization;

namespace RainfallAPI.Domain.Models.RainfallReadings
{
    public class RainfallReadingResponse
    {
        [JsonPropertyName("items")]
        public IList<RainfallReading> Readings { get; set; }
    }
}
