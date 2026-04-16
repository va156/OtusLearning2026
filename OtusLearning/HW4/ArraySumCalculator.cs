using System.Collections.Concurrent;
using System.Diagnostics;

namespace OtusLearning.HW4;

public class ArraySumCalculator
{
	public static async Task Run()
	{
		Console.WriteLine("\n=== ДЗ: Многопоточный проект ===\n");
		ShowSystemInfo();

		int[] sizes = { 100_000, 1_000_000, 10_000_000 };

		Console.WriteLine("\nТАБЛИЦА 1: Только сложение");
		RunTests(sizes, false);

		Console.WriteLine("\nТАБЛИЦА 2: Операции посложнее");
		RunTests(sizes, true);
	}

	private static void RunTests(int[] sizes, bool useHeavy)
	{
		Console.WriteLine("| Размер массива | Последовательно (мс) | Параллельно Thread (мс) | PLINQ (мс) |");
		Console.WriteLine("|----------------|----------------------|-------------------------|------------|");

		foreach (int size in sizes)
		{
			int[] array = GenerateRandomArray(size);

			var sw = Stopwatch.StartNew();
			long sequentialSum = SequentialSum(array, useHeavy);
			sw.Stop();
			long sequentialTime = sw.ElapsedMilliseconds;

			sw.Restart();
			long threadSum = ParallelThreadSum(array, useHeavy);
			sw.Stop();
			long threadTime = sw.ElapsedMilliseconds;

			sw.Restart();
			long plinqSum = PlinqSum(array, useHeavy);
			sw.Stop();
			long plinqTime = sw.ElapsedMilliseconds;

			Console.WriteLine($"| {size,14:N0} | {sequentialTime,20} | {threadTime,23} | {plinqTime,10} |");
		}
	}
	private static long SequentialSum(int[] arr, bool useHeavy)
	{
		long sum = 0;
		for (int i = 0; i < arr.Length; i++)
		{
			if (useHeavy)
				sum += (long)Math.Sqrt(arr[i] * 1000) + (long)Math.Pow(arr[i] % 50, 2) + (long)Math.Sin(arr[i]);
			else
				sum += arr[i];
		}
		return sum;
	}
	private static long ParallelThreadSum(int[] arr, bool useHeavy)
	{
		int threadCount = Environment.ProcessorCount;
		List<Thread> threads = new List<Thread>();
		List<long> partialSums = new List<long>(new long[threadCount]);

		var partitioner = Partitioner.Create(0, arr.Length);
		var ranges = partitioner.GetPartitions(threadCount).ToList();

		for (int i = 0; i < threadCount; i++)
		{
			int idx = i;
			var range = ranges[i];

			Thread thread = new Thread(() =>
			{
				long sum = 0;
				while (range.MoveNext())
				{
					var (start, end) = range.Current;
					for (int j = start; j < end; j++)
					{
						if (useHeavy)
							sum += (long)Math.Sqrt(arr[j] * 1000) + (long)Math.Pow(arr[j] % 50, 2) + (long)Math.Sin(arr[j]);
						else
							sum += arr[j];
					}
				}
				partialSums[idx] = sum;
			});

			threads.Add(thread);
			thread.Start();
		}

		foreach (Thread t in threads) t.Join();

		long total = 0;
		for (int i = 0; i < partialSums.Count; i++)
			total += partialSums[i];
		return total;
	}

	private static long PlinqSum(int[] arr, bool useHeavy)
	{
		if (useHeavy)
		{
			return arr.AsParallel()
				.Select(x => (long)Math.Sqrt(x * 1000) + (long)Math.Pow(x % 50, 2) + (long)Math.Sin(x))
				.Sum();
		}
		else
		{
			return arr.AsParallel().Sum(x => (long)x);
		}
	}

	private static int[] GenerateRandomArray(int size)
	{
		Random random = new Random();
		int[] array = new int[size];
		for (int i = 0; i < size; i++)
			array[i] = random.Next(1, 100);
		return array;
	}

	private static void ShowSystemInfo()
	{
		Console.WriteLine($"Процессор: {Environment.ProcessorCount} логических ядер");
		Console.WriteLine($"ОС: {Environment.OSVersion}");
		Console.WriteLine($"64-разрядная ОС: {Environment.Is64BitOperatingSystem}");
		Console.WriteLine($".NET версия: {Environment.Version}");
	}
}