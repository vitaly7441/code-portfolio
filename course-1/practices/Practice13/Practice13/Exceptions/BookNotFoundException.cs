using System;
namespace Practice13
{
	class BookNotFoundException:LibraryException
	{
        public BookNotFoundException(string message):base(message) {}
    }
}

