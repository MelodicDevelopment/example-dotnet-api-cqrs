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

		public int Execute(IDbContext context, IDbTransaction transaction = null)
		{
			var param = new {
				BookID = _bookID
			};

			return context.Command(Sql, param, transaction: transaction);
		}
	}
}
