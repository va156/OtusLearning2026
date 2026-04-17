using OtusLearning.HW6.Interfaces;

namespace OtusLearning.HW6.Output;

/// <summary>
/// Выводит сообщения в консоль
/// Принцип S: отвечает только за вывод сообщений
/// </summary>
public class ConsoleOutputWriter : IOutputWriter
{
	public void Write(string message)
	{
		Console.Write(message);
	}

	public void WriteLine(string message)
	{
		Console.WriteLine(message);
	}
}