using System;
namespace Practice_9
{
	public class Book
	{
		private string title, author;
		private int price;

		public int Price {
			get {
				return price;
			}
		}

		public Book(string title, string author, int price) {
			this.title = title;
			this.author = author;
			this.price = price;
		}

        public void PrintDetails()
		{
			Console.WriteLine($"{title}, {author}, {price}");
		}
	}
}

