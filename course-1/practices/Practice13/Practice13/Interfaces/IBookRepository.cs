using System;
namespace Practice13
{
	interface IBookRepository
    {
        void AddBook(Book book);
        void RemoveBook(int bookId);
        void FindBookByTitle(string title);
        void FindBooksByAuthor(string author);
    }
}

