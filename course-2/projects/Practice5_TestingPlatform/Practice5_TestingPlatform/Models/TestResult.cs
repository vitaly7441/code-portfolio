using System;
using System.ComponentModel.DataAnnotations;

namespace Practice5_TestingPlatform.Models
{
	/// <summary>
	/// Результаты теста
	/// </summary>
	public class TestResult
	{
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Сдан или нет
        /// </summary>
        [Required]
        public bool Passed { get; set; }

        /// <summary>
        /// ID теста
        /// </summary>
        [Required]
        public int TestId { get; set; }

        /// <summary>
        /// Лучшая попытка
        /// </summary>
        [Required]
        public int AttemptId { get; set; }

        /// <summary>
        /// Студент
        /// </summary>
        [Required]
        public int StudentId { get; set; }

        public Test Test { get; set; }

        public Attempt Attempt { get; set; }

        public Student Student { get; set; }
    }
}

