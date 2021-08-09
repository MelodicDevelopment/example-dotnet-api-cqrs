using System.Collections.Generic;
using dotnet_api_cqrs.contracts.dto;

namespace dotnet_api_cqrs.contracts.services
{
	public interface IAuthorService
	{
		IEnumerable<Author> GetAllAuthors();
		Author GetAuthor(int authorID);
		Author InsertAuthor(Author author);
		void DeleteAuthor(int authorID);
	}
}
