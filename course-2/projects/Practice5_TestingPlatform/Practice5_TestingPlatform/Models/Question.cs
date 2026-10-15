using System;
using Practice5_TestingPlatform.Enums;
using System.ComponentModel.DataAnnotations;

namespace Practice5_TestingPlatform.Models
{
    /// <summary>
    /// Вопрос
    /// </summary>
    public class Question
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Текст вопроса
        /// </summary>
        [Required]
        public string Text { get; set; }

        /// <summary>
        /// Номер вопроса
        /// </summary>
        [Required]
        public int Number { get; set; }

        /// <summary>
        /// Описание вопроса
        /// </summary>
        [MaxLength(2000)]
        public string Description { get; set; }

        /// <summary>
        /// Описание вопроса
        /// </summary>
        public Test Test { get; set; }

        // Навигация к ответам пользователя
        public List<UserAttemptAnswer> UserAttemptAnswers { get; set; } = new List<UserAttemptAnswer>();

        // Навигация к вариантам ответов
        public List<Answer> Answers { get; set; } = new List<Answer>();

        /// <summary>
        /// Тип ответа
        /// </summary>
        public AnswerType AnswerType { get; set; }

        /// <summary>
        /// Счет
        /// </summary>
        public bool? IsScoring { get; set; } = true;

        /// <summary>
        /// Максимальный балл?
        /// </summary>
        public int? MaxScore { get; set; }

        /// <summary>
        /// Id теста
        /// </summary>
        [Required]
        public int TestId { get; set; }
    }
}

