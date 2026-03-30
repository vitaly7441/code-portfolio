using System;
namespace vizov_01
{
    public class Report
    {
        public DateTime GeneratedAt { get; set; }
        public int TotalErrors { get; set; }
        public int TotalWarns { get; set; }
        public List<ReportIssue>? TopIssues { get; set; }
    }
}

