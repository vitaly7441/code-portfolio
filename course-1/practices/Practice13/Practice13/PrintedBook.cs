using System;

namespace Practice13
{
    class PrintedBook : Book
    {
        public int PageCount { get; set; }

        public PrintedBook(int id, string title, string author, string isbn, int yearPublished, bool isAvailable, int pageCount): base(id, title, author, isbn, yearPublished, isAvailable)
        {
            Id = id;
            Title = title;
            Author = author;
            ISBN = isbn;
            YearPublished = yearPublished;
            IsAvailable = isAvailable;
            PageCount = pageCount;
        }
    }
}