using System;
namespace Practice_9
{
	public class Car : Toy
	{
		public Car(string name, int price) : base(name, price)
		{
		}

		public override void Play() {
			Console.WriteLine("Врум!");
		}

    }
}

