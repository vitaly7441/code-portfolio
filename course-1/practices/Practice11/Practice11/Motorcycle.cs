using System;
namespace Practice11
{
	public class Motorcycle:Vehicle
    {
		private string type;
		public Motorcycle(int speed, string type) :base(speed)
		{
			this.type = type;
        }

        public override void Move()
        {
            Console.WriteLine($"Мотоцикл {type} едет со скоростью {speed}, остаток топлива: {fuel}");
        }
    }
}

