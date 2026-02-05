using System;
using System.Security.Principal;

namespace Practice11
{
    interface ITransaction {
		public void transfer(int amount, string account);

    }

	public class BankAccount:ITransaction
	{
		protected int _balance;
        public void transfer(int amount, string account)
        {
			Console.WriteLine($"Внесено {amount}, на {account}");
        }
        public void deposit(int amount)
		{
			_balance += amount;
			transfer(amount, "Account");
        }
		public virtual void withdraw(int amount) { }

		public void get_balance() {
			Console.WriteLine($"Текущий баланс: {_balance}");
		}

    }
}

