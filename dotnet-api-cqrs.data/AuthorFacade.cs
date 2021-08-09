using System;
using System.Collections.Generic;
using System.Data;
using dotnet_api_cqrs.data.Interfaces;
using dotnet_api_cqrs.dto;

namespace dotnet_api_cqrs.data
{
	public class AuthorFacade : Facade, IAuthorFacade
	{
		public Func<IDbContext, IDbTransaction, IEnumerable<Author>> GetAuthors()
		{
			throw new NotImplementedException();
		}

		public Func<IDbContext, IDbTransaction, Author> GetAuthor(int authorID)
		{
			throw new NotImplementedException();
		}

		public Action<IDbContext, IDbTransaction> InsertAuthor(Author author)
		{
			throw new NotImplementedException();
		}

		public Action<IDbContext, IDbTransaction> DeleteAuthor(int authorID)
		{
			throw new NotImplementedException();
		}
	}
}
