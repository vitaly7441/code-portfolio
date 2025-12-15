using System;
using System.Linq;

namespace Practice5
{
    ////1

    //class Program
    //{
    //    static void Main()
    //    {
    //        Car car = new Car("Mercedes", "AMG GT", 2014);
    //        car.ShowInfo();
    //    }
    //}



    ////2

    //class Program
    //{
    //    static void Main()
    //    {
    //        Calculator calculator = new Calculator();

    //        Console.WriteLine(calculator.Add(1, 3));
    //        Console.WriteLine(calculator.Multiply(3, 9));
    //        int result = calculator.Divide(1, 0);


    //        if (calculator.isAcceptable == true)
    //        {
    //            Console.WriteLine(result);
    //        }
    //    }
    //}


    //// 3

    //class Program
    //{
    //    static void Main()
    //    {
    //        Book book1 = new Book("Title1", "Author1", 124);
    //        Book book2 = new Book("Title2", "Author2", 216);
    //        book1.ShowInfo();
    //        book2.ShowInfo();
    //    }
    //}



    //// 4

    //class Program
    //{
    //    static void Main()
    //    {
    //        BankAccount bankAccount = new BankAccount(777777, 125000);
    //        bankAccount.Deposit(570);
    //        bankAccount.Withdraw(100000000);
    //        bankAccount.Withdraw(1870);
    //        bankAccount.ShowBalance();
    //    }
    //}




    ////5

    //class Program {
    //    static void Main() {
    //        int sum = 0;
    //        List<Product> products = new List<Product>();

    //        products.Add(new Product("Product1", 260, 3));
    //        products.Add(new Product("Product2", 74, 8));
    //        products.Add(new Product("Product3", 110, 3));

    //        foreach (var product in products)
    //        {
    //            sum += product.GetTotalCost();
    //        }

    //        Console.WriteLine($"Общая стоимость всех товаров: {sum}");
    //    }
    //}




    //// 6
    //class Program {
    //    static void Main() {
    //        Student[] students = new Student[3];
    //        students[0] = new Student("Student1", 17, new int[] { 4, 5, 4, 5 });
    //        students[1] = new Student("Student2", 15, new int[] { 5, 5, 5, 4 });
    //        students[2] = new Student("Student3", 19, new int[] { 3, 4, 3, 2 });

    //        Student bestStudent = students[0];
    //        foreach (var student in students) {
    //            if (student.GetAverageGrade() >= bestStudent.GetAverageGrade()) {
    //                bestStudent = student;
    //            }
    //        }

    //        Console.Write("Самый успешный студент: ");
    //        bestStudent.ShowInfo();
    //    }
    //}




    //// 7

    //class Dog : Animal
    //{
    //    public Dog(string name) : base(name) {

    //    }

    //    public override void MakeSound()
    //    {
    //        Console.WriteLine("Гав-гав");
    //    }
    //}

    //class Cat : Animal
    //{
    //    public Cat(string name) : base(name) { }

    //    public override void MakeSound()
    //    {
    //        Console.WriteLine("Мяу-мяу");
    //    }
    //}

    //class Cow : Animal
    //{
    //    public Cow(string name) : base(name) { }

    //    public override void MakeSound()
    //    {
    //        Console.WriteLine("Мууу");
    //    }
    //}

    //class Program {
    //    static void Main() {
    //        Animal[] animals = new Animal[]
    //        {
    //            new Dog("Дружок"),
    //            new Cat("Мурзик"),
    //            new Cow("Бурёнка")
    //        };

    //        foreach (Animal animal in animals)
    //        {
    //            Console.Write($"{animal.name} говорит: ");
    //            animal.MakeSound();
    //        }
    //    }
    //}







    //// 8

    //class Circle : Shape
    //{

    //    private int radius;

    //    public Circle(int radius)
    //    {
    //        this.radius = radius;
    //    }

    //    public override double GetArea()
    //    {
    //        return Math.PI * radius;
    //    }
    //}


    //class Rectangle : Shape
    //{

    //    private int width, height;

    //    public Rectangle(int width, int height)
    //    {
    //        this.width = width;
    //        this.height = height;
    //    }

    //    public void widthShow()
    //    {
    //        Console.WriteLine(width);
    //    }

    //    public override double GetArea()
    //    {
    //        return width * height;
    //    }
    //}

    //class Program
    //{
    //    static void Main()
    //    {
    //        Shape[] shapes = new Shape[] {
    //            new Circle(25),
    //            new Rectangle(15,4),
    //            new Circle(150),
    //        };

    //        Shape theBiggestS = shapes[0];
    //        int numberOfTheBiggestS = 0;
    //        foreach (var shape in shapes)
    //        {
    //            if (shape.GetArea() >= theBiggestS.GetArea())
    //            {
    //                theBiggestS = shape;
    //                numberOfTheBiggestS = Array.IndexOf(shapes, shape) + 1;
    //            }
    //        }

    //        Console.WriteLine($"Самая большая площадь у фигуры номер {numberOfTheBiggestS}: {theBiggestS.GetArea()}");
    //    }
    //}
}