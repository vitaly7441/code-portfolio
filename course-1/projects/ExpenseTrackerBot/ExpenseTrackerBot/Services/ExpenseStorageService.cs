using System.Text.Json;
using ExpenseTrackerBot.Models;

namespace ExpenseTrackerBot.Services
{
    public class ExpenseStorageService
    {
        private readonly string? _filePath = "Data/expenses.json";
        private List<Expense> _expenses;
        private readonly object _lock = new object();

        public ExpenseStorageService()
        {
            LoadExpenses();
        }

        private void LoadExpenses()
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                _expenses = JsonSerializer.Deserialize<List<Expense>>(json) ?? new List<Expense>();
            }
            else
            {
                _expenses = new List<Expense>();
                Directory.CreateDirectory(Path.GetDirectoryName(_filePath));
            }
        }

        private void SaveExpenses()
        {
            lock (_lock)
            {
                var json = JsonSerializer.Serialize(_expenses, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_filePath, json);
            }
        }

        public void AddExpense(Expense expense)
        {
            expense.Id = Guid.NewGuid();
            expense.CreatedAt = DateTime.UtcNow;
            _expenses.Add(expense);
            SaveExpenses();
        }

        public List<Expense> GetExpensesByUserId(long userId)
        {
            lock (_lock)
            {
                return _expenses.Where(e => e.UserId == userId).ToList();
            }
        }

        public List<Expense> GetExpensesForPeriod(long userId, DateTime start, DateTime end)
        {
            lock (_lock)
            {
                return _expenses.Where(e => e.UserId == userId && e.CreatedAt >= start && e.CreatedAt < end).ToList();
            }
        }

        public List<Expense> GetLastExpenses(long userId, int count)
        {
            lock (_lock)
            {
                return _expenses.Where(e => e.UserId == userId)
                                .OrderByDescending(e => e.CreatedAt)
                                .Take(count)
                                .ToList();
            }
        }
    }
}

