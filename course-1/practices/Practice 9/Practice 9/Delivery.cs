using System;
using System.Diagnostics;
using System.Net;

namespace Practice_9
{
	public class Delivery
	{
		protected string adress;
		protected int price;

        public Delivery(string adress, int price)
        {
            this.adress = adress;
            this.price = price;
        }

    }
}

