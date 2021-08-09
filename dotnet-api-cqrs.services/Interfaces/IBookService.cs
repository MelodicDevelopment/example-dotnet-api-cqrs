﻿using System.Collections.Generic;
using dotnet_api_cqrs.dto;

namespace dotnet_api_cqrs.services.Interfaces
{
	public interface IBookService
	{
		IEnumerable<Book> GetAllBooks();
		Book GetBook(int bookID);
		Book InsertBook(Book book);
		void DeleteBook(int bookID);
	}
}