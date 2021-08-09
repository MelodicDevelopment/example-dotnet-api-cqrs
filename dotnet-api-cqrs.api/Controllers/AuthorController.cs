using System.Collections.Generic;
using dotnet_api_cqrs.dto;
using dotnet_api_cqrs.services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dotnet_api_cqrs.api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthorController : ControllerBase
	{
		private readonly ILogger<AuthorController> _logger;
		private readonly IAuthorService _authorService;

		public AuthorController(ILogger<AuthorController> logger, IAuthorService authorService)
		{
			_logger = logger;
			_authorService = authorService;
		}

		[HttpGet]
		public IEnumerable<Author> Get()
		{
			return _authorService.GetAllAuthors();
		}

		[HttpGet("{authorID:int}")]
		public Author Get(int authorID)
		{
			return _authorService.GetAuthor(authorID);
		}

		[HttpPost]
		public Author Post(Author author)
		{
			return _authorService.InsertAuthor(author);
		}

		[HttpDelete("{authorID:int}")]
		public IActionResult Delete(int authorID)
		{
			_authorService.DeleteAuthor(authorID);
			return Ok();
		}
	}
}
