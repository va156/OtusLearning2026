using OtusLearning.HW5.Services;

namespace OtusLearning.HW5.Models;

/// <summary>
/// Класс "Кофе", наследуется от HotBeverage
/// Добавляет свойства: количество порций эспрессо и наличие сахара
/// </summary>
public class Coffee : HotBeverage, IMyCloneable<Coffee>, ICloneable
{
	public int EspressoShots { get; set; }
	public bool HasSugar { get; set; }

	public Coffee(string name, int volumeMl, decimal price, int temperatureCelsius, int espressoShots, bool hasSugar, List<string>? ingredients = null)
		: base(name, volumeMl, price, temperatureCelsius, ingredients)
	{
		EspressoShots = espressoShots;
		HasSugar = hasSugar;
	}

	/// <summary>
	/// Конструктор копирования для паттерна Прототип
	/// Копирует все свойства включая унаследованные
	/// </summary>
	public Coffee(Coffee other) : base(other)
	{
		EspressoShots = other.EspressoShots;
		HasSugar = other.HasSugar;
	}

	public override Coffee MyClone() => new Coffee(this);

	public override string ToString()
	{
		return $"Кофе: {base.ToString()}, {EspressoShots} порций эспрессо, {(HasSugar ? "с сахаром" : "без сахара")}";
	}
}