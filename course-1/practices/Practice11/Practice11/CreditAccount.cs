using System;
namespace Practice11
{
	public class CreditAccount:BankAccount
	{
        public override void withdraw(int amount)
        {
            if (_balance - amount < -1000) {
                Console.WriteLine("Вы достигли лимита снятия!");
            }
            else
            {
                Console.WriteLine($"Вы успешно сняли {amount}");
            }
        }
    }
}

