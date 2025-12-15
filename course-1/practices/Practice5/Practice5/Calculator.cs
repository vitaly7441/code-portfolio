using System;
namespace Practice5
{
	class Calculator
	{
        private bool isAcceptable;

        public Calculator(bool isAcceptable) {
            this.isAcceptable = isAcceptable;
        }

        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }
        public int Multiply(int a, int b)
        {
            return a * b;
        }
        public int Divide(int a, int b)
        {
            if (b == 0)
            {
                isAcceptable = false;
                Console.WriteLine("Деление на ноль запрещено.");
                return -1;
            }
            else
            {
                isAcceptable = true;
                return a / b;
            }
        }
    }
}