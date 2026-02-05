using System;
namespace Practice11
{
    interface IReadable {
        public void Read();
    }

    public class Book
	{
		protected string title, author;
		public Book(string title, string author)
		{
			this.title = title;
			this.author = author;
		}

        public void Add_Book(List<Book> list, Book nameOfBook)
        {
            list.Add(nameOfBook);
            Console.WriteLine($"Добавлена книга {nameOfBook}");
        }

        public void Take_Book(List<Book> list, Book nameOfBook)
        {
            list.Remove(nameOfBook);
            Console.WriteLine($"Арендовали книгу {nameOfBook.title}");
        }
    }
}

