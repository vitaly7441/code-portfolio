using System;
namespace Practice_9
{
	public class CourierDelivery:Delivery
	{

		public CourierDelivery(string adress, int price):base(adress, price) {

		}
		public void DeliverByCourier()
		{
			Console.WriteLine($"Доставлено курьером на адрес {adress}, оплачено {price}");
		}
	}
}

