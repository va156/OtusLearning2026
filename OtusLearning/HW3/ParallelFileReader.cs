using System.Diagnostics;

namespace OtusLearning.HW3;

public class ParallelFileReader
{
	public static async Task Run()
	{
		string folderPath = "C:\\Users\\strekv01\\Desktop\\Otus\\PFR";
		string file1Name = "file1.txt";
		string file2Name = "file2.txt";
		string file3Name = "file3.txt";
		string[] targetFilesForTask1 =
		{
			folderPath + "\\" + file1Name,
			folderPath + "\\" + file2Name,
			folderPath + "\\" + file3Name,
		};
		var sw = new Stopwatch();

		Console.WriteLine("\n=== ДЗ: Task: Параллельное считывание файлов. ===\n");

		sw.Start();
		await Task1_CountSpacesInMultipleFilesAsync(targetFilesForTask1);
		sw.Stop();
		Console.WriteLine($"Время выполнения Задания 1: {sw.ElapsedMilliseconds} мс\n");
		sw.Reset();

		sw.Start();
		await Task2_CountSpacesInFolderAsync(folderPath);
		sw.Stop();
		Console.WriteLine($"Время выполнения Задания 2: {sw.ElapsedMilliseconds} мс\n");
	}

	static async Task Task1_CountSpacesInMultipleFilesAsync(string[] filePaths)
	{
		Console.WriteLine("1. Прочитать 3 файла параллельно и вычислить количество пробелов в них (через Task).\n");
		var tasks = filePaths.Select(file => Task.Run(() =>
		{
			int spaces = CountSpacesInFile(file);
			return (Path.GetFileName(file), spaces);
		}));

		var results = await Task.WhenAll(tasks);

		foreach (var (fileName, spaces) in results)
			Console.WriteLine($"  {fileName}: {spaces} пробелов");
	}

	static async Task Task2_CountSpacesInFolderAsync(string folderPath)
	{
		Console.WriteLine("2. Написать функцию, принимающую в качестве аргумента путь к папке. Из этой папки параллельно прочитать все файлы и вычислить количество пробелов в них.\n");
		var files = Directory.GetFiles(folderPath, "*.txt");

		if (files.Length == 0)
		{
			Console.WriteLine("Нет .txt файлов в папке");
			return;
		}

		Console.WriteLine($"Найдено файлов: {files.Length}");

		var tasks = files.Select(file => Task.Run(() =>
		{
			int spaces = CountSpacesInFile(file);
			return (Path.GetFileName(file), spaces);
		}));

		var results = await Task.WhenAll(tasks);

		int total = 0;
		foreach (var (fileName, spaces) in results)
		{
			Console.WriteLine($"  {fileName}: {spaces} пробелов");
			total += spaces;
		}
		Console.WriteLine($"Всего пробелов: {total}");
	}

	static int CountSpacesInFile(string filePath)
	{
		try
		{
			string content = File.ReadAllText(filePath);
			return content.Count(c => c == ' ');
		}
		catch (FileNotFoundException)
		{
			Console.WriteLine($"  Файл не найден: {filePath}");
			return 0;
		}
		catch (UnauthorizedAccessException)
		{
			Console.WriteLine($"  Нет доступа к файлу: {filePath}");
			return 0;
		}
		catch (Exception ex)
		{
			Console.WriteLine($"  Ошибка при чтении файла {filePath}: {ex.Message}");
			return 0;
		}
	}
}
