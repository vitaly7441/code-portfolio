using System;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Practice_9
{
    public class Warrior : GameCharacter
    {
        public int armor, damage;

        public Warrior(string name, int health, int armor, int damage) : base(name, health)
        {
            this.armor = armor;
            this.damage = damage;
            this.health += armor;
        }

        public override void Attack(GameCharacter target)
        {
            target.health -= damage;
            Console.WriteLine($"{name} ударил {target.name} на {damage} урона.");
            Console.WriteLine($"У {target.name} осталось {target.health} здоровья.");
        }

    }

}

