using System;
namespace Practice11
{
	interface IFightable {
		public void Attack();
        public void AddInInventory(List<string> inventory, string item);
        public void TakeFromInventory(List<string> inventory, string item);
    }

    public class Character
	{
		protected string name;
		protected int health;
		public Character(string name, int health)
		{
			this.name = name;
			this.health = health;
		}
	}
}

