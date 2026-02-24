using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Timers;

namespace project_code_cat
{
    public class Cat
    {
        public int Energy { get; set; }
        public int Happiness { get; set; }
        public int Connection { get; set; }

        public string LastAction { get; set; }
        public int ActionStreak { get; set; }
        public string Name { get; set; }

        private const int MaxEnergy = 100;
        private const int MinEnergy = 0;
        private const int MaxHappiness = 100;
        private const int MinHappiness = 0;
        private const int MaxConnection = 100;
        private const int MinConnection = 0;
        private CancellationTokenSource _cancellationTokenSource;

        private static readonly string[] Jokes = {
        "Почему коты боятся огурцов? Потому что думают, что это ниндзя-змеи!",
        "Кот пошел к врачу: 'Доктор, у меня проблемы с памятью!' Доктор: 'С каких пор?' Кот: 'С каких пор что?'",
        "Что говорит кот, когда его кормят? 'Муррр-пасибо!'",
        "Почему коты любят коробки? Потому что это их личный телепорт в другое измерение!",
        "Кот к мыши: 'Я тебя съем!' Мышь: 'А зубы у тебя есть?' Кот: 'Нет, но зато усы длинные!'"
    };

        public Cat(string name)
        {
            Name = name;
            Energy = 50;
            Happiness = 50;
            Connection = 50;
            LastAction = "";
            ActionStreak = 0;
            _cancellationTokenSource = new CancellationTokenSource();
            StartDecayTimer();
        }

        private async void StartDecayTimer()
        {
            while (!_cancellationTokenSource.Token.IsCancellationRequested)
            {
                await Task.Delay(4000, _cancellationTokenSource.Token);
                Energy = Math.Max(MinEnergy, Energy - 2);
                Happiness = Math.Max(MinHappiness, Happiness - 2);
                Connection = Math.Max(MinConnection, Connection - 2);
            }
        }

        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine($"{Name}: Что будем делать? \n");
            ShowStatus();
            Console.WriteLine("1) Feed (Кормить)");
            Console.WriteLine("2) Play (Играть)");
            Console.WriteLine("3) Rest (Отдых)");
            Console.WriteLine("4) Talk (Поговорить)");
            Console.WriteLine("5) Сохранить и выйти");
            Console.Write("Выберите действие (1-5): ");
        }

        public void Run()
        {
            Console.WriteLine("\n ==== Добро пожаловать в програму 'Ваш цифровой кот' ====!");
            Console.WriteLine($"--- Это ваш питомец {Name}! --- \n");
            Thread.Sleep(5000);
            ShowMenu();

            while (true)
            {
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Feed();
                        break;
                    case "2":
                        Play();
                        break;
                    case "3":
                        Rest();
                        break;
                    case "4":
                        Talk();
                        break;
                    case "5":
                        Save();
                        Thread.Sleep(5000);
                        _cancellationTokenSource.Cancel();
                        return;
                    default:
                        Console.WriteLine("Неверный выбор! Введите число от 1 до 5.");
                        break;
                }

                if (Energy <= 0 || Happiness <= 0 || Connection <= 0)
                {
                    Console.Clear();
                    Console.WriteLine($"\n <<< Жизненные показатели слишком низкие. {Name} покинул вас. Приходите снова! >>> \n");
                    Thread.Sleep(5000);
                    _cancellationTokenSource.Cancel();
                    return;
                }

                Console.WriteLine("\nНажмите Enter для продолжения...");
                Console.ReadLine();
                ShowMenu();
            }
        }

        public void Feed()
        {
            if (ActionStreak >= 3)
            {
                Console.WriteLine($"\n =( {Name} заскучал от однотипных действий... Счастье -10, Связь -5 =( \n");
                Console.Clear();
            }
            else
            {
                Console.Clear();
            }
            if (Energy >= MaxEnergy - 10)
            {
                Console.WriteLine($"\n ~~~ {Name} сыт и гордо отворачивается от еды. ~~~\n");
                ShowStatus();
                return;
            }

            PerformAction("feed");
            Energy = Math.Min(MaxEnergy, Energy + 15);
            Happiness = Math.Min(MaxHappiness, Happiness + 5);
            Console.WriteLine($"\n ~~~ {Name} жадно ест и мурлычет. Энергия +15, Счастье +5. ~~~\n");
            ShowStatus();
        }

        public void Play()
        {
            if (ActionStreak >= 3)
            {
                Console.WriteLine($"\n =( {Name} заскучал от однотипных действий... Счастье -10, Связь -5 =( \n");
                Console.Clear();
            }
            else
            {
                Console.Clear();
            }
            if (Energy < 20)
            {
                Console.WriteLine($"\n ~~~ {Name} слишком устал, чтобы играть. Ему нужен отдых. ~~~\n");
                ShowStatus();
                return;
            }

            PerformAction("play");
            Energy = Math.Max(MinEnergy, Energy - 20);
            Happiness = Math.Min(MaxHappiness, Happiness + 15);
            Connection = Math.Min(MaxConnection, Connection + 10);
            Console.WriteLine($"\n ~~~ {Name} весело играет с вами! Энергия -20, Счастье +15, Связь +10. ~~~\n");
            ShowStatus();
        }

        public void Rest()
        {
            if (ActionStreak >= 3)
            {
                Console.WriteLine($"\n =( {Name} заскучал от однотипных действий... Счастье -10, Связь -5 =( \n");
                Console.Clear();
            }
            else
            {
                Console.Clear();
            }
            PerformAction("rest");
            Energy = Math.Min(MaxEnergy, Energy + 25);
            Happiness = Math.Max(MinHappiness, Happiness - 5);
            Console.WriteLine($"\n ~~~ {Name} свернулся в клубок и уютно спит. Энергия +25, Счастье -5. ~~~\n");
            ShowStatus();
        }

        public void Talk()
        {
            if (ActionStreak >= 3)
            {
                Console.WriteLine($"\n =( {Name} заскучал от однотипных действий... Счастье -10, Связь -5 =( \n");
                Console.Clear();
            }
            else
            {
                Console.Clear();
            }
            PerformAction("talk");
            Connection = Math.Min(MaxConnection, Connection + 15);
            Happiness = Math.Min(MaxHappiness, Happiness + 5);
            Console.WriteLine($"\n ~~~ {Name} слушает вас с интересом. Связь +15, Счастье +5. ~~~\n");
            ShowStatus();
        }

        private void PerformAction(string actionName)
        {
            if (actionName == LastAction)
            {
                ActionStreak++;
                if (ActionStreak >= 3)
                {
                    Console.WriteLine($"\n =( {Name} заскучал от однотипных действий... Счастье -10, Связь -5 =( \n");
                    Happiness = Math.Max(MinHappiness, Happiness - 10);
                    Connection = Math.Max(MinConnection, Connection - 5);
                    ActionStreak = 0;
                    LastAction = "";
                }
            }
            else
            {
                LastAction = actionName;
                ActionStreak = 1;
            }
        }

        private void ShowStatus()
        {
            Console.WriteLine(" -- Текущие показатели: -- ");
            Console.WriteLine($"~ Энергия: {Energy}");
            Console.WriteLine($"~ Счастье: {Happiness}");
            Console.WriteLine($"~ Связь: {Connection}");

            if (Energy < 10)
            {
                Console.WriteLine($"\n --- {Name}: я очень устал, дай мне отдохнуть \n");
            }

            if (Happiness < 10)
            {
                Console.WriteLine($"\n --- {Name}: я очень расстроенный =( \n");
            }

            if (Connection < 10)
            {
                Console.WriteLine($"\n --- {Name}: я отдалён от тебя =( \n");
            }

            if (Happiness > 95)
            {
                Random rand = new Random();
                string joke = Jokes[rand.Next(Jokes.Length)];
                Console.WriteLine($"\n{Name} счастлив и рассказывает анекдот: \"{joke}\"");
            }

            Console.WriteLine();
        }

        private const string SaveFileName = "Cat.json";

        public void Save()
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(this, options);
                File.WriteAllText(SaveFileName, jsonString);
                Console.Clear();
                Console.WriteLine("Состояние питомца сохранено.");
                Console.WriteLine("\n =) До свидания! Ваш котик помнит Вас =) !\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении: {ex.Message}");
            }
        }

        public static Cat LoadOrCreate(string defaultName = "Мурзик")
        {
            if (File.Exists(SaveFileName))
            {
                try
                {
                    string jsonString = File.ReadAllText(SaveFileName);
                    Cat cat = JsonSerializer.Deserialize<Cat>(jsonString);
                    cat._cancellationTokenSource = new CancellationTokenSource();
                    cat.StartDecayTimer();
                    Console.WriteLine($"Питомец '{cat.Name}' загружен.");
                    return cat;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при загрузке: {ex.Message}. Создается новый питомец.");
                    return new Cat(defaultName);
                }
            }
            else
            {
                Console.WriteLine("Файл сохранения не найден. Создается новый питомец.");
                return new Cat(defaultName);
            }
        }
    }
}