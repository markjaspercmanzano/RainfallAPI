using MediatR;
using RainfallAPI.Application.Queries.Models;
using RainfallAPI.Domain.Models.Errors;
using RainfallAPI.Domain.Models.RainfallReadings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RainfallAPI.Application.Queries.GetRainfallReadingQuery
{
    public class GetRainfallReadingQueryHandler : IRequestHandler<GetRainfallReadingQuery, RainfallReadingQueryResponse>
    {
        private const int DefaultReadingCount = 10;
        private const int MinimumReadingCount = 1;
        private const int MaxReadingCount = 100;
        private const string BaseUri = "http://environment.data.gov.uk/flood-monitoring";
        // for future use: add shared services in the constructor initialization
        public GetRainfallReadingQueryHandler()
        { 
        }

        public async Task<RainfallReadingQueryResponse> Handle(GetRainfallReadingQuery request, CancellationToken cancellationToken)
        {
            var rainfallReadingQueryResponse = new RainfallReadingQueryResponse();
            rainfallReadingQueryResponse.ErrorResponses = new List<Error>();
            if (!request.Count.HasValue) request.Count = DefaultReadingCount;

            if (string.IsNullOrEmpty(request.StationId))
            {
                rainfallReadingQueryResponse.ErrorResponses.Add(new Error()
                {
                    Message = "Station ID is required",
                    Detail = new List<ErrorDetail>() { new() { PropertyName = "StationID", Message = "Station ID cannot be null or empty."} }
                });
            }

            if (request.Count < MinimumReadingCount || request.Count > MaxReadingCount)
            {
                rainfallReadingQueryResponse.ErrorResponses.Add(new Error()
                {
                    Message = "Invalid Count",
                    Detail = new List<ErrorDetail>() { new() { PropertyName = "Count", Message = "Count should be between 1 to 100." } }
                });
            }

            rainfallReadingQueryResponse.RainfallReadings = await GetRainfallReadingResponses(request.StationId, request.Count.Value);

            if (rainfallReadingQueryResponse.RainfallReadings == null || rainfallReadingQueryResponse.RainfallReadings.Readings.Count == 0)
            {
                rainfallReadingQueryResponse.ErrorResponses.Add(new Error()
                {
                    Message = $"No rainfall readings found for Station ID {request.StationId}"
                });
            }

            return rainfallReadingQueryResponse;
        }

        private async Task<RainfallReadingResponse> GetRainfallReadingResponses(string stationId, int count)
        {
            // to-do: move this to a helper service for reusability
            using HttpClient client = new();
            var response = await client.GetAsync($"{BaseUri}/id/stations/{stationId}/readings?_limit={count}");
            var rainfallReadingResponse = await JsonSerializer.DeserializeAsync<RainfallReadingResponse>(await response.Content.ReadAsStreamAsync());

            return rainfallReadingResponse;
        }
    }
}
