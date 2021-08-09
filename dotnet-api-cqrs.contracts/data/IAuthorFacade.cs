using System;
using System.Collections.Generic;
using System.Data;
using dotnet_api_cqrs.contracts.dto;

namespace dotnet_api_cqrs.contracts.data
{
	public interface IAuthorFacade
	{
		Func<IDbContext, IDbTransaction, IEnumerable<Author>> GetAuthors();
		Func<IDbContext, IDbTransaction, Author> GetAuthor(int authorID);
		Func<IDbContext, IDbTransaction, int> InsertAuthor(Author author);
		Action<IDbContext, IDbTransaction> DeleteAuthor(int authorID);
	}
}
