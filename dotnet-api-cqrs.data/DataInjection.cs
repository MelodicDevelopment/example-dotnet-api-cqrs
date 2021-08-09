using dotnet_api_cqrs.data.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace dotnet_api_cqrs.data
{
	public static class DataInjection
	{
		public static void Configure(IServiceCollection services, IConfiguration configuration)
		{
			services.AddScoped<IDbContext>(sp => new DbContext($"{configuration.GetConnectionString("DbContext")}"));

			services.AddScoped<IBookFacade, BookFacade>();
			services.AddScoped<IAuthorFacade, AuthorFacade>();
		}
	}
}