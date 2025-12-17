using System;

namespace Homework6 {
    class Program {
        static void Main() {

            //// 1
            //var m1 = new Movie();
            //var m2 = new Movie("Матрица");
            //var m3 = new Movie("Начало", "Фантастика", 9);

            //m1.PrintInfo();
            //m2.PrintInfo();
            //m3.PrintInfo();



            //// 2
            var kettle = new Kettle();
            kettle.Name = "Redmond";
            kettle.TurnOn();
            kettle.Boil();

            var toaster = new Toaster();
            toaster.Name = "Philips";
            toaster.TurnOn();
            toaster.Toast();


            //// 3

            var k = new Kettle();
            var t = new Toaster();

            var t21 = new Device();

            k.Beep();
            t.Beep();
        }
    }
}