using System;
using System.Collections.Generic;

public static class ListExtensions
{
	public static bool IsNullOrEmpty<T>(this T[] data)
	{
		return data == null || data.Length == 0;
	}

	public static bool IsNullOrEmpty<T>(this List<T> data)
	{
		return data == null || data.Count == 0;
	}

	public static bool IsNullOrEmpty<T1, T2>(this Dictionary<T1, T2> data)
	{
		return data == null || data.Count == 0;
	}

	public static T DequeueOrNull<T>(this Queue<T> q)
	{
		T result;
		try
		{
			result = ((q.Count <= 0) ? default(T) : q.Dequeue());
		}
		catch (Exception)
		{
			result = default(T);
		}
		return result;
	}
}
