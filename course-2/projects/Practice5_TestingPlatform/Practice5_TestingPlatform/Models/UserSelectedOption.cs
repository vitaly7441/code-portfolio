using System;
using System.ComponentModel.DataAnnotations;

namespace Practice5_TestingPlatform.Models
{
    /// <summary>
    /// Выбранный ответ
    /// </summary>
    public class UserSelectedOption
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int UserAttemptAnswerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int AnswerId { get; set; }

        public UserAttemptAnswer UserAttemptAnswer { get; set; }

        public Answer Answer { get; set; }
    }
}