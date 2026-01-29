using System;
using System.Security.Cryptography;

namespace Practice10
{
	public abstract class BankAccount
	{
		public double Balance { get; set; }

		public abstract void Withdraw(double amount);

		public void Deposit(double amount) {
			Balance += amount;
			Console.WriteLine($"Вы успешно внесли {amount}. Текуший баланс: {Balance}");
		}

    }
}

