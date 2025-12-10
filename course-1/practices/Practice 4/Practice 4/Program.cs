using System.Collections.Generic;

//class Car
//{
//    public string brand;
//    public int speed;

//    public Car() :this("Audi Q8", 34) {

//    }

//    public Car(string brandName, int speedValue) {
//        this.brand = brandName;
//        this.speed = speedValue;
//    }

//    public int Accelerate() {
//        return speed += 10;
//    }
//}


class Book
{
    public string title, author;
    public int pages;

    public Book(string bookTitle, string bookAuthor, int bookPages)
    {
        title = bookTitle;
        author = bookAuthor;
        pages = bookPages;
    }

    public void Read(int enteredPages)
    {
        if (enteredPages <= pages)
        {
            Console.WriteLine($"Вы прочитали {enteredPages} страниц из {pages}");
        }
        else
        {
            Console.WriteLine("Неверное количество страниц.");
        }
    }
}


class Library
{

    List<Book> books = new List<Book>();

    public Library() {
        books = new List<Book>() {
            new Book("BookTitle", "BookAuthor", 29),
            new Book("BookTitle2", "BookAuthor2", 45)
        };
    }

    public void AddBook(Book book) {
        books.Add(book);
    }

    public void PrintAllBooks() {
        foreach (var book in books) {
            Console.WriteLine($"Книга {book.title}, автор: {book.author}, {book.pages}");
        }
    }
}