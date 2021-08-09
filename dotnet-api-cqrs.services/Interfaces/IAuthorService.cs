using System.Collections.Generic;
using dotnet_api_cqrs.dto;

namespace dotnet_api_cqrs.services.Interfaces
{
	public interface IAuthorService
	{
		IEnumerable<Author> GetAllAuthors();
		Author GetAuthor(int authorID);
		Author InsertAuthor(Author author);
		void DeleteAuthor(int authorID);
	}
}
