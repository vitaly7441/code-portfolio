using System;
namespace Practice11
{
	public class Guitar:ITunable
    {
        public void Tune() {
            Console.WriteLine("Настройка гитары...");
        }

        public void Get_sound()
        {
            Console.WriteLine("Звук гитары");
        }

    }
}

