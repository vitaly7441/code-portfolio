using System;
using System.ComponentModel.DataAnnotations;

namespace Practice5_TestingPlatform.Models
{
    /// <summary>
    /// Направление
    /// </summary>
    public class Direction
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название направления
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Список групп внутри направления
        /// </summary>
        public List<Group> Groups { get; set; }

        /// <summary>
        /// Список тестов внутри направления
        /// </summary>
        public List<Test> Tests { get; set; }

        public List<TestDirection> TestDirection { get; set; }
    }
}

