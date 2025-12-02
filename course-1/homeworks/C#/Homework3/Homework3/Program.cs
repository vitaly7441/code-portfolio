// 1

//int[] grades = {3,3,4,5,1,2,5}; //плохой ученик =))
//int sum = 0, fives = 0, twos =0, arithMean;

//for (int i = 0; i < grades.Length; i++) {
//    sum += grades[i];
//    if (grades[i] == 5)
//    {
//        fives++;
//    }
//    else if (grades[i] == 2) {
//        twos++;
//    }
//}

//arithMean = sum / grades.Length;

//Console.WriteLine($"Средний балл: {arithMean}");
//Console.WriteLine($"Количество «пятёрок»: {fives}");
//Console.WriteLine($"Количество двоек: {twos}");



// 2

//int[] arr = { 1, 2, 3, 4, 5 };

//foreach (var num in arr)
//{
//    Console.Write(num);
//}

//Array.Reverse(arr);


//Console.WriteLine(); // перенос на новую строку

//foreach (var num in arr)
//{
//    Console.Write(num);
//}


// 3

//for (int i = 1; i <= 20; i++) {
//    Console.Write(i + " ");
//}

//Console.WriteLine(); // перенос на новую строку

//for (int i = 1; i <= 20; i++)
//{
//    if (i % 2 != 0)
//        continue;
//    Console.Write(i + " ");
//}



// 4

//for (int i = 0; i <= 3; i++)
//{
//    int pass = Convert.ToInt32(Console.ReadLine());
//    if (pass == 1234)
//    {
//        Console.WriteLine("Доступ разрешён");
//        break;
//    }

//    if (pass != 1234 && i == 3)
//    {
//        Console.WriteLine("Доступ запрещён");
//        break;
//    }
//}