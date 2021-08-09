﻿using System.Collections.Generic;
using dotnet_api_cqrs.dto;
using dotnet_api_cqrs.services.Interfaces;
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
	}
}
