using System;
namespace Practice11
{
	public class Mage:Character
	{
		public Mage(string name, int health):base(name, health)
		{
		}

        public void Attack()
        {
            Console.WriteLine("Маг атакует");
        }

        public void TakeFromInventory(List<string> inventory, string item)
        {
            if (inventory.IndexOf(item) == -1)
            {
                Console.WriteLine("Предмета в инвентаре нет");
            }
            else
            {
                inventory.Remove(item);
                Console.WriteLine($"Из инвентаря мага взят(а) {item}");
            }
        }

        public void AddInInventory(List<string> inventory, string item)
        {
            inventory.Add(item);
            Console.WriteLine($"В инвентарь мага добавлен(а) {item}");
        }
    }
}

