using System;
namespace Practice11
{
	interface IRefuelable
	{
		void refuel(int amount);
    }

    public class Vehicle:IRefuelable
	{
		protected int speed;
		protected int fuel = 50;

		public void refuel(int amount) {
			fuel += amount;
		}

		public virtual void Move() {
			Console.WriteLine("Транспорт движется");
		}

		public Vehicle(int speed)
		{
			this.speed = speed;
		}
	}
}

