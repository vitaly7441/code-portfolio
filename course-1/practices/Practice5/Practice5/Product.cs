using System;
namespace Practice5
{
	public class Product
	{
		private string name;
		private int price, quantity;

		public Product(string name, int price, int quantity) {
			this.name = name;
			this.price = price;
			this.quantity = quantity;
		}

		public int GetTotalCost() {
			return price * quantity;
		}

		public void ShowInfo() {
			Console.WriteLine($"Наименование: {name}, цена: {price}, количество: {quantity}");
		}

    }
}