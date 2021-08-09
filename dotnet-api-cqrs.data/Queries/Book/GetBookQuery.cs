using System.Data;
using dotnet_api_cqrs.contracts.data;
using D = dotnet_api_cqrs.contracts.dto;

namespace dotnet_api_cqrs.data.Queries.Book
{
	public class GetBookQuery : IQuery<D.Book>
	{
		private readonly int _bookID;

		public string Sql { get; set; }

		public GetBookQuery(int bookID)
		{
			_bookID = bookID;

			Sql = $@"
SELECT				BookID,
					Title,
					CopyRightYear,
					AuthorID
FROM				dbo.Books
WHERE				BookID = @BookID;";
		}

		/// <summary>
		/// This is an example. Since I don't have a real database setup, I'm just returning hard coded data.
		/// However, I have the actual code commented out so you can see how it works if there really were a database.
		/// </summary>
		public D.Book Execute(IDbContext context, IDbTransaction transaction = null)
		{
			//var param = new {
			//	BookID = _bookID
			//};

			//return context.QueryFirst<D.Author>(Sql, param, transaction: transaction);

			return TestData.Books.Find(b => b.BookID == _bookID);
		}
	}
}
