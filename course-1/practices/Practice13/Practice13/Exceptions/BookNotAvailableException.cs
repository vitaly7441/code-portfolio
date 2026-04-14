using System;
namespace Practice13
{
	class BookNotAvailableException:LibraryException
	{
        public BookNotAvailableException(string message):base(message) { }
    }
}

