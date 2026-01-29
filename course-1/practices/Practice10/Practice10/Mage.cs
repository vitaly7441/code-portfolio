using System;
namespace Practice10
{
	public class Mage:GameCharacter
	{
        public Mage(string name)
        {
            Name = name;
        }
        public override void Attack()
        {
            Console.WriteLine($"{Name} атакует магией!");
        }
    }
}

