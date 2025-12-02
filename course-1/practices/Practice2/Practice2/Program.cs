
// 1
//int[] arr = new int[5];
//for (int i = 0; i < arr.Length; i++)
//{
//    arr[i] = Convert.ToInt32(Console.ReadLine());
//}

//for (int i = 0; i < arr.Length; i++)
//{
//    Console.WriteLine(arr[i]);
//}


// 2
//int[] arr = { 1, 2, 3, 4, 5 };
//int sum = 0;

//for (int i = 0; i < arr.Length; i++)
//{
//    sum += arr[i];
//}

//Console.WriteLine(sum / arr.Length);


// 3
//int[] arr = new int[8];
//Random random = new Random();
//int minValue = 1, maxValue = 101;

//for (int i = 0; i < arr.Length; i++)
//{
//    arr[i] = random.Next(minValue, maxValue);
//}

//for (int i = 0; i < arr.Length; i++)
//{
//    Console.WriteLine(arr[i]);
//}

//Console.WriteLine(arr.Max());




// 4
//string[] arr = { "Яблоко", "Банан", "Груша", "Слива", "Абрикос" };

//foreach (string name in arr)
//{
//    Console.WriteLine(name);
//}


// 5
//int[,] arr = new int[3, 3] {
//    {1,2,3},
//    {4,5,6},
//    {7,8,9}
//};

//for (int i = 0; i < arr.GetLength(0); i++)
//{
//    for (int j = 0; j < arr.GetLength(1); j++)
//    {
//        Console.Write(arr[i, j] + " ");
//    }
//    Console.WriteLine();
//}


// 6

//string? pass;

//do {
//    pass = Console.ReadLine();
//} while (pass != "1234");