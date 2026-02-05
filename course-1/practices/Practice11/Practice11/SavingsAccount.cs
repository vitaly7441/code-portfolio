using System;
namespace Practice11
{
	public class SavingsAccount:BankAccount
	{
        public override void withdraw(int amount)
        {
            Console.WriteLine("Снятие запрещено!");
        }

    }
}

