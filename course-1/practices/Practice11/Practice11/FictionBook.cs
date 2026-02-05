using System;
namespace Practice11
{
	public class FictionBook:Book, IReadable
	{
		public FictionBook(string title, string author):base(title, author)
		{
		}

		public void Read() {
			Console.WriteLine("Fiction Book reading...");
		}
	}
}

