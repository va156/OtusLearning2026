using OtusLearning.HW6.Config;
using OtusLearning.HW6.Core;
using OtusLearning.HW6.Generators;
using OtusLearning.HW6.Input;
using OtusLearning.HW6.Interfaces;
using OtusLearning.HW6.Models;
using OtusLearning.HW6.Output;

namespace OtusLearning.HW6;

/// <summary>
/// Запускает игру "Угадай число"
/// Принцип S: отвечает только за сборку зависимостей и запуск
/// Принцип D: собирает все зависимости в одном месте
/// </summary>
public static class GuessNumberGameRunner
{
	public static void Run()
	{
		// Загружаем настройки из JSON файла
		GameSettings settings = AppConfig.LoadSettings();

		// Создаём зависимости
		INumberGenerator generator = new RandomNumberGenerator();
		IInputReader inputReader = new ConsoleInputReader();
		IOutputWriter outputWriter = new ConsoleOutputWriter();

		// Собираем игру
		Game game = new Game(generator, inputReader, outputWriter, settings);

		// Запускаем
		game.Run();
	}
}