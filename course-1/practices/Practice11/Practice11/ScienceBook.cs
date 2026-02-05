using System;
namespace Practice11
{
	public class ScienceBook:Book, IReadable
	{
		public ScienceBook(string title, string author):base(title, author)
		{
		}

        public void Read()
        {
            Console.WriteLine("Science Book reading...");
        }
    }
}

