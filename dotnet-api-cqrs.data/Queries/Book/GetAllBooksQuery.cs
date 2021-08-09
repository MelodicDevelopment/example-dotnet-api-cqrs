using System.Collections.Generic;
using System.Data;
using dotnet_api_cqrs.data.Interfaces;
using D = dotnet_api_cqrs.dto;

namespace dotnet_api_cqrs.data.Queries.Book
{
	public class GetAllBooksQuery : IQuery<IEnumerable<D.Book>>
	{
		public string Sql { get; set; }

		public GetAllBooksQuery()
		{
			Sql = @$"
SELECT				BookID,
					Title,
					CopyRightYear,
					AuthorID
FROM				dbo.Books
ORDER BY			Title";
		}

		/// <summary>
		/// This is an example. Since I don't have a real database setup, I'm just returning hard coded data.
		/// However, I have the actual code commented out so you can see how it works if there really were a database.
		/// </summary>
		public IEnumerable<D.Book> Execute(IDbContext context, IDbTransaction transaction = null)
		{
			// return context.Query<D.Book>(Sql, transaction: transaction);

			return new List<D.Book> {
				new D.Book { BookID = 1, Title = "Sense & Respond", CopyRightYear = 2007, AuthorID = 1 },
				new D.Book { BookID = 2, Title = "Design Patterns", CopyRightYear = 2004, AuthorID = 2 },
				new D.Book { BookID = 3, Title = "Clean Code", CopyRightYear = 2009, AuthorID = 3 }
			};
		}
	}
}
