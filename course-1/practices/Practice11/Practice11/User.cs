using System;
namespace Practice11
{
	interface IManageable {
		public void Add_Product(List<string> list, string nameOfProduct);
        public void Remove_Product(List<string> list, string nameOfProduct);
    }

    public class User
	{
		protected string name, email;
		public User(string name, string email)
		{
			this.name = name;
			this.email = email;
		}
	}
}

