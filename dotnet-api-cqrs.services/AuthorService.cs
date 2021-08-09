using System.Collections.Generic;
using dotnet_api_cqrs.data.Interfaces;
using dotnet_api_cqrs.dto;
using dotnet_api_cqrs.services.Interfaces;

namespace dotnet_api_cqrs.services
{
	public class AuthorService : Service, IAuthorService
	{
		private readonly IAuthorFacade _authorFacade;

		public AuthorService(IDbContext context, IAuthorFacade authorFacade) : base(context)
		{
			_authorFacade = authorFacade;
		}

		public IEnumerable<Author> GetAllAuthors()
		{
			return _authorFacade.GetAuthors()(Context, null);
		}

		public Author GetAuthor(int authorID)
		{
			return _authorFacade.GetAuthor(authorID)(Context, null);
		}

		public Author InsertAuthor(Author author)
		{
			var newAuthorID = _authorFacade.InsertAuthor(author)(Context, null);
			return _authorFacade.GetAuthor(newAuthorID)(Context, null);
		}

		public void DeleteAuthor(int authorID)
		{
			_authorFacade.DeleteAuthor(authorID)(Context, null);
		}
	}
}
