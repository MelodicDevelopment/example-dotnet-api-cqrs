using dotnet_api_cqrs.contracts.services;
using Microsoft.Extensions.DependencyInjection;

namespace dotnet_api_cqrs.services
{
	public static class ServicesInjection
	{
		public static void Configure(IServiceCollection services)
		{
			services.AddScoped<IAuthorService, AuthorService>();
			services.AddScoped<IBookService, BookService>();
		}
	}
}
