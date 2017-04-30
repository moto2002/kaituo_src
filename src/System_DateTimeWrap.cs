using LuaInterface;
using System;
using System.Globalization;

public class System_DateTimeWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(DateTime), null, null);
		L.RegFunction("Add", new LuaCSFunction(System_DateTimeWrap.Add));
		L.RegFunction("AddDays", new LuaCSFunction(System_DateTimeWrap.AddDays));
		L.RegFunction("AddTicks", new LuaCSFunction(System_DateTimeWrap.AddTicks));
		L.RegFunction("AddHours", new LuaCSFunction(System_DateTimeWrap.AddHours));
		L.RegFunction("AddMilliseconds", new LuaCSFunction(System_DateTimeWrap.AddMilliseconds));
		L.RegFunction("AddMinutes", new LuaCSFunction(System_DateTimeWrap.AddMinutes));
		L.RegFunction("AddMonths", new LuaCSFunction(System_DateTimeWrap.AddMonths));
		L.RegFunction("AddSeconds", new LuaCSFunction(System_DateTimeWrap.AddSeconds));
		L.RegFunction("AddYears", new LuaCSFunction(System_DateTimeWrap.AddYears));
		L.RegFunction("Compare", new LuaCSFunction(System_DateTimeWrap.Compare));
		L.RegFunction("CompareTo", new LuaCSFunction(System_DateTimeWrap.CompareTo));
		L.RegFunction("IsDaylightSavingTime", new LuaCSFunction(System_DateTimeWrap.IsDaylightSavingTime));
		L.RegFunction("Equals", new LuaCSFunction(System_DateTimeWrap.Equals));
		L.RegFunction("ToBinary", new LuaCSFunction(System_DateTimeWrap.ToBinary));
		L.RegFunction("FromBinary", new LuaCSFunction(System_DateTimeWrap.FromBinary));
		L.RegFunction("SpecifyKind", new LuaCSFunction(System_DateTimeWrap.SpecifyKind));
		L.RegFunction("DaysInMonth", new LuaCSFunction(System_DateTimeWrap.DaysInMonth));
		L.RegFunction("FromFileTime", new LuaCSFunction(System_DateTimeWrap.FromFileTime));
		L.RegFunction("FromFileTimeUtc", new LuaCSFunction(System_DateTimeWrap.FromFileTimeUtc));
		L.RegFunction("FromOADate", new LuaCSFunction(System_DateTimeWrap.FromOADate));
		L.RegFunction("GetDateTimeFormats", new LuaCSFunction(System_DateTimeWrap.GetDateTimeFormats));
		L.RegFunction("GetHashCode", new LuaCSFunction(System_DateTimeWrap.GetHashCode));
		L.RegFunction("GetTypeCode", new LuaCSFunction(System_DateTimeWrap.GetTypeCode));
		L.RegFunction("IsLeapYear", new LuaCSFunction(System_DateTimeWrap.IsLeapYear));
		L.RegFunction("Parse", new LuaCSFunction(System_DateTimeWrap.Parse));
		L.RegFunction("ParseExact", new LuaCSFunction(System_DateTimeWrap.ParseExact));
		L.RegFunction("TryParse", new LuaCSFunction(System_DateTimeWrap.TryParse));
		L.RegFunction("TryParseExact", new LuaCSFunction(System_DateTimeWrap.TryParseExact));
		L.RegFunction("Subtract", new LuaCSFunction(System_DateTimeWrap.Subtract));
		L.RegFunction("ToFileTime", new LuaCSFunction(System_DateTimeWrap.ToFileTime));
		L.RegFunction("ToFileTimeUtc", new LuaCSFunction(System_DateTimeWrap.ToFileTimeUtc));
		L.RegFunction("ToLongDateString", new LuaCSFunction(System_DateTimeWrap.ToLongDateString));
		L.RegFunction("ToLongTimeString", new LuaCSFunction(System_DateTimeWrap.ToLongTimeString));
		L.RegFunction("ToOADate", new LuaCSFunction(System_DateTimeWrap.ToOADate));
		L.RegFunction("ToShortDateString", new LuaCSFunction(System_DateTimeWrap.ToShortDateString));
		L.RegFunction("ToShortTimeString", new LuaCSFunction(System_DateTimeWrap.ToShortTimeString));
		L.RegFunction("ToString", new LuaCSFunction(System_DateTimeWrap.ToString));
		L.RegFunction("ToLocalTime", new LuaCSFunction(System_DateTimeWrap.ToLocalTime));
		L.RegFunction("ToUniversalTime", new LuaCSFunction(System_DateTimeWrap.ToUniversalTime));
		L.RegFunction("New", new LuaCSFunction(System_DateTimeWrap._CreateSystem_DateTime));
		L.RegFunction("__add", new LuaCSFunction(System_DateTimeWrap.op_Addition));
		L.RegFunction("__sub", new LuaCSFunction(System_DateTimeWrap.op_Subtraction));
		L.RegFunction("__eq", new LuaCSFunction(System_DateTimeWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("MaxValue", new LuaCSFunction(System_DateTimeWrap.get_MaxValue), null);
		L.RegVar("MinValue", new LuaCSFunction(System_DateTimeWrap.get_MinValue), null);
		L.RegVar("Date", new LuaCSFunction(System_DateTimeWrap.get_Date), null);
		L.RegVar("Month", new LuaCSFunction(System_DateTimeWrap.get_Month), null);
		L.RegVar("Day", new LuaCSFunction(System_DateTimeWrap.get_Day), null);
		L.RegVar("DayOfWeek", new LuaCSFunction(System_DateTimeWrap.get_DayOfWeek), null);
		L.RegVar("DayOfYear", new LuaCSFunction(System_DateTimeWrap.get_DayOfYear), null);
		L.RegVar("TimeOfDay", new LuaCSFunction(System_DateTimeWrap.get_TimeOfDay), null);
		L.RegVar("Hour", new LuaCSFunction(System_DateTimeWrap.get_Hour), null);
		L.RegVar("Minute", new LuaCSFunction(System_DateTimeWrap.get_Minute), null);
		L.RegVar("Second", new LuaCSFunction(System_DateTimeWrap.get_Second), null);
		L.RegVar("Millisecond", new LuaCSFunction(System_DateTimeWrap.get_Millisecond), null);
		L.RegVar("Now", new LuaCSFunction(System_DateTimeWrap.get_Now), null);
		L.RegVar("Ticks", new LuaCSFunction(System_DateTimeWrap.get_Ticks), null);
		L.RegVar("Today", new LuaCSFunction(System_DateTimeWrap.get_Today), null);
		L.RegVar("UtcNow", new LuaCSFunction(System_DateTimeWrap.get_UtcNow), null);
		L.RegVar("Year", new LuaCSFunction(System_DateTimeWrap.get_Year), null);
		L.RegVar("Kind", new LuaCSFunction(System_DateTimeWrap.get_Kind), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateSystem_DateTime(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1)
			{
				long ticks = LuaDLL.tolua_checkint64(L, 1);
				DateTime dateTime = new DateTime(ticks);
				ToLua.PushValue(L, dateTime);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(long), typeof(uint)))
			{
				long ticks2 = LuaDLL.tolua_checkint64(L, 1);
				DateTimeKind kind = (DateTimeKind)LuaDLL.luaL_checknumber(L, 2);
				DateTime dateTime2 = new DateTime(ticks2, kind);
				ToLua.PushValue(L, dateTime2);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(int), typeof(int)))
			{
				int year = (int)LuaDLL.luaL_checknumber(L, 1);
				int month = (int)LuaDLL.luaL_checknumber(L, 2);
				int day = (int)LuaDLL.luaL_checknumber(L, 3);
				DateTime dateTime3 = new DateTime(year, month, day);
				ToLua.PushValue(L, dateTime3);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(int), typeof(int), typeof(Calendar)))
			{
				int year2 = (int)LuaDLL.luaL_checknumber(L, 1);
				int month2 = (int)LuaDLL.luaL_checknumber(L, 2);
				int day2 = (int)LuaDLL.luaL_checknumber(L, 3);
				Calendar calendar = (Calendar)ToLua.CheckObject(L, 4, typeof(Calendar));
				DateTime dateTime4 = new DateTime(year2, month2, day2, calendar);
				ToLua.PushValue(L, dateTime4);
				result = 1;
			}
			else if (num == 6 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(int), typeof(int), typeof(int), typeof(int), typeof(int)))
			{
				int year3 = (int)LuaDLL.luaL_checknumber(L, 1);
				int month3 = (int)LuaDLL.luaL_checknumber(L, 2);
				int day3 = (int)LuaDLL.luaL_checknumber(L, 3);
				int hour = (int)LuaDLL.luaL_checknumber(L, 4);
				int minute = (int)LuaDLL.luaL_checknumber(L, 5);
				int second = (int)LuaDLL.luaL_checknumber(L, 6);
				DateTime dateTime5 = new DateTime(year3, month3, day3, hour, minute, second);
				ToLua.PushValue(L, dateTime5);
				result = 1;
			}
			else if (num == 7 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(int), typeof(int), typeof(int), typeof(int), typeof(int), typeof(uint)))
			{
				int year4 = (int)LuaDLL.luaL_checknumber(L, 1);
				int month4 = (int)LuaDLL.luaL_checknumber(L, 2);
				int day4 = (int)LuaDLL.luaL_checknumber(L, 3);
				int hour2 = (int)LuaDLL.luaL_checknumber(L, 4);
				int minute2 = (int)LuaDLL.luaL_checknumber(L, 5);
				int second2 = (int)LuaDLL.luaL_checknumber(L, 6);
				DateTimeKind kind2 = (DateTimeKind)LuaDLL.luaL_checknumber(L, 7);
				DateTime dateTime6 = new DateTime(year4, month4, day4, hour2, minute2, second2, kind2);
				ToLua.PushValue(L, dateTime6);
				result = 1;
			}
			else if (num == 7 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(int), typeof(int), typeof(int), typeof(int), typeof(int), typeof(int)))
			{
				int year5 = (int)LuaDLL.luaL_checknumber(L, 1);
				int month5 = (int)LuaDLL.luaL_checknumber(L, 2);
				int day5 = (int)LuaDLL.luaL_checknumber(L, 3);
				int hour3 = (int)LuaDLL.luaL_checknumber(L, 4);
				int minute3 = (int)LuaDLL.luaL_checknumber(L, 5);
				int second3 = (int)LuaDLL.luaL_checknumber(L, 6);
				int millisecond = (int)LuaDLL.luaL_checknumber(L, 7);
				DateTime dateTime7 = new DateTime(year5, month5, day5, hour3, minute3, second3, millisecond);
				ToLua.PushValue(L, dateTime7);
				result = 1;
			}
			else if (num == 7 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(int), typeof(int), typeof(int), typeof(int), typeof(int), typeof(Calendar)))
			{
				int year6 = (int)LuaDLL.luaL_checknumber(L, 1);
				int month6 = (int)LuaDLL.luaL_checknumber(L, 2);
				int day6 = (int)LuaDLL.luaL_checknumber(L, 3);
				int hour4 = (int)LuaDLL.luaL_checknumber(L, 4);
				int minute4 = (int)LuaDLL.luaL_checknumber(L, 5);
				int second4 = (int)LuaDLL.luaL_checknumber(L, 6);
				Calendar calendar2 = (Calendar)ToLua.CheckObject(L, 7, typeof(Calendar));
				DateTime dateTime8 = new DateTime(year6, month6, day6, hour4, minute4, second4, calendar2);
				ToLua.PushValue(L, dateTime8);
				result = 1;
			}
			else if (num == 8 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(int), typeof(int), typeof(int), typeof(int), typeof(int), typeof(int), typeof(uint)))
			{
				int year7 = (int)LuaDLL.luaL_checknumber(L, 1);
				int month7 = (int)LuaDLL.luaL_checknumber(L, 2);
				int day7 = (int)LuaDLL.luaL_checknumber(L, 3);
				int hour5 = (int)LuaDLL.luaL_checknumber(L, 4);
				int minute5 = (int)LuaDLL.luaL_checknumber(L, 5);
				int second5 = (int)LuaDLL.luaL_checknumber(L, 6);
				int millisecond2 = (int)LuaDLL.luaL_checknumber(L, 7);
				DateTimeKind kind3 = (DateTimeKind)LuaDLL.luaL_checknumber(L, 8);
				DateTime dateTime9 = new DateTime(year7, month7, day7, hour5, minute5, second5, millisecond2, kind3);
				ToLua.PushValue(L, dateTime9);
				result = 1;
			}
			else if (num == 8 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(int), typeof(int), typeof(int), typeof(int), typeof(int), typeof(int), typeof(Calendar)))
			{
				int year8 = (int)LuaDLL.luaL_checknumber(L, 1);
				int month8 = (int)LuaDLL.luaL_checknumber(L, 2);
				int day8 = (int)LuaDLL.luaL_checknumber(L, 3);
				int hour6 = (int)LuaDLL.luaL_checknumber(L, 4);
				int minute6 = (int)LuaDLL.luaL_checknumber(L, 5);
				int second6 = (int)LuaDLL.luaL_checknumber(L, 6);
				int millisecond3 = (int)LuaDLL.luaL_checknumber(L, 7);
				Calendar calendar3 = (Calendar)ToLua.CheckObject(L, 8, typeof(Calendar));
				DateTime dateTime10 = new DateTime(year8, month8, day8, hour6, minute6, second6, millisecond3, calendar3);
				ToLua.PushValue(L, dateTime10);
				result = 1;
			}
			else if (num == 9 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(int), typeof(int), typeof(int), typeof(int), typeof(int), typeof(int), typeof(Calendar), typeof(uint)))
			{
				int year9 = (int)LuaDLL.luaL_checknumber(L, 1);
				int month9 = (int)LuaDLL.luaL_checknumber(L, 2);
				int day9 = (int)LuaDLL.luaL_checknumber(L, 3);
				int hour7 = (int)LuaDLL.luaL_checknumber(L, 4);
				int minute7 = (int)LuaDLL.luaL_checknumber(L, 5);
				int second7 = (int)LuaDLL.luaL_checknumber(L, 6);
				int millisecond4 = (int)LuaDLL.luaL_checknumber(L, 7);
				Calendar calendar4 = (Calendar)ToLua.CheckObject(L, 8, typeof(Calendar));
				DateTimeKind kind4 = (DateTimeKind)LuaDLL.luaL_checknumber(L, 9);
				DateTime dateTime11 = new DateTime(year9, month9, day9, hour7, minute7, second7, millisecond4, calendar4, kind4);
				ToLua.PushValue(L, dateTime11);
				result = 1;
			}
			else if (num == 0)
			{
				ToLua.PushValue(L, default(DateTime));
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: System.DateTime.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Add(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			DateTime dateTime = (DateTime)ToLua.CheckObject(L, 1, typeof(DateTime));
			TimeSpan value = (TimeSpan)ToLua.CheckObject(L, 2, typeof(TimeSpan));
			DateTime dateTime2 = dateTime.Add(value);
			ToLua.PushValue(L, dateTime2);
			ToLua.SetBack(L, 1, dateTime);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddDays(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			DateTime dateTime = (DateTime)ToLua.CheckObject(L, 1, typeof(DateTime));
			double value = LuaDLL.luaL_checknumber(L, 2);
			DateTime dateTime2 = dateTime.AddDays(value);
			ToLua.PushValue(L, dateTime2);
			ToLua.SetBack(L, 1, dateTime);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddTicks(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			DateTime dateTime = (DateTime)ToLua.CheckObject(L, 1, typeof(DateTime));
			long value = LuaDLL.tolua_checkint64(L, 2);
			DateTime dateTime2 = dateTime.AddTicks(value);
			ToLua.PushValue(L, dateTime2);
			ToLua.SetBack(L, 1, dateTime);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddHours(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			DateTime dateTime = (DateTime)ToLua.CheckObject(L, 1, typeof(DateTime));
			double value = LuaDLL.luaL_checknumber(L, 2);
			DateTime dateTime2 = dateTime.AddHours(value);
			ToLua.PushValue(L, dateTime2);
			ToLua.SetBack(L, 1, dateTime);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddMilliseconds(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			DateTime dateTime = (DateTime)ToLua.CheckObject(L, 1, typeof(DateTime));
			double value = LuaDLL.luaL_checknumber(L, 2);
			DateTime dateTime2 = dateTime.AddMilliseconds(value);
			ToLua.PushValue(L, dateTime2);
			ToLua.SetBack(L, 1, dateTime);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddMinutes(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			DateTime dateTime = (DateTime)ToLua.CheckObject(L, 1, typeof(DateTime));
			double value = LuaDLL.luaL_checknumber(L, 2);
			DateTime dateTime2 = dateTime.AddMinutes(value);
			ToLua.PushValue(L, dateTime2);
			ToLua.SetBack(L, 1, dateTime);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddMonths(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			DateTime dateTime = (DateTime)ToLua.CheckObject(L, 1, typeof(DateTime));
			int months = (int)LuaDLL.luaL_checknumber(L, 2);
			DateTime dateTime2 = dateTime.AddMonths(months);
			ToLua.PushValue(L, dateTime2);
			ToLua.SetBack(L, 1, dateTime);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddSeconds(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			DateTime dateTime = (DateTime)ToLua.CheckObject(L, 1, typeof(DateTime));
			double value = LuaDLL.luaL_checknumber(L, 2);
			DateTime dateTime2 = dateTime.AddSeconds(value);
			ToLua.PushValue(L, dateTime2);
			ToLua.SetBack(L, 1, dateTime);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddYears(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			DateTime dateTime = (DateTime)ToLua.CheckObject(L, 1, typeof(DateTime));
			int value = (int)LuaDLL.luaL_checknumber(L, 2);
			DateTime dateTime2 = dateTime.AddYears(value);
			ToLua.PushValue(L, dateTime2);
			ToLua.SetBack(L, 1, dateTime);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Compare(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			DateTime t = (DateTime)ToLua.CheckObject(L, 1, typeof(DateTime));
			DateTime t2 = (DateTime)ToLua.CheckObject(L, 2, typeof(DateTime));
			int n = DateTime.Compare(t, t2);
			LuaDLL.lua_pushinteger(L, n);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CompareTo(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(DateTime), typeof(DateTime)))
			{
				DateTime dateTime = (DateTime)ToLua.ToObject(L, 1);
				DateTime value = (DateTime)ToLua.ToObject(L, 2);
				int n = dateTime.CompareTo(value);
				LuaDLL.lua_pushinteger(L, n);
				ToLua.SetBack(L, 1, dateTime);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(DateTime), typeof(object)))
			{
				DateTime dateTime2 = (DateTime)ToLua.ToObject(L, 1);
				object value2 = ToLua.ToVarObject(L, 2);
				int n2 = dateTime2.CompareTo(value2);
				LuaDLL.lua_pushinteger(L, n2);
				ToLua.SetBack(L, 1, dateTime2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.DateTime.CompareTo");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsDaylightSavingTime(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			DateTime dateTime = (DateTime)ToLua.CheckObject(L, 1, typeof(DateTime));
			bool value = dateTime.IsDaylightSavingTime();
			LuaDLL.lua_pushboolean(L, value);
			ToLua.SetBack(L, 1, dateTime);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Equals(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(DateTime), typeof(DateTime)))
			{
				DateTime dateTime = (DateTime)ToLua.ToObject(L, 1);
				DateTime value = (DateTime)ToLua.ToObject(L, 2);
				bool value2 = dateTime.Equals(value);
				LuaDLL.lua_pushboolean(L, value2);
				ToLua.SetBack(L, 1, dateTime);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(DateTime), typeof(object)))
			{
				DateTime dateTime2 = (DateTime)ToLua.ToObject(L, 1);
				object value3 = ToLua.ToVarObject(L, 2);
				bool value4 = dateTime2.Equals(value3);
				LuaDLL.lua_pushboolean(L, value4);
				ToLua.SetBack(L, 1, dateTime2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.DateTime.Equals");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ToBinary(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			DateTime dateTime = (DateTime)ToLua.CheckObject(L, 1, typeof(DateTime));
			long n = dateTime.ToBinary();
			LuaDLL.tolua_pushint64(L, n);
			ToLua.SetBack(L, 1, dateTime);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FromBinary(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			long dateData = LuaDLL.tolua_checkint64(L, 1);
			DateTime dateTime = DateTime.FromBinary(dateData);
			ToLua.PushValue(L, dateTime);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SpecifyKind(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			DateTime value = (DateTime)ToLua.CheckObject(L, 1, typeof(DateTime));
			DateTimeKind kind = (DateTimeKind)LuaDLL.luaL_checknumber(L, 2);
			DateTime dateTime = DateTime.SpecifyKind(value, kind);
			ToLua.PushValue(L, dateTime);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DaysInMonth(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			int year = (int)LuaDLL.luaL_checknumber(L, 1);
			int month = (int)LuaDLL.luaL_checknumber(L, 2);
			int n = DateTime.DaysInMonth(year, month);
			LuaDLL.lua_pushinteger(L, n);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FromFileTime(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			long fileTime = LuaDLL.tolua_checkint64(L, 1);
			DateTime dateTime = DateTime.FromFileTime(fileTime);
			ToLua.PushValue(L, dateTime);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FromFileTimeUtc(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			long fileTime = LuaDLL.tolua_checkint64(L, 1);
			DateTime dateTime = DateTime.FromFileTimeUtc(fileTime);
			ToLua.PushValue(L, dateTime);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FromOADate(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			double d = LuaDLL.luaL_checknumber(L, 1);
			DateTime dateTime = DateTime.FromOADate(d);
			ToLua.PushValue(L, dateTime);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetDateTimeFormats(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(DateTime)))
			{
				DateTime dateTime = (DateTime)ToLua.ToObject(L, 1);
				string[] dateTimeFormats = dateTime.GetDateTimeFormats();
				ToLua.Push(L, dateTimeFormats);
				ToLua.SetBack(L, 1, dateTime);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(DateTime), typeof(IFormatProvider)))
			{
				DateTime dateTime2 = (DateTime)ToLua.ToObject(L, 1);
				IFormatProvider provider = (IFormatProvider)ToLua.ToObject(L, 2);
				string[] dateTimeFormats2 = dateTime2.GetDateTimeFormats(provider);
				ToLua.Push(L, dateTimeFormats2);
				ToLua.SetBack(L, 1, dateTime2);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(DateTime), typeof(char)))
			{
				DateTime dateTime3 = (DateTime)ToLua.ToObject(L, 1);
				char format = (char)LuaDLL.lua_tonumber(L, 2);
				string[] dateTimeFormats3 = dateTime3.GetDateTimeFormats(format);
				ToLua.Push(L, dateTimeFormats3);
				ToLua.SetBack(L, 1, dateTime3);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(DateTime), typeof(char), typeof(IFormatProvider)))
			{
				DateTime dateTime4 = (DateTime)ToLua.ToObject(L, 1);
				char format2 = (char)LuaDLL.lua_tonumber(L, 2);
				IFormatProvider provider2 = (IFormatProvider)ToLua.ToObject(L, 3);
				string[] dateTimeFormats4 = dateTime4.GetDateTimeFormats(format2, provider2);
				ToLua.Push(L, dateTimeFormats4);
				ToLua.SetBack(L, 1, dateTime4);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.DateTime.GetDateTimeFormats");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetHashCode(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			DateTime dateTime = (DateTime)ToLua.CheckObject(L, 1, typeof(DateTime));
			int hashCode = dateTime.GetHashCode();
			LuaDLL.lua_pushinteger(L, hashCode);
			ToLua.SetBack(L, 1, dateTime);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetTypeCode(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			DateTime dateTime = (DateTime)ToLua.CheckObject(L, 1, typeof(DateTime));
			TypeCode typeCode = dateTime.GetTypeCode();
			ToLua.Push(L, typeCode);
			ToLua.SetBack(L, 1, dateTime);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsLeapYear(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			int year = (int)LuaDLL.luaL_checknumber(L, 1);
			bool value = DateTime.IsLeapYear(year);
			LuaDLL.lua_pushboolean(L, value);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Parse(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(string)))
			{
				string s = ToLua.ToString(L, 1);
				DateTime dateTime = DateTime.Parse(s);
				ToLua.PushValue(L, dateTime);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(IFormatProvider)))
			{
				string s2 = ToLua.ToString(L, 1);
				IFormatProvider provider = (IFormatProvider)ToLua.ToObject(L, 2);
				DateTime dateTime2 = DateTime.Parse(s2, provider);
				ToLua.PushValue(L, dateTime2);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(IFormatProvider), typeof(uint)))
			{
				string s3 = ToLua.ToString(L, 1);
				IFormatProvider provider2 = (IFormatProvider)ToLua.ToObject(L, 2);
				DateTimeStyles styles = (DateTimeStyles)LuaDLL.lua_tonumber(L, 3);
				DateTime dateTime3 = DateTime.Parse(s3, provider2, styles);
				ToLua.PushValue(L, dateTime3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.DateTime.Parse");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ParseExact(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string), typeof(IFormatProvider)))
			{
				string s = ToLua.ToString(L, 1);
				string format = ToLua.ToString(L, 2);
				IFormatProvider provider = (IFormatProvider)ToLua.ToObject(L, 3);
				DateTime dateTime = DateTime.ParseExact(s, format, provider);
				ToLua.PushValue(L, dateTime);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string[]), typeof(IFormatProvider), typeof(uint)))
			{
				string s2 = ToLua.ToString(L, 1);
				string[] formats = ToLua.CheckStringArray(L, 2);
				IFormatProvider provider2 = (IFormatProvider)ToLua.ToObject(L, 3);
				DateTimeStyles style = (DateTimeStyles)LuaDLL.lua_tonumber(L, 4);
				DateTime dateTime2 = DateTime.ParseExact(s2, formats, provider2, style);
				ToLua.PushValue(L, dateTime2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string), typeof(IFormatProvider), typeof(uint)))
			{
				string s3 = ToLua.ToString(L, 1);
				string format2 = ToLua.ToString(L, 2);
				IFormatProvider provider3 = (IFormatProvider)ToLua.ToObject(L, 3);
				DateTimeStyles style2 = (DateTimeStyles)LuaDLL.lua_tonumber(L, 4);
				DateTime dateTime3 = DateTime.ParseExact(s3, format2, provider3, style2);
				ToLua.PushValue(L, dateTime3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.DateTime.ParseExact");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TryParse(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(LuaOut<DateTime>)))
			{
				string s = ToLua.ToString(L, 1);
				DateTime dateTime;
				bool value = DateTime.TryParse(s, out dateTime);
				LuaDLL.lua_pushboolean(L, value);
				ToLua.PushValue(L, dateTime);
				result = 2;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(IFormatProvider), typeof(uint), typeof(LuaOut<DateTime>)))
			{
				string s2 = ToLua.ToString(L, 1);
				IFormatProvider provider = (IFormatProvider)ToLua.ToObject(L, 2);
				DateTimeStyles styles = (DateTimeStyles)LuaDLL.lua_tonumber(L, 3);
				DateTime dateTime2;
				bool value2 = DateTime.TryParse(s2, provider, styles, out dateTime2);
				LuaDLL.lua_pushboolean(L, value2);
				ToLua.PushValue(L, dateTime2);
				result = 2;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.DateTime.TryParse");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TryParseExact(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string[]), typeof(IFormatProvider), typeof(uint), typeof(LuaOut<DateTime>)))
			{
				string s = ToLua.ToString(L, 1);
				string[] formats = ToLua.CheckStringArray(L, 2);
				IFormatProvider provider = (IFormatProvider)ToLua.ToObject(L, 3);
				DateTimeStyles style = (DateTimeStyles)LuaDLL.lua_tonumber(L, 4);
				DateTime dateTime;
				bool value = DateTime.TryParseExact(s, formats, provider, style, out dateTime);
				LuaDLL.lua_pushboolean(L, value);
				ToLua.PushValue(L, dateTime);
				result = 2;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string), typeof(IFormatProvider), typeof(uint), typeof(LuaOut<DateTime>)))
			{
				string s2 = ToLua.ToString(L, 1);
				string format = ToLua.ToString(L, 2);
				IFormatProvider provider2 = (IFormatProvider)ToLua.ToObject(L, 3);
				DateTimeStyles style2 = (DateTimeStyles)LuaDLL.lua_tonumber(L, 4);
				DateTime dateTime2;
				bool value2 = DateTime.TryParseExact(s2, format, provider2, style2, out dateTime2);
				LuaDLL.lua_pushboolean(L, value2);
				ToLua.PushValue(L, dateTime2);
				result = 2;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.DateTime.TryParseExact");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Subtract(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(DateTime), typeof(TimeSpan)))
			{
				DateTime dateTime = (DateTime)ToLua.ToObject(L, 1);
				TimeSpan value = (TimeSpan)ToLua.ToObject(L, 2);
				DateTime dateTime2 = dateTime.Subtract(value);
				ToLua.PushValue(L, dateTime2);
				ToLua.SetBack(L, 1, dateTime);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(DateTime), typeof(DateTime)))
			{
				DateTime dateTime3 = (DateTime)ToLua.ToObject(L, 1);
				DateTime value2 = (DateTime)ToLua.ToObject(L, 2);
				TimeSpan timeSpan = dateTime3.Subtract(value2);
				ToLua.PushValue(L, timeSpan);
				ToLua.SetBack(L, 1, dateTime3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.DateTime.Subtract");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ToFileTime(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			DateTime dateTime = (DateTime)ToLua.CheckObject(L, 1, typeof(DateTime));
			long n = dateTime.ToFileTime();
			LuaDLL.tolua_pushint64(L, n);
			ToLua.SetBack(L, 1, dateTime);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ToFileTimeUtc(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			DateTime dateTime = (DateTime)ToLua.CheckObject(L, 1, typeof(DateTime));
			long n = dateTime.ToFileTimeUtc();
			LuaDLL.tolua_pushint64(L, n);
			ToLua.SetBack(L, 1, dateTime);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ToLongDateString(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			DateTime dateTime = (DateTime)ToLua.CheckObject(L, 1, typeof(DateTime));
			string str = dateTime.ToLongDateString();
			LuaDLL.lua_pushstring(L, str);
			ToLua.SetBack(L, 1, dateTime);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ToLongTimeString(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			DateTime dateTime = (DateTime)ToLua.CheckObject(L, 1, typeof(DateTime));
			string str = dateTime.ToLongTimeString();
			LuaDLL.lua_pushstring(L, str);
			ToLua.SetBack(L, 1, dateTime);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ToOADate(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			DateTime dateTime = (DateTime)ToLua.CheckObject(L, 1, typeof(DateTime));
			double number = dateTime.ToOADate();
			LuaDLL.lua_pushnumber(L, number);
			ToLua.SetBack(L, 1, dateTime);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ToShortDateString(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			DateTime dateTime = (DateTime)ToLua.CheckObject(L, 1, typeof(DateTime));
			string str = dateTime.ToShortDateString();
			LuaDLL.lua_pushstring(L, str);
			ToLua.SetBack(L, 1, dateTime);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ToShortTimeString(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			DateTime dateTime = (DateTime)ToLua.CheckObject(L, 1, typeof(DateTime));
			string str = dateTime.ToShortTimeString();
			LuaDLL.lua_pushstring(L, str);
			ToLua.SetBack(L, 1, dateTime);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ToString(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(DateTime)))
			{
				string str = ((DateTime)ToLua.ToObject(L, 1)).ToString();
				LuaDLL.lua_pushstring(L, str);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(DateTime), typeof(string)))
			{
				DateTime dateTime = (DateTime)ToLua.ToObject(L, 1);
				string format = ToLua.ToString(L, 2);
				string str2 = dateTime.ToString(format);
				LuaDLL.lua_pushstring(L, str2);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(DateTime), typeof(IFormatProvider)))
			{
				DateTime dateTime2 = (DateTime)ToLua.ToObject(L, 1);
				IFormatProvider provider = (IFormatProvider)ToLua.ToObject(L, 2);
				string str3 = dateTime2.ToString(provider);
				LuaDLL.lua_pushstring(L, str3);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(DateTime), typeof(string), typeof(IFormatProvider)))
			{
				DateTime dateTime3 = (DateTime)ToLua.ToObject(L, 1);
				string format2 = ToLua.ToString(L, 2);
				IFormatProvider provider2 = (IFormatProvider)ToLua.ToObject(L, 3);
				string str4 = dateTime3.ToString(format2, provider2);
				LuaDLL.lua_pushstring(L, str4);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.DateTime.ToString");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ToLocalTime(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			DateTime dateTime = (DateTime)ToLua.CheckObject(L, 1, typeof(DateTime));
			DateTime dateTime2 = dateTime.ToLocalTime();
			ToLua.PushValue(L, dateTime2);
			ToLua.SetBack(L, 1, dateTime);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ToUniversalTime(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			DateTime dateTime = (DateTime)ToLua.CheckObject(L, 1, typeof(DateTime));
			DateTime dateTime2 = dateTime.ToUniversalTime();
			ToLua.PushValue(L, dateTime2);
			ToLua.SetBack(L, 1, dateTime);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int op_Addition(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			DateTime d = (DateTime)ToLua.CheckObject(L, 1, typeof(DateTime));
			TimeSpan t = (TimeSpan)ToLua.CheckObject(L, 2, typeof(TimeSpan));
			DateTime dateTime = d + t;
			ToLua.PushValue(L, dateTime);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int op_Equality(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			DateTime d = (DateTime)ToLua.ToObject(L, 1);
			DateTime d2 = (DateTime)ToLua.ToObject(L, 2);
			bool value = d == d2;
			LuaDLL.lua_pushboolean(L, value);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int op_Subtraction(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(DateTime), typeof(TimeSpan)))
			{
				DateTime d = (DateTime)ToLua.ToObject(L, 1);
				TimeSpan t = (TimeSpan)ToLua.ToObject(L, 2);
				DateTime dateTime = d - t;
				ToLua.PushValue(L, dateTime);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(DateTime), typeof(DateTime)))
			{
				DateTime d2 = (DateTime)ToLua.ToObject(L, 1);
				DateTime d3 = (DateTime)ToLua.ToObject(L, 2);
				TimeSpan timeSpan = d2 - d3;
				ToLua.PushValue(L, timeSpan);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.DateTime.op_Subtraction");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_MaxValue(IntPtr L)
	{
		int result;
		try
		{
			ToLua.PushValue(L, DateTime.MaxValue);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_MinValue(IntPtr L)
	{
		int result;
		try
		{
			ToLua.PushValue(L, DateTime.MinValue);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Date(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			DateTime date = ((DateTime)obj).Date;
			ToLua.PushValue(L, date);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Date on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Month(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			int month = ((DateTime)obj).Month;
			LuaDLL.lua_pushinteger(L, month);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Month on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Day(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			int day = ((DateTime)obj).Day;
			LuaDLL.lua_pushinteger(L, day);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Day on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_DayOfWeek(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			DayOfWeek dayOfWeek = ((DateTime)obj).DayOfWeek;
			ToLua.Push(L, dayOfWeek);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index DayOfWeek on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_DayOfYear(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			int dayOfYear = ((DateTime)obj).DayOfYear;
			LuaDLL.lua_pushinteger(L, dayOfYear);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index DayOfYear on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_TimeOfDay(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TimeSpan timeOfDay = ((DateTime)obj).TimeOfDay;
			ToLua.PushValue(L, timeOfDay);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index TimeOfDay on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Hour(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			int hour = ((DateTime)obj).Hour;
			LuaDLL.lua_pushinteger(L, hour);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Hour on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Minute(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			int minute = ((DateTime)obj).Minute;
			LuaDLL.lua_pushinteger(L, minute);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Minute on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Second(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			int second = ((DateTime)obj).Second;
			LuaDLL.lua_pushinteger(L, second);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Second on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Millisecond(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			int millisecond = ((DateTime)obj).Millisecond;
			LuaDLL.lua_pushinteger(L, millisecond);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Millisecond on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Now(IntPtr L)
	{
		int result;
		try
		{
			ToLua.PushValue(L, DateTime.Now);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Ticks(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			long ticks = ((DateTime)obj).Ticks;
			LuaDLL.tolua_pushint64(L, ticks);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Ticks on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Today(IntPtr L)
	{
		int result;
		try
		{
			ToLua.PushValue(L, DateTime.Today);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_UtcNow(IntPtr L)
	{
		int result;
		try
		{
			ToLua.PushValue(L, DateTime.UtcNow);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Year(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			int year = ((DateTime)obj).Year;
			LuaDLL.lua_pushinteger(L, year);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Year on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Kind(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			DateTimeKind kind = ((DateTime)obj).Kind;
			ToLua.Push(L, kind);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Kind on a nil value");
		}
		return result;
	}
}
