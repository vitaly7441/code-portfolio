using System;
using System.ComponentModel.DataAnnotations;

namespace Practice5_TestingPlatform.Models
{
    /// <summary>
    /// Выбранный ответ(текст)
    /// </summary>
    public class UserTextAnswer
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Текстовый ответ
        /// </summary>
        [Required]
        public string TextAnswer { get; set; }

        /// <summary>
        /// ID UserAttemptAnswer
        /// </summary>
        [Required]
        public int UserAttemptAnswerId { get; set; }

        public UserAttemptAnswer UserAttemptAnswer { get; set; }
    }
}