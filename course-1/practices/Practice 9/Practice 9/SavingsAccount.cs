using System;
namespace Practice_9
{
	public class SavingsAccount : BankAccount
	{
		private int interestRate;

		public SavingsAccount(int accountNumber, int balance, int interestRate) :base( accountNumber, balance)
        {
			this.interestRate = interestRate;

        }

		public void AddInterest() {
			balance += balance * (interestRate / 100.0);
			Console.WriteLine(balance);
		}

    }
}

