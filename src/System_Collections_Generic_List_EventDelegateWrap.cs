using LuaInterface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class System_Collections_Generic_List_EventDelegateWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(List<EventDelegate>), typeof(object), "List_EventDelegate");
		L.RegFunction("Add", new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap.Add));
		L.RegFunction("AddRange", new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap.AddRange));
		L.RegFunction("AsReadOnly", new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap.AsReadOnly));
		L.RegFunction("BinarySearch", new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap.BinarySearch));
		L.RegFunction("Clear", new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap.Clear));
		L.RegFunction("Contains", new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap.Contains));
		L.RegFunction("CopyTo", new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap.CopyTo));
		L.RegFunction("Exists", new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap.Exists));
		L.RegFunction("Find", new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap.Find));
		L.RegFunction("FindAll", new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap.FindAll));
		L.RegFunction("FindIndex", new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap.FindIndex));
		L.RegFunction("FindLast", new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap.FindLast));
		L.RegFunction("FindLastIndex", new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap.FindLastIndex));
		L.RegFunction("ForEach", new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap.ForEach));
		L.RegFunction("GetEnumerator", new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap.GetEnumerator));
		L.RegFunction("GetRange", new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap.GetRange));
		L.RegFunction("IndexOf", new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap.IndexOf));
		L.RegFunction("Insert", new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap.Insert));
		L.RegFunction("InsertRange", new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap.InsertRange));
		L.RegFunction("LastIndexOf", new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap.LastIndexOf));
		L.RegFunction("Remove", new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap.Remove));
		L.RegFunction("RemoveAll", new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap.RemoveAll));
		L.RegFunction("RemoveAt", new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap.RemoveAt));
		L.RegFunction("RemoveRange", new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap.RemoveRange));
		L.RegFunction("Reverse", new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap.Reverse));
		L.RegFunction("Sort", new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap.Sort));
		L.RegFunction("ToArray", new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap.ToArray));
		L.RegFunction("TrimExcess", new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap.TrimExcess));
		L.RegFunction("TrueForAll", new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap.TrueForAll));
		L.RegFunction(".geti", new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap.get_Item));
		L.RegFunction("get_Item", new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap.get_Item));
		L.RegFunction(".seti", new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap.set_Item));
		L.RegFunction("set_Item", new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap.set_Item));
		L.RegFunction("New", new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap._CreateSystem_Collections_Generic_List_EventDelegate));
		L.RegVar("this", new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap._this), null);
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Capacity", new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap.get_Capacity), new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap.set_Capacity));
		L.RegVar("Count", new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap.get_Count), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateSystem_Collections_Generic_List_EventDelegate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 0)
			{
				List<EventDelegate> o = new List<EventDelegate>();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(int)))
			{
				int capacity = (int)LuaDLL.luaL_checknumber(L, 1);
				List<EventDelegate> o2 = new List<EventDelegate>(capacity);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(IEnumerable<EventDelegate>)))
			{
				IEnumerable<EventDelegate> collection = (IEnumerable<EventDelegate>)ToLua.CheckObject(L, 1, typeof(IEnumerable<EventDelegate>));
				List<EventDelegate> o3 = new List<EventDelegate>(collection);
				ToLua.PushObject(L, o3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: System.Collections.Generic.List<EventDelegate>.New");
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
			List<EventDelegate> list = (List<EventDelegate>)ToLua.CheckObject(L, 1, typeof(List<EventDelegate>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			EventDelegate o = list[index];
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
	private static int _set_this(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			List<EventDelegate> list = (List<EventDelegate>)ToLua.CheckObject(L, 1, typeof(List<EventDelegate>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			EventDelegate value = (EventDelegate)ToLua.CheckObject(L, 3, typeof(EventDelegate));
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
			LuaDLL.tolua_bindthis(L, new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap._get_this), new LuaCSFunction(System_Collections_Generic_List_EventDelegateWrap._set_this));
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
			List<EventDelegate> list = (List<EventDelegate>)ToLua.CheckObject(L, 1, typeof(List<EventDelegate>));
			EventDelegate item = (EventDelegate)ToLua.CheckObject(L, 2, typeof(EventDelegate));
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
			List<EventDelegate> list = (List<EventDelegate>)ToLua.CheckObject(L, 1, typeof(List<EventDelegate>));
			IEnumerable<EventDelegate> collection = (IEnumerable<EventDelegate>)ToLua.CheckObject(L, 2, typeof(IEnumerable<EventDelegate>));
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
			List<EventDelegate> list = (List<EventDelegate>)ToLua.CheckObject(L, 1, typeof(List<EventDelegate>));
			ReadOnlyCollection<EventDelegate> o = list.AsReadOnly();
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
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<EventDelegate>), typeof(EventDelegate)))
			{
				List<EventDelegate> list = (List<EventDelegate>)ToLua.ToObject(L, 1);
				EventDelegate item = (EventDelegate)ToLua.ToObject(L, 2);
				int n = list.BinarySearch(item);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<EventDelegate>), typeof(EventDelegate), typeof(IComparer<EventDelegate>)))
			{
				List<EventDelegate> list2 = (List<EventDelegate>)ToLua.ToObject(L, 1);
				EventDelegate item2 = (EventDelegate)ToLua.ToObject(L, 2);
				IComparer<EventDelegate> comparer = (IComparer<EventDelegate>)ToLua.ToObject(L, 3);
				int n2 = list2.BinarySearch(item2, comparer);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(List<EventDelegate>), typeof(int), typeof(int), typeof(EventDelegate), typeof(IComparer<EventDelegate>)))
			{
				List<EventDelegate> list3 = (List<EventDelegate>)ToLua.ToObject(L, 1);
				int index = (int)LuaDLL.lua_tonumber(L, 2);
				int count = (int)LuaDLL.lua_tonumber(L, 3);
				EventDelegate item3 = (EventDelegate)ToLua.ToObject(L, 4);
				IComparer<EventDelegate> comparer2 = (IComparer<EventDelegate>)ToLua.ToObject(L, 5);
				int n3 = list3.BinarySearch(index, count, item3, comparer2);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<EventDelegate>.BinarySearch");
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
			List<EventDelegate> list = (List<EventDelegate>)ToLua.CheckObject(L, 1, typeof(List<EventDelegate>));
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
			List<EventDelegate> list = (List<EventDelegate>)ToLua.CheckObject(L, 1, typeof(List<EventDelegate>));
			EventDelegate item = (EventDelegate)ToLua.CheckObject(L, 2, typeof(EventDelegate));
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
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<EventDelegate>), typeof(EventDelegate[])))
			{
				List<EventDelegate> list = (List<EventDelegate>)ToLua.ToObject(L, 1);
				EventDelegate[] array = ToLua.CheckObjectArray<EventDelegate>(L, 2);
				list.CopyTo(array);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<EventDelegate>), typeof(EventDelegate[]), typeof(int)))
			{
				List<EventDelegate> list2 = (List<EventDelegate>)ToLua.ToObject(L, 1);
				EventDelegate[] array2 = ToLua.CheckObjectArray<EventDelegate>(L, 2);
				int arrayIndex = (int)LuaDLL.lua_tonumber(L, 3);
				list2.CopyTo(array2, arrayIndex);
				result = 0;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(List<EventDelegate>), typeof(int), typeof(EventDelegate[]), typeof(int), typeof(int)))
			{
				List<EventDelegate> list3 = (List<EventDelegate>)ToLua.ToObject(L, 1);
				int index = (int)LuaDLL.lua_tonumber(L, 2);
				EventDelegate[] array3 = ToLua.CheckObjectArray<EventDelegate>(L, 3);
				int arrayIndex2 = (int)LuaDLL.lua_tonumber(L, 4);
				int count = (int)LuaDLL.lua_tonumber(L, 5);
				list3.CopyTo(index, array3, arrayIndex2, count);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<EventDelegate>.CopyTo");
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
			List<EventDelegate> list = (List<EventDelegate>)ToLua.CheckObject(L, 1, typeof(List<EventDelegate>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Predicate<EventDelegate> match;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				match = (Predicate<EventDelegate>)ToLua.CheckObject(L, 2, typeof(Predicate<EventDelegate>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				match = (DelegateFactory.CreateDelegate(typeof(Predicate<EventDelegate>), func) as Predicate<EventDelegate>);
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
			List<EventDelegate> list = (List<EventDelegate>)ToLua.CheckObject(L, 1, typeof(List<EventDelegate>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Predicate<EventDelegate> match;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				match = (Predicate<EventDelegate>)ToLua.CheckObject(L, 2, typeof(Predicate<EventDelegate>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				match = (DelegateFactory.CreateDelegate(typeof(Predicate<EventDelegate>), func) as Predicate<EventDelegate>);
			}
			EventDelegate o = list.Find(match);
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
	private static int FindAll(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			List<EventDelegate> list = (List<EventDelegate>)ToLua.CheckObject(L, 1, typeof(List<EventDelegate>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Predicate<EventDelegate> match;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				match = (Predicate<EventDelegate>)ToLua.CheckObject(L, 2, typeof(Predicate<EventDelegate>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				match = (DelegateFactory.CreateDelegate(typeof(Predicate<EventDelegate>), func) as Predicate<EventDelegate>);
			}
			List<EventDelegate> o = list.FindAll(match);
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
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<EventDelegate>), typeof(Predicate<EventDelegate>)))
			{
				List<EventDelegate> list = (List<EventDelegate>)ToLua.ToObject(L, 1);
				LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
				Predicate<EventDelegate> match;
				if (luaTypes != LuaTypes.LUA_TFUNCTION)
				{
					match = (Predicate<EventDelegate>)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func = ToLua.ToLuaFunction(L, 2);
					match = (DelegateFactory.CreateDelegate(typeof(Predicate<EventDelegate>), func) as Predicate<EventDelegate>);
				}
				int n = list.FindIndex(match);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<EventDelegate>), typeof(int), typeof(Predicate<EventDelegate>)))
			{
				List<EventDelegate> list2 = (List<EventDelegate>)ToLua.ToObject(L, 1);
				int startIndex = (int)LuaDLL.lua_tonumber(L, 2);
				LuaTypes luaTypes2 = LuaDLL.lua_type(L, 3);
				Predicate<EventDelegate> match2;
				if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
				{
					match2 = (Predicate<EventDelegate>)ToLua.ToObject(L, 3);
				}
				else
				{
					LuaFunction func2 = ToLua.ToLuaFunction(L, 3);
					match2 = (DelegateFactory.CreateDelegate(typeof(Predicate<EventDelegate>), func2) as Predicate<EventDelegate>);
				}
				int n2 = list2.FindIndex(startIndex, match2);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(List<EventDelegate>), typeof(int), typeof(int), typeof(Predicate<EventDelegate>)))
			{
				List<EventDelegate> list3 = (List<EventDelegate>)ToLua.ToObject(L, 1);
				int startIndex2 = (int)LuaDLL.lua_tonumber(L, 2);
				int count = (int)LuaDLL.lua_tonumber(L, 3);
				LuaTypes luaTypes3 = LuaDLL.lua_type(L, 4);
				Predicate<EventDelegate> match3;
				if (luaTypes3 != LuaTypes.LUA_TFUNCTION)
				{
					match3 = (Predicate<EventDelegate>)ToLua.ToObject(L, 4);
				}
				else
				{
					LuaFunction func3 = ToLua.ToLuaFunction(L, 4);
					match3 = (DelegateFactory.CreateDelegate(typeof(Predicate<EventDelegate>), func3) as Predicate<EventDelegate>);
				}
				int n3 = list3.FindIndex(startIndex2, count, match3);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<EventDelegate>.FindIndex");
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
			List<EventDelegate> list = (List<EventDelegate>)ToLua.CheckObject(L, 1, typeof(List<EventDelegate>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Predicate<EventDelegate> match;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				match = (Predicate<EventDelegate>)ToLua.CheckObject(L, 2, typeof(Predicate<EventDelegate>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				match = (DelegateFactory.CreateDelegate(typeof(Predicate<EventDelegate>), func) as Predicate<EventDelegate>);
			}
			EventDelegate o = list.FindLast(match);
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
	private static int FindLastIndex(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<EventDelegate>), typeof(Predicate<EventDelegate>)))
			{
				List<EventDelegate> list = (List<EventDelegate>)ToLua.ToObject(L, 1);
				LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
				Predicate<EventDelegate> match;
				if (luaTypes != LuaTypes.LUA_TFUNCTION)
				{
					match = (Predicate<EventDelegate>)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func = ToLua.ToLuaFunction(L, 2);
					match = (DelegateFactory.CreateDelegate(typeof(Predicate<EventDelegate>), func) as Predicate<EventDelegate>);
				}
				int n = list.FindLastIndex(match);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<EventDelegate>), typeof(int), typeof(Predicate<EventDelegate>)))
			{
				List<EventDelegate> list2 = (List<EventDelegate>)ToLua.ToObject(L, 1);
				int startIndex = (int)LuaDLL.lua_tonumber(L, 2);
				LuaTypes luaTypes2 = LuaDLL.lua_type(L, 3);
				Predicate<EventDelegate> match2;
				if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
				{
					match2 = (Predicate<EventDelegate>)ToLua.ToObject(L, 3);
				}
				else
				{
					LuaFunction func2 = ToLua.ToLuaFunction(L, 3);
					match2 = (DelegateFactory.CreateDelegate(typeof(Predicate<EventDelegate>), func2) as Predicate<EventDelegate>);
				}
				int n2 = list2.FindLastIndex(startIndex, match2);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(List<EventDelegate>), typeof(int), typeof(int), typeof(Predicate<EventDelegate>)))
			{
				List<EventDelegate> list3 = (List<EventDelegate>)ToLua.ToObject(L, 1);
				int startIndex2 = (int)LuaDLL.lua_tonumber(L, 2);
				int count = (int)LuaDLL.lua_tonumber(L, 3);
				LuaTypes luaTypes3 = LuaDLL.lua_type(L, 4);
				Predicate<EventDelegate> match3;
				if (luaTypes3 != LuaTypes.LUA_TFUNCTION)
				{
					match3 = (Predicate<EventDelegate>)ToLua.ToObject(L, 4);
				}
				else
				{
					LuaFunction func3 = ToLua.ToLuaFunction(L, 4);
					match3 = (DelegateFactory.CreateDelegate(typeof(Predicate<EventDelegate>), func3) as Predicate<EventDelegate>);
				}
				int n3 = list3.FindLastIndex(startIndex2, count, match3);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<EventDelegate>.FindLastIndex");
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
			List<EventDelegate> list = (List<EventDelegate>)ToLua.CheckObject(L, 1, typeof(List<EventDelegate>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action<EventDelegate> action;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				action = (Action<EventDelegate>)ToLua.CheckObject(L, 2, typeof(Action<EventDelegate>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				action = (DelegateFactory.CreateDelegate(typeof(Action<EventDelegate>), func) as Action<EventDelegate>);
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
			List<EventDelegate> list = (List<EventDelegate>)ToLua.CheckObject(L, 1, typeof(List<EventDelegate>));
			List<EventDelegate>.Enumerator enumerator = list.GetEnumerator();
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
			List<EventDelegate> list = (List<EventDelegate>)ToLua.CheckObject(L, 1, typeof(List<EventDelegate>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			int count = (int)LuaDLL.luaL_checknumber(L, 3);
			List<EventDelegate> range = list.GetRange(index, count);
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
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<EventDelegate>), typeof(EventDelegate)))
			{
				List<EventDelegate> list = (List<EventDelegate>)ToLua.ToObject(L, 1);
				EventDelegate item = (EventDelegate)ToLua.ToObject(L, 2);
				int n = list.IndexOf(item);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<EventDelegate>), typeof(EventDelegate), typeof(int)))
			{
				List<EventDelegate> list2 = (List<EventDelegate>)ToLua.ToObject(L, 1);
				EventDelegate item2 = (EventDelegate)ToLua.ToObject(L, 2);
				int index = (int)LuaDLL.lua_tonumber(L, 3);
				int n2 = list2.IndexOf(item2, index);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(List<EventDelegate>), typeof(EventDelegate), typeof(int), typeof(int)))
			{
				List<EventDelegate> list3 = (List<EventDelegate>)ToLua.ToObject(L, 1);
				EventDelegate item3 = (EventDelegate)ToLua.ToObject(L, 2);
				int index2 = (int)LuaDLL.lua_tonumber(L, 3);
				int count = (int)LuaDLL.lua_tonumber(L, 4);
				int n3 = list3.IndexOf(item3, index2, count);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<EventDelegate>.IndexOf");
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
			List<EventDelegate> list = (List<EventDelegate>)ToLua.CheckObject(L, 1, typeof(List<EventDelegate>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			EventDelegate item = (EventDelegate)ToLua.CheckObject(L, 3, typeof(EventDelegate));
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
			List<EventDelegate> list = (List<EventDelegate>)ToLua.CheckObject(L, 1, typeof(List<EventDelegate>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			IEnumerable<EventDelegate> collection = (IEnumerable<EventDelegate>)ToLua.CheckObject(L, 3, typeof(IEnumerable<EventDelegate>));
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
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<EventDelegate>), typeof(EventDelegate)))
			{
				List<EventDelegate> list = (List<EventDelegate>)ToLua.ToObject(L, 1);
				EventDelegate item = (EventDelegate)ToLua.ToObject(L, 2);
				int n = list.LastIndexOf(item);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<EventDelegate>), typeof(EventDelegate), typeof(int)))
			{
				List<EventDelegate> list2 = (List<EventDelegate>)ToLua.ToObject(L, 1);
				EventDelegate item2 = (EventDelegate)ToLua.ToObject(L, 2);
				int index = (int)LuaDLL.lua_tonumber(L, 3);
				int n2 = list2.LastIndexOf(item2, index);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(List<EventDelegate>), typeof(EventDelegate), typeof(int), typeof(int)))
			{
				List<EventDelegate> list3 = (List<EventDelegate>)ToLua.ToObject(L, 1);
				EventDelegate item3 = (EventDelegate)ToLua.ToObject(L, 2);
				int index2 = (int)LuaDLL.lua_tonumber(L, 3);
				int count = (int)LuaDLL.lua_tonumber(L, 4);
				int n3 = list3.LastIndexOf(item3, index2, count);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<EventDelegate>.LastIndexOf");
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
			List<EventDelegate> list = (List<EventDelegate>)ToLua.CheckObject(L, 1, typeof(List<EventDelegate>));
			EventDelegate item = (EventDelegate)ToLua.CheckObject(L, 2, typeof(EventDelegate));
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
			List<EventDelegate> list = (List<EventDelegate>)ToLua.CheckObject(L, 1, typeof(List<EventDelegate>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Predicate<EventDelegate> match;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				match = (Predicate<EventDelegate>)ToLua.CheckObject(L, 2, typeof(Predicate<EventDelegate>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				match = (DelegateFactory.CreateDelegate(typeof(Predicate<EventDelegate>), func) as Predicate<EventDelegate>);
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
			List<EventDelegate> list = (List<EventDelegate>)ToLua.CheckObject(L, 1, typeof(List<EventDelegate>));
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
			List<EventDelegate> list = (List<EventDelegate>)ToLua.CheckObject(L, 1, typeof(List<EventDelegate>));
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
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(List<EventDelegate>)))
			{
				List<EventDelegate> list = (List<EventDelegate>)ToLua.ToObject(L, 1);
				list.Reverse();
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<EventDelegate>), typeof(int), typeof(int)))
			{
				List<EventDelegate> list2 = (List<EventDelegate>)ToLua.ToObject(L, 1);
				int index = (int)LuaDLL.lua_tonumber(L, 2);
				int count = (int)LuaDLL.lua_tonumber(L, 3);
				list2.Reverse(index, count);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<EventDelegate>.Reverse");
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
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(List<EventDelegate>)))
			{
				List<EventDelegate> list = (List<EventDelegate>)ToLua.ToObject(L, 1);
				list.Sort();
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<EventDelegate>), typeof(Comparison<EventDelegate>)))
			{
				List<EventDelegate> list2 = (List<EventDelegate>)ToLua.ToObject(L, 1);
				LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
				Comparison<EventDelegate> comparison;
				if (luaTypes != LuaTypes.LUA_TFUNCTION)
				{
					comparison = (Comparison<EventDelegate>)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func = ToLua.ToLuaFunction(L, 2);
					comparison = (DelegateFactory.CreateDelegate(typeof(Comparison<EventDelegate>), func) as Comparison<EventDelegate>);
				}
				list2.Sort(comparison);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<EventDelegate>), typeof(IComparer<EventDelegate>)))
			{
				List<EventDelegate> list3 = (List<EventDelegate>)ToLua.ToObject(L, 1);
				IComparer<EventDelegate> comparer = (IComparer<EventDelegate>)ToLua.ToObject(L, 2);
				list3.Sort(comparer);
				result = 0;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(List<EventDelegate>), typeof(int), typeof(int), typeof(IComparer<EventDelegate>)))
			{
				List<EventDelegate> list4 = (List<EventDelegate>)ToLua.ToObject(L, 1);
				int index = (int)LuaDLL.lua_tonumber(L, 2);
				int count = (int)LuaDLL.lua_tonumber(L, 3);
				IComparer<EventDelegate> comparer2 = (IComparer<EventDelegate>)ToLua.ToObject(L, 4);
				list4.Sort(index, count, comparer2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<EventDelegate>.Sort");
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
			List<EventDelegate> list = (List<EventDelegate>)ToLua.CheckObject(L, 1, typeof(List<EventDelegate>));
			EventDelegate[] array = list.ToArray();
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
			List<EventDelegate> list = (List<EventDelegate>)ToLua.CheckObject(L, 1, typeof(List<EventDelegate>));
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
			List<EventDelegate> list = (List<EventDelegate>)ToLua.CheckObject(L, 1, typeof(List<EventDelegate>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Predicate<EventDelegate> match;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				match = (Predicate<EventDelegate>)ToLua.CheckObject(L, 2, typeof(Predicate<EventDelegate>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				match = (DelegateFactory.CreateDelegate(typeof(Predicate<EventDelegate>), func) as Predicate<EventDelegate>);
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
			List<EventDelegate> list = (List<EventDelegate>)ToLua.CheckObject(L, 1, typeof(List<EventDelegate>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			EventDelegate o = list[index];
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
	private static int set_Item(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			List<EventDelegate> list = (List<EventDelegate>)ToLua.CheckObject(L, 1, typeof(List<EventDelegate>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			EventDelegate value = (EventDelegate)ToLua.CheckObject(L, 3, typeof(EventDelegate));
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
			List<EventDelegate> list = (List<EventDelegate>)obj;
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
			List<EventDelegate> list = (List<EventDelegate>)obj;
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
			List<EventDelegate> list = (List<EventDelegate>)obj;
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
