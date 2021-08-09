﻿using dotnet_api_cqrs.services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace dotnet_api_cqrs.services
{
	public static class ServicesInjection
	{
		public static void Configure(IServiceCollection services)
		{
			services.AddScoped<IBookService, BookService>();
		}
	}
}