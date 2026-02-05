using System;
using System.Diagnostics;
using System.Xml.Linq;

namespace Practice11
{
	public class Teacher:Person
	{
		private string subject;
        public Teacher(string name, int age, string subject) : base(name, age)
        {
            this.subject = subject;
        }
        public override void introduce()
        {
            Console.WriteLine($"Учитель {name} {age} лет преподаёт {subject}");
        }
    }
}

