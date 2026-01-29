using System;
namespace Practice10
{
	public class Car:Transport
	{
        public Car(int speed) {
            Speed = speed;
        }

        public override void Move()
        {
            Console.WriteLine($"Еду по дороге со скоростью {Speed} км/ч");
        }
    }
}

