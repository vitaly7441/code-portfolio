using System;
namespace Practice_9
{
	public class Toy
	{
		public string name;
		public int price;

		public Toy(string name, int price)
		{
			this.name = name;
			this.price = price;
		}

        public virtual void Play()
        {
            Console.WriteLine("Это просто игрушка.");
        }
    }
}

