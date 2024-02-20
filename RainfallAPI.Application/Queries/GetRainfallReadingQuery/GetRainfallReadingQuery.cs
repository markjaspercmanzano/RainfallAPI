using MediatR;
using RainfallAPI.Application.Queries.Models;
using RainfallAPI.Domain.Models.RainfallReadings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainfallAPI.Application.Queries.GetRainfallReadingQuery
{
    public class GetRainfallReadingQuery : IRequest<RainfallReadingQueryResponse>
    {
        public string? StationId { get; set; }
        public int? Count { get; set; }
    }
}
