using System;
namespace Practice_9
{
	public class Pickup:Delivery
	{
        public Pickup(string adress, int price) : base(adress, price)
        {

        }
        public void PickUpFromStore()
        {
            Console.WriteLine($"Самовывоз, цена {price}");
        }
    }
}

