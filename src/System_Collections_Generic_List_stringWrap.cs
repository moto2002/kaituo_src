using LuaInterface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class System_Collections_Generic_List_stringWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(List<string>), typeof(object), "List_string");
		L.RegFunction("Add", new LuaCSFunction(System_Collections_Generic_List_stringWrap.Add));
		L.RegFunction("AddRange", new LuaCSFunction(System_Collections_Generic_List_stringWrap.AddRange));
		L.RegFunction("AsReadOnly", new LuaCSFunction(System_Collections_Generic_List_stringWrap.AsReadOnly));
		L.RegFunction("BinarySearch", new LuaCSFunction(System_Collections_Generic_List_stringWrap.BinarySearch));
		L.RegFunction("Clear", new LuaCSFunction(System_Collections_Generic_List_stringWrap.Clear));
		L.RegFunction("Contains", new LuaCSFunction(System_Collections_Generic_List_stringWrap.Contains));
		L.RegFunction("CopyTo", new LuaCSFunction(System_Collections_Generic_List_stringWrap.CopyTo));
		L.RegFunction("Exists", new LuaCSFunction(System_Collections_Generic_List_stringWrap.Exists));
		L.RegFunction("Find", new LuaCSFunction(System_Collections_Generic_List_stringWrap.Find));
		L.RegFunction("FindAll", new LuaCSFunction(System_Collections_Generic_List_stringWrap.FindAll));
		L.RegFunction("FindIndex", new LuaCSFunction(System_Collections_Generic_List_stringWrap.FindIndex));
		L.RegFunction("FindLast", new LuaCSFunction(System_Collections_Generic_List_stringWrap.FindLast));
		L.RegFunction("FindLastIndex", new LuaCSFunction(System_Collections_Generic_List_stringWrap.FindLastIndex));
		L.RegFunction("ForEach", new LuaCSFunction(System_Collections_Generic_List_stringWrap.ForEach));
		L.RegFunction("GetEnumerator", new LuaCSFunction(System_Collections_Generic_List_stringWrap.GetEnumerator));
		L.RegFunction("GetRange", new LuaCSFunction(System_Collections_Generic_List_stringWrap.GetRange));
		L.RegFunction("IndexOf", new LuaCSFunction(System_Collections_Generic_List_stringWrap.IndexOf));
		L.RegFunction("Insert", new LuaCSFunction(System_Collections_Generic_List_stringWrap.Insert));
		L.RegFunction("InsertRange", new LuaCSFunction(System_Collections_Generic_List_stringWrap.InsertRange));
		L.RegFunction("LastIndexOf", new LuaCSFunction(System_Collections_Generic_List_stringWrap.LastIndexOf));
		L.RegFunction("Remove", new LuaCSFunction(System_Collections_Generic_List_stringWrap.Remove));
		L.RegFunction("RemoveAll", new LuaCSFunction(System_Collections_Generic_List_stringWrap.RemoveAll));
		L.RegFunction("RemoveAt", new LuaCSFunction(System_Collections_Generic_List_stringWrap.RemoveAt));
		L.RegFunction("RemoveRange", new LuaCSFunction(System_Collections_Generic_List_stringWrap.RemoveRange));
		L.RegFunction("Reverse", new LuaCSFunction(System_Collections_Generic_List_stringWrap.Reverse));
		L.RegFunction("Sort", new LuaCSFunction(System_Collections_Generic_List_stringWrap.Sort));
		L.RegFunction("ToArray", new LuaCSFunction(System_Collections_Generic_List_stringWrap.ToArray));
		L.RegFunction("TrimExcess", new LuaCSFunction(System_Collections_Generic_List_stringWrap.TrimExcess));
		L.RegFunction("TrueForAll", new LuaCSFunction(System_Collections_Generic_List_stringWrap.TrueForAll));
		L.RegFunction(".geti", new LuaCSFunction(System_Collections_Generic_List_stringWrap.get_Item));
		L.RegFunction("get_Item", new LuaCSFunction(System_Collections_Generic_List_stringWrap.get_Item));
		L.RegFunction(".seti", new LuaCSFunction(System_Collections_Generic_List_stringWrap.set_Item));
		L.RegFunction("set_Item", new LuaCSFunction(System_Collections_Generic_List_stringWrap.set_Item));
		L.RegFunction("New", new LuaCSFunction(System_Collections_Generic_List_stringWrap._CreateSystem_Collections_Generic_List_string));
		L.RegVar("this", new LuaCSFunction(System_Collections_Generic_List_stringWrap._this), null);
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Capacity", new LuaCSFunction(System_Collections_Generic_List_stringWrap.get_Capacity), new LuaCSFunction(System_Collections_Generic_List_stringWrap.set_Capacity));
		L.RegVar("Count", new LuaCSFunction(System_Collections_Generic_List_stringWrap.get_Count), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateSystem_Collections_Generic_List_string(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 0)
			{
				List<string> o = new List<string>();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(int)))
			{
				int capacity = (int)LuaDLL.luaL_checknumber(L, 1);
				List<string> o2 = new List<string>(capacity);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(IEnumerable<string>)))
			{
				IEnumerable<string> collection = (IEnumerable<string>)ToLua.CheckObject(L, 1, typeof(IEnumerable<string>));
				List<string> o3 = new List<string>(collection);
				ToLua.PushObject(L, o3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: System.Collections.Generic.List<string>.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _get_this(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			List<string> list = (List<string>)ToLua.CheckObject(L, 1, typeof(List<string>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			string str = list[index];
			LuaDLL.lua_pushstring(L, str);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _set_this(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			List<string> list = (List<string>)ToLua.CheckObject(L, 1, typeof(List<string>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			string value = ToLua.CheckString(L, 3);
			list[index] = value;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _this(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushvalue(L, 1);
			LuaDLL.tolua_bindthis(L, new LuaCSFunction(System_Collections_Generic_List_stringWrap._get_this), new LuaCSFunction(System_Collections_Generic_List_stringWrap._set_this));
			result = 1;
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
			List<string> list = (List<string>)ToLua.CheckObject(L, 1, typeof(List<string>));
			string item = ToLua.CheckString(L, 2);
			list.Add(item);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddRange(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			List<string> list = (List<string>)ToLua.CheckObject(L, 1, typeof(List<string>));
			IEnumerable<string> collection = (IEnumerable<string>)ToLua.CheckObject(L, 2, typeof(IEnumerable<string>));
			list.AddRange(collection);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AsReadOnly(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			List<string> list = (List<string>)ToLua.CheckObject(L, 1, typeof(List<string>));
			ReadOnlyCollection<string> o = list.AsReadOnly();
			ToLua.PushObject(L, o);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int BinarySearch(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<string>), typeof(string)))
			{
				List<string> list = (List<string>)ToLua.ToObject(L, 1);
				string item = ToLua.ToString(L, 2);
				int n = list.BinarySearch(item);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<string>), typeof(string), typeof(IComparer<string>)))
			{
				List<string> list2 = (List<string>)ToLua.ToObject(L, 1);
				string item2 = ToLua.ToString(L, 2);
				IComparer<string> comparer = (IComparer<string>)ToLua.ToObject(L, 3);
				int n2 = list2.BinarySearch(item2, comparer);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(List<string>), typeof(int), typeof(int), typeof(string), typeof(IComparer<string>)))
			{
				List<string> list3 = (List<string>)ToLua.ToObject(L, 1);
				int index = (int)LuaDLL.lua_tonumber(L, 2);
				int count = (int)LuaDLL.lua_tonumber(L, 3);
				string item3 = ToLua.ToString(L, 4);
				IComparer<string> comparer2 = (IComparer<string>)ToLua.ToObject(L, 5);
				int n3 = list3.BinarySearch(index, count, item3, comparer2);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<string>.BinarySearch");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Clear(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			List<string> list = (List<string>)ToLua.CheckObject(L, 1, typeof(List<string>));
			list.Clear();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Contains(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			List<string> list = (List<string>)ToLua.CheckObject(L, 1, typeof(List<string>));
			string item = ToLua.CheckString(L, 2);
			bool value = list.Contains(item);
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
	private static int CopyTo(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<string>), typeof(string[])))
			{
				List<string> list = (List<string>)ToLua.ToObject(L, 1);
				string[] array = ToLua.CheckStringArray(L, 2);
				list.CopyTo(array);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<string>), typeof(string[]), typeof(int)))
			{
				List<string> list2 = (List<string>)ToLua.ToObject(L, 1);
				string[] array2 = ToLua.CheckStringArray(L, 2);
				int arrayIndex = (int)LuaDLL.lua_tonumber(L, 3);
				list2.CopyTo(array2, arrayIndex);
				result = 0;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(List<string>), typeof(int), typeof(string[]), typeof(int), typeof(int)))
			{
				List<string> list3 = (List<string>)ToLua.ToObject(L, 1);
				int index = (int)LuaDLL.lua_tonumber(L, 2);
				string[] array3 = ToLua.CheckStringArray(L, 3);
				int arrayIndex2 = (int)LuaDLL.lua_tonumber(L, 4);
				int count = (int)LuaDLL.lua_tonumber(L, 5);
				list3.CopyTo(index, array3, arrayIndex2, count);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<string>.CopyTo");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Exists(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			List<string> list = (List<string>)ToLua.CheckObject(L, 1, typeof(List<string>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Predicate<string> match;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				match = (Predicate<string>)ToLua.CheckObject(L, 2, typeof(Predicate<string>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				match = (DelegateFactory.CreateDelegate(typeof(Predicate<string>), func) as Predicate<string>);
			}
			bool value = list.Exists(match);
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
	private static int Find(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			List<string> list = (List<string>)ToLua.CheckObject(L, 1, typeof(List<string>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Predicate<string> match;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				match = (Predicate<string>)ToLua.CheckObject(L, 2, typeof(Predicate<string>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				match = (DelegateFactory.CreateDelegate(typeof(Predicate<string>), func) as Predicate<string>);
			}
			string str = list.Find(match);
			LuaDLL.lua_pushstring(L, str);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FindAll(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			List<string> list = (List<string>)ToLua.CheckObject(L, 1, typeof(List<string>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Predicate<string> match;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				match = (Predicate<string>)ToLua.CheckObject(L, 2, typeof(Predicate<string>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				match = (DelegateFactory.CreateDelegate(typeof(Predicate<string>), func) as Predicate<string>);
			}
			List<string> o = list.FindAll(match);
			ToLua.PushObject(L, o);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FindIndex(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<string>), typeof(Predicate<string>)))
			{
				List<string> list = (List<string>)ToLua.ToObject(L, 1);
				LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
				Predicate<string> match;
				if (luaTypes != LuaTypes.LUA_TFUNCTION)
				{
					match = (Predicate<string>)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func = ToLua.ToLuaFunction(L, 2);
					match = (DelegateFactory.CreateDelegate(typeof(Predicate<string>), func) as Predicate<string>);
				}
				int n = list.FindIndex(match);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<string>), typeof(int), typeof(Predicate<string>)))
			{
				List<string> list2 = (List<string>)ToLua.ToObject(L, 1);
				int startIndex = (int)LuaDLL.lua_tonumber(L, 2);
				LuaTypes luaTypes2 = LuaDLL.lua_type(L, 3);
				Predicate<string> match2;
				if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
				{
					match2 = (Predicate<string>)ToLua.ToObject(L, 3);
				}
				else
				{
					LuaFunction func2 = ToLua.ToLuaFunction(L, 3);
					match2 = (DelegateFactory.CreateDelegate(typeof(Predicate<string>), func2) as Predicate<string>);
				}
				int n2 = list2.FindIndex(startIndex, match2);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(List<string>), typeof(int), typeof(int), typeof(Predicate<string>)))
			{
				List<string> list3 = (List<string>)ToLua.ToObject(L, 1);
				int startIndex2 = (int)LuaDLL.lua_tonumber(L, 2);
				int count = (int)LuaDLL.lua_tonumber(L, 3);
				LuaTypes luaTypes3 = LuaDLL.lua_type(L, 4);
				Predicate<string> match3;
				if (luaTypes3 != LuaTypes.LUA_TFUNCTION)
				{
					match3 = (Predicate<string>)ToLua.ToObject(L, 4);
				}
				else
				{
					LuaFunction func3 = ToLua.ToLuaFunction(L, 4);
					match3 = (DelegateFactory.CreateDelegate(typeof(Predicate<string>), func3) as Predicate<string>);
				}
				int n3 = list3.FindIndex(startIndex2, count, match3);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<string>.FindIndex");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FindLast(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			List<string> list = (List<string>)ToLua.CheckObject(L, 1, typeof(List<string>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Predicate<string> match;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				match = (Predicate<string>)ToLua.CheckObject(L, 2, typeof(Predicate<string>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				match = (DelegateFactory.CreateDelegate(typeof(Predicate<string>), func) as Predicate<string>);
			}
			string str = list.FindLast(match);
			LuaDLL.lua_pushstring(L, str);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FindLastIndex(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<string>), typeof(Predicate<string>)))
			{
				List<string> list = (List<string>)ToLua.ToObject(L, 1);
				LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
				Predicate<string> match;
				if (luaTypes != LuaTypes.LUA_TFUNCTION)
				{
					match = (Predicate<string>)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func = ToLua.ToLuaFunction(L, 2);
					match = (DelegateFactory.CreateDelegate(typeof(Predicate<string>), func) as Predicate<string>);
				}
				int n = list.FindLastIndex(match);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<string>), typeof(int), typeof(Predicate<string>)))
			{
				List<string> list2 = (List<string>)ToLua.ToObject(L, 1);
				int startIndex = (int)LuaDLL.lua_tonumber(L, 2);
				LuaTypes luaTypes2 = LuaDLL.lua_type(L, 3);
				Predicate<string> match2;
				if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
				{
					match2 = (Predicate<string>)ToLua.ToObject(L, 3);
				}
				else
				{
					LuaFunction func2 = ToLua.ToLuaFunction(L, 3);
					match2 = (DelegateFactory.CreateDelegate(typeof(Predicate<string>), func2) as Predicate<string>);
				}
				int n2 = list2.FindLastIndex(startIndex, match2);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(List<string>), typeof(int), typeof(int), typeof(Predicate<string>)))
			{
				List<string> list3 = (List<string>)ToLua.ToObject(L, 1);
				int startIndex2 = (int)LuaDLL.lua_tonumber(L, 2);
				int count = (int)LuaDLL.lua_tonumber(L, 3);
				LuaTypes luaTypes3 = LuaDLL.lua_type(L, 4);
				Predicate<string> match3;
				if (luaTypes3 != LuaTypes.LUA_TFUNCTION)
				{
					match3 = (Predicate<string>)ToLua.ToObject(L, 4);
				}
				else
				{
					LuaFunction func3 = ToLua.ToLuaFunction(L, 4);
					match3 = (DelegateFactory.CreateDelegate(typeof(Predicate<string>), func3) as Predicate<string>);
				}
				int n3 = list3.FindLastIndex(startIndex2, count, match3);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<string>.FindLastIndex");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ForEach(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			List<string> list = (List<string>)ToLua.CheckObject(L, 1, typeof(List<string>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action<string> action;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				action = (Action<string>)ToLua.CheckObject(L, 2, typeof(Action<string>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				action = (DelegateFactory.CreateDelegate(typeof(Action<string>), func) as Action<string>);
			}
			list.ForEach(action);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetEnumerator(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			List<string> list = (List<string>)ToLua.CheckObject(L, 1, typeof(List<string>));
			List<string>.Enumerator enumerator = list.GetEnumerator();
			ToLua.Push(L, enumerator);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetRange(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			List<string> list = (List<string>)ToLua.CheckObject(L, 1, typeof(List<string>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			int count = (int)LuaDLL.luaL_checknumber(L, 3);
			List<string> range = list.GetRange(index, count);
			ToLua.PushObject(L, range);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IndexOf(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<string>), typeof(string)))
			{
				List<string> list = (List<string>)ToLua.ToObject(L, 1);
				string item = ToLua.ToString(L, 2);
				int n = list.IndexOf(item);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<string>), typeof(string), typeof(int)))
			{
				List<string> list2 = (List<string>)ToLua.ToObject(L, 1);
				string item2 = ToLua.ToString(L, 2);
				int index = (int)LuaDLL.lua_tonumber(L, 3);
				int n2 = list2.IndexOf(item2, index);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(List<string>), typeof(string), typeof(int), typeof(int)))
			{
				List<string> list3 = (List<string>)ToLua.ToObject(L, 1);
				string item3 = ToLua.ToString(L, 2);
				int index2 = (int)LuaDLL.lua_tonumber(L, 3);
				int count = (int)LuaDLL.lua_tonumber(L, 4);
				int n3 = list3.IndexOf(item3, index2, count);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<string>.IndexOf");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Insert(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			List<string> list = (List<string>)ToLua.CheckObject(L, 1, typeof(List<string>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			string item = ToLua.CheckString(L, 3);
			list.Insert(index, item);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int InsertRange(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			List<string> list = (List<string>)ToLua.CheckObject(L, 1, typeof(List<string>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			IEnumerable<string> collection = (IEnumerable<string>)ToLua.CheckObject(L, 3, typeof(IEnumerable<string>));
			list.InsertRange(index, collection);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LastIndexOf(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<string>), typeof(string)))
			{
				List<string> list = (List<string>)ToLua.ToObject(L, 1);
				string item = ToLua.ToString(L, 2);
				int n = list.LastIndexOf(item);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<string>), typeof(string), typeof(int)))
			{
				List<string> list2 = (List<string>)ToLua.ToObject(L, 1);
				string item2 = ToLua.ToString(L, 2);
				int index = (int)LuaDLL.lua_tonumber(L, 3);
				int n2 = list2.LastIndexOf(item2, index);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(List<string>), typeof(string), typeof(int), typeof(int)))
			{
				List<string> list3 = (List<string>)ToLua.ToObject(L, 1);
				string item3 = ToLua.ToString(L, 2);
				int index2 = (int)LuaDLL.lua_tonumber(L, 3);
				int count = (int)LuaDLL.lua_tonumber(L, 4);
				int n3 = list3.LastIndexOf(item3, index2, count);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<string>.LastIndexOf");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Remove(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			List<string> list = (List<string>)ToLua.CheckObject(L, 1, typeof(List<string>));
			string item = ToLua.CheckString(L, 2);
			bool value = list.Remove(item);
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
	private static int RemoveAll(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			List<string> list = (List<string>)ToLua.CheckObject(L, 1, typeof(List<string>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Predicate<string> match;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				match = (Predicate<string>)ToLua.CheckObject(L, 2, typeof(Predicate<string>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				match = (DelegateFactory.CreateDelegate(typeof(Predicate<string>), func) as Predicate<string>);
			}
			int n = list.RemoveAll(match);
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
	private static int RemoveAt(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			List<string> list = (List<string>)ToLua.CheckObject(L, 1, typeof(List<string>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			list.RemoveAt(index);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveRange(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			List<string> list = (List<string>)ToLua.CheckObject(L, 1, typeof(List<string>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			int count = (int)LuaDLL.luaL_checknumber(L, 3);
			list.RemoveRange(index, count);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Reverse(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(List<string>)))
			{
				List<string> list = (List<string>)ToLua.ToObject(L, 1);
				list.Reverse();
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<string>), typeof(int), typeof(int)))
			{
				List<string> list2 = (List<string>)ToLua.ToObject(L, 1);
				int index = (int)LuaDLL.lua_tonumber(L, 2);
				int count = (int)LuaDLL.lua_tonumber(L, 3);
				list2.Reverse(index, count);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<string>.Reverse");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Sort(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(List<string>)))
			{
				List<string> list = (List<string>)ToLua.ToObject(L, 1);
				list.Sort();
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<string>), typeof(Comparison<string>)))
			{
				List<string> list2 = (List<string>)ToLua.ToObject(L, 1);
				LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
				Comparison<string> comparison;
				if (luaTypes != LuaTypes.LUA_TFUNCTION)
				{
					comparison = (Comparison<string>)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func = ToLua.ToLuaFunction(L, 2);
					comparison = (DelegateFactory.CreateDelegate(typeof(Comparison<string>), func) as Comparison<string>);
				}
				list2.Sort(comparison);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<string>), typeof(IComparer<string>)))
			{
				List<string> list3 = (List<string>)ToLua.ToObject(L, 1);
				IComparer<string> comparer = (IComparer<string>)ToLua.ToObject(L, 2);
				list3.Sort(comparer);
				result = 0;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(List<string>), typeof(int), typeof(int), typeof(IComparer<string>)))
			{
				List<string> list4 = (List<string>)ToLua.ToObject(L, 1);
				int index = (int)LuaDLL.lua_tonumber(L, 2);
				int count = (int)LuaDLL.lua_tonumber(L, 3);
				IComparer<string> comparer2 = (IComparer<string>)ToLua.ToObject(L, 4);
				list4.Sort(index, count, comparer2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<string>.Sort");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ToArray(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			List<string> list = (List<string>)ToLua.CheckObject(L, 1, typeof(List<string>));
			string[] array = list.ToArray();
			ToLua.Push(L, array);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TrimExcess(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			List<string> list = (List<string>)ToLua.CheckObject(L, 1, typeof(List<string>));
			list.TrimExcess();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TrueForAll(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			List<string> list = (List<string>)ToLua.CheckObject(L, 1, typeof(List<string>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Predicate<string> match;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				match = (Predicate<string>)ToLua.CheckObject(L, 2, typeof(Predicate<string>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				match = (DelegateFactory.CreateDelegate(typeof(Predicate<string>), func) as Predicate<string>);
			}
			bool value = list.TrueForAll(match);
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
	private static int get_Item(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			List<string> list = (List<string>)ToLua.CheckObject(L, 1, typeof(List<string>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			string str = list[index];
			LuaDLL.lua_pushstring(L, str);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Item(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			List<string> list = (List<string>)ToLua.CheckObject(L, 1, typeof(List<string>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			string value = ToLua.CheckString(L, 3);
			list[index] = value;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Capacity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			List<string> list = (List<string>)obj;
			int capacity = list.Capacity;
			LuaDLL.lua_pushinteger(L, capacity);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Capacity on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Count(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			List<string> list = (List<string>)obj;
			int count = list.Count;
			LuaDLL.lua_pushinteger(L, count);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Count on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Capacity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			List<string> list = (List<string>)obj;
			int capacity = (int)LuaDLL.luaL_checknumber(L, 2);
			list.Capacity = capacity;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Capacity on a nil value");
		}
		return result;
	}
}
