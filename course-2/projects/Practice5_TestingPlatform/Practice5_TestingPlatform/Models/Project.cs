using System;
using System.ComponentModel.DataAnnotations;

namespace Practice5_TestingPlatform.Models
{
    /// <summary>
    /// Проект
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название проекта.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Список групп внутри проекта
        /// </summary>
        public List<Group> Groups { get; set; }

        /// <summary>
        /// Список тестов внутри проекта
        /// </summary>
        public List<Test> Tests { get; set; }

        public List<TestProject> TestProject { get; set; }
    }
}



