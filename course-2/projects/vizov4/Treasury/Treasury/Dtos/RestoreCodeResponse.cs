using System;
namespace Treasury.Dtos
{
    public class RestoreCodeResponse
    {
        /// <summary>
        /// Отсутствующие символы, отсортированные по алфавиту
        /// </summary>
        public string MissingSymbols { get; set; } = string.Empty;

        /// <summary>
        /// Флаг, указывающий, что код восстановлен полностью (все символы на месте)
        /// </summary>
        public bool IsComplete { get; set; }
    }
}

