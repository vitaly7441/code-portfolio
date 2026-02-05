using System;
namespace Practice11
{
	public class Piano:ITunable
	{
        public void Tune()
        {
            Console.WriteLine("Настройка пианино...");
        }

        public void Get_sound()
        {
            Console.WriteLine("Звук пианино");
        }
    }
}

