using System;
namespace Practice_9
{
	public class Animal
	{
		private string name;
		private int age;

		public void SetName(string name) {
			this.name = name;
		}
        public void GetName()
        {
            Console.WriteLine(name);
        }
        public void SetAge(int age)
        {
            this.age = age;
        }
        public void GetAge()
        {
            Console.WriteLine(age);
        }


        public void PrintInfo() {
			Console.WriteLine($"Имя: {name}, возраст: {age}");
		}
	}
}

