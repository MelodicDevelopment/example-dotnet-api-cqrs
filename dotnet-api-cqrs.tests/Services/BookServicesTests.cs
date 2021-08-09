using dotnet_api_cqrs.contracts.data;
using dotnet_api_cqrs.data;
using dotnet_api_cqrs.services;
using Moq;
using Xunit;

namespace dotnet_api_cqrs.tests.Services
{
	public class BookServicesTests : TestBase
	{
		[Fact]
		public void GetAllBooksTest()
		{
			var mockFacade = new Mock<IBookFacade>();
			mockFacade.Setup(repo => repo.GetBooks())
				.Returns((context, transaction) => {
					return TestData.Books;
				});

			var bookService = new BookService(TestDbContext, mockFacade.Object);

			Assert.NotEmpty(bookService.GetAllBooks());
		}
	}
}
