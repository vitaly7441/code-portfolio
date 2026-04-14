using System;
namespace Practice13
{
    class Reader
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<Book> BorrowedBooks = new List<Book>();
        public ICollection<BorrowRecord> BorrowRecords { get; set; }

        public Reader(int id, string fullName, string email) {
            Id = id;
            FullName = fullName;
            Email = email;
        }

        public override string ToString()
        {
            return $"ID: {Id}, ФИО: {FullName}, Email: {Email}, Взято книг: {BorrowedBooks.Count}";
        }
    }
}

