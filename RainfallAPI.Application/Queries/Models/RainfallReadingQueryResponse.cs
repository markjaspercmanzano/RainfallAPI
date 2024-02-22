using RainfallAPI.Domain.Models.Errors;
using RainfallAPI.Domain.Models.RainfallReadings;

namespace RainfallAPI.Application.Queries.Models
{
    public class RainfallReadingQueryResponse
    {
        public RainfallReadingResponse RainfallReadings { get; set; }
        public IList<Error> ErrorResponses { get; set; }
    }
}
