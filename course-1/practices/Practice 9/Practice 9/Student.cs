using System;
namespace Practice_9
{
	public class Student : Person
	{
		private int grade;
		public Student(string name, int age, int grade): base(name, age)
		{
			this.grade = grade;
		}

		public override void Study() {
			Console.WriteLine($"Я учусь в {grade} классе");
		}
	}
}

