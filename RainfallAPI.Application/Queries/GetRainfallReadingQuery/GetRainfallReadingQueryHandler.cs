using MediatR;
using RainfallAPI.Application.Queries.Models;
using RainfallAPI.Domain.Models.Errors;
using RainfallAPI.Domain.Models.RainfallReadings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainfallAPI.Application.Queries.GetRainfallReadingQuery
{
    public class GetRainfallReadingQueryHandler : IRequestHandler<GetRainfallReadingQuery, RainfallReadingQueryResponse>
    {
        private const int DefaultReadingCount = 10;
        private const int MinimumReadingCount = 1;
        private const int MaxReadingCount = 100;
        // for future use: add shared services in the constructor initialization
        public GetRainfallReadingQueryHandler() 
        {
        }

        public Task<RainfallReadingQueryResponse> Handle(GetRainfallReadingQuery request, CancellationToken cancellationToken)
        {
            var rainfallReadingQueryResponse = new RainfallReadingQueryResponse();
            if (!request.Count.HasValue) request.Count = DefaultReadingCount;

            if (string.IsNullOrEmpty(request.StationId))
            {
                rainfallReadingQueryResponse.ErrorResponses.Add(new Error()
                {
                    Message = "Station ID is required",
                    Detail = new List<ErrorDetail>() { new() { PropertyName = "StationID", Message = "Station ID cannot be null or empty."} }
                });
            }

            if (request.Count.Value < MinimumReadingCount && request.Count.Value > MaxReadingCount)
            {
                rainfallReadingQueryResponse.ErrorResponses.Add(new Error()
                {
                    Message = "Invalid Count",
                    Detail = new List<ErrorDetail>() { new() { PropertyName = "Count", Message = "Count should be between 1 to 100." } }
                });
            }
            return Task.FromResult(rainfallReadingQueryResponse);
        }
    }
}
