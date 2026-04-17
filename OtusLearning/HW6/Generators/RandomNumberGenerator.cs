using OtusLearning.HW6.Interfaces;

namespace OtusLearning.HW6.Generators;

/// <summary>
/// Генерирует случайное число в заданном диапазоне
/// Принцип S: отвечает только за генерацию чисел
/// </summary>
public class RandomNumberGenerator : INumberGenerator
{
	private readonly Random _random = new Random();

	public int Generate(int min, int max)
	{
		return _random.Next(min, max + 1);
	}
}