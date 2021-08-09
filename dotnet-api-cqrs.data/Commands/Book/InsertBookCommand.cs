using System.Data;
using dotnet_api_cqrs.data.Interfaces;
using D = dotnet_api_cqrs.dto;

namespace dotnet_api_cqrs.data.Commands.Book
{
	public class InsertBookCommand : ICommand
	{
		private readonly D.Book _book;

		public string Sql { get; set; }

		public InsertBookCommand(D.Book book)
		{
			_book = book;

			Sql = $@"
INSERT INTO			dbo.Books
					(Title, CopyRightYear, AuthorID)
VALUES				(@Title, @CopyRightYear, AuthorID);";
		}

		/// <summary>
		/// This is an example. Since I don't have a real database setup, I'm just returning hard coded data.
		/// However, I have the actual code commented out so you can see how it works if there really were a database.
		/// </summary>
		public int Execute(IDbContext context, IDbTransaction transaction = null)
		{
			//var param = new {
			//	Title = _book.Title,
			//	CopyRightYear = _book.CopyRightYear,
			//	AuthorID = _book.AuthorID
			//};

			//return context.InsertSingle(Sql, param, transaction: transaction);

			return 1;
		}
	}
}
