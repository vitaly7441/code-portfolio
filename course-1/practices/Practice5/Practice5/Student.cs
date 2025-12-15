using System;
using System.Linq;

namespace Practice5
{
	public class Student
	{

		private string name;
		private int age;
		private int[] grades;

		public Student(string name, int age, int[] grades)
		{
			this.name = name;
			this.age = age;
			this.grades = grades;
		}

		public double GetAverageGrade() {
			return grades.Average();
		}

		public void ShowInfo() {
			Console.WriteLine($"Имя: {name}, возраст: {age}, средний балл: {GetAverageGrade()}");
		}
    }
}

