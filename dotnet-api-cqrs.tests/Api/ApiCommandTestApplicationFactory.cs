using dotnet_api_cqrs.contracts.data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace dotnet_api_cqrs.tests.Api
{
	public class ApiCommandTestApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup: class
	{
		protected override void ConfigureWebHost(IWebHostBuilder builder)
		{
			base.ConfigureWebHost(builder);

			builder.ConfigureTestServices(services => {
				services.RemoveAll<IDbContext>();
				services.TryAddScoped<IDbContext>(sp => new TestDbContext($"use-configuration-to-get-connection-string", true));
			});
		}
	}
}
