using OtusLearning.HW5.Services;

namespace OtusLearning.HW5.Models;

/// <summary>
/// Класс "Чай", наследуется от HotBeverage
/// Добавляет свойства: тип чая (чёрный, зелёный, травяной) и наличие лимона
/// </summary>
public class Tea : HotBeverage, IMyCloneable<Tea>, ICloneable
{
	public string TeaType { get; set; }
	public bool HasLemon { get; set; }

	public Tea(string name, int volumeMl, decimal price, int temperatureCelsius, string teaType, bool hasLemon, List<string>? ingredients = null)
		: base(name, volumeMl, price, temperatureCelsius, ingredients)
	{
		TeaType = teaType;
		HasLemon = hasLemon;
	}

	/// <summary>
	/// Конструктор копирования для паттерна Прототип
	/// Копирует все свойства включая унаследованные
	/// </summary>
	public Tea(Tea other) : base(other)
	{
		TeaType = other.TeaType;
		HasLemon = other.HasLemon;
	}

	public override Tea MyClone() => new Tea(this);

	public override string ToString()
	{
		return $"Чай: {base.ToString()}, тип: {TeaType}, {(HasLemon ? "с лимоном" : "без лимона")}";
	}
}