using System;
namespace Practice10
{
	public class Plane:Transport
	{
        public Plane(int speed)
        {
            Speed = speed;
        }

        public override void Move()
        {
            Console.WriteLine($"Лечу в небе со скоростью {Speed} км/ч");
        }
    }
}

