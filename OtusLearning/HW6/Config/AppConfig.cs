using System.Text.Json;
using OtusLearning.HW6.Models;

namespace OtusLearning.HW6.Config;

/// <summary>
/// Загружает настройки игры из JSON файла
/// Принцип S: отвечает только за загрузку настроек
/// </summary>
public static class AppConfig
{
	public static GameSettings LoadSettings(string filePath = "HW6/Config/appsettings.json")
	{
		try
		{
			var json = File.ReadAllText(filePath);
			var settings = JsonSerializer.Deserialize<GameSettings>(json);

			return settings ?? new GameSettings { MinNumber = 1, MaxNumber = 100, MaxAttempts = 5 };
		}
		catch
		{
			return new GameSettings { MinNumber = 1, MaxNumber = 100, MaxAttempts = 5 };
		}
	}
}