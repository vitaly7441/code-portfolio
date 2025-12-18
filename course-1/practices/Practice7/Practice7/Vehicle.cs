using System;
namespace Practice7
{
	public class Vehicle
	{

		public int Speed;
		public int Passengers;

		public virtual void Move() {
			Console.WriteLine("Транспорт движется");
		}

        public Vehicle()
		{
		}
	}
}

