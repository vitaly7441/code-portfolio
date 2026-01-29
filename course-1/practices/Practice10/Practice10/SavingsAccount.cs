using System;
namespace Practice10
{
	public class SavingsAccount:BankAccount
	{
        public override void Withdraw(double amount)
        {
            if (Balance-amount < 100)
            {
                Console.WriteLine("Невозможно снятие, баланс меньше 100!");
            }
            else {
                Balance -= amount;
                Console.WriteLine($"Вы успешно сняли {amount}");
            }
        }
    }
}

