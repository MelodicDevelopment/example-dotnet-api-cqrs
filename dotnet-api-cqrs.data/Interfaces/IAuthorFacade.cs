using System;
using System.Collections.Generic;
using System.Data;
using dotnet_api_cqrs.dto;

namespace dotnet_api_cqrs.data.Interfaces
{
	public interface IAuthorFacade
	{
		Func<IDbContext, IDbTransaction, IEnumerable<Author>> GetAuthors();
		Func<IDbContext, IDbTransaction, Author> GetAuthor(int authorID);
		Action<IDbContext, IDbTransaction> InsertAuthor(Author author);
		Action<IDbContext, IDbTransaction> DeleteAuthor(int authorID);
	}
}
