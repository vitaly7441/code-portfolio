using System;
namespace Practice5
{
	public class Car
	{
        private string brand, model;
        private int year;

        public Car(string brand, string model, int year)
        {
            this.brand = brand;
            this.model = model;
            this.year = year;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Марка: {brand}, модель: {model}, год выпуска: {year}");
        }
    }
}

