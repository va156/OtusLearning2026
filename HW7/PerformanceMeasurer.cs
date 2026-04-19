using System.Diagnostics;

namespace HW7;

public static class PerformanceMeasurer
{
	public static long Measure(Action action, int iterations)
	{
		Stopwatch sw = Stopwatch.StartNew();

		for (int i = 0; i < iterations; i++)
		{
			action();
		}

		sw.Stop();
		return sw.ElapsedMilliseconds;
	}

	public static (T result, long time) MeasureWithResult<T>(Func<T> func, int iterations)
	{
		T result = default;
		Stopwatch sw = Stopwatch.StartNew();

		for (int i = 0; i < iterations; i++)
		{
			result = func();
		}

		sw.Stop();
		return (result, sw.ElapsedMilliseconds);
	}
}