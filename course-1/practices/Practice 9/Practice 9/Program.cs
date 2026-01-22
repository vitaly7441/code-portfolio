namespace Practice_9
{
    class Program
    {
        static void Main()
        {
            //// 1
            //Animal[] animals = {
            //    new Animal(),
            //    new Animal(),
            //    new Animal(),
            //    new Animal(),
            //    new Animal(),
            //};
            //animals[0].SetName("Dog");
            //animals[0].SetAge(12);
            //animals[1].SetName("Name2");
            //animals[1].SetAge(1);
            //animals[2].SetName("Name3");
            //animals[2].SetAge(5);
            //animals[3].SetName("Name4");
            //animals[3].SetAge(7);
            //animals[4].SetName("Name5");
            //animals[4].SetAge(16);

            //animals[0].PrintInfo();
            //animals[1].PrintInfo();
            //animals[2].PrintInfo();
            //animals[3].PrintInfo();
            //animals[4].PrintInfo();




            //// 2
            //Book[] books = {
            //    new Book("Book1", "Author1", 200),
            //    new Book("Book2", "Author2", 3200),
            //    new Book("Book3", "Author3", 100),
            //    new Book("Book4", "Author4", 4303),
            //    new Book("Book5", "Author5", 490)
            //};

            //foreach (var book in books) {
            //    if (book.Price > 500) {
            //        book.PrintDetails();
            //    }
            //}




            //// 3

            //List<FarmAnimal> farmAnimals = new List<FarmAnimal>() {
            //    new Cow(),
            //    new Chicken(),
            //    new Chicken(),
            //};

            //farmAnimals[0].Speak();
            //farmAnimals[1].Speak();
            //farmAnimals[2].Speak();


            //// 4
            //SavingsAccount savingAccount = new SavingsAccount(123444000, 10000, 50);
            //savingAccount.AddInterest();
            //savingAccount.Deposit(300);


            //// 5
            //Toy[] toys = new Toy[]
            //{
            //    new Car("Car", 2000),
            //    new Doll("Doll", 2100)
            //};

            //foreach (Toy toy in toys)
            //{
            //    Console.WriteLine($"Название: {toy.name}, Цена: {toy.price}");
            //    toy.Play();
            //    Console.WriteLine();
            //}


            //// 6

            //Person[] persons = new Person[] {
            //    new Student("Student1",14, 8),
            //    new Student("Student2",15, 10),
            //    new Teacher("Teacher",35, "Math"),
            //};

            //persons[0].Study();
            //persons[1].Study();
            //persons[2].Teach();


            //// 7
            //Warrior warrior = new Warrior("Боец", 100, 50, 20);
            //Mage mage = new Mage("Волшебник", 100, 80, 30);

            //Console.WriteLine("Бой начинается!");

            //while (warrior.health > 0 && mage.health > 0)
            //{
            //    warrior.Attack(mage);
            //    if (mage.health <= 0) break;
            //    mage.Attack(warrior);
            //}

            //if (warrior.health <= 0)
            //{
            //    Console.WriteLine($"{mage.name} победил!");
            //}
            //else
            //{
            //    Console.WriteLine($"{warrior.name} победил!");
            //}


            //// 8
            //Delivery[] deliveries = new Delivery[] {
            //    new CourierDelivery("Addres", 1000),
            //    new Pickup("Addres2", 2000)
            //};

            //foreach (var del in deliveries) {
            //    if (del is CourierDelivery courierDelivery)
            //    {
            //        courierDelivery.DeliverByCourier();
            //    }
            //    else if (del is Pickup pickup)
            //    {
            //        pickup.PickUpFromStore();
            //    }
            //}


            //// 9
            //Book[] books = new Book[] {
            //    new Book("Title1", "Author1", 2000),
            //    new Book("Title2", "Author2", 900),
            //    new Book("Title3", "Author3", 1230),
            //    new Book("Title4", "Author4", 750),
            //};

            //foreach (Book book in books) {
            //    if (book.Price > 300 && book.Price < 1000) {
            //        book.PrintDetails();
            //    }
            //}


            //// 10

            //Lesson[] lessons = new Lesson[] {
            //    new Lesson("Lesson1", "10:30", "Teacher1"),
            //    new Lesson("Lesson2", "11:30", "Teacher2"),
            //    new Lesson("Lesson3", "12:30", "Teacher3"),
            //    new Lesson("Lesson4", "14:30", "Teacher1"),
            //};

            //string definiteTeacher = "Teacher1";

            //foreach (Lesson les in lessons) {
            //    if (les.Teacher == definiteTeacher) {
            //        les.GetInfo();
            //    }
            //}

        }
    }
}