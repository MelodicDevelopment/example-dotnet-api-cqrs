using dotnet_api_cqrs.data.Queries.Book;
using Xunit;

namespace dotnet_api_cqrs.tests.Data.Book
{
	public class BookQueryTests : TestBase
	{
		[Fact]
		public void GetAllBooksTest()
		{
			var query = new GetAllBooksQuery();
			var results = query.Execute(TestDbContext);

			Assert.NotEmpty(results);
		}

		[Theory]
		[InlineData(1)]
		public void GetBookByIDTest(int bookID)
		{
			var query = new GetBookQuery(bookID);
			var results = query.Execute(TestDbContext);

			Assert.NotNull(results);
		}


		[Theory]
		[InlineData(1)]
		public void GetBookForAuthorTest(int authorID)
		{
			var query = new GetBooksForAuthorQuery(authorID);
			var results = query.Execute(TestDbContext);

			Assert.NotNull(results);
		}
	}
}
