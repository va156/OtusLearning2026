using OtusLearning.HW5.Services;

namespace OtusLearning.HW5.Models;

/// <summary>
/// Базовый класс "Напиток"
/// Содержит общие свойства для всех напитков: название, объём, цену и список ингредиентов
/// Реализует глубокое клонирование через конструктор копирования
/// </summary>
public class Beverage : IMyCloneable<Beverage>, ICloneable
{
	public string Name { get; set; }
	public int VolumeMl { get; set; }
	public decimal Price { get; set; }
	public List<string> Ingredients { get; set; }

	public Beverage(string name, int volumeMl, decimal price, List<string>? ingredients = null)
	{
		Name = name;
		VolumeMl = volumeMl;
		Price = price;
		Ingredients = ingredients ?? new List<string>();
	}

	/// <summary>
	/// Конструктор копирования для паттерна Прототип
	/// Обеспечивает глубокое копирование списка ингредиентов
	/// </summary>
	/// <param name="other">Исходный объект для копирования</param>
	public Beverage(Beverage other)
	{
		Name = other.Name;
		VolumeMl = other.VolumeMl;
		Price = other.Price;
		Ingredients = new List<string>(other.Ingredients);
	}

	public virtual Beverage MyClone() => new Beverage(this);

	public object Clone() => MyClone();

	public override string ToString()
	{
		return $"{Name}, {VolumeMl}мл, {Price}руб.\n  Ингредиенты: {(Ingredients.Any() ? string.Join(", ", Ingredients) : "нет")}";
	}
}