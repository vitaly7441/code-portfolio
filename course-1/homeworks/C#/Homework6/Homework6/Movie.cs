using System;
namespace Homework6
{
	public class Movie
	{
		private string title;
		private string genre;
		private int rating;

		public Movie() : this("Без названия", "Неизвестен", 0) {}

        public Movie(string title) : this(title, "Неизвестен", 0) { }

        public Movie(string title, string genre, int rating)
        {
            this.title = title;
            this.genre = genre;
            this.rating = rating;
        }

        public void PrintInfo() {
            Console.WriteLine($"Название: {this.title}, жанр: {this.genre}, рейтинг: {this.rating}");
        }
    }
}

