using System;
namespace Practice13
{
    class Library : IBookRepository, IReaderRepository
    {
        List<Book> Books = new List<Book>();
        List<Reader> Readers = new List<Reader>();

        Dictionary<Reader, Book> readersBooks = new Dictionary<Reader, Book>();
        

        public void AddBook(Book book)
        {
            Books.Add(book);
            Console.WriteLine($"Книга '{book.Id}' успешно добавлена.");
        }

        public void AddReader(Reader reader) {
            Readers.Add(reader);
        }

        public void RemoveBook(int bookId)
        {
            var bookToRemove = Books.FirstOrDefault(b => b.Id == bookId);
            if (bookToRemove != null)
            {
                Books.Remove(bookToRemove);
                Console.WriteLine($"Книга с ID {bookId} успешно удалена.");
            }
            else
            {
                throw new BookNotFoundException($"Книга с ID {bookId} не найдена.");
            }
        }

        public void FindBookByTitle(string title)
        {
            List<Book> booksByTitle = new List<Book>();
            foreach (var book in Books) {
                if (book.Title == title)
                {
                    booksByTitle.Add(book);
                }
            }
            if (booksByTitle.Count == 0)
            {
                Console.WriteLine("Книг с таким названием не найдено");
            }
            else {
                foreach (var book in booksByTitle)
                {
                    Console.WriteLine(book);
                }
            }
        }

        public void FindBooksByAuthor(string author)
        {
            List<Book> booksByAuthor = new List<Book>();
            foreach (var book in Books)
            {
                if (book.Author == author)
                {
                    booksByAuthor.Add(book);
                }
            }
            if (booksByAuthor.Count == 0)
            {
                Console.WriteLine("Книг с таким автором не найдено");
            }
            else
            {
                foreach (var book in booksByAuthor)
                {
                    Console.WriteLine(book);
                }
            }
        }

        public void BorrowBook(int bookId, int readerId)
        {
            var book = Books.FirstOrDefault(b => b.Id == bookId);
            var reader = Readers.FirstOrDefault(r => r.Id == readerId);

            if (book == null)
            {
                throw new BookNotFoundException($"Книга с ID {bookId} не найдена.");
            }
            if (reader == null)
            {
                throw new ReaderNotFoundException($"Читатель с ID {readerId} не найден.");
            }
            if (!book.IsAvailable)
            {
                throw new BookNotAvailableException($"Книга '{book.Title}' недоступна для выдачи.");
            }

            book.IsAvailable = false;
            reader.BorrowedBooks.Add(book);
            Console.WriteLine($"Книга '{book.Title}' выдана читателю '{reader.FullName}'.");
        }

        public void ReturnBook(int bookId, int readerId)
        {
            var book = Books.FirstOrDefault(b => b.Id == bookId);
            var reader = Readers.FirstOrDefault(r => r.Id == readerId);

            if (book == null)
            {
                throw new BookNotFoundException($"Книга с ID {bookId} не найдена.");
            }
            if (reader == null)
            {
                throw new ReaderNotFoundException($"Читатель с ID {readerId} не найден.");
            }

            if (reader.BorrowedBooks.Remove(book))
            {
                book.IsAvailable = true;
                Console.WriteLine($"Книга '{book.Title}' возвращена читателем '{reader.FullName}'.");
            }
            else
            {
                Console.WriteLine($"Ошибка: Читатель '{reader.FullName}' не брал книгу '{book.Title}'.");
            }
        }

        public List<Book> GetAvailableBooks()
        {
            return Books.Where(b => b.IsAvailable).ToList();
        }

        public List<Book> GetBorrowedBooks(int readerId)
        {
            var reader = Readers.FirstOrDefault(r => r.Id == readerId);
            if (reader == null)
            {
                throw new ReaderNotFoundException($"Читатель с ID {readerId} не найден.");
            }
            return reader.BorrowedBooks;
        }
    }
}

