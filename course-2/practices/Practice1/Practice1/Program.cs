using System;

namespace Practice1 {
    class Program
    {
        static void Main() {
            //1
            //Employee Employee1 = new Employee("Name1", "Director", 35, 90000);
            //Employee Employee2 = new Employee("Name2", "Post2", 20, 30000);
            //Employee Employee3 = new Employee("Name3", "Post3", 45, 45000);

            //Employee1.InfoAbout();
            //Employee2.InfoAbout();
            //Employee3.InfoAbout();



            //2
            //BankAccount bankAccount = new BankAccount(1102329485, "Ivan");
            //bankAccount.Withdraw(1000000);
            //bankAccount.topUp(20000);
            //bankAccount.Withdraw(5000);



            //3
            //Product product1 = new Product("Product1", 1000, 3);
            //Product product2 = new Product("Product2", 250, 2);
            //Product product3 = new Product("Product3", 3500, 1);
            //Cart cart = new Cart();

            //cart.AddProduct(product1);
            //cart.AddProduct(product2);
            //cart.AddProduct(product3);
            //cart.TotalCost();
            //cart.DeleteProduct(product3);
            //cart.ChangeAmount(product1, -1);
            //cart.TotalCost();


            //4
            Car car = new Car("BrandCar", "ModelCar", 2010, 150, "red");
            Motorcycle motorcycle = new Motorcycle("BrandMotorcycle", "ModelMotorcycle", 2000, 300, "Road");
            Truck truck = new Truck("BrandTruck", "ModelTruck", 2025, 100, 10000);

            car.infoAbout();
            motorcycle.infoAbout();
            truck.infoAbout();
        }
    }
}