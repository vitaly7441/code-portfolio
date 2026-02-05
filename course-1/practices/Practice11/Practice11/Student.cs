using System;
namespace Practice11
{
	public class Student:Person
	{

		private int grade;
		public Student(string name, int age, int grade):base(name, age)
        {
			this.grade = grade;
		}

        public override void introduce()
        {
			Console.WriteLine($"Ученик {name} {age} лет учится в {grade} классе");
        }
    }
}

