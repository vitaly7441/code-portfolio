using System;
using System.ComponentModel.DataAnnotations;

namespace Practice5_TestingPlatform.Models
{
    /// <summary>
    /// Попытка
    /// </summary>
    public class Attempt
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Время старта
        /// </summary>
        public DateTimeOffset StartedAt { get; set; }

        /// <summary>
        /// Время проверки
        /// </summary>
        public DateTimeOffset? SubmittedAt { get; set; }

        /// <summary>
        /// Счет
        /// </summary>
        public int? Score { get; set; }

        /// <summary>
        /// ID теста
        /// </summary>
        [Required]
        public int TestId { get; set; }

        /// <summary>
        /// ID студента
        /// </summary>
        [Required]
        public int StudentId { get; set; }

        public Test Test { get; set; }

        public Student Student { get; set; }

        public List<UserAttemptAnswer> UserAttemptAnswers { get; set; }
    }
}