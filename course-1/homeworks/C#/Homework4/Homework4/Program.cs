using System;
using System.Reflection;

namespace Program
{

    //1
    class Program
    {
        static int Add(int a, int b)
        {
            return a + b;
        }

        static int Subtract(int a, int b)
        {
            return a - b;
        }

        static int Multiply(int a, int b)
        {
            return a * b;
        }

        static int Divide(int a, int b)
        {
            return a / b;
        }

        static void Main()
        {

            string? input;
            do
            {
                Console.WriteLine("Введите выражение (или exit): ");
                input = Console.ReadLine();

                string[] parts = input.Split(' ');

                if (parts.Length != 3 && parts[0] != "exit")
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите выражение в формате: число оператор число (например: 5 + 3)");
                }
                else
                {
                    if (parts[0] == "exit")
                    {
                        Console.WriteLine("Программа завершена");
                    }
                    else if (parts[1] == "+")
                    {
                        Console.WriteLine(Add(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[2])));
                    }
                    else if (parts[1] == "-")
                    {
                        Console.WriteLine(Subtract(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[2])));
                    }
                    else if (parts[1] == "*")
                    {
                        Console.WriteLine(Multiply(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[2])));
                    }
                    else if (parts[1] == "/")
                    {
                        Console.WriteLine(Divide(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[2])));
                    }
                    else
                    {
                        Console.WriteLine("Неверный символ операции( Допустимые: +-*/ )");
                    }
                }


            } while (input != "exit");
        }
    }







    ////2
    //class Phone
    //{
    //    public string? Model;
    //    public int Battery;

    //    public int Charge(int amount)
    //    {
    //        return Battery += amount;
    //    }

    //    public int Use(int amount)
    //    {
    //        return Battery -= amount;
    //    }
    //}

    //class Program
    //{
    //    static void Main()
    //    {
    //        var phone = new Phone { Model = "Samsung Galaxy" };

    //        phone.Charge(30);
    //        Console.WriteLine($"Заряд: {phone.Battery}%");

    //        phone.Use(10);
    //        Console.WriteLine($"Заряд: {phone.Battery}%");
    //    }
    //}

}