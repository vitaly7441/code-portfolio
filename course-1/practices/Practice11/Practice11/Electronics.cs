using System;
namespace Practice11
{
	public class Electronics:Product
    {
        public bool warranty;

        public Electronics(string name, int price, bool warranty) : base(name, price)
        {
            this.warranty = warranty;
        }

    }
}

