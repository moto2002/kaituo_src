using System;

public static class TimeSpanExtensions
{
	public static int GetWeeks(this TimeSpan span)
	{
		return span.Days / 7;
	}

	public static int GetFortnights(this TimeSpan span)
	{
		return span.GetWeeks() / 2;
	}

	public static TimeSpan SecondsToTimeSpan(this int seconds)
	{
		return TimeSpan.FromSeconds((double)seconds);
	}

	public static TimeSpan MinutesToTimeSpan(this int minutes)
	{
		return TimeSpan.FromMinutes((double)minutes);
	}
}
