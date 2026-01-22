using System;
namespace Practice_9
{
    public class Teacher : Person
    {
        private string subject;
        public Teacher(string name, int age, string subject) : base(name, age)
        {
            this.subject = subject;
        }

        public override void Teach()
        {
            Console.WriteLine($"Я преподаю {subject}");
        }
    }
}

