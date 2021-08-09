using System.Collections.Generic;
using System.Data;
using dotnet_api_cqrs.data.Interfaces;
using D = dotnet_api_cqrs.dto;

namespace dotnet_api_cqrs.data.Queries.Author
{
	public class GetAllAuthorsQuery : IQuery<IEnumerable<D.Author>>
	{
		public string Sql { get; set; }

		public GetAllAuthorsQuery()
		{
			Sql = $@"
SELECT			AuthorID,
				FirstName,
				LastName
FROM			dbo.Authors
ORDER BY		LastName, FirstName";
		}

		/// <summary>
		/// This is an example. Since I don't have a real database setup, I'm just returning hard coded data.
		/// However, I have the actual code commented out so you can see how it works if there really were a database.
		/// </summary>
		public IEnumerable<D.Author> Execute(IDbContext context, IDbTransaction transaction = null)
		{
			// return context.Query<D.Book>(Sql, transaction: transaction);

			return TestData.Authors;
		}
	}
}
