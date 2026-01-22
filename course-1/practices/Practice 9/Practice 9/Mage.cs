using System;
using System.Xml.Linq;

namespace Practice_9
{
    public class Mage : GameCharacter
    {
        public int mana { get; set; }
        public int magicDamage { get; set; }

        public Mage(string name, int health, int mana, int magicDamage) : base(name, health)
        {
            this.mana = mana;
            this.magicDamage = magicDamage;
            this.health += mana;
        }

        public override void Attack(GameCharacter target)
        {
            target.health -= magicDamage;
            Console.WriteLine($"{name} использует магию и атакует {target.name}!");
            Console.WriteLine($"{name} нанес {magicDamage} магического урона {target.name}. У {target.name} осталось {target.health} здоровья.");
        }
    }
}

