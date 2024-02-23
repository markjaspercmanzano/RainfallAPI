using RainfallAPI.Application.Queries.GetRainfallReadingQuery;

namespace RainfallAPI.ApplicationTests.RainfallAPITests.Queries
{
    public class GetRainfallReadingQueryHandlerTests
    {
        private readonly GetRainfallReadingQueryHandler _handler;

        public GetRainfallReadingQueryHandlerTests()
        {
            _handler = new GetRainfallReadingQueryHandler();
        }

        [Fact]
        public async Task Handler_ValidStationIDAndCount_ShouldHaveNoErrors()
        {
            // Arrange
            var validRainfallReadingRequest = new GetRainfallReadingQuery()
            {
                StationId = "3680",
                Count = 10
            };

            // Act
            var response = await _handler.Handle(validRainfallReadingRequest, default);

            // Assert
            Assert.Empty(response.ErrorResponses.Errors);
        }

        [Fact]
        public async Task Handler_InvalidCount_ShouldHaveErrors()
        {
            // Arrange
            var validRainfallReadingRequest = new GetRainfallReadingQuery()
            {
                StationId = "3680",
                Count = 1000
            };

            // Act
            var response = await _handler.Handle(validRainfallReadingRequest, default);

            // Assert
            Assert.Single(response.ErrorResponses.Errors);
        }

        [Fact]
        public async Task Handler_EmptyRequest_ShouldHaveErrors()
        {
            // Arrange
            var validRainfallReadingRequest = new GetRainfallReadingQuery()
            {
                StationId = ""
            };


            // Act
            var response = await _handler.Handle(validRainfallReadingRequest, default);

            // Assert
            Assert.Single(response.ErrorResponses.Errors);
        }
    }
}
