using System;
namespace Practice10
{
	public class CreditAccount:BankAccount
	{
        public override void Withdraw(double amount)
        {
            if (Balance-amount < -500)
            {
                Console.WriteLine("Невозможно снятие, Вы превысили лимит!");
            }
            else
            {
                Balance -= amount;
                Console.WriteLine($"Вы успешно сняли {amount}");
            }
        }
    }
}

