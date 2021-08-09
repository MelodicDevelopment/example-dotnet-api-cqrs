using System;
using System.Collections.Generic;
using System.Data;
using dotnet_api_cqrs.data.Commands.Author;
using dotnet_api_cqrs.data.Interfaces;
using dotnet_api_cqrs.data.Queries.Author;
using dotnet_api_cqrs.dto;

namespace dotnet_api_cqrs.data
{
	public class AuthorFacade : Facade, IAuthorFacade
	{
		public Func<IDbContext, IDbTransaction, IEnumerable<Author>> GetAuthors()
		{
			return Prepare(new GetAllAuthorsQuery());
		}

		public Func<IDbContext, IDbTransaction, Author> GetAuthor(int authorID)
		{
			return Prepare(new GetAuthorQuery(authorID));
		}

		public Func<IDbContext, IDbTransaction, int> InsertAuthor(Author author)
		{
			return Prepare<int>(new InsertAuthorCommand(author));
		}

		public Action<IDbContext, IDbTransaction> DeleteAuthor(int authorID)
		{
			return Prepare(new DeleteAuthorCommand(authorID));
		}
	}
}
