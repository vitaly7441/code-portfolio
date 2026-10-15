using System;
using Practice5_TestingPlatform.Enums;
using System.ComponentModel.DataAnnotations;

namespace Practice5_TestingPlatform.Models
{
    /// <summary>
    /// Тест
    /// </summary>
    public class Test
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название теста
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Описание теста
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Можно ли тест пройти повторно или есть только одна попытка
        /// </summary>
        public bool IsRepeatable { get; set; } = false;

        /// <summary>
        /// Тип теста - образовательный, дополнительные активности, другое
        /// </summary>
        public TestType Type { get; set; }

        /// <summary>
        /// Тип ответа на вопрос
        /// </summary>
        public AnswerType AnswerType { get; set; }

        /// <summary>
        /// Когда создан
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Когда опубликован (стал доступен студентам)
        /// </summary>
        [Required]
        public DateTimeOffset PublishedAt { get; set; }

        /// <summary>
        /// Срок выполнения теста
        /// </summary>
        [Required]
        public DateTimeOffset Deadline { get; set; }

        /// <summary>
        /// Время на выполнение теста
        /// </summary>
        public int? DurationMinutes { get; set; }

        /// <summary>
        /// Опубликован ли (доступен студнтам для прохождения)
        /// </summary>
        public bool IsPublic { get; set; } = false;

        /// <summary>
        /// Проходной балл (достигнув которого тест больше нельзя пройти)
        /// </summary>
        public int? PassingScore { get; set; }

        /// <summary>
        /// Максимальное количество попыток прохождения теста
        /// </summary>
        public int? MaxAttempts { get; set; }

        /// <summary>
        /// Список вопросов в тесте
        /// </summary>
        public List<Question> Questions { get; set; }

        /// <summary>
        /// Список студентов, для которых доступен тест
        /// </summary>
        public List<TestStudent> TestStudents { get; set; } = new List<TestStudent>();

        /// <summary>
        /// Список проектов, для которых доступен тест
        /// </summary>
        public List<TestProject> TestProjects { get; set; } = new List<TestProject>();

        public List<Course> Courses { get; set; } = new();

        /// <summary>
        /// Список курсов, для которых доступен тест
        /// </summary>
        public List<TestCourse> TestCourses { get; set; } = new List<TestCourse>();

        /// <summary>
        /// Список групп, для которых доступен тест
        /// </summary>
        public List<TestGroup> TestGroups { get; set; } = new List<TestGroup>();

        /// <summary>
        /// Список направлений, для которых доступен тест
        /// </summary>
        public List<TestDirection> TestDirections { get; set; } = new List<TestDirection>();
    }
}