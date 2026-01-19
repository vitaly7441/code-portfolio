using System;
namespace Practice8
{
    public class Calculator
    {
        private Dictionary<string, double> cache = new Dictionary<string, double>();

        public int CacheSize
        {
            get
            {
                return cache.Count;
            }
        }

        public double Add(double a, double b)
        {
            string key = $"{a}+{b}";
            return CalculateCached(key, () => a + b);
        }

        public double Multiply(double a, double b)
        {
            string key = $"{a}*{b}";
            return CalculateCached(key, () => a * b);
        }

        public double Calculate(string expression)
        {
            expression = expression.Replace(" ", "");
            if (expression.Contains("+"))
            {
                string[] parts = expression.Split('+');
                if (parts.Length == 2 && double.TryParse(parts[0], out double a) && double.TryParse(parts[1], out double b))
                {
                    return Add(a, b);
                }
            }
            else if (expression.Contains("*"))
            {
                string[] parts = expression.Split('*');
                if (parts.Length == 2 && double.TryParse(parts[0], out double a) && double.TryParse(parts[1], out double b))
                {
                    return Multiply(a, b);
                }

            }
            throw new ArgumentException("Неподдерживаемое выражение");

        }


        private double CalculateCached(string key, Func<double> calculation)
        {
            if (cache.TryGetValue(key, out double result))
            {
                Console.WriteLine($"Взято из кэша: {key}");
                return result;
            }
            else
            {
                Console.WriteLine($"Вычисление: {key}");
                result = calculation();
                cache[key] = result;
                return result;
            }
        }



        public void ClearCache()
        {
            cache.Clear();
            Console.WriteLine("Кэш очищен.");
        }
    }
}

