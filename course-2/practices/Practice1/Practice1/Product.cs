using System;
namespace Practice1
{
	public class Product
	{
		public string Name { get;set;}
		public int Price { get; set; }
		public int Amount { get; set; }

		public Product(string name, int price, int amount)
		{
			Name = name;
			Price = price;
			Amount = amount;
		}
	}
}

