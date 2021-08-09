using System.Net.Http;
using System.Threading.Tasks;
using dotnet_api_cqrs.api;
using Xunit;

namespace dotnet_api_cqrs.tests.Api.Controllers
{
	public class BookControllerTests : IClassFixture<ApiQueryTestApplicationFactory<Startup>>
	{
		private readonly ApiQueryTestApplicationFactory<Startup> _factory;
		private readonly HttpClient _httpClient;

		public BookControllerTests(ApiQueryTestApplicationFactory<Startup> factory)
		{
			_factory = factory;
			_httpClient = _factory.CreateClient();
		}

		[Fact]
		public async Task GetBooks_IsSuccessful()
		{
			var response = await _httpClient.GetAsync($"/api/book");

			response.EnsureSuccessStatusCode();
			Assert.True(response.IsSuccessStatusCode);
		}
	}
}
