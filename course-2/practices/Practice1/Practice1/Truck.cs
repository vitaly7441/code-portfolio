using System;
namespace Practice1
{
	public class Truck : Vehicle
	{
		public int TrunkCapacity { get; set; }
		public Truck(string brand, string model, int yearRelease, int maxSpeed, int trunkСapacity) :base(brand, model, yearRelease, maxSpeed)
		{
			TrunkCapacity = trunkСapacity;
		}

        public override void infoAbout()
        {
			Console.WriteLine($"Грузовик, {Brand}, {Model}, {YearRelease} год, {MaxSpeed} км/ч, {TrunkCapacity}");
        }
    }
}

