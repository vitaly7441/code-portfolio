using System;
namespace Practice1
{
	public class Cart
	{
		List<Product> Products = new List<Product>();

		public void AddProduct(Product product) {
			Products.Add(product);
            Console.WriteLine($"Добавлен(о) {product.Amount} штук {product.Name} за {product.Price}/шт.");
		}

        public void DeleteProduct(Product product)
        {
            Products.Remove(product);
            Console.WriteLine($"Удален(ы) {product.Amount} штук {product.Name} за {product.Price}/шт.");
        }

        public void ChangeAmount(Product product, int changeAmount)
        {
            product.Amount += changeAmount;
            Console.WriteLine($"Изменено количество {product.Name} на {changeAmount}");
        }

        public void TotalCost() {
            int total=0;
            foreach (Product product in Products) {
                total += (product.Price * product.Amount);
            }
            Console.WriteLine($"Общая стоимость- {total}");
        }
    }
}

