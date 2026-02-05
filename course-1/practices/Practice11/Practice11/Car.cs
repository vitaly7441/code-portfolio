using System;
namespace Practice11
{
	public class Car : Vehicle
    {
		private string brand;
		public Car(int speed, string brand):base(speed)
		{
			this.brand = brand;
		}

        public override void Move()
        {
			Console.WriteLine($"Машина {brand} едет со скоростью {speed}, остаток топлива: {fuel}");
        }
    }
}

