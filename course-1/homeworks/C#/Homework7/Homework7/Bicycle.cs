using System;
namespace Homework7
{
	public class Bicycle:Transport
	{
        public void Pedal() {
            Speed += 5;
        }

        public override void Move()
        {
            Console.WriteLine("Велосипед крутит педали");
        }

    }
}

