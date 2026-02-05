using System;
namespace Practice11
{
    interface ICanFly
    {
        public void Fly();
    }

    public class Parrot : Animal, ICanFly
    {
        public void Fly() {
            Console.WriteLine("Я лечу");
        }

        public Parrot(string name)
        {
            _name = name;
        }

        public override void make_sound()
        {
            Console.WriteLine("Привет!");
        }

        public override void info()
        {
            Console.WriteLine($"Имя: {_name}, тип: Попугай");
        }
    }
}

