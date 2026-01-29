using System;
namespace Practice10
{
	public class Boat:Transport
	{
        public Boat(int speed)
        {
            Speed = speed;
        }

        public override void Move()
        {
            Console.WriteLine($"Плыву по воде со скоростью {Speed} км/ч");
        }
    }
}

