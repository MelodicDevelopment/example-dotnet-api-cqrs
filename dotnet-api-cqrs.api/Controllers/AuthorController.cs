using System.Collections.Generic;
using dotnet_api_cqrs.dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dotnet_api_cqrs.api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthorController : ControllerBase
	{
		private readonly ILogger<AuthorController> _logger;

		public AuthorController(ILogger<AuthorController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public IEnumerable<Author> Get()
		{
			return new List<Author> {
				new Author { AuthorID = 1, FirstName = "Jeff", LastName = "Gothelf" },
				new Author { AuthorID = 2, FirstName = "Eric", LastName = "Freeman" },
				new Author { AuthorID = 3, FirstName = "Robert", LastName = "Martin" }
			};
		}
	}
}
