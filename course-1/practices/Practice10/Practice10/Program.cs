using System;

namespace Practice10 {
    class Program {
        static void Main() {
            //// 1
            //Shape[] shapes = {
            //    new Rectangle(20,30),
            //    new Rectangle(50,30),
            //    new Circle(20),
            //    new Circle(34),
            //    new Circle(16),
            //};

            //foreach (Shape shape in shapes) {
            //    Console.WriteLine($"Площадь = {shape.GetArea()}");
            //    Console.WriteLine($"Периметр = {shape.GetPerimeter()}");
            //}


            //// 2
            //List<Animal> animals = new List<Animal>();
            //animals.AddRange(new Animal[] {new Dog(), new Cat(), new Cow()});
            //foreach (Animal animal in animals) {
            //    animal.MakeSound();
            //}



            //// 3
            //Transport[] transports = {
            //    new Car(110),
            //    new Boat(7),
            //    new Plane(1200)
            //};

            //foreach (Transport transport in transports) {
            //    transport.Move();
            //}


            //// 4
            //SavingsAccount savingsAccount1 = new SavingsAccount();
            //CreditAccount creditAccount1 = new CreditAccount();

            //savingsAccount1.Deposit(10000);
            //creditAccount1.Deposit(10000);
            //savingsAccount1.Withdraw(1000);
            //creditAccount1.Withdraw(1000);
            //savingsAccount1.Withdraw(9400);
            //creditAccount1.Withdraw(9400);


            //// 5
            //GameCharacter[] gameCharacters = {
            //    new Warrior("Воин"),
            //    new Mage("Маг"),
            //    new Archer("Лучник")
            //};

            //foreach (GameCharacter gameCharacter in gameCharacters) {
            //    gameCharacter.Attack();
            //}


            //// 6
            CleanerRobot cleanerRobot = new CleanerRobot("Робот-уборщик");
            CookRobot cookRobot = new CookRobot("Робот-повар");
            GuardRobot guardRobot = new GuardRobot("Робот-охранник");

            cleanerRobot.PerformTask();
            cookRobot.PerformTask();
            guardRobot.PerformTask();
        }
    }
}