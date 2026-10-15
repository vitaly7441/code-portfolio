namespace Practice5_TestingPlatform.Models;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Студент
/// </summary>
public class Student
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Номер телефона
    /// </summary>
    [Required]
    [MaxLength(30)]
    public string Phone { get; set; }

    /// <summary>
    /// Ссылка на профиль в ВК
    /// </summary>
    [Required]
    public string VkProfileLink { get; set; }

    /// <summary>
    /// 1:1 к пользователю (обязателен для студента)
    /// </summary>
    [Required]
    public int UserId { get; set; }
    [Required]
    public User User { get; set; }

    /// <summary>
    /// Группы, в которых состоит студент
    /// </summary>
    public List<Group> Groups { get; set; }

    /// <summary>
    /// Тесты для студента
    /// </summary>
    public List<Test> Tests { get; set; }

    /// <summary>
    /// Попытки прохождения
    /// </summary>
    public List<Attempt> Attempts { get; set; }

    /// <summary>
    /// Результаты
    /// </summary>
    public List<TestResult> TestResults { get; set; }
}