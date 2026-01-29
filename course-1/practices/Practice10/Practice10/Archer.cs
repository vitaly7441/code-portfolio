using System;
namespace Practice10
{
	public class Archer:GameCharacter
	{
        public Archer(string name)
        {
            Name = name;
        }
        public override void Attack()
        {
            Console.WriteLine($"{Name} стреляет из лука!");
        }
    }
}

