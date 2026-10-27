using System;
namespace Gates.Models
{
	public class ValidResult
	{
		/// <summary>
		/// Является ли код корректным
		/// </summary>
		public bool IsValid { get; set; }

		/// <summary>
		/// Список обнаруженных ошибок
		/// </summary>
		public List<string> Errors { get; set; } = new();

		/// <summary>
		/// Итоговое сообщение
		/// </summary>
		public string Message { get; set; }
	}
}

