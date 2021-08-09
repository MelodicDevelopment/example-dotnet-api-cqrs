using System;
using System.Collections.Generic;
using System.Data;
using dotnet_api_cqrs.dto;

namespace dotnet_api_cqrs.data.Interfaces
{
	public interface IBookFacade
	{
		Func<IDbContext, IDbTransaction, IEnumerable<Book>> GetAllBooks();
		Func<IDbContext, IDbTransaction, Book> GetBook(int bookID);
		Func<IDbContext, IDbTransaction, IEnumerable<Book>> GetBooksForAuthor(int authorID);
		Func<IDbContext, IDbTransaction, int> InsertBook(Book book);
		Action<IDbContext, IDbTransaction> DeleteBook(int bookID);
	}
}
