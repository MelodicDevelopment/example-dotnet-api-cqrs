using System.Collections.Generic;
using dotnet_api_cqrs.dto;

namespace dotnet_api_cqrs.data
{
	public static class TestData
	{
		public static List<Author> Authors = new() {
			new Author { AuthorID = 1, FirstName = "Jeff", LastName = "Gothelf" },
			new Author { AuthorID = 2, FirstName = "Eric", LastName = "Freeman" },
			new Author { AuthorID = 3, FirstName = "Robert", LastName = "Martin" }
		};

		public static List<Book> Books = new() {
			new Book { BookID = 1, Title = "Sense & Respond", CopyRightYear = 2007, AuthorID = 1 },
			new Book { BookID = 2, Title = "Design Patterns", CopyRightYear = 2004, AuthorID = 2 },
			new Book { BookID = 3, Title = "Clean Code", CopyRightYear = 2009, AuthorID = 3 }
		};
	}
}
