using System.Data;
using dotnet_api_cqrs.data.Interfaces;

namespace dotnet_api_cqrs.data.Commands.Book
{
	public class DeleteBookCommand : ICommand
	{
		private readonly int _bookID;

		public string Sql { get; set; }

		public DeleteBookCommand(int bookID)
		{
			_bookID = bookID;

			Sql = $@"
DELETE FROM			dbo.Books
WHERE				BookID = @BookID;";
		}

		/// <summary>
		/// This is an example. Since I don't have a real database setup, I'm just returning hard coded data.
		/// However, I have the actual code commented out so you can see how it works if there really were a database.
		/// </summary>
		public int Execute(IDbContext context, IDbTransaction transaction = null)
		{
			//var param = new {
			//	BookID = _bookID
			//};

			//return context.Command(Sql, param, transaction: transaction);

			return 1;
		}
	}
}
