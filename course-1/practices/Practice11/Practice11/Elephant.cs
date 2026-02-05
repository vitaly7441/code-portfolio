using System;
namespace Practice11
{
	public class Elephant : Animal
	{

        public Elephant(string name)
        {
            _name = name;
        }

        public override void make_sound()
        {
            Console.WriteLine("Тууу!");
        }

        public override void info()
        {
            Console.WriteLine($"Имя: {_name}, тип: Слон");
        }
    }
}

