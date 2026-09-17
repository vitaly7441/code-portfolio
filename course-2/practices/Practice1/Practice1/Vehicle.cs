using System;
namespace Practice1
{
	public class Vehicle
	{
		public string Brand { get; set; }
		public string Model { get; set; }
		public int YearRelease { get; set; }
		public int MaxSpeed { get; set; }

		public Vehicle(string brand, string model, int yearRelease, int maxSpeed)
		{
			Brand = brand;
			Model = model;
			YearRelease = yearRelease;
			MaxSpeed = maxSpeed;
		}

		public virtual void infoAbout() {
			Console.WriteLine("Транспорт не задан");
		}
	}
}

