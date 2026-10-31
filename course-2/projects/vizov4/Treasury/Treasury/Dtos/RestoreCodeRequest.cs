using System;
using System.ComponentModel.DataAnnotations;

namespace Treasury.Dtos
{
    public class RestoreCodeRequest
    {
        /// <summary>
        /// Эталонный код (уникальные латинские буквы от A до Z)
        /// </summary>
        /// <example>DRAGON</example>
        [Required(ErrorMessage = "Поле reference обязательно.")]
        [RegularExpression("^[A-Z]+$", ErrorMessage = "Reference должен содержать только заглавные латинские буквы (A-Z).")]
        public string Reference { get; set; } = string.Empty;

        /// <summary>
        /// Поврежденный код (только символы из эталонного кода)
        /// </summary>
        /// <example>GOD</example>
        [Required(ErrorMessage = "Поле damaged обязательно.")]
        [RegularExpression("^[A-Z]*$", ErrorMessage = "Damaged должен содержать только заглавные латинские буквы (A-Z).")]
        public string Damaged { get; set; } = string.Empty;
    }
}

