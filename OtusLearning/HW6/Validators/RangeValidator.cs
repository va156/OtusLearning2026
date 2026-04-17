using OtusLearning.HW6.Interfaces;

namespace OtusLearning.HW6.Validators;

/// <summary>
/// Проверяет, что введённое число находится в заданном диапазоне
/// Принцип S: отвечает только за валидацию чисел
/// </summary>
public class RangeValidator : IInputValidator
{
	private readonly int _min;
	private readonly int _max;

	public RangeValidator(int min, int max)
	{
		_min = min;
		_max = max;
	}

	public bool IsValid(string input, out int result)
	{
		result = 0;

		if (!int.TryParse(input, out result))
		{
			return false;
		}

		return result >= _min && result <= _max;
	}

	public string GetErrorMessage()
	{
		return $"Ошибка! Введите число от {_min} до {_max}.";
	}
}