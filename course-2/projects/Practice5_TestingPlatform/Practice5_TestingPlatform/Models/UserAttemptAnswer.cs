using System;
using System.ComponentModel.DataAnnotations;

namespace Practice5_TestingPlatform.Models
{
    /// <summary>
    /// Попытка ответа
    /// </summary>
    public class UserAttemptAnswer
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ScoreAwarded { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int AttemptId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int QuestionId { get; set; }

        public Attempt Attempt { get; set; }

        public Question Question { get; set; }

        public List<UserSelectedOption>? UserSelectedOptions { get; set; }

        public UserTextAnswer? UserTextAnswer { get; set; }
    }
}