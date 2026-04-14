using System;
namespace Practice13
{
	class EBook : Book
	{
		public double FileSizeMb { get; set; }
		public string Format { get; set; }

        public EBook(int id, string title, string author, string isbn, int yearPublished, bool isAvailable, int pageCount, double fileSizeMb, string format) : base(id, title, author, isbn, yearPublished, isAvailable)
        {
            Id = id;
            Title = title;
            Author = author;
            ISBN = isbn;
            YearPublished = yearPublished;
            IsAvailable = isAvailable;
            FileSizeMb = fileSizeMb;
            Format = format;
        }
    }
}

