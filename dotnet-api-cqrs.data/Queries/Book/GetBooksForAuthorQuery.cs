using System.Collections.Generic;
using System.Data;
using System.Linq;
using dotnet_api_cqrs.data.Interfaces;
using D = dotnet_api_cqrs.dto;

namespace dotnet_api_cqrs.data.Queries.Book
{
	public class GetBooksForAuthorQuery : IQuery<IEnumerable<D.Book>>
	{
		private readonly int _authorID;

		public string Sql { get; set; }

		public GetBooksForAuthorQuery(int authorID)
		{
			_authorID = authorID;

			Sql = $@"
SELECT				BookID,
					Title,
					CopyRightYear,
					AuthorID
FROM				dbo.Books
WHERE				AuthorID = @AuthorID
ORDER BY			CopyRightYear, Title;";
		}

		/// <summary>
		/// This is an example. Since I don't have a real database setup, I'm just returning hard coded data.
		/// However, I have the actual code commented out so you can see how it works if there really were a database.
		/// </summary>
		public IEnumerable<D.Book> Execute(IDbContext context, IDbTransaction transaction = null)
		{
			//var param = new {
			//	AuthorID = _authorID
			//};

			//return context.Query<D.Author>(Sql, param, transaction: transaction);

			return TestData.Books.Where(b => b.AuthorID == _authorID);
		}
	}
}
