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

		public int Execute(IDbContext context, IDbTransaction transaction = null)
		{
			var param = new {
				Title = _book.Title,
				CopyRightYear = _book.CopyRightYear,
				AuthorID = _book.AuthorID
			};

			return context.Command(Sql, param, transaction: transaction);
		}
	}
}
