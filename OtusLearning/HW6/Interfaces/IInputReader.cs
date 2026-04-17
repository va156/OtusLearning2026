namespace OtusLearning.HW6.Interfaces;

/// <summary>
/// Отвечает только за чтение ввода пользователя
/// Принцип I: узкий интерфейс, только одна задача
/// </summary>
public interface IInputReader
{
	string ReadLine();
}