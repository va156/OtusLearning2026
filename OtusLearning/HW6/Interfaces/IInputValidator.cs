namespace OtusLearning.HW6.Interfaces;

/// <summary>
/// Отвечает только за проверку корректности ввода
/// Принцип I: узкий интерфейс, только одна задача
/// </summary>
public interface IInputValidator
{
	bool IsValid(string input, out int result);
	string GetErrorMessage();
}