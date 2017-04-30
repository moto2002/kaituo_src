using System;
using System.Text.RegularExpressions;

public static class NumberExtensions
{
	public static decimal Rounded(this decimal value, int decimals)
	{
		return Math.Round(value, decimals, MidpointRounding.AwayFromZero);
	}

	public static bool IsNumeric(this string input)
	{
		return !string.IsNullOrEmpty(input) && new Regex("^-?[0-9]*\\.?[0-9]+$").IsMatch(input.Trim());
	}

	public static bool HasNumeric(this string input)
	{
		return !string.IsNullOrEmpty(input) && new Regex("[0-9]+").IsMatch(input);
	}

	public static int Negate(this int number)
	{
		return number * -1;
	}

	public static int AbsoluteValue(this int number)
	{
		return Math.Abs(number);
	}

	public static long Negate(this long number)
	{
		return number * -1L;
	}

	public static long AbsoluteValue(this long number)
	{
		return Math.Abs(number);
	}
}
