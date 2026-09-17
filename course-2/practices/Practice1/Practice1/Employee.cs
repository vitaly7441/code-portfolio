using System;

namespace Practice1
{
	public class Employee
	{
		private int age, salary;

		public string Name { get; set; }
		public string Post { get; set; }
		public int Age { get { return age; } set {
				if (value > 0)
					age = value;
				else
					Console.WriteLine("Возраст не может быть отрицательным");
			}
		}
        public int Salary
        {
            get { return salary; }
            set
            {
                if (value > 0)
                    salary = value;
                else
                    Console.WriteLine("Зарплата не может быть отрицательна");
            }
        }

        public Employee(string name, string post, int age, int salary) {
            Name = name;
            Post = post;
            Age = age;
            Salary = salary;
        }

        public void InfoAbout() {
			Console.WriteLine($"Имя - {Name} Должность - {Post} Возраст - {Age} Зарплата - {Salary}");
		}

        public void UpSalary(int upAmount)
        {
			Salary += upAmount;
        }
    }
}

