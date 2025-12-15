using System;
namespace Practice5
{
	public class Animal
	{
		public string name;

		public Animal(string name)
		{
			this.name = name;
		}

        public virtual void MakeSound()
        {
            Console.WriteLine("Животное издает звук");
        }
    }
}

