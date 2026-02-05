using System;
namespace Practice11
{
	public class BikeRacer : Racer
	{

		public BikeRacer(int speed):base(speed)
		{

		}

        public void Get_race_status()
        {
            Console.WriteLine($"Текущая скорость мотоциклиста: {speed}");
        }

    }
}

