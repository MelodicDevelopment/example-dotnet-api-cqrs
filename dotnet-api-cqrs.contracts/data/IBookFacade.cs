using System;
using System.Collections.Generic;
using System.Data;
using dotnet_api_cqrs.contracts.dto;

namespace dotnet_api_cqrs.contracts.data
{
	public interface IBookFacade
	{
		Func<IDbContext, IDbTransaction, IEnumerable<Book>> GetBooks();
		Func<IDbContext, IDbTransaction, Book> GetBook(int bookID);
		Func<IDbContext, IDbTransaction, IEnumerable<Book>> GetBooksForAuthor(int authorID);
		Func<IDbContext, IDbTransaction, int> InsertBook(Book book);
		Action<IDbContext, IDbTransaction> DeleteBook(int bookID);
	}
}
