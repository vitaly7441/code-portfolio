namespace Practice3;

class Program
{
    static void Main()
    {
        List<Order> orders = new()
        {
            new Order { Id = 1, Customer = "Анна", City = "Москва", Price = 1500, Completed = true },
            new Order { Id = 2, Customer = "Иван", City = "Казань", Price = 4200, Completed = true },
            new Order { Id = 3, Customer = "Мария", City = "Москва", Price = 500, Completed = false },
            new Order { Id = 4, Customer = "Владислав", City = "Москва", Price = 2000, Completed = true },
            new Order { Id = 5, Customer = "Николай", City = "Москва", Price = 1900, Completed = true },
            new Order { Id = 5, Customer = "Николай", City = "Москва", Price = 2900, Completed = true },
            new Order { Id = 5, Customer = "Николай", City = "Москва", Price = 3000, Completed = true },
            new Order { Id = 5, Customer = "Николай", City = "Москва", Price = 300, Completed = true },
            new Order { Id = 5, Customer = "Николай", City = "Москва", Price = 100, Completed = true }
        };

        //1
        //var top5 = orders
        //    .OrderByDescending(order => order.Price)
        //    .Take(5);

        //Console.WriteLine("Топ-5 самых дорогих заказов:");
        //foreach (var order in top5)
        //{
        //    Console.WriteLine($"Заказ #{order.Id}: {order.Customer} — {order.Price} руб.");
        //}

        //2
        //var byCity = orders.GroupBy(order => order.City);

        //Console.WriteLine("Заказы по городам:");
        //foreach (var cityGroup in byCity)
        //{
        //    Console.WriteLine($"{cityGroup.Key}: {cityGroup.Count()}");
        //}

        //3
        //var revenueByCity = orders
        //    .Where(order => order.Completed)
        //    .GroupBy(order => order.City)
        //    .Select(cityGroup => new
        //    {
        //        City = cityGroup.Key,
        //        Revenue = cityGroup.Sum(order => order.Price)
        //    })
        //    .OrderByDescending(x => x.Revenue);

        //Console.WriteLine("Выручка по городам:");
        //foreach (var item in revenueByCity)
        //{
        //    Console.WriteLine($"{item.City}: {item.Revenue} руб.");
        //}

        //4
        //var activeClients = orders
        //    .GroupBy(order => order.Customer)
        //    .Where(clientGroup => clientGroup.Count() > 3)
        //    .Select(clientGroup => new
        //    {
        //        Name = clientGroup.Key,
        //        Count = clientGroup.Count()
        //    });

        //Console.WriteLine("Клиенты с более чем 3 заказами:");
        //foreach (var client in activeClients)
        //{
        //    Console.WriteLine($"{client.Name}: {client.Count} заказов");
        //}

        //5
        var topClients = orders
            .Where(order => order.Completed)
            .GroupBy(order => order.Customer)
            .Select(clientGroup => new
            {
                Name = clientGroup.Key,
                Total = clientGroup.Sum(order => order.Price)
            })
            .OrderByDescending(x => x.Total)
            .Take(5);

        Console.WriteLine("ТОП-5 клиентов:");
        foreach (var client in topClients)
        {
            Console.WriteLine($"{client.Name}: {client.Total} руб.");
        }
    }
}
