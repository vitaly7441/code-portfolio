using System;
namespace Practice_9
{
	public class Person
	{
		public string name;
		public int age;
		public Person(string name, int age)
		{
			this.name = name;
			this.age = age;
		}

		public virtual void Study() { }
        public virtual void Teach() { }

    }
}

