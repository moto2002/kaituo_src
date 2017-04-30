using System;
using System.Collections.Generic;

namespace Assets.Tools.Script.Helper
{
	public static class KeyValueHelper
	{
		public static void DeleteKey(List<string> keys, List<string> values, string key)
		{
			int num = keys.FindIndex((string e) => e == key);
			if (num >= 0)
			{
				keys.RemoveAt(num);
				values.RemoveAt(num);
			}
		}

		public static void Add(List<string> keys, List<string> values, string key, string value)
		{
			int num = keys.FindIndex((string e) => e == key);
			if (num >= 0)
			{
				values[num] = value;
			}
			else
			{
				keys.Add(key);
				values.Add(value);
			}
		}

		public static string GetValue(List<string> keys, List<string> values, string key)
		{
			int num = keys.FindIndex((string e) => e == key);
			if (num >= 0)
			{
				return values[num];
			}
			return null;
		}

		public static void SetValue(List<string> keys, List<string> values, string key, string value)
		{
			int num = keys.FindIndex((string e) => e == key);
			if (num >= 0)
			{
				values[num] = value;
			}
		}

		public static void ForEachKeyValue(List<string> keys, List<string> values, Action<string, string> action)
		{
			for (int i = 0; i < keys.Count; i++)
			{
				action(keys[i], values[i]);
			}
		}
	}
}
