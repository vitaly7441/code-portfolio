using System;
namespace Practice8
{
	public partial class BankAccount
	{
		private double _balance;

		public BankAccount () {
			_balance = 24000;
		}

		public void Deposit(double amount) {
			if (amount > 0)
			{
				_balance += amount;
				Console.WriteLine($"Вы внесли {amount}");
                listTransaction.Add(new Transaction(DateTime.Now, "Deposit", amount, _balance));
            }
			else {
				Console.WriteLine("Введите корректное значение(>0)");
			}
		}

        public void Withdraw(double amount) {
			if (amount < 0)
			{
				Console.WriteLine("Введите корректное значение(>0)");
			}
			else if (amount > _balance)
			{
				Console.WriteLine("Недостаточно средств");
			}
			else
			{
                _balance -= amount;
                Console.WriteLine($"Снято {amount}. Текущий баланс: {_balance}");
				listTransaction.Add(new Transaction(DateTime.Now, "Withdraw", amount, _balance));
            }
		}

		public void GetBalance() {
			Console.WriteLine($"Текущий баланс: {_balance}");
		}
    }


    public partial class BankAccount // for admin
    {
		private List<Transaction> listTransaction = new List<Transaction>();
        private bool _isBlocked = false;


		public class Transaction
		{
            public DateTime DateTime { get; }
            public string Type { get; }
            public double Amount { get; }
            public double BalanceAfter { get; }

            public Transaction(DateTime dateTime, string type, double amount, double balanceAfter)
            {
                DateTime = dateTime;
                Type = type;
                Amount = amount;
                BalanceAfter = balanceAfter;
            }
        }


        public List<Transaction> GetTransactionHistory()
        {
            return listTransaction.ToList();
        }

        private void BlockAccount()
        {
            _isBlocked = true;
        }

        private bool IsBlocked
        {
            get
            {
                return _isBlocked;
            }
        }
    }
}

