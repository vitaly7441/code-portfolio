using System;
namespace Practice5
{
	public class Book
	{
        private string title, author;
        private int pages;

        public Book(string title, string author, int pages)
        {
            this.title = title;
            this.author = author;
            this.pages = pages;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Название: {title}, автор: {author}, страниц: {pages}");
        }
    }
}

