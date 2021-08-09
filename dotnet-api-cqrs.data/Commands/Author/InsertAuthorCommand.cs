using System.Data;
using dotnet_api_cqrs.data.Interfaces;
using D = dotnet_api_cqrs.dto;

namespace dotnet_api_cqrs.data.Commands.Author
{
	public class InsertAuthorCommand : ICommand
	{
		private readonly D.Author _author;

		public string Sql { get; set; }

		public InsertAuthorCommand(D.Author author)
		{
			_author = author;

			Sql = $@"
INSERT INTO			dbo.Authors
					(FirstName, LastName)
VALUES				(@FirstName, @LastName);";
		}

		public int Execute(IDbContext context, IDbTransaction transaction = null)
		{
			var param = new {
				FirstName = _author.FirstName,
				LastName = _author.LastName
			};

			return context.Command(Sql, param, transaction: transaction);
		}
	}
}
