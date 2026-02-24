using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using project_code_cat;

namespace project_code_cat {
    public class Program
    {
        public static void Main(string[] args)
        {
            Cat cat = Cat.LoadOrCreate("Мурзик");
            cat.Run();
        }
    }
}