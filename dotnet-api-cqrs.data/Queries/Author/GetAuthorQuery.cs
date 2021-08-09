using System.Data;
using dotnet_api_cqrs.data.Interfaces;
using D = dotnet_api_cqrs.dto;

namespace dotnet_api_cqrs.data.Queries.Author
{
	public class GetAuthorQuery : IQuery<D.Author>
	{
		private readonly int _authorID;

		public string Sql { get; set; }

		public GetAuthorQuery(int authorID)
		{
			_authorID = authorID;

			Sql = $@"
SELECT			AuthorID,
				FirstName,
				LastName
FROM			dbo.Authors
WHERE			AuthorID = @AuthorID;";
		}

		/// <summary>
		/// This is an example. Since I don't have a real database setup, I'm just returning hard coded data.
		/// However, I have the actual code commented out so you can see how it works if there really were a database.
		/// </summary>
		public D.Author Execute(IDbContext context, IDbTransaction transaction = null)
		{
			//var param = new {
			//	AuthorID = _authorID
			//};

			//return context.QueryFirst<D.Author>(Sql, param, transaction: transaction);

			return TestData.Authors.Find(a => a.AuthorID == _authorID);
		}
	}
}
