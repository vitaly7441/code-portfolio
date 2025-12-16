using System;
namespace Practice_6
{
	sealed class Dog : Animal
	{
        public Dog(string name, int age, string color) : base(name, age, color) {
            
        }

        public override void MakeSound()
        {
            Console.WriteLine("Гав-гав");
        }
    }
}

