using OtusLearning.HW6.Interfaces;

namespace OtusLearning.HW6.Input;

/// <summary>
/// Читает ввод пользователя из консоли
/// Принцип S: отвечает только за чтение ввода
/// </summary>
public class ConsoleInputReader : IInputReader
{
	public string ReadLine()
	{
		return Console.ReadLine() ?? string.Empty;
	}
}