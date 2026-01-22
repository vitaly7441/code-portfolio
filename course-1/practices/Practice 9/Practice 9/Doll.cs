using System;
namespace Practice_9
{
    public class Doll : Toy
    {
        public Doll(string name, int price) : base(name, price)
        {
        }

        public override void Play()
        {
            Console.WriteLine("Привет, я твоя новая кукла!");
        }

    }
}

