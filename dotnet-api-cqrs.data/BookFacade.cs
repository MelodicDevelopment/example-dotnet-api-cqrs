using System;
using System.Collections.Generic;
using System.Data;
using dotnet_api_cqrs.data.Interfaces;
using dotnet_api_cqrs.data.Queries.Book;
using dotnet_api_cqrs.dto;

namespace dotnet_api_cqrs.data
{
	public class BookFacade : Facade, IBookFacade
	{
		public Func<IDbContext, IDbTransaction, IEnumerable<Book>> GetAllBooks()
		{
			return Prepare(new GetAllBooksQuery());
		}

		public Func<IDbContext, IDbTransaction, Book> GetBook(int bookID)
		{
			throw new NotImplementedException();
		}

		public Func<IDbContext, IDbTransaction, IEnumerable<Book>> GetBooksForAuthor(int authorID)
		{
			throw new NotImplementedException();
		}

		public Func<IDbContext, IDbTransaction, int> InsertBook(Book book)
		{
			throw new NotImplementedException();
		}

		public Action<IDbContext, IDbTransaction> DeleteBook(int bookID)
		{
			throw new NotImplementedException();
		}
	}
}
