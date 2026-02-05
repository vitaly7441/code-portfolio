using System;
namespace Practice11
{
	public class Customer:User
	{
        public Customer(string name, string email) : base(name, email)
        {
        }

        public void Buy_Product(List<string> list, string nameOfProduct)
        {
            if (list.BinarySearch(nameOfProduct) == -1) {
                Console.WriteLine("Товар не найден");
            }
            else {
                list.Remove(nameOfProduct);
                Console.WriteLine($"Товар {nameOfProduct} куплен");
            }
        }
    }
}

