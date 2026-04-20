using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Xml.Linq;

namespace HW8;

public static class EnumerableExtensions
{
	public static T GetMax<T>(this IEnumerable collection, Func<T, float> convertToNumber) where T : class
	{
		if (collection == null) throw new ArgumentNullException(nameof(collection));
		if (convertToNumber == null) throw new ArgumentNullException(nameof(convertToNumber));

		T maxEl = null;
		float maxVal = float.MinValue;

		foreach (var item in collection)
		{
			T currentItem = item as T;
			if (currentItem == null)
				continue;

			float currentVal = convertToNumber(currentItem);

			if (currentVal > maxVal) 
			{
				maxVal = currentVal;
				maxEl = currentItem;
			}
		}

		return maxEl;
	}
}
