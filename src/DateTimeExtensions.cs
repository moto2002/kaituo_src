using System;

public static class DateTimeExtensions
{
	internal const int DAYS_PER_WEEK = 7;

	internal const int DAYS_PER_FORTNIGHT = 14;

	internal const int WEEKS_PER_FORTNIGHT = 2;

	internal const int YEARS_PER_DECADE = 10;

	internal const int YEARS_PER_CENTURY = 100;

	private const int JANUARY = 1;

	private const int FEBRUARY = 2;

	private const int MARCH = 3;

	private const int APRIL = 4;

	private const int MAY = 5;

	private const int JUNE = 6;

	private const int JULY = 7;

	private const int AUGUST = 8;

	private const int SEPTEMBER = 9;

	private const int OCTOBER = 10;

	private const int NOVEMBER = 11;

	private const int DECEMBER = 12;

	public static bool IsBetween(this DateTime value, DateTime from, DateTime to)
	{
		return from <= value && to >= value;
	}

	public static DateTime Midnight(this DateTime value)
	{
		return new DateTime(value.Year, value.Month, value.Day);
	}

	public static DateTime DateFromDay(this int day, int month)
	{
		return new DateTime(DateTime.Now.Year, month, day);
	}

	public static DateTime DateFromDay(this int day, int month, int year)
	{
		return new DateTime(year, month, day);
	}

	public static DateTime DateFromMonth(this int month, int day)
	{
		return new DateTime(DateTime.Now.Year, month, day);
	}

	public static DateTime DateFromMonth(this int month, int day, int year)
	{
		return new DateTime(year, month, day);
	}

	public static DateTime FirstOfMonth(this DateTime value)
	{
		return new DateTime(value.Year, value.Month, 1);
	}

	public static DateTime FirstOfMonth(this int month)
	{
		return new DateTime(DateTime.Now.Year, month, 1);
	}

	public static DateTime FirstOfMonth(this int month, int year)
	{
		return new DateTime(year, month, 1);
	}

	public static DateTime EndOfMonth(this DateTime value)
	{
		DateTime dateTime = new DateTime(value.Year, value.Month, 1);
		return dateTime.AddMonths(1).AddDays(-1.0);
	}

	public static DateTime EndOfMonth(this int month)
	{
		return new DateTime(DateTime.Now.Year, month, 1).EndOfMonth();
	}

	public static DateTime EndOfMonth(this int month, int year)
	{
		return new DateTime(year, month, 1).EndOfMonth();
	}

	public static DateTime Yesterday(this DateTime value)
	{
		return value.AddDays(-1.0);
	}

	public static DateTime YesterdayMidnight(this DateTime value)
	{
		return value.Yesterday().Midnight();
	}

	public static DateTime Tomorrow(this DateTime value)
	{
		return value.AddDays(1.0);
	}

	public static DateTime TomorrowMidnight(this DateTime value)
	{
		return value.Tomorrow().Midnight();
	}

	public static bool IsSameDay(this DateTime value, DateTime compareDate)
	{
		return value.Midnight().Equals(compareDate.Midnight());
	}

	public static bool IsLaterDate(this DateTime value, DateTime compareDate)
	{
		return value > compareDate;
	}

	public static bool IsOlderDate(this DateTime value, DateTime compareDate)
	{
		return value < compareDate;
	}

	public static bool IsToday(this DateTime date)
	{
		return date.Date == DateTime.Now.Date;
	}

	public static bool IsTomorrow(this DateTime date)
	{
		return date.Date == DateTime.Now.Date.AddDays(1.0);
	}

	public static bool IsYesterday(this DateTime date)
	{
		return date.Date == DateTime.Now.Date.AddDays(-1.0);
	}

	public static bool IsOlderThanASecond(this DateTime date)
	{
		return date.Subtract(DateTime.Now).Seconds < 0;
	}

	public static bool IsOlderThanAMinute(this DateTime date)
	{
		return date.Subtract(DateTime.Now).Minutes < 0;
	}

	public static bool IsOlderThanAnHour(this DateTime date)
	{
		return date.Subtract(DateTime.Now).Hours < 0;
	}

	public static bool IsOlderThanADay(this DateTime date)
	{
		return date.Subtract(DateTime.Now).Days < 0;
	}

	public static bool IsOlderThanAWeek(this DateTime date)
	{
		return date.Subtract(DateTime.Now).Days < 7;
	}

	public static bool IsOlderThanAFortnight(this DateTime date)
	{
		return date.Subtract(DateTime.Now).Days < 14;
	}

	public static bool IsOlderThanAMonth(this DateTime date)
	{
		DateTime secondDate = DateTime.Now.AddMonths(-1);
		return date.IsOlderThan(secondDate);
	}

	public static bool IsOlderThanHalfYear(this DateTime date)
	{
		DateTime secondDate = DateTime.Now.AddMonths(-6);
		return date.IsOlderThan(secondDate);
	}

	public static bool IsOlderThanAYear(this DateTime date)
	{
		DateTime secondDate = DateTime.Now.AddYears(-1);
		return date.IsOlderThan(secondDate);
	}

	public static bool IsOlderThanADecade(this DateTime date)
	{
		DateTime secondDate = DateTime.Now.AddYears(10.Negate());
		return date.IsOlderThan(secondDate);
	}

	public static bool IsOlderThanACentury(this DateTime date)
	{
		DateTime secondDate = DateTime.Now.AddYears(100.Negate());
		return date.IsOlderThan(secondDate);
	}

	public static bool IsOlderThan(this DateTime firstDate, DateTime secondDate)
	{
		return firstDate.Subtract(secondDate).Ticks < 0L;
	}

	public static bool IsYoungerThanASecond(this DateTime date)
	{
		return date.Subtract(DateTime.Now).TotalSeconds > 0.0;
	}

	public static bool IsYoungerThanAMinute(this DateTime date)
	{
		return date.Subtract(DateTime.Now).TotalMinutes > 0.0;
	}

	public static bool IsYoungerThanAnHour(this DateTime date)
	{
		return date.Subtract(DateTime.Now).TotalHours > 0.0;
	}

	public static bool IsYoungerThanADay(this DateTime date)
	{
		return date.Subtract(DateTime.Now).Days > 0;
	}

	public static bool IsYoungerThanAWeek(this DateTime date)
	{
		DateTime now = DateTime.Now;
		return date.Subtract(now).Days >= 7 && date.IsYoungerThan(now);
	}

	public static bool IsYoungerThanAFortnight(this DateTime date)
	{
		DateTime now = DateTime.Now;
		return date.Subtract(now).Days >= 14 && date.IsYoungerThan(now);
	}

	public static bool IsYoungerThanAMonth(this DateTime date)
	{
		DateTime secondDate = DateTime.Now.AddMonths(1);
		return date.IsYoungerThan(secondDate);
	}

	public static bool IsYoungerThanHalfYear(this DateTime date)
	{
		DateTime secondDate = DateTime.Now.AddMonths(6);
		return date.IsYoungerThan(secondDate);
	}

	public static bool IsYoungerThanAYear(this DateTime date)
	{
		DateTime secondDate = DateTime.Now.AddYears(1);
		return date.IsYoungerThan(secondDate);
	}

	public static bool IsYoungerThanADecade(this DateTime date)
	{
		DateTime secondDate = DateTime.Now.AddYears(10);
		return date.IsYoungerThan(secondDate);
	}

	public static bool IsYoungerThanACentury(this DateTime date)
	{
		DateTime secondDate = DateTime.Now.AddYears(100);
		return date.IsYoungerThan(secondDate);
	}

	public static bool IsYoungerThan(this DateTime firstDate, DateTime secondDate)
	{
		return firstDate.Subtract(secondDate).Ticks > 0L;
	}

	public static DateTime AddASecond(this DateTime date)
	{
		return date.AddSeconds(1.0);
	}

	public static DateTime AddAMinute(this DateTime date)
	{
		return date.AddMinutes(1.0);
	}

	public static DateTime AddHalfAnHour(this DateTime date)
	{
		return date.AddMinutes(30.0);
	}

	public static DateTime AddAnHour(this DateTime date)
	{
		return date.AddHours(1.0);
	}

	public static DateTime AddADay(this DateTime date)
	{
		return date.AddDays(1.0);
	}

	public static DateTime AddAWeek(this DateTime date)
	{
		return date.AddWeeks(1);
	}

	public static DateTime AddAFortnight(this DateTime date)
	{
		return date.AddFortnights(1);
	}

	public static DateTime AddAMonth(this DateTime date)
	{
		return date.AddMonths(1);
	}

	public static DateTime AddAYear(this DateTime date)
	{
		return date.AddYears(1);
	}

	public static DateTime AddADecade(this DateTime date)
	{
		return date.AddDecades(1);
	}

	public static DateTime AddWeeks(this DateTime date, int weeks)
	{
		return date.AddDays((double)(weeks * 7));
	}

	public static DateTime AddFortnights(this DateTime date, int fortnights)
	{
		return date.AddDays((double)(fortnights * 14));
	}

	public static DateTime AddACentury(this DateTime date)
	{
		return date.AddCenturies(1);
	}

	public static DateTime AddDecades(this DateTime date, int decades)
	{
		return date.AddYears(decades * 10);
	}

	public static DateTime AddCenturies(this DateTime date, int centuries)
	{
		return date.AddYears(centuries * 100);
	}

	public static DateTime SubtractASecond(this DateTime date)
	{
		return date.SubtractSeconds(1);
	}

	public static DateTime SubtractAMinute(this DateTime date)
	{
		return date.SubtractMinutes(1);
	}

	public static DateTime SubtractHalfAnHour(this DateTime date)
	{
		return date.SubtractMinutes(30);
	}

	public static DateTime SubtractAnHour(this DateTime date)
	{
		return date.SubtractHours(1);
	}

	public static DateTime SubtractADay(this DateTime date)
	{
		return date.SubtractDays(1);
	}

	public static DateTime SubtractAWeek(this DateTime date)
	{
		return date.SubtractWeeks(1);
	}

	public static DateTime SubtractAFortnight(this DateTime date)
	{
		return date.SubtractFortnights(1);
	}

	public static DateTime SubtractAMonth(this DateTime date)
	{
		return date.SubtractMonths(1);
	}

	public static DateTime SubtractAYear(this DateTime date)
	{
		return date.SubtractYears(1);
	}

	public static DateTime SubtractADecade(this DateTime date)
	{
		return date.SubtractDecades(1);
	}

	public static DateTime SubtractACentury(this DateTime date)
	{
		return date.SubtractCenturies(1);
	}

	public static DateTime SubtractTicks(this DateTime date, int ticks)
	{
		return date.AddTicks((long)ticks.Negate());
	}

	public static DateTime SubtractMilliSeconds(this DateTime date, int milliSeconds)
	{
		return date.AddMilliseconds((double)milliSeconds.Negate());
	}

	public static DateTime SubtractSeconds(this DateTime date, int seconds)
	{
		return date.AddSeconds((double)seconds.Negate());
	}

	public static DateTime SubtractMinutes(this DateTime date, int minutes)
	{
		return date.AddMinutes((double)minutes.Negate());
	}

	public static DateTime SubtractHours(this DateTime date, int hours)
	{
		return date.AddHours((double)hours.Negate());
	}

	public static DateTime SubtractDays(this DateTime date, int days)
	{
		return date.AddDays((double)days.Negate());
	}

	public static DateTime SubtractWeeks(this DateTime date, int weeks)
	{
		return date.AddWeeks(weeks.Negate());
	}

	public static DateTime SubtractFortnights(this DateTime date, int fortnights)
	{
		return date.AddFortnights(fortnights.Negate());
	}

	public static DateTime SubtractMonths(this DateTime date, int months)
	{
		return date.AddMonths(months.Negate());
	}

	public static DateTime SubtractYears(this DateTime date, int years)
	{
		return date.AddYears(years.Negate());
	}

	public static DateTime SubtractDecades(this DateTime date, int decades)
	{
		return date.AddDecades(decades.Negate());
	}

	public static DateTime SubtractCenturies(this DateTime date, int centuries)
	{
		return date.AddCenturies(centuries.Negate());
	}

	public static long GetTicksSince(this DateTime time)
	{
		long ticks = DateTime.Now.Subtract(time).Ticks;
		return ticks.AbsoluteValue();
	}

	public static long GetMilliSecondsSince(this DateTime time)
	{
		int milliseconds = DateTime.Now.Subtract(time).Milliseconds;
		return (long)milliseconds.AbsoluteValue();
	}

	public static long GetSecondsSince(this DateTime time)
	{
		int seconds = DateTime.Now.Subtract(time).Seconds;
		return (long)seconds.AbsoluteValue();
	}

	public static long GetMinutesSince(this DateTime time)
	{
		int minutes = DateTime.Now.Subtract(time).Minutes;
		return (long)minutes.AbsoluteValue();
	}

	public static long GetHoursSince(this DateTime time)
	{
		int hours = DateTime.Now.Subtract(time).Hours;
		return (long)hours.AbsoluteValue();
	}

	public static long GetDaysSince(this DateTime time)
	{
		int days = DateTime.Now.Subtract(time).Days;
		return (long)days.AbsoluteValue();
	}

	public static long GetWeeksSince(this DateTime time)
	{
		int weeks = DateTime.Now.Subtract(time).GetWeeks();
		return (long)weeks.AbsoluteValue();
	}

	public static long GetFortnightsSince(this DateTime time)
	{
		int fortnights = DateTime.Now.Subtract(time).GetFortnights();
		return (long)fortnights.AbsoluteValue();
	}

	public static long GetMonthsSince(this DateTime time)
	{
		DateTime dateTime = DateTime.Now;
		long num = -1L;
		if (time.IsYoungerThan(dateTime))
		{
			do
			{
				num += 1L;
				dateTime = dateTime.AddMonths(1);
			}
			while (dateTime.IsOlderThan(time));
		}
		else
		{
			do
			{
				num += 1L;
				dateTime = dateTime.SubtractMonths(1);
			}
			while (dateTime.IsYoungerThan(time));
		}
		return num;
	}

	public static long GetYearsSince(this DateTime time)
	{
		DateTime dateTime = DateTime.Now;
		long num = -1L;
		if (time.IsYoungerThan(dateTime))
		{
			do
			{
				num += 1L;
				dateTime = dateTime.AddYears(1);
			}
			while (dateTime.IsOlderThan(time));
		}
		else
		{
			do
			{
				num += 1L;
				dateTime = dateTime.SubtractYears(1);
			}
			while (dateTime.IsYoungerThan(time));
		}
		return num;
	}

	public static long GetDecadesSince(this DateTime time)
	{
		long yearsSince = time.GetYearsSince();
		return (yearsSince / 10L).AbsoluteValue();
	}

	public static long GetCenturiesSince(this DateTime time)
	{
		long yearsSince = time.GetYearsSince();
		return (yearsSince / 100L).AbsoluteValue();
	}

	public static bool IsAMonday(this DateTime date)
	{
		return date.DayOfWeek == DayOfWeek.Monday;
	}

	public static bool IsATuesday(this DateTime date)
	{
		return date.DayOfWeek == DayOfWeek.Tuesday;
	}

	public static bool IsAWednesday(this DateTime date)
	{
		return date.DayOfWeek == DayOfWeek.Wednesday;
	}

	public static bool IsAThursday(this DateTime date)
	{
		return date.DayOfWeek == DayOfWeek.Thursday;
	}

	public static bool IsAFriday(this DateTime date)
	{
		return date.DayOfWeek == DayOfWeek.Friday;
	}

	public static bool IsASaturday(this DateTime date)
	{
		return date.DayOfWeek == DayOfWeek.Saturday;
	}

	public static bool IsASunday(this DateTime date)
	{
		return date.DayOfWeek == DayOfWeek.Sunday;
	}

	public static bool IsInJanuary(this DateTime date)
	{
		return date.Month.Equals(1);
	}

	public static bool IsInFebruary(this DateTime date)
	{
		return date.Month.Equals(2);
	}

	public static bool IsInMarch(this DateTime date)
	{
		return date.Month.Equals(3);
	}

	public static bool IsInApril(this DateTime date)
	{
		return date.Month.Equals(4);
	}

	public static bool IsInMay(this DateTime date)
	{
		return date.Month.Equals(5);
	}

	public static bool IsInJune(this DateTime date)
	{
		return date.Month.Equals(6);
	}

	public static bool IsInJuly(this DateTime date)
	{
		return date.Month.Equals(7);
	}

	public static bool IsInAugust(this DateTime date)
	{
		return date.Month.Equals(8);
	}

	public static bool IsInSeptember(this DateTime date)
	{
		return date.Month.Equals(9);
	}

	public static bool IsInOctober(this DateTime date)
	{
		return date.Month.Equals(10);
	}

	public static bool IsInNovember(this DateTime date)
	{
		return date.Month.Equals(11);
	}

	public static bool IsInDecember(this DateTime date)
	{
		return date.Month.Equals(12);
	}

	public static DateTime GetFirstDayOccurrenceOfTheMonth(this DateTime date, DayOfWeek day)
	{
		DateTime firstDayOfTheMonth = date.GetFirstDayOfTheMonth();
		return (firstDayOfTheMonth.DayOfWeek != day) ? firstDayOfTheMonth.GetNextDay(day) : firstDayOfTheMonth;
	}

	public static DateTime GetFirstMondayOfTheMonth(this DateTime date)
	{
		return date.GetFirstDayOccurrenceOfTheMonth(DayOfWeek.Monday);
	}

	public static DateTime GetFirstTuesdayOfTheMonth(this DateTime date)
	{
		return date.GetFirstDayOccurrenceOfTheMonth(DayOfWeek.Tuesday);
	}

	public static DateTime GetFirstWednesdayOfTheMonth(this DateTime date)
	{
		return date.GetFirstDayOccurrenceOfTheMonth(DayOfWeek.Wednesday);
	}

	public static DateTime GetFirstThursdayOfTheMonth(this DateTime date)
	{
		return date.GetFirstDayOccurrenceOfTheMonth(DayOfWeek.Thursday);
	}

	public static DateTime GetFirstFridayOfTheMonth(this DateTime date)
	{
		return date.GetFirstDayOccurrenceOfTheMonth(DayOfWeek.Friday);
	}

	public static DateTime GetFirstSaturdayOfTheMonth(this DateTime date)
	{
		return date.GetFirstDayOccurrenceOfTheMonth(DayOfWeek.Saturday);
	}

	public static DateTime GetFirstSundayOfTheMonth(this DateTime date)
	{
		return date.GetFirstDayOccurrenceOfTheMonth(DayOfWeek.Sunday);
	}

	public static DateTime GetFirstDayOfTheMonth(this DateTime date)
	{
		return new DateTime(date.Year, date.Month, 1);
	}

	public static DateTime GetLastDayOfTheMonth(this DateTime date)
	{
		return date.GetFirstDayOfTheMonth().AddAMonth().SubtractADay();
	}

	public static DateTime GetLastDayOccurrenceOfTheMonth(this DateTime date, DayOfWeek day)
	{
		DateTime lastDayOfTheMonth = date.GetLastDayOfTheMonth();
		return (lastDayOfTheMonth.DayOfWeek != day) ? lastDayOfTheMonth.GetPreviousDay(day) : lastDayOfTheMonth;
	}

	public static DateTime GetLastMondayOfTheMonth(this DateTime date)
	{
		return date.GetLastDayOccurrenceOfTheMonth(DayOfWeek.Monday);
	}

	public static DateTime GetLastTuesdayOfTheMonth(this DateTime date)
	{
		return date.GetLastDayOccurrenceOfTheMonth(DayOfWeek.Tuesday);
	}

	public static DateTime GetLastWednesdayOfTheMonth(this DateTime date)
	{
		return date.GetLastDayOccurrenceOfTheMonth(DayOfWeek.Wednesday);
	}

	public static DateTime GetLastThursdayOfTheMonth(this DateTime date)
	{
		return date.GetLastDayOccurrenceOfTheMonth(DayOfWeek.Thursday);
	}

	public static DateTime GetLastFridayOfTheMonth(this DateTime date)
	{
		return date.GetLastDayOccurrenceOfTheMonth(DayOfWeek.Friday);
	}

	public static DateTime GetLastSaturdayOfTheMonth(this DateTime date)
	{
		return date.GetLastDayOccurrenceOfTheMonth(DayOfWeek.Saturday);
	}

	public static DateTime GetLastSundayOfTheMonth(this DateTime date)
	{
		return date.GetLastDayOccurrenceOfTheMonth(DayOfWeek.Sunday);
	}

	public static DateTime GetFirstDayOccurrenceOfTheYear(this DateTime date, DayOfWeek day)
	{
		DateTime firstDayOfTheYear = date.GetFirstDayOfTheYear();
		return (firstDayOfTheYear.DayOfWeek != day) ? firstDayOfTheYear.GetNextDay(day) : firstDayOfTheYear;
	}

	public static DateTime GetFirstMondayOfTheYear(this DateTime date)
	{
		return date.GetFirstDayOccurrenceOfTheYear(DayOfWeek.Monday);
	}

	public static DateTime GetFirstTuesdayOfTheYear(this DateTime date)
	{
		return date.GetFirstDayOccurrenceOfTheYear(DayOfWeek.Tuesday);
	}

	public static DateTime GetFirstWednesdayOfTheYear(this DateTime date)
	{
		return date.GetFirstDayOccurrenceOfTheYear(DayOfWeek.Wednesday);
	}

	public static DateTime GetFirstThursdayOfTheYear(this DateTime date)
	{
		return date.GetFirstDayOccurrenceOfTheYear(DayOfWeek.Thursday);
	}

	public static DateTime GetFirstFridayOfTheYear(this DateTime date)
	{
		return date.GetFirstDayOccurrenceOfTheYear(DayOfWeek.Friday);
	}

	public static DateTime GetFirstSaturdayOfTheYear(this DateTime date)
	{
		return date.GetFirstDayOccurrenceOfTheYear(DayOfWeek.Saturday);
	}

	public static DateTime GetFirstSundayOfTheYear(this DateTime date)
	{
		return date.GetFirstDayOccurrenceOfTheYear(DayOfWeek.Sunday);
	}

	public static DateTime GetFirstDayOfTheYear(this DateTime date)
	{
		return new DateTime(date.Year, 1, 1);
	}

	public static DateTime GetLastDayOfTheYear(this DateTime date)
	{
		return new DateTime(date.Year, 12, 31);
	}

	public static DateTime GetLastDayOccurrenceOfTheYear(this DateTime date, DayOfWeek day)
	{
		DateTime lastDayOfTheYear = date.GetLastDayOfTheYear();
		return (lastDayOfTheYear.DayOfWeek != day) ? lastDayOfTheYear.GetPreviousDay(day) : lastDayOfTheYear;
	}

	public static DateTime GetLastMondayOfTheYear(this DateTime date)
	{
		return date.GetLastDayOccurrenceOfTheYear(DayOfWeek.Monday);
	}

	public static DateTime GetLastTuesdayOfTheYear(this DateTime date)
	{
		return date.GetLastDayOccurrenceOfTheYear(DayOfWeek.Tuesday);
	}

	public static DateTime GetLastWednesdayOfTheYear(this DateTime date)
	{
		return date.GetLastDayOccurrenceOfTheYear(DayOfWeek.Wednesday);
	}

	public static DateTime GetLastThursdayOfTheYear(this DateTime date)
	{
		return date.GetLastDayOccurrenceOfTheYear(DayOfWeek.Thursday);
	}

	public static DateTime GetLastFridayOfTheYear(this DateTime date)
	{
		return date.GetLastDayOccurrenceOfTheYear(DayOfWeek.Friday);
	}

	public static DateTime GetLastSaturdayOfTheYear(this DateTime date)
	{
		return date.GetLastDayOccurrenceOfTheYear(DayOfWeek.Saturday);
	}

	public static DateTime GetLastSundayOfTheYear(this DateTime date)
	{
		return date.GetLastDayOccurrenceOfTheYear(DayOfWeek.Sunday);
	}

	public static DateTime GetNextMonday(this DateTime date)
	{
		return date.GetNextDay(DayOfWeek.Monday);
	}

	public static DateTime GetNextTuesday(this DateTime date)
	{
		return date.GetNextDay(DayOfWeek.Tuesday);
	}

	public static DateTime GetNextWednesday(this DateTime date)
	{
		return date.GetNextDay(DayOfWeek.Wednesday);
	}

	public static DateTime GetNextThursday(this DateTime date)
	{
		return date.GetNextDay(DayOfWeek.Thursday);
	}

	public static DateTime GetNextFriday(this DateTime date)
	{
		return date.GetNextDay(DayOfWeek.Friday);
	}

	public static DateTime GetNextSaturday(this DateTime date)
	{
		return date.GetNextDay(DayOfWeek.Saturday);
	}

	public static DateTime GetNextSunday(this DateTime date)
	{
		return date.GetNextDay(DayOfWeek.Sunday);
	}

	public static DateTime GetNextDay(this DateTime date, DayOfWeek day)
	{
		DateTime dateTime = date.AddADay();
		while (dateTime.DayOfWeek != day)
		{
			dateTime = dateTime.AddADay();
		}
		return dateTime;
	}

	public static DateTime GetPreviousMonday(this DateTime date)
	{
		return date.GetPreviousDay(DayOfWeek.Monday);
	}

	public static DateTime GetPreviousTuesday(this DateTime date)
	{
		return date.GetPreviousDay(DayOfWeek.Tuesday);
	}

	public static DateTime GetPreviousWednesday(this DateTime date)
	{
		return date.GetPreviousDay(DayOfWeek.Wednesday);
	}

	public static DateTime GetPreviousThursday(this DateTime date)
	{
		return date.GetPreviousDay(DayOfWeek.Thursday);
	}

	public static DateTime GetPreviousFriday(this DateTime date)
	{
		return date.GetPreviousDay(DayOfWeek.Friday);
	}

	public static DateTime GetPreviousSaturday(this DateTime date)
	{
		return date.GetPreviousDay(DayOfWeek.Saturday);
	}

	public static DateTime GetPreviousSunday(this DateTime date)
	{
		return date.GetPreviousDay(DayOfWeek.Sunday);
	}

	public static DateTime GetPreviousDay(this DateTime date, DayOfWeek day)
	{
		DateTime dateTime = date.SubtractADay();
		while (dateTime.DayOfWeek != day)
		{
			dateTime = dateTime.SubtractADay();
		}
		return dateTime;
	}

	public static string GetDayString(this DateTime date)
	{
		return date.DayOfWeek.ToString();
	}

	public static string GetMonthString(this DateTime date)
	{
		return date.ToString("MMMM");
	}

	public static string ToDdMmYySlash(this DateTime date)
	{
		return date.ToString("dd/MM/yy");
	}

	public static string ToDdMmYyDot(this DateTime date)
	{
		return date.ToString("dd.MM.yy");
	}

	public static string ToDdMmYyHyphen(this DateTime date)
	{
		return date.ToString("dd-MM-yy");
	}

	public static string ToDdMmYyWithSep(this DateTime date, string separator)
	{
		return date.ToString(string.Format("dd{0}MM{0}yy", separator));
	}

	public static string ToDdMmYyyySlash(this DateTime date)
	{
		return date.ToString("dd/MM/yyyy");
	}

	public static string ToDdMmYyyyDot(this DateTime date)
	{
		return date.ToString("dd.MM.yyyy");
	}

	public static string ToDdMmYyyyHyphen(this DateTime date)
	{
		return date.ToString("dd-MM-yyyy");
	}

	public static string ToDdMmYyyyWithSep(this DateTime date, string separator)
	{
		return date.ToString(string.Format("dd{0}MM{0}yyyy", separator));
	}

	public static string ToMmDdYySlash(this DateTime date)
	{
		return date.ToString("MM/dd/yy");
	}

	public static string ToMmDdYyDot(this DateTime date)
	{
		return date.ToString("MM.dd.yy");
	}

	public static string ToMmDdYyHyphen(this DateTime date)
	{
		return date.ToString("MM-dd-yy");
	}

	public static string ToMmDdYyWithSep(this DateTime date, string separator)
	{
		return date.ToString(string.Format("MM{0}dd{0}yy", separator));
	}

	public static string ToMmDdYyyySlash(this DateTime date)
	{
		return date.ToString("MM/dd/yyyy");
	}

	public static string ToMmDdYyyyDot(this DateTime date)
	{
		return date.ToString("MM.dd.yyyy");
	}

	public static string ToMmDdYyyyHyphen(this DateTime date)
	{
		return date.ToString("MM-dd-yyyy");
	}

	public static string ToMmDdYyyyWithSep(this DateTime date, string separator)
	{
		return date.ToString(string.Format("MM{0}dd{0}yyyy", separator));
	}

	public static string ToYyMmDdSlash(this DateTime date)
	{
		return date.ToString("yy/MM/dd");
	}

	public static string ToYyMmDdDot(this DateTime date)
	{
		return date.ToString("yy.MM.dd");
	}

	public static string ToYyMmDdHyphen(this DateTime date)
	{
		return date.ToString("yy-MM-dd");
	}

	public static string ToYyMmDdWithSep(this DateTime date, string separator)
	{
		return date.ToString(string.Format("yy{0}MM{0}dd", separator));
	}

	public static string ToYyyyMmDdSlash(this DateTime date)
	{
		return date.ToString("yyyy/MM/dd");
	}

	public static string ToYyyyMmDdDot(this DateTime date)
	{
		return date.ToString("yyyy.MM.dd");
	}

	public static string ToYyyyMmDdHyphen(this DateTime date)
	{
		return date.ToString("yyyy-MM-dd");
	}

	public static string ToYyyyMmDdWithSep(this DateTime date, string separator)
	{
		return date.ToString(string.Format("yyyy{0}MM{0}dd", separator));
	}
}
