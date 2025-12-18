using System;

namespace Practice7
{


    //// 1
    
    class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Гав-гав");
        }
    }

    public class Cat : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Мяу-мяу");
        }
    }

    //// 2

    public class Car : Vehicle {

        public Car(int speed, int passengers) {
            Speed = speed;
            Passengers = passengers;
        }

        public override void Move()
        {
            Console.WriteLine($"Машина едет со скоростью {this.Speed} км/ч");
        }
    }

    public class Bicycle : Vehicle
    {

        public Bicycle(int speed, int passengers)
        {
            Speed = speed;
            Passengers = passengers;
        }

        public override void Move()
        {
            Console.WriteLine($"Велосипед движется со скоростью {Speed} км/ч");
        }
    }

    //// 3
    ///
    public class Manager : Employee {
        public override int GetSalary()
        {
            return 50000;
        }
    }

    public class Developer : Employee {

        private int hoursWorked;
        private int hourlyRate;

        public Developer(int hoursWorked, int hourlyRate) {
            this.hoursWorked = hoursWorked;
            this.hourlyRate = hourlyRate;
        }
        public override int GetSalary()
        {
            return hoursWorked * hourlyRate;
        }
    }

    // 4

    class Rectangle : Shape {
        private int Width;
        private int Height;

        public Rectangle(int width, int height) {
            Width = width;
            Height = height;
        }

        public override double GetArea()
        {
            return Width * Height;
        }
    }


    class Circle : Shape
    {
        private int Radius;
        public Circle(int radius)
        {
            Radius = radius;
        }

        public override double GetArea()
        {
            return Math.PI * Radius;
        }
    }



    // 5

    public class Book : Material
    {

        public string Author;

        public Book(string title, string author) : base(title)
        {
            Author = author;
        }

        public override void Display()
        {
            Console.WriteLine($"{Title} - {Author}");
        }
    }

    public class Video : Material
    {
        public int Duration;

        public Video(string title, int duration) : base(title)
        {
            Duration = duration;
        }

        public override void Display()
        {
            Console.WriteLine($"{Title} - {Duration}");
        }
    }



    // 6

    public class DigitalProduct : Product {

        private int Price;

        public DigitalProduct(int price) {
            Price = price;
        }

        public override int GetPrice() {
            return Price;
        }
    }

    public class PhysicalProduct : Product
    {

        private int Price;
        private int ShippingCost;

        public PhysicalProduct(int price, int shippingCost)
        {
            Price = price;
            ShippingCost = shippingCost;
        }

        public override int GetPrice()
        {
            return Price + ShippingCost;
        }
    }

    class Program
    {
        static void Main()
        {
            //// 1
            //Animal[] animals = {
            //    new Cat(),
            //    new Dog(),
            //    new Dog(),
            //};

            //animals[0].MakeSound();
            //animals[1].MakeSound();
            //animals[2].MakeSound();

            //// 2
            //Vehicle[] Vehicle = {
            //    new Bicycle(5, 1),
            //    new Car(78, 4),
            //    new Car(110, 2),
            //};

            //Vehicle[0].Move();
            //Vehicle[1].Move();
            //Vehicle[2].Move();


            //// 3
            ///

            //int totalSalary = 0;

            //Employee[] employees = {
            //    new Manager(),
            //    new Developer(5, 1000),
            //    new Developer(10, 2000),
            //    new Developer(24, 1500)
            //};

            //foreach (Employee empl in employees) {
            //    totalSalary += empl.GetSalary();
            //}

            //Console.WriteLine(totalSalary);


            //// 4

            //Shape[] shapes = {
            //    new Rectangle(20, 40),
            //    new Circle(30),
            //    new Circle(5)
            //};

            //double maxS = shapes[0].GetArea();

            //foreach (Shape shape in shapes)
            //{
            //    if (shape.GetArea() > maxS)
            //    {
            //        maxS = shape.GetArea();
            //    }
            //}

            //Console.WriteLine(maxS);


            //// 5
            ///

            //Material[] materials = {
            //    new Book("Book", "AuthorOfBook"),
            //    new Video("Video1", 60),
            //    new Video("Video2", 190)
            //};

            //foreach (Material mat in materials)
            //{
            //    mat.Display();
            //}


            //// 6

            //Product[] products = {
            //    new DigitalProduct(2600),
            //    new PhysicalProduct(5000, 2000),
            //    new DigitalProduct(19000),
            //    new PhysicalProduct(7000, 1500)
            //};

            //int totalPrice = 0;

            //foreach (Product el in products)
            //{
            //    totalPrice += el.GetPrice();
            //}

            //Console.WriteLine(totalPrice);
        }
    }
}