using System;
namespace Practice11
{
	public class CarRacer:Racer
	{

		public CarRacer(int speed):base(speed)
		{

		}

        public void Get_race_status()
        {
            Console.WriteLine($"Текущая скорость автомобилиста: {speed}");
        }

    }
}

