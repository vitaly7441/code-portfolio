using System;
namespace Practice11
{
	interface ITeachable {
		void Teach();
	}

    public class Person
	{
		protected string name;
        protected int age;

		public Person(string name, int age)
		{
			this.name = name;
			this.age = age;
		}

		public virtual void introduce() {
			Console.WriteLine("Информация");
		}

    }
}

