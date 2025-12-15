using System;
namespace Practice5
{
	public class BankAccount
	{
		private int accountNumber;
		private decimal balance;

		public BankAccount(int accountNumber, int balance)
		{
			this.accountNumber = accountNumber;
            this.balance = balance;
		}

		public decimal Deposit(decimal amount) {
			return this.balance += amount;
		}

		public decimal Withdraw(decimal amount) {
			if (amount <= this.balance)
			{
				return this.balance -= amount;
			}
			else {
				Console.WriteLine($"Не хватает средств для снятия. Текущий баланс: {balance}");
				return this.balance;
			}
		}

		public void ShowBalance() {
			Console.WriteLine($"Текущий баланс: {this.balance}");
		}
    }
}

