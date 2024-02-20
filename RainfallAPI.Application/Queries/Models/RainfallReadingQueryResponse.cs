using RainfallAPI.Domain.Models.Errors;
using RainfallAPI.Domain.Models.RainfallReadings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainfallAPI.Application.Queries.Models
{
    public class RainfallReadingQueryResponse
    {
        public IList<RainfallReadingResponse> RainfallReadings { get; set; }
        public IList<Error> ErrorResponses { get; set; }
    }
}
