using System.Collections.Generic;
using dotnet_api_cqrs.data.Interfaces;
using dotnet_api_cqrs.dto;
using dotnet_api_cqrs.services.Interfaces;

namespace dotnet_api_cqrs.services
{
	public class BookService : Service, IBookService
	{
		private readonly IBookFacade _bookFacade;

		public BookService(IDbContext context, IBookFacade bookFacade) : base(context)
		{
			_bookFacade = bookFacade;
		}

		public IEnumerable<Book> GetAllBooks()
		{
			return _bookFacade.GetBooks()(Context, null);
		}

		public Book GetBook(int bookID)
		{
			return _bookFacade.GetBook(bookID)(Context, null);
		}

		public IEnumerable<Book> GetBooksForAuthor(int authorID)
		{
			return _bookFacade.GetBooksForAuthor(authorID)(Context, null);
		}

		public Book InsertBook(Book book)
		{
			var newBookID = _bookFacade.InsertBook(book)(Context, null);
			return _bookFacade.GetBook(newBookID)(Context, null);
		}

		public void DeleteBook(int bookID)
		{
			_bookFacade.DeleteBook(bookID)(Context, null);
		}

		public Book ReplaceBook(Book oldBook, Book newBook)
		{
			return Context.Transaction<Book>(_transaction => {
				_bookFacade.DeleteBook(oldBook.BookID)(Context, _transaction);

				var newBookID = _bookFacade.InsertBook(newBook)(Context, _transaction);
				return _bookFacade.GetBook(newBookID)(Context, _transaction);
			});
		}
	}
}
