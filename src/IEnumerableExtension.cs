using System;
using System.Collections.Generic;

public static class IEnumerableExtension
{
	public static List<T> ToList<T>(this IEnumerable<T> collection)
	{
		List<T> list = new List<T>();
		foreach (T current in collection)
		{
			list.Add(current);
		}
		return list;
	}
}
