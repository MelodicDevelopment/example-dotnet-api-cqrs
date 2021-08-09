using System;

namespace dotnet_api_cqrs.dto
{
	public class Book
	{
		public int BookID { get; set; }
		public string Title { get; set; }
		public int CopyRightYear { get; set; } 
		public int AuthorID { get; set; }
	}
}
