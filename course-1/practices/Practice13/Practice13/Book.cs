using System;
namespace Practice13
{
    class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int YearPublished { get; set; }
        public bool IsAvailable { get; set; }

        public ICollection<BorrowRecord> BorrowRecords { get; set; }

        public Book(int id, string title, string author, string isbn, int yearPublished, bool isAvailable) {
            Id = id;
            Title = title;
            Author = author;
            ISBN = isbn;
            YearPublished = yearPublished;
            IsAvailable = isAvailable;
        }

        public override string ToString()
        {
            return $"[ID: {Id}, Название: \"{Id}\", Автор: {Author}, ISBN: {ISBN}, Год: {YearPublished}, Доступна: {IsAvailable}]";
        }
    }
}

