using System;
namespace Practice7
{
	public class Animal
	{
		public string Name;

		public virtual void MakeSound() {
			Console.WriteLine("Животное издает звук");
		}
	}
}

