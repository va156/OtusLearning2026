namespace OtusLearning.HW6.Interfaces;

/// <summary>
/// Отвечает только за генерацию случайного числа
/// Принцип I: узкий интерфейс, только одна задача
/// </summary>
public interface INumberGenerator
{
	int Generate(int min, int max);
}