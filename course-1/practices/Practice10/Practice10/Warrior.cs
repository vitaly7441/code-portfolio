using System;
namespace Practice10
{
	public class Warrior:GameCharacter
	{
        public Warrior(string name)
        {
            Name = name;
        }
        public override void Attack()
        {
            Console.WriteLine($"{Name} атакует мечом!");
        }
    }
}

