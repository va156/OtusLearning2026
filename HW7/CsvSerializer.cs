using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace HW7;

public class CsvSerializer
{
	public static string SerializeToCsv(F f)
	{
		if (f == null) return "";

		FieldInfo[] fieldInfos = typeof(F).GetFields(BindingFlags.Instance | BindingFlags.Public);

		StringBuilder sb = new StringBuilder();

		for (int i = 0; i < fieldInfos.Length; i++)
		{
			object value = fieldInfos[i].GetValue(f);
			sb.Append(value);
			if (i < fieldInfos.Length - 1)
				sb.Append(",");
		}
		return sb.ToString();
	}

	public static F DeserializeFromCsv(string csv)
	{
		if (!string.IsNullOrEmpty(csv))
			return new F();

		string[] values = csv.Split(',');

		FieldInfo[] fieldInfos = typeof(F).GetFields(BindingFlags.Public | BindingFlags.Instance);
		
		F f = new F();

		for (int i = 0; i < fieldInfos.Length; i++)
		{
			object convertedValue = Convert.ChangeType(values[i], fieldInfos[i].FieldType);
			fieldInfos[i].SetValue(f, convertedValue);
		}

		return f;
	}
}
