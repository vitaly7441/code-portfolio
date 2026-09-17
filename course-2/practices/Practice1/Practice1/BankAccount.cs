using System;
namespace Practice1
{
	public class BankAccount
	{
		public int AccountNumber { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }

        public BankAccount(int accountNumber, string name) {
            AccountNumber = accountNumber;
            Name = name;
            Balance = 0;
        }

        public void topUp(int amount) {
            if (amount < 0)
            {
                Console.WriteLine("Нельзя пополнить счет на отрицательную сумму!");
                Console.WriteLine($"Баланс: {Balance}");
            }
            else {
                Balance += amount;
                Console.WriteLine($"Счет пополнен на {amount}");
                Console.WriteLine($"Баланс: {Balance}");
            }
        }

        public void Withdraw(int amount) {
            if (amount > Balance)
            {
                Console.WriteLine("Недостаточно средств для снятия!");
                Console.WriteLine($"Баланс: {Balance}");
            }
            else
            {
                Balance -= amount;
                Console.WriteLine($"Успешно снято {amount}");
                Console.WriteLine($"Баланс: {Balance}");
            }
        }

    }
}

