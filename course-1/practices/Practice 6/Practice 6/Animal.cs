using System;
namespace Practice_6
{
	public class Animal
	{
        protected string name;
        protected int age;
        protected string color;

		public Animal (string name, int age, string color) {
			this.name = name;
			this.age = age;
			this.color = color;
		}

		public virtual void MakeSound() {
			Console.WriteLine("Животное издаёт звук");
		}
	}
}

