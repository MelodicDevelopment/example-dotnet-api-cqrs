using System;
using System.Collections.Generic;
using System.Data;
using dotnet_api_cqrs.data.Commands.Book;
using dotnet_api_cqrs.data.Interfaces;
using dotnet_api_cqrs.data.Queries.Book;
using dotnet_api_cqrs.dto;

namespace dotnet_api_cqrs.data
{
	public class BookFacade : Facade, IBookFacade
	{
		public Func<IDbContext, IDbTransaction, IEnumerable<Book>> GetBooks()
		{
			return Prepare(new GetAllBooksQuery());
		}

		public Func<IDbContext, IDbTransaction, Book> GetBook(int bookID)
		{
			return Prepare(new GetBookQuery(bookID));
		}

		public Func<IDbContext, IDbTransaction, IEnumerable<Book>> GetBooksForAuthor(int authorID)
		{
			return Prepare(new GetBooksForAuthorQuery(authorID));
		}

		public Func<IDbContext, IDbTransaction, int> InsertBook(Book book)
		{
			return Prepare<int>(new InsertBookCommand(book));
		}

		public Action<IDbContext, IDbTransaction> DeleteBook(int bookID)
		{
			return Prepare(new DeleteBookCommand(bookID));
		}
	}
}
