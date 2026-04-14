using System;
using System.Net.Http;

namespace Practice13 {
    class Program {

        static void Main() {

            Library library = new Library();

            Book book1 = new Book(1, "Book1", "AuthorOfBook1", "111111", 2021, true);
            Book book2 = new Book(2, "Book2", "AuthorOfBook2", "222222", 2022, true);
            Book book3 = new Book(3, "Book3", "AuthorOfBook3", "333333", 2023, true);
            Book book4 = new Book(4, "Book4", "AuthorOfBook2", "444444", 2024, true);

            Reader reader1 = new Reader(111, "Ivan Petrov", "ivanpetrov12@gmail.com");
            Reader reader2 = new Reader(222, "Sergey Borisovich", "sbroe442@gmail.com");

            library.AddBook(book1);
            library.AddBook(book2);
            library.AddBook(book3);
            library.AddBook(book4);

            library.AddReader(reader1);
            library.AddReader(reader2);

            library.BorrowBook(1, 222);
            library.BorrowBook(4, 222);
            library.BorrowBook(2, 111);
            library.BorrowBook(3, 111);

        }
    }
}