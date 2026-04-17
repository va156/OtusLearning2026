using OtusLearning.HW6.Interfaces;
using OtusLearning.HW6.Models;

namespace OtusLearning.HW6.Core;

/// <summary>
/// Основная логика игры
/// Принцип D: зависит от абстракций (интерфейсов), а не от конкретных классов
/// Принцип O: открыт для расширения (можно заменить любую зависимость)
/// Принцип L: любые реализации интерфейсов взаимозаменяемы
/// </summary>
public class Game
{
	private readonly INumberGenerator _numberGenerator;
	private readonly IInputReader _inputReader;
	private readonly IOutputWriter _outputWriter;
	private readonly GameSettings _settings;

	public Game(
		INumberGenerator numberGenerator,
		IInputReader inputReader,
		IOutputWriter outputWriter,
		GameSettings settings)
	{
		_numberGenerator = numberGenerator;
		_inputReader = inputReader;
		_outputWriter = outputWriter;
		_settings = settings;
	}

	public void Run()
	{
		_outputWriter.WriteLine($"=== Игра 'Угадай число' ===");
		_outputWriter.WriteLine($"Диапазон: от {_settings.MinNumber} до {_settings.MaxNumber}");
		_outputWriter.WriteLine($"Количество попыток: {_settings.MaxAttempts}");
		_outputWriter.WriteLine("");

		// Генерируем загаданное число
		int secretNumber = _numberGenerator.Generate(_settings.MinNumber, _settings.MaxNumber);
		int attemptsLeft = _settings.MaxAttempts;
		bool isGuessed = false;

		// Создаём валидатор для проверки ввода
		var validator = new Validators.RangeValidator(_settings.MinNumber, _settings.MaxNumber);

		while (attemptsLeft > 0 && !isGuessed)
		{
			_outputWriter.Write($"Попытка {_settings.MaxAttempts - attemptsLeft + 1}/{_settings.MaxAttempts}. Введите число: ");
			string input = _inputReader.ReadLine();

			// Валидируем ввод
			if (!validator.IsValid(input, out int userNumber))
			{
				_outputWriter.WriteLine(validator.GetErrorMessage());
				continue;
			}

			// Сравниваем с загаданным числом
			if (userNumber == secretNumber)
			{
				_outputWriter.WriteLine($"Поздравляю! Вы угадали число {secretNumber}!");
				isGuessed = true;
			}
			else if (userNumber < secretNumber)
			{
				_outputWriter.WriteLine("Загаданное число БОЛЬШЕ");
				attemptsLeft--;
			}
			else
			{
				_outputWriter.WriteLine("Загаданное число МЕНЬШЕ");
				attemptsLeft--;
			}

			if (attemptsLeft > 0 && !isGuessed)
			{
				_outputWriter.WriteLine($"Осталось попыток: {attemptsLeft}");
				_outputWriter.WriteLine("");
			}
		}

		if (!isGuessed)
		{
			_outputWriter.WriteLine($"");
			_outputWriter.WriteLine($"Игра окончена! Было загадано число {secretNumber}");
		}
	}
}