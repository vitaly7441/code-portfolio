using System;

namespace Practice8
{
    class Program
    {
        static void Main()
        {

            //// 1
            //BankAccount account = new BankAccount();
            //account.GetBalance();
            //account.Deposit(2500);
            //account.GetBalance();
            //account.Withdraw(1000000);
            //account.Withdraw(20000);


            //// 2
            //User user = new User("qwqasdw", "222221", "sdsds@sdsds");
            //Console.WriteLine(user.Username);
            //Console.WriteLine(user.Email);
            //user.ChangePassword("222222", "123123");
            //user.ChangePassword("222221", "123123");
            //Console.WriteLine(user.Authenticate("222222"));
            //Console.WriteLine(user.Authenticate("123123"));

            //// 3
            //Thermometer thermometer = new Thermometer();
            //thermometer.TemperatureFahrenheit = 1001;
            //Console.WriteLine(thermometer.TemperatureFahrenheit);


            //// 4
            //Product product = new Product("Name1", 5000, 0.5);
            //product.ApplyDiscount(25);
            //Console.WriteLine(product.Name);
            //Console.WriteLine(product.FinalPrice);

            //// 5
            //MyStack<int> myStack = new MyStack<int>();
            //myStack.Push(132);
            //myStack.Push(987);
            //myStack.Push(622);
            //myStack.Pop(2);
            //Console.WriteLine("Count: " + myStack.Count);
            //Console.WriteLine("Peek: " + myStack.Peek());

            //// 6
            //GradeBook gradeBook = new GradeBook();

            //gradeBook.AddGrade("Иван Иванов", 5);
            //gradeBook.AddGrade("Петр Владимирович", 9);
            //gradeBook.AddGrade("Иннокентий Сергеевич", 9);
            //gradeBook.AddGrade("Петр Владимирович", 10);
            //gradeBook.AddGrade("Иван Иванов", 8);
            //gradeBook.AddGrade("Иван Иванов", 4);

            //List<int> ivanGrades = gradeBook.GetGrades("Иван Иванов");
            //Console.WriteLine("Оценки Ивана: " + string.Join(", ", ivanGrades));
            //Console.WriteLine("Средний балл Ивана: " + gradeBook.GetAverageGrade("Иван Иванов"));

            //List<int> peterGrades = gradeBook.GetGrades("Петр Владимирович");
            //Console.WriteLine("Оценки Петра: " + string.Join(", ", peterGrades));
            //Console.WriteLine("Средний балл Петра: " + gradeBook.GetAverageGrade("Петр Владимирович"));

            //List<string> allStudents = gradeBook.GetAllStudents();
            //Console.WriteLine("Все студенты: " + string.Join(", ", allStudents));




            //// 7
            //BankAccount account = new BankAccount();
            //account.GetBalance();
            //account.Deposit(2500);
            //account.GetBalance();
            //account.Withdraw(1000000);
            //account.Withdraw(20000);
            //List<BankAccount.Transaction> history = account.GetTransactionHistory();
            //Console.WriteLine("История транзакций:");
            //foreach (var transaction in history)
            //{
            //    Console.WriteLine($"{transaction.DateTime}: {transaction.Type} - {transaction.Amount}, Баланс: {transaction.BalanceAfter}");
            //}



            //// 8

            //Calculator calculator = new Calculator();

            //Console.WriteLine($"5 + 3 = {calculator.Add(5, 3)}");
            //Console.WriteLine($"Размер кэша: {calculator.CacheSize}");

            //Console.WriteLine($"5 + 3 = {calculator.Add(5, 3)}");
            //Console.WriteLine($"Размер кэша: {calculator.CacheSize}");

            //Console.WriteLine($"2 * 4 = {calculator.Multiply(2, 4)}");
            //Console.WriteLine($"Размер кэша: {calculator.CacheSize}");

            //Console.WriteLine($"Выражение '10+5' : {calculator.Calculate("10+5")}");
            //Console.WriteLine($"Размер кэша: {calculator.CacheSize}");

            //Console.WriteLine($"10 + 5 = {calculator.Add(10, 5)}");
            //Console.WriteLine($"Размер кэша: {calculator.CacheSize}");
                                  
            //calculator.ClearCache();
            //Console.WriteLine($"Размер кэша: {calculator.CacheSize}");

            //Console.WriteLine($"5 + 3 = {calculator.Add(5, 3)}");
            //Console.WriteLine($"Размер кэша: {calculator.CacheSize}");                                                          // Размер кэша: 1
        }
    }
}