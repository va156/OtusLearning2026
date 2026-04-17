namespace OtusLearning.HW6.Models;

/// <summary>
/// Хранит настройки игры: диапазон чисел и количество попыток
/// Принцип S: отвечает только за хранение настроек
/// </summary>
public class GameSettings
{
	public int MinNumber { get; set; }
	public int MaxNumber { get; set; }
	public int MaxAttempts { get; set; }
}