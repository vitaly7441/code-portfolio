using System;
namespace Practice11
{
	interface TurboBoost {
		public void Boost(int boost);
	}

    public class Racer:TurboBoost
	{
		protected int speed;
		public Racer(int speed)
		{
			this.speed = speed;
		}

		public void Boost(int boost) {
			speed += boost;
		}

		public virtual void race() {
			Console.WriteLine("Гонщик едет");
		}
    }
}

