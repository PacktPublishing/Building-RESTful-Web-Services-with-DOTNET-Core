using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace Chap06_02_Test.Services
{
    public class ProductTest
    {
        public ProductTest()
        {
            // Arrange
            var server = new TestServer(new WebHostBuilder()
                .UseStartup<TestStartup>());
            _client = server.CreateClient();
        }

        private readonly HttpClient _client;


        [Fact]
        public async Task ReturnProductList()
        {
            // Act
            var response = await _client.GetAsync("api/Product/productlist"); //change per setting
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.NotEmpty(responseString);
        }
    }
}