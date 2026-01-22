using System;
namespace Homework7
{
    public class Car : Transport
    {
        public void Accelerate(int value) {
            if (Speed > 200)
            {
                Console.WriteLine("Слишком большая скорость!");
            }
            else {
                Speed += value;
            }
        }

        public override void Move()
        {
            Console.WriteLine("Машина едет по дороге");
        }

    }
}

