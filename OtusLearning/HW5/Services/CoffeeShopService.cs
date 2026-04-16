using OtusLearning.HW5.Models;

namespace OtusLearning.HW5.Services;

public static class CoffeeShopService
{
	public static void Run()
	{
		Console.WriteLine("=== Демонстрация паттерна Прототип ===\n");

		// ========== IMyCloneable<T> ==========
		Console.WriteLine("--- IMyCloneable<T> (кастомный интерфейс) на примере Coffee ---\n");

		// Создаём оригинал
		var originalCoffee = new Coffee(
			name: "Американо",
			volumeMl: 250,
			price: 180m,
			temperatureCelsius: 85,
			espressoShots: 2,
			hasSugar: false,
			ingredients: new List<string> { "вода", "эспрессо" }
		);

		Console.WriteLine("Оригинал:");
		Console.WriteLine(originalCoffee);
		Console.WriteLine();

		// Клонируем 
		var clonedCoffee = originalCoffee.MyClone();

		// Изменяем клон
		clonedCoffee.HasSugar = true;
		clonedCoffee.Price = 200m;
		clonedCoffee.Ingredients.Add("корица");

		Console.WriteLine("Клон после изменений:");
		Console.WriteLine(clonedCoffee);
		Console.WriteLine();

		Console.WriteLine("Оригинал после изменения клона (не изменился):");
		Console.WriteLine(originalCoffee);
		Console.WriteLine();

		// ========== ICloneable ==========
		Console.WriteLine("--- ICloneable ---\n");

		// Создаём оригинал
		var originalTea = new Tea(
			name: "Зелёный чай",
			volumeMl: 300,
			price: 150m,
			temperatureCelsius: 80,
			teaType: "зелёный",
			hasLemon: true,
			ingredients: new List<string> { "вода", "чай" }
		);

		Console.WriteLine("Оригинал:");
		Console.WriteLine(originalTea);
		Console.WriteLine();

		// Клонируем - нужно приведение типов
		var clonedTea = (Tea)originalTea.Clone();

		// Изменяем клон
		clonedTea.HasLemon = false;
		clonedTea.TeaType = "чёрный";
		clonedTea.Name = "Чёрный чай";

		Console.WriteLine("Клон после изменений:");
		Console.WriteLine(clonedTea);
		Console.WriteLine();

		Console.WriteLine("Оригинал после изменения клона:");
		Console.WriteLine(originalTea);
		Console.WriteLine();

		// ========== Глубокое копирование ==========
		Console.WriteLine("--- Глубокое копирование ---\n");

		originalTea.Ingredients.Add("мята");

		Console.WriteLine("Оригинал после добавления мяты в ингредиенты оригинала:");
		Console.WriteLine(originalTea);
		Console.WriteLine();

		Console.WriteLine("Клон - ингредиенты не изменились:");
		Console.WriteLine(clonedTea);
	}
}