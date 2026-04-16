namespace OtusLearning.HW5.Services;

/// <summary>
/// Кастомный generic-интерфейс для реализации паттерна "Прототип"
/// </summary>
/// <typeparam name="T">Тип объекта, который будет клонироваться</typeparam>
public interface IMyCloneable<T>
{
	/// <summary>
	/// Создаёт глубокую копию объекта
	/// </summary>
	/// <returns>Клон объекта типа T</returns>
	T MyClone();
}