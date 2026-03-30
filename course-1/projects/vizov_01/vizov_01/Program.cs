using System.Text.Json;
using System.Text.RegularExpressions;
using vizov_01;


public class LogAnalyzer
{
    private const string LogLinePattern = @"\[(\d{4}\-\d{2}\-\d{2}\s\d{2}\:\d{2}\:\d{2})\]\s\[(INFO|DEBUG|WARN|ERROR)\]\s(.*)";

    public static void Main(string[] args)
    {
        if (args.Length == 0) {
            Console.WriteLine("Пожалуйста, укажите путь к файлу app.log в командной строке.");
            return;
        }


        try {
            string logFilePath =  args[0];
            string reportFilePath = Path.Combine(Path.GetDirectoryName(logFilePath), "report.json");
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
        } catch(ArgumentException e) {
            Console.WriteLine($"Ошибка: {e.Message}");
        } catch (FileNotFoundException e) {
            Console.WriteLine($"Ошибка: {e.Message}");
        } catch (Exception e) {
            Console.WriteLine($"Ошибка: {e.Message}");
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
