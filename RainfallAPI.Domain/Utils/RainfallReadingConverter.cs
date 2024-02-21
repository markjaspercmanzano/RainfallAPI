using RainfallAPI.Domain.Models.RainfallReadings;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RainfallAPI.Domain.Utils
{
    public class RainfallReadingConverter : JsonConverter <RainfallReading>
    {
        private const string DateTimePropertyName = "dateTime";
        private const string ValuePropertyName = "value";
        private const string DateMeasuredPropertyName = "dateMeasured";
        private const string AmountMeasuredPropertyName = "amountMeasured";
        public override RainfallReading Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using JsonDocument doc = JsonDocument.ParseValue(ref reader);

            return new RainfallReading
            {
                DateMeasured = doc.RootElement.GetProperty(DateTimePropertyName).GetString(),
                AmountMeasured = doc.RootElement.GetProperty(ValuePropertyName).GetDecimal()
            };
        }
        public override void Write(Utf8JsonWriter writer, RainfallReading value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString(DateMeasuredPropertyName, value.DateMeasured);
            writer.WriteNumber(AmountMeasuredPropertyName, value.AmountMeasured);
            writer.WriteEndObject();
        }
    }
}
