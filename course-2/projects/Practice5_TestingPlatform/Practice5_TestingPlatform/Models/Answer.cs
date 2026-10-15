using System;
using Practice5_TestingPlatform.Enums;
using System.ComponentModel.DataAnnotations;

namespace Practice5_TestingPlatform.Models
{
    /// <summary>
    /// Ответ
    /// </summary>
    public class Answer
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Текст Ответа
        /// </summary>
        [Required]
        public string Text { get; set; }

        /// <summary>
        /// Правильность ответа
        /// </summary>
        [Required]
        public bool IsCorrect { get; set; }

        /// <summary>
        /// ID вопроса
        /// </summary>
        [Required]
        public int QuestionId { get; set; }

        /// <summary>
        /// Навигация вопроса
        /// </summary>
        public Question Question { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<UserSelectedOption> UserSelectedOptions { get; set; }
    }
}