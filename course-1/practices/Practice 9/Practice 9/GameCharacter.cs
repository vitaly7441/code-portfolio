namespace Practice_9
{
	public class GameCharacter
	{
		public string name;
		public int health;

        public GameCharacter(string name, int health)
        {
            this.name = name;
            this.health = health;
        }

        public virtual void Attack(GameCharacter target)
        {
            Console.WriteLine($"{name} атакует {target.name}!");
        }
    }
}

