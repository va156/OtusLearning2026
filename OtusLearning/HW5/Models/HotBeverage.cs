using OtusLearning.HW5.Services;

namespace OtusLearning.HW5.Models;

/// <summary>
/// Класс "Горячий напиток", наследуется от Beverage
/// Добавляет свойство TemperatureCelsius — температуру подачи напитка
/// </summary>
public class HotBeverage : Beverage, IMyCloneable<HotBeverage>, ICloneable
{
	public int TemperatureCelsius { get; set; }

	public HotBeverage(string name, int volumeMl, decimal price, int temperatureCelsius, List<string>? ingredients = null)
		: base(name, volumeMl, price, ingredients)
	{
		TemperatureCelsius = temperatureCelsius;
	}

	/// <summary>
	/// Конструктор копирования для паттерна Прототип
	/// Вызывает конструктор копирования базового класса
	/// </summary>
	public HotBeverage(HotBeverage other) : base(other)
	{
		TemperatureCelsius = other.TemperatureCelsius;
	}

	public override HotBeverage MyClone() => new HotBeverage(this);

	public override string ToString()
    {
		return $"{base.ToString()}, {TemperatureCelsius}°C";
	}
}