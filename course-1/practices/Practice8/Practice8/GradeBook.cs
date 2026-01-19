using System;
namespace Practice8
{
    public class GradeBook
    {
        private Dictionary<string, List<int>> _grades = new Dictionary<string, List<int>>();

        public void AddGrade(string studentName, int grade)
        {
            if (grade < 1 || grade > 10)
            {
                Console.WriteLine("Оценка должна быть от 1 до 10.");
            }
            if (!_grades.ContainsKey(studentName))
            {
                _grades[studentName] = new List<int>();
            }

            _grades[studentName].Add(grade);
        }

        public List<int> GetGrades(string studentName)
        {
            return new List<int>(_grades[studentName]);
        }

        public double GetAverageGrade(string studentName)
        {
            return _grades[studentName].Average();
        }

        public List<string> GetAllStudents()
        {
            return _grades.Keys.ToList();
        }
    }
}

