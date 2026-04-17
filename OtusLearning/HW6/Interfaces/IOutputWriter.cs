namespace OtusLearning.HW6.Interfaces;

/// <summary>
/// Отвечает только за вывод сообщений
/// Принцип I: узкий интерфейс, только одна задача
/// </summary>
public interface IOutputWriter
{
	void Write(string message);
	void WriteLine(string message);
}