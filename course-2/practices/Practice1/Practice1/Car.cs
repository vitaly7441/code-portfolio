using System;
namespace Practice1
{
	public class Car:Vehicle
	{
		public string Color { get; set; }
		public Car(string brand, string model, int yearRelease, int maxSpeed, string color):base(brand, model, yearRelease, maxSpeed)
		{
			Color = color;
		}

        public override void infoAbout()
        {
			Console.WriteLine($"Автомобиль, {Brand}, {Model}, {YearRelease} год, {MaxSpeed} км/ч, {Color}");
        }
    }
}

