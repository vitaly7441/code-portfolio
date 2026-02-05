using System;
namespace Practice11
{
	interface IDiscountable {
		void apply_discount(double percent);

    }

    public class Product : IDiscountable
    {
		private string name;
		private double price;

        public Product(string name, double price) {
            this.name = name;
            this.price = price;
        }

        public void apply_discount(double percent)
        {
            price -= price * (percent / 100);
        }

        public virtual void print_info() {
            Console.WriteLine($"Name: {name}, price: {price}");
        }

    }
}

