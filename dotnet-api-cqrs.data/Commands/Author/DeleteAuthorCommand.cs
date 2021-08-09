using System.Data;
using dotnet_api_cqrs.data.Interfaces;

namespace dotnet_api_cqrs.data.Commands.Author
{
	public class DeleteAuthorCommand : ICommand
	{
		private readonly int _authorID;

		public string Sql { get; set; }

		public DeleteAuthorCommand(int authorID)
		{
			_authorID = authorID;

			Sql = $@"
DELETE FROM			dbo.Authors
WHERE				AuthorID = @AuthorID;";
		}

		/// <summary>
		/// This is an example. Since I don't have a real database setup, I'm just returning hard coded data.
		/// However, I have the actual code commented out so you can see how it works if there really were a database.
		/// </summary>
		public int Execute(IDbContext context, IDbTransaction transaction = null)
		{
			//var param = new {
			//	AuthorID = _authorID
			//};

			//return context.Command(Sql, param, transaction: transaction);

			return 1;
		}
	}
}
