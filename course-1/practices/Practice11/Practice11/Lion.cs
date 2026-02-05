using System;
namespace Practice11
{
	public class Lion:Animal
	{
        public Lion(string name) {
            _name = name;
        }

        public override void make_sound()
        {
            Console.WriteLine("Р-р-р!");
        }

        public override void info()
        {
            Console.WriteLine($"Имя: {_name}, тип: Лев");
        }
    }
}

