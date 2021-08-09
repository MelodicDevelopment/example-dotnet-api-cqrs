using System.Collections.Generic;
using dotnet_api_cqrs.contracts.dto;
using dotnet_api_cqrs.contracts.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dotnet_api_cqrs.api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class BookController : ControllerBase
	{
		private readonly ILogger<BookController> _logger;
		private readonly IBookService _bookService;

		public BookController(ILogger<BookController> logger, IBookService bookService)
		{
			_logger = logger;
			_bookService = bookService;
		}

		[HttpGet]
		public IEnumerable<Book> Get()
		{
			return _bookService.GetAllBooks();
		}

		[HttpGet("{bookID:int}")]
		public Book Get(int bookID)
		{
			return _bookService.GetBook(bookID);
		}

		[HttpGet("author/{authorID:int}")]
		public IEnumerable<Book> GetForAuthor(int authorID)
		{
			return _bookService.GetBooksForAuthor(authorID);
		}

		[HttpPost]
		public Book Post(Book book)
		{
			return _bookService.InsertBook(book);
		}

		[HttpDelete("{bookID:int}")]
		public IActionResult Delete(int bookID)
		{
			_bookService.DeleteBook(bookID);
			return Ok();
		}
	}
}
