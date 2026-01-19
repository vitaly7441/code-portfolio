using System;
namespace Practice8
{
    public class Product
    {
        private string _name;
        private int _price;
        private double _discount;

        public Product(string name, int price, double discount) {
            _name = name;
            Price = price;
            Discount = discount;
        }

		public string Name
		{
			get
			{
				return _name;
			}
		}

        public int Price
        {
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Цена должна быть > 0");
                }
                else {
                    _price = value;
                }
            }
        }

        public double Discount
        {
            set
            {
                if (value < 0 || value > 0.5)
                {
                    Console.WriteLine("Введите корректное значение скидки(0-0.5)");
                }
                else {
                    _discount = value;
                }
            }
        }

        public double FinalPrice
        {
            get
            {
                return _price * _discount;
            }
        }

        public void ApplyDiscount(double percent) {
            Discount = percent / 100;
        }

    }
}

