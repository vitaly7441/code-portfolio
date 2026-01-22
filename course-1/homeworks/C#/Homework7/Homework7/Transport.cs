using System;
namespace Homework7
{
	public class Transport
	{
        public string Model { get; set; }
        protected int Speed = 0;

        public void ShowInfo() {
            Console.WriteLine($"Модель: {Model}, скорость: {Speed} км/ч");
        }

        public virtual void Move() {
            Console.WriteLine("Транспорт движется");
        }

    }
}

