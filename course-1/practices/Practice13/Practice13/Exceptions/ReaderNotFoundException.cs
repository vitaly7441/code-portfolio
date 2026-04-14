using System;
namespace Practice13
{
	class ReaderNotFoundException:LibraryException
	{
        public ReaderNotFoundException(string message):base(message) { }
    }
}

