using System.Linq;
using dotnet_api_cqrs.data;
using dotnet_api_cqrs.data.Commands.Book;
using Xunit;
using D = dotnet_api_cqrs.contracts.dto;

namespace dotnet_api_cqrs.tests.Data.Book
{
	public class BookCommandTests : TestBase
	{
		private readonly D.Book _testBook;

		public BookCommandTests() : base(true)
		{
			_testBook = TestData.Books.First();
		}

		[Fact]
		public void InsertBookCommandTest()
		{
			var command = new InsertBookCommand(_testBook);
			var results = command.Execute(TestDbContext);

			Assert.True(results == 1);
		}

		[Fact]
		public void DeleteBookCommandTest()
		{
			var command = new DeleteBookCommand(_testBook.BookID);
			var results = command.Execute(TestDbContext);

			Assert.True(results == 1);
		}
	}
}
