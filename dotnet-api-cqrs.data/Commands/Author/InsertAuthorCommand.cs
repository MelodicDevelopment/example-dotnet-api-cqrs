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

		/// <summary>
		/// This is an example. Since I don't have a real database setup, I'm just returning hard coded data.
		/// However, I have the actual code commented out so you can see how it works if there really were a database.
		/// </summary>
		public int Execute(IDbContext context, IDbTransaction transaction = null)
		{
			//var param = new {
			//	FirstName = _author.FirstName,
			//	LastName = _author.LastName
			//};

			//return context.InsertSingle(Sql, param, transaction: transaction);

			return 1;
		}
	}
}
