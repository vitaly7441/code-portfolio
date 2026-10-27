using System;
using Gates.Models;

namespace Gates.Services
{
	public class AccessCodeValidator : IAccessValidator
	{
		private static readonly string SpecialChars = "!@#$%";

		public ValidResult Validate(string code) {
			var result = new ValidResult { IsValid = true };

			if (code.Length < 8 || code.Length > 16) {
				result.IsValid = false;
				result.Errors.Add("Длина должна быть от 8 до 16 символов включительно.");
			}

			if (!code.Any(c => c >= 'A' && c <= 'Z'))
            {
                result.IsValid = false;
                result.Errors.Add("Нет заглавной латинской буквы.");
            }

            if (!code.Any(c => c >= 'a' && c <= 'z'))
            {
                result.IsValid = false;
                result.Errors.Add("Нет строчной латинской буквы.");
            }

            if (!code.Any(char.IsDigit))
            {
                result.IsValid = false;
                result.Errors.Add("Нет хотя бы одной цифры от 0 до 9.");
            }

            if (!code.Any(c => SpecialChars.Contains(c)))
            {
                result.IsValid = false;
                result.Errors.Add("Нет специального символа.");
            }

            if (code.Any(char.IsWhiteSpace))
            {
                result.IsValid = false;
                result.Errors.Add("Код не должен содержать пробелов.");
            }

            for (int i = 0; i <= code.Length - 3; i++) {
                if (code[i] == code[i + 1] && code[i] == code[i + 2]) {
                    if (!result.Errors.Contains("Обнаружены три одинаковых символа подряд.")) {
                        result.IsValid = false;
                        result.Errors.Add("Обнаружены три одинаковых символа подряд.");
                    }
                }
            }

            for (int i = 0; i <= code.Length - 3; i++)
            {
                if (char.IsDigit(code[i]) && char.IsDigit(code[i+1]) && char.IsDigit(code[i+2]))
                {
                    if (!result.Errors.Contains("Обнаружена последовательность из трёх или более подряд идущих цифр."))
                    {
                        result.IsValid = false;
                        result.Errors.Add("Обнаружена последовательность из трёх или более подряд идущих цифр.");
                    }
                }
            }

            if (!char.IsLetter(code[0])) {
                result.IsValid = false;
                result.Errors.Add("Первый символ должен быть буквой.");
            }

            char LastChar = code[code.Length-1];
            if (!char.IsDigit(LastChar) && !SpecialChars.Contains(LastChar)) {
                result.IsValid = false;
                result.Errors.Add("Последний символ должен быть цифрой или специальным разрешённым символом.");
            }

            result.Message = result.IsValid ? "Код принят. Ворота открываются." : "Код отклонён.";
            return result;
		}
	}
}

