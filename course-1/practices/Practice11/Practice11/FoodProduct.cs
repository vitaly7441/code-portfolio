using System;
namespace Practice11
{
	public class FoodProduct:Product
	{
		public string shelf_life;

        public FoodProduct(string name, int price, string shelf_life):base(name, price) {
			this.shelf_life = shelf_life;
		}
    }
}

