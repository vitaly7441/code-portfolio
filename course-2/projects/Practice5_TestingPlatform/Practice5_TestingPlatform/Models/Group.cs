using System;
using System.ComponentModel.DataAnnotations;

namespace Practice5_TestingPlatform.Models
{
    /// <summary>
    /// Группа
    /// </summary>
    public class Group
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название группы
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Направление группы
        /// </summary>
        [Required]
        public int DirectionId { get; set; }
        public Direction Direction { get; set; }

        /// <summary>
        /// Курс группы
        /// </summary>
        [Required]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        /// <summary>
        /// Проект группы
        /// </summary>
        [Required]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        /// <summary>
        /// Студенты, которые состоят в группе
        /// </summary>
        public List<Student> Students { get; set; }

        /// <summary>
        /// Назначение тестов по группам
        /// </summary>
        public List<Test> Tests { get; set; }
    }
}

