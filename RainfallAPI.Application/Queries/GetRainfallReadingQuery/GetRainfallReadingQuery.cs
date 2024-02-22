using MediatR;
using RainfallAPI.Application.Queries.Models;

namespace RainfallAPI.Application.Queries.GetRainfallReadingQuery
{
    public class GetRainfallReadingQuery : IRequest<RainfallReadingQueryResponse>
    {
        public string? StationId { get; set; }
        public int? Count { get; set; }
    }
}
