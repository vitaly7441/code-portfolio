using System;
namespace Practice13
{
	interface IReaderRepository
	{
        void AddReader(Reader reader);
        void BorrowBook(int bookId, int readerId);
        void ReturnBook(int bookId, int readerId);
        List<Book> GetAvailableBooks();
        List<Book> GetBorrowedBooks(int readerId);
    }
}

