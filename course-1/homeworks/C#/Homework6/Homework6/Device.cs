using System;
namespace Homework6
{
	public class Device
	{
		public string Name;

		public void TurnOn() {
			Console.WriteLine("Устройство включено.");
		}

        public virtual void Beep()
        {
            Console.WriteLine("Устройство подаёт сигнал.");
        }


    }


    class Kettle : Device {
		public void Boil() {
			Console.WriteLine("Чайник кипятит воду.");
		}

        public override void Beep()
        {
			Console.WriteLine("Чайник пикнул: пи-пи!");
        }
    }

	class Toaster : Device {
		public void Toast() {
			Console.WriteLine("Тостер поджаривает хлеб.");
		}

        public override void Beep()
        {
            Console.WriteLine("Тостер пикнул: динь!");
        }
    }
}

