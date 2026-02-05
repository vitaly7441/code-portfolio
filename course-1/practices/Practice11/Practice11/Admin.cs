using System;
namespace Practice11
{
	public class Admin : User, IManageable
	{
		public Admin(string name, string email):base(name, email)
		{
		}

		public void Add_Product(List<string> list, string nameOfProduct) {
			list.Add(nameOfProduct);
			Console.WriteLine($"Админ добавил {nameOfProduct}");
		}

        public void Remove_Product(List<string> list, string nameOfProduct)
        {
			list.Remove(nameOfProduct);
            Console.WriteLine($"Покупатель купил {nameOfProduct}");
        }
    }
}

