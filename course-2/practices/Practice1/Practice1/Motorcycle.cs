using System;
namespace Practice1
{
	public class Motorcycle : Vehicle
	{
		public string UsageZone { get; set; }
		public Motorcycle(string brand, string model, int yearRelease, int maxSpeed, string usageZone):base(brand, model, yearRelease, maxSpeed)
		{
			UsageZone = usageZone;
		}

        public override void infoAbout()
        {
			Console.WriteLine($"Мотоцикл, {Brand}, {Model}, {YearRelease} год, {MaxSpeed} км/ч, {UsageZone}");
        }
    }
}

