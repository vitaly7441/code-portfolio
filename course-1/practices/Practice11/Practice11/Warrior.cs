using System;
namespace Practice11
{
	public class Warrior:Character, IFightable
    {
		public Warrior(string name, int health):base(name, health)
		{
		}

        public void Attack()
        {
            Console.WriteLine("Воин атакует");
        }

        public void TakeFromInventory(List<string> inventory, string item)
        {
            if (inventory.IndexOf(item) == -1)
            {
                Console.WriteLine("Предмета в инвентаре нет");
            }
            else {
                inventory.Remove(item);
                Console.WriteLine($"Из инвентаря воина взят(а) {item}");
            }
        }

        public void AddInInventory(List<string> inventory, string item) {
            inventory.Add(item);
            Console.WriteLine($"В инвентарь воина добавлен(а) {item}");
        }

    }
}

