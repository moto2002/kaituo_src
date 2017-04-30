using System;
using System.Collections.Generic;

public static class GenericExtensions
{
	public static List<T> AsList<T>(this T tobject)
	{
		return new List<T>
		{
			tobject
		};
	}

	public static bool IsTNull<T>(this T tObj)
	{
		return EqualityComparer<T>.Default.Equals(tObj, default(T));
	}
}
