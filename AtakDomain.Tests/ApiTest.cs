using AtakDomain.Common.Models;
using System.Net;
using System.Net.Http.Json;

namespace AtakDomain.Tests
{
    public class ApiTest
    {
        [Fact]
        public async Task GetHistory_ShouldReturn_ZeroProducts()
        {
            // Arrange
            using var application = new TestApp();
            var client = application.CreateClient();

            // Act
            var response = await client.GetAsync("/api/History?userId=user-1");

            // Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GetBestSeller_ShouldReturn_ZeroProduct()
        {
            // Arrange
            using var application = new TestApp();
            var client = application.CreateClient();

            // Act
            var response = await client.GetFromJsonAsync<Response>("/api/BestSeller?userId=user-1");

            // Assert
            Assert.NotNull(response);
            Assert.Equal(0, response?.Products.Count);
        }
    }
}