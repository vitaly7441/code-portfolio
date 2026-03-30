using System.Text.Json;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class LogEntry
{
    public DateTime Timestamp { get; set; }
    public string ?Level { get; set; }
    public string ?Message { get; set; }
}

public class ReportIssue
{
    public string? Message { get; set; }
    public int Count { get; set; }
    public string ?Level { get; set; }
}

public class Report
{
    public DateTime GeneratedAt { get; set; }
    public int TotalErrors { get; set; }
    public int TotalWarns { get; set; }
    public List<ReportIssue> ?TopIssues { get; set; }
}

public class LogAnalyzer
{
    private const string LogLinePattern = @"\[(\d{4}\-\d{2}\-\d{2}\s\d{2}\:\d{2}\:\d{2})\]\s\[(INFO|DEBUG|WARN|ERROR)\]\s(.*)";

    public static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Пожалуйста, укажите путь к файлу app.log в командной строке.");
            return;
        }

        string logFilePath = args[0];
        string reportFilePath = Path.Combine(Path.GetDirectoryName(logFilePath), "report.json");

        try
        {
            List<LogEntry> logEntries = ReadLogFile(logFilePath);

            var filteredEntries = logEntries
                .Where(entry => entry.Level == "ERROR" || entry.Level == "WARN")
                .ToList();

            var groupedIssues = filteredEntries
                .GroupBy(entry => new { entry.Message, entry.Level })
                .Select(group => new ReportIssue
                {
                    Message = group.Key.Message,
                    Count = group.Count(),
                    Level = group.Key.Level
                })
                .OrderByDescending(issue => issue.Count) 
                .ToList();

            var report = new Report
            {
                GeneratedAt = DateTime.UtcNow,
                TotalErrors = filteredEntries.Count(entry => entry.Level == "ERROR"),
                TotalWarns = filteredEntries.Count(entry => entry.Level == "WARN"),
                TopIssues = groupedIssues.Take(2).ToList()
            };


            string jsonReport = JsonSerializer.Serialize(report, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(reportFilePath, jsonReport);
            Console.WriteLine("Отчет сформирован:");
            Console.WriteLine(jsonReport);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Ошибка: Файл логов не найден по пути: {logFilePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }

    private static List<LogEntry> ReadLogFile(string filePath)
    {
        var entries = new List<LogEntry>();
        var regex = new Regex(LogLinePattern);

        using (var reader = new StreamReader(filePath))
        {
            string ?line;
            while ((line = reader.ReadLine()) != null)
            {
                var match = regex.Match(line);
                if (match.Success)
                {
                    entries.Add(new LogEntry
                    {
                        Timestamp = DateTime.Parse($"{match.Groups[1].Value}"), 
                        Level = match.Groups[2].Value,
                        Message = match.Groups[3].Value.Trim()
                    });
                }
            }
        }
        return entries;
    }
}
