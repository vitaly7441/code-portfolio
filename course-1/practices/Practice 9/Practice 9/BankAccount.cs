using System;
namespace Practice_9
{
	public class BankAccount
	{
		protected double accountNumber, balance;

		public BankAccount(int accountNumber, int balance) {
			this.accountNumber = accountNumber;
			this.balance = balance;
		}

		public void Deposit(int amount) {
			balance += amount;
			Console.WriteLine($"Вы пополнили баланс на {amount}, текущий баланс: {balance}");
		}
        public void Withdraw(int amount)
        {
			if (amount > balance)
			{
				Console.WriteLine("Сумма снятия превышает баланс!");
			}
			else {
                balance -= amount;
                Console.WriteLine($"Вы сняли {amount}, текущий баланс: {balance}");
            }
        }

    }
}

