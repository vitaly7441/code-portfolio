using System;
using System.ComponentModel.DataAnnotations;

namespace Practice5_TestingPlatform.Models
{
    /// <summary>
    /// Курс
    /// </summary>
    public class Course
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название курса
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Список групп внутри курса
        /// </summary>
        public List<Group> Groups { get; set; }

        /// <summary>
        /// Список тестов внутри курса
        /// </summary>
        public List<Test> Tests { get; set; }

        public List<TestCourse> TestCourses { get; set; } = new();
    }
}

