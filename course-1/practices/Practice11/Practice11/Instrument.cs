using System;
namespace Practice11
{
	interface ITunable {
		void Tune();
	}

    public class Instrument
	{
		public Instrument()
		{
		}

		public virtual void Play()
		{
			Console.WriteLine("Инструмент играет");
		}
	}
}

