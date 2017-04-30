using LuaInterface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class System_Collections_Generic_List_objectWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(List<object>), typeof(object), "List_object");
		L.RegFunction("Add", new LuaCSFunction(System_Collections_Generic_List_objectWrap.Add));
		L.RegFunction("AddRange", new LuaCSFunction(System_Collections_Generic_List_objectWrap.AddRange));
		L.RegFunction("AsReadOnly", new LuaCSFunction(System_Collections_Generic_List_objectWrap.AsReadOnly));
		L.RegFunction("BinarySearch", new LuaCSFunction(System_Collections_Generic_List_objectWrap.BinarySearch));
		L.RegFunction("Clear", new LuaCSFunction(System_Collections_Generic_List_objectWrap.Clear));
		L.RegFunction("Contains", new LuaCSFunction(System_Collections_Generic_List_objectWrap.Contains));
		L.RegFunction("CopyTo", new LuaCSFunction(System_Collections_Generic_List_objectWrap.CopyTo));
		L.RegFunction("Exists", new LuaCSFunction(System_Collections_Generic_List_objectWrap.Exists));
		L.RegFunction("Find", new LuaCSFunction(System_Collections_Generic_List_objectWrap.Find));
		L.RegFunction("FindAll", new LuaCSFunction(System_Collections_Generic_List_objectWrap.FindAll));
		L.RegFunction("FindIndex", new LuaCSFunction(System_Collections_Generic_List_objectWrap.FindIndex));
		L.RegFunction("FindLast", new LuaCSFunction(System_Collections_Generic_List_objectWrap.FindLast));
		L.RegFunction("FindLastIndex", new LuaCSFunction(System_Collections_Generic_List_objectWrap.FindLastIndex));
		L.RegFunction("ForEach", new LuaCSFunction(System_Collections_Generic_List_objectWrap.ForEach));
		L.RegFunction("GetEnumerator", new LuaCSFunction(System_Collections_Generic_List_objectWrap.GetEnumerator));
		L.RegFunction("GetRange", new LuaCSFunction(System_Collections_Generic_List_objectWrap.GetRange));
		L.RegFunction("IndexOf", new LuaCSFunction(System_Collections_Generic_List_objectWrap.IndexOf));
		L.RegFunction("Insert", new LuaCSFunction(System_Collections_Generic_List_objectWrap.Insert));
		L.RegFunction("InsertRange", new LuaCSFunction(System_Collections_Generic_List_objectWrap.InsertRange));
		L.RegFunction("LastIndexOf", new LuaCSFunction(System_Collections_Generic_List_objectWrap.LastIndexOf));
		L.RegFunction("Remove", new LuaCSFunction(System_Collections_Generic_List_objectWrap.Remove));
		L.RegFunction("RemoveAll", new LuaCSFunction(System_Collections_Generic_List_objectWrap.RemoveAll));
		L.RegFunction("RemoveAt", new LuaCSFunction(System_Collections_Generic_List_objectWrap.RemoveAt));
		L.RegFunction("RemoveRange", new LuaCSFunction(System_Collections_Generic_List_objectWrap.RemoveRange));
		L.RegFunction("Reverse", new LuaCSFunction(System_Collections_Generic_List_objectWrap.Reverse));
		L.RegFunction("Sort", new LuaCSFunction(System_Collections_Generic_List_objectWrap.Sort));
		L.RegFunction("ToArray", new LuaCSFunction(System_Collections_Generic_List_objectWrap.ToArray));
		L.RegFunction("TrimExcess", new LuaCSFunction(System_Collections_Generic_List_objectWrap.TrimExcess));
		L.RegFunction("TrueForAll", new LuaCSFunction(System_Collections_Generic_List_objectWrap.TrueForAll));
		L.RegFunction(".geti", new LuaCSFunction(System_Collections_Generic_List_objectWrap.get_Item));
		L.RegFunction("get_Item", new LuaCSFunction(System_Collections_Generic_List_objectWrap.get_Item));
		L.RegFunction(".seti", new LuaCSFunction(System_Collections_Generic_List_objectWrap.set_Item));
		L.RegFunction("set_Item", new LuaCSFunction(System_Collections_Generic_List_objectWrap.set_Item));
		L.RegFunction("New", new LuaCSFunction(System_Collections_Generic_List_objectWrap._CreateSystem_Collections_Generic_List_object));
		L.RegVar("this", new LuaCSFunction(System_Collections_Generic_List_objectWrap._this), null);
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Capacity", new LuaCSFunction(System_Collections_Generic_List_objectWrap.get_Capacity), new LuaCSFunction(System_Collections_Generic_List_objectWrap.set_Capacity));
		L.RegVar("Count", new LuaCSFunction(System_Collections_Generic_List_objectWrap.get_Count), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateSystem_Collections_Generic_List_object(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 0)
			{
				List<object> o = new List<object>();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(int)))
			{
				int capacity = (int)LuaDLL.luaL_checknumber(L, 1);
				List<object> o2 = new List<object>(capacity);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(IEnumerable<object>)))
			{
				IEnumerable<object> collection = (IEnumerable<object>)ToLua.CheckObject(L, 1, typeof(IEnumerable<object>));
				List<object> o3 = new List<object>(collection);
				ToLua.PushObject(L, o3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: System.Collections.Generic.List<object>.New");
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
			List<object> list = (List<object>)ToLua.CheckObject(L, 1, typeof(List<object>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			object obj = list[index];
			ToLua.Push(L, obj);
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
			List<object> list = (List<object>)ToLua.CheckObject(L, 1, typeof(List<object>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			object value = ToLua.ToVarObject(L, 3);
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
			LuaDLL.tolua_bindthis(L, new LuaCSFunction(System_Collections_Generic_List_objectWrap._get_this), new LuaCSFunction(System_Collections_Generic_List_objectWrap._set_this));
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
			List<object> list = (List<object>)ToLua.CheckObject(L, 1, typeof(List<object>));
			object item = ToLua.ToVarObject(L, 2);
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
			List<object> list = (List<object>)ToLua.CheckObject(L, 1, typeof(List<object>));
			IEnumerable<object> collection = (IEnumerable<object>)ToLua.CheckObject(L, 2, typeof(IEnumerable<object>));
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
			List<object> list = (List<object>)ToLua.CheckObject(L, 1, typeof(List<object>));
			ReadOnlyCollection<object> o = list.AsReadOnly();
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
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<object>), typeof(object)))
			{
				List<object> list = (List<object>)ToLua.ToObject(L, 1);
				object item = ToLua.ToVarObject(L, 2);
				int n = list.BinarySearch(item);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<object>), typeof(object), typeof(IComparer<object>)))
			{
				List<object> list2 = (List<object>)ToLua.ToObject(L, 1);
				object item2 = ToLua.ToVarObject(L, 2);
				IComparer<object> comparer = (IComparer<object>)ToLua.ToObject(L, 3);
				int n2 = list2.BinarySearch(item2, comparer);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(List<object>), typeof(int), typeof(int), typeof(object), typeof(IComparer<object>)))
			{
				List<object> list3 = (List<object>)ToLua.ToObject(L, 1);
				int index = (int)LuaDLL.lua_tonumber(L, 2);
				int count = (int)LuaDLL.lua_tonumber(L, 3);
				object item3 = ToLua.ToVarObject(L, 4);
				IComparer<object> comparer2 = (IComparer<object>)ToLua.ToObject(L, 5);
				int n3 = list3.BinarySearch(index, count, item3, comparer2);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<object>.BinarySearch");
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
			List<object> list = (List<object>)ToLua.CheckObject(L, 1, typeof(List<object>));
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
			List<object> list = (List<object>)ToLua.CheckObject(L, 1, typeof(List<object>));
			object item = ToLua.ToVarObject(L, 2);
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
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<object>), typeof(object[])))
			{
				List<object> list = (List<object>)ToLua.ToObject(L, 1);
				object[] array = ToLua.CheckObjectArray(L, 2);
				list.CopyTo(array);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<object>), typeof(object[]), typeof(int)))
			{
				List<object> list2 = (List<object>)ToLua.ToObject(L, 1);
				object[] array2 = ToLua.CheckObjectArray(L, 2);
				int arrayIndex = (int)LuaDLL.lua_tonumber(L, 3);
				list2.CopyTo(array2, arrayIndex);
				result = 0;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(List<object>), typeof(int), typeof(object[]), typeof(int), typeof(int)))
			{
				List<object> list3 = (List<object>)ToLua.ToObject(L, 1);
				int index = (int)LuaDLL.lua_tonumber(L, 2);
				object[] array3 = ToLua.CheckObjectArray(L, 3);
				int arrayIndex2 = (int)LuaDLL.lua_tonumber(L, 4);
				int count = (int)LuaDLL.lua_tonumber(L, 5);
				list3.CopyTo(index, array3, arrayIndex2, count);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<object>.CopyTo");
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
			List<object> list = (List<object>)ToLua.CheckObject(L, 1, typeof(List<object>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Predicate<object> match;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				match = (Predicate<object>)ToLua.CheckObject(L, 2, typeof(Predicate<object>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				match = (DelegateFactory.CreateDelegate(typeof(Predicate<object>), func) as Predicate<object>);
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
			List<object> list = (List<object>)ToLua.CheckObject(L, 1, typeof(List<object>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Predicate<object> match;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				match = (Predicate<object>)ToLua.CheckObject(L, 2, typeof(Predicate<object>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				match = (DelegateFactory.CreateDelegate(typeof(Predicate<object>), func) as Predicate<object>);
			}
			object obj = list.Find(match);
			ToLua.Push(L, obj);
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
			List<object> list = (List<object>)ToLua.CheckObject(L, 1, typeof(List<object>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Predicate<object> match;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				match = (Predicate<object>)ToLua.CheckObject(L, 2, typeof(Predicate<object>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				match = (DelegateFactory.CreateDelegate(typeof(Predicate<object>), func) as Predicate<object>);
			}
			List<object> o = list.FindAll(match);
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
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<object>), typeof(Predicate<object>)))
			{
				List<object> list = (List<object>)ToLua.ToObject(L, 1);
				LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
				Predicate<object> match;
				if (luaTypes != LuaTypes.LUA_TFUNCTION)
				{
					match = (Predicate<object>)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func = ToLua.ToLuaFunction(L, 2);
					match = (DelegateFactory.CreateDelegate(typeof(Predicate<object>), func) as Predicate<object>);
				}
				int n = list.FindIndex(match);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<object>), typeof(int), typeof(Predicate<object>)))
			{
				List<object> list2 = (List<object>)ToLua.ToObject(L, 1);
				int startIndex = (int)LuaDLL.lua_tonumber(L, 2);
				LuaTypes luaTypes2 = LuaDLL.lua_type(L, 3);
				Predicate<object> match2;
				if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
				{
					match2 = (Predicate<object>)ToLua.ToObject(L, 3);
				}
				else
				{
					LuaFunction func2 = ToLua.ToLuaFunction(L, 3);
					match2 = (DelegateFactory.CreateDelegate(typeof(Predicate<object>), func2) as Predicate<object>);
				}
				int n2 = list2.FindIndex(startIndex, match2);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(List<object>), typeof(int), typeof(int), typeof(Predicate<object>)))
			{
				List<object> list3 = (List<object>)ToLua.ToObject(L, 1);
				int startIndex2 = (int)LuaDLL.lua_tonumber(L, 2);
				int count = (int)LuaDLL.lua_tonumber(L, 3);
				LuaTypes luaTypes3 = LuaDLL.lua_type(L, 4);
				Predicate<object> match3;
				if (luaTypes3 != LuaTypes.LUA_TFUNCTION)
				{
					match3 = (Predicate<object>)ToLua.ToObject(L, 4);
				}
				else
				{
					LuaFunction func3 = ToLua.ToLuaFunction(L, 4);
					match3 = (DelegateFactory.CreateDelegate(typeof(Predicate<object>), func3) as Predicate<object>);
				}
				int n3 = list3.FindIndex(startIndex2, count, match3);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<object>.FindIndex");
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
			List<object> list = (List<object>)ToLua.CheckObject(L, 1, typeof(List<object>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Predicate<object> match;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				match = (Predicate<object>)ToLua.CheckObject(L, 2, typeof(Predicate<object>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				match = (DelegateFactory.CreateDelegate(typeof(Predicate<object>), func) as Predicate<object>);
			}
			object obj = list.FindLast(match);
			ToLua.Push(L, obj);
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
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<object>), typeof(Predicate<object>)))
			{
				List<object> list = (List<object>)ToLua.ToObject(L, 1);
				LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
				Predicate<object> match;
				if (luaTypes != LuaTypes.LUA_TFUNCTION)
				{
					match = (Predicate<object>)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func = ToLua.ToLuaFunction(L, 2);
					match = (DelegateFactory.CreateDelegate(typeof(Predicate<object>), func) as Predicate<object>);
				}
				int n = list.FindLastIndex(match);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<object>), typeof(int), typeof(Predicate<object>)))
			{
				List<object> list2 = (List<object>)ToLua.ToObject(L, 1);
				int startIndex = (int)LuaDLL.lua_tonumber(L, 2);
				LuaTypes luaTypes2 = LuaDLL.lua_type(L, 3);
				Predicate<object> match2;
				if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
				{
					match2 = (Predicate<object>)ToLua.ToObject(L, 3);
				}
				else
				{
					LuaFunction func2 = ToLua.ToLuaFunction(L, 3);
					match2 = (DelegateFactory.CreateDelegate(typeof(Predicate<object>), func2) as Predicate<object>);
				}
				int n2 = list2.FindLastIndex(startIndex, match2);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(List<object>), typeof(int), typeof(int), typeof(Predicate<object>)))
			{
				List<object> list3 = (List<object>)ToLua.ToObject(L, 1);
				int startIndex2 = (int)LuaDLL.lua_tonumber(L, 2);
				int count = (int)LuaDLL.lua_tonumber(L, 3);
				LuaTypes luaTypes3 = LuaDLL.lua_type(L, 4);
				Predicate<object> match3;
				if (luaTypes3 != LuaTypes.LUA_TFUNCTION)
				{
					match3 = (Predicate<object>)ToLua.ToObject(L, 4);
				}
				else
				{
					LuaFunction func3 = ToLua.ToLuaFunction(L, 4);
					match3 = (DelegateFactory.CreateDelegate(typeof(Predicate<object>), func3) as Predicate<object>);
				}
				int n3 = list3.FindLastIndex(startIndex2, count, match3);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<object>.FindLastIndex");
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
			List<object> list = (List<object>)ToLua.CheckObject(L, 1, typeof(List<object>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action<object> action;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				action = (Action<object>)ToLua.CheckObject(L, 2, typeof(Action<object>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				action = (DelegateFactory.CreateDelegate(typeof(Action<object>), func) as Action<object>);
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
			List<object> list = (List<object>)ToLua.CheckObject(L, 1, typeof(List<object>));
			List<object>.Enumerator enumerator = list.GetEnumerator();
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
			List<object> list = (List<object>)ToLua.CheckObject(L, 1, typeof(List<object>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			int count = (int)LuaDLL.luaL_checknumber(L, 3);
			List<object> range = list.GetRange(index, count);
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
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<object>), typeof(object)))
			{
				List<object> list = (List<object>)ToLua.ToObject(L, 1);
				object item = ToLua.ToVarObject(L, 2);
				int n = list.IndexOf(item);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<object>), typeof(object), typeof(int)))
			{
				List<object> list2 = (List<object>)ToLua.ToObject(L, 1);
				object item2 = ToLua.ToVarObject(L, 2);
				int index = (int)LuaDLL.lua_tonumber(L, 3);
				int n2 = list2.IndexOf(item2, index);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(List<object>), typeof(object), typeof(int), typeof(int)))
			{
				List<object> list3 = (List<object>)ToLua.ToObject(L, 1);
				object item3 = ToLua.ToVarObject(L, 2);
				int index2 = (int)LuaDLL.lua_tonumber(L, 3);
				int count = (int)LuaDLL.lua_tonumber(L, 4);
				int n3 = list3.IndexOf(item3, index2, count);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<object>.IndexOf");
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
			List<object> list = (List<object>)ToLua.CheckObject(L, 1, typeof(List<object>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			object item = ToLua.ToVarObject(L, 3);
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
			List<object> list = (List<object>)ToLua.CheckObject(L, 1, typeof(List<object>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			IEnumerable<object> collection = (IEnumerable<object>)ToLua.CheckObject(L, 3, typeof(IEnumerable<object>));
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
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<object>), typeof(object)))
			{
				List<object> list = (List<object>)ToLua.ToObject(L, 1);
				object item = ToLua.ToVarObject(L, 2);
				int n = list.LastIndexOf(item);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<object>), typeof(object), typeof(int)))
			{
				List<object> list2 = (List<object>)ToLua.ToObject(L, 1);
				object item2 = ToLua.ToVarObject(L, 2);
				int index = (int)LuaDLL.lua_tonumber(L, 3);
				int n2 = list2.LastIndexOf(item2, index);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(List<object>), typeof(object), typeof(int), typeof(int)))
			{
				List<object> list3 = (List<object>)ToLua.ToObject(L, 1);
				object item3 = ToLua.ToVarObject(L, 2);
				int index2 = (int)LuaDLL.lua_tonumber(L, 3);
				int count = (int)LuaDLL.lua_tonumber(L, 4);
				int n3 = list3.LastIndexOf(item3, index2, count);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<object>.LastIndexOf");
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
			List<object> list = (List<object>)ToLua.CheckObject(L, 1, typeof(List<object>));
			object item = ToLua.ToVarObject(L, 2);
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
			List<object> list = (List<object>)ToLua.CheckObject(L, 1, typeof(List<object>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Predicate<object> match;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				match = (Predicate<object>)ToLua.CheckObject(L, 2, typeof(Predicate<object>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				match = (DelegateFactory.CreateDelegate(typeof(Predicate<object>), func) as Predicate<object>);
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
			List<object> list = (List<object>)ToLua.CheckObject(L, 1, typeof(List<object>));
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
			List<object> list = (List<object>)ToLua.CheckObject(L, 1, typeof(List<object>));
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
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(List<object>)))
			{
				List<object> list = (List<object>)ToLua.ToObject(L, 1);
				list.Reverse();
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<object>), typeof(int), typeof(int)))
			{
				List<object> list2 = (List<object>)ToLua.ToObject(L, 1);
				int index = (int)LuaDLL.lua_tonumber(L, 2);
				int count = (int)LuaDLL.lua_tonumber(L, 3);
				list2.Reverse(index, count);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<object>.Reverse");
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
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(List<object>)))
			{
				List<object> list = (List<object>)ToLua.ToObject(L, 1);
				list.Sort();
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<object>), typeof(Comparison<object>)))
			{
				List<object> list2 = (List<object>)ToLua.ToObject(L, 1);
				LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
				Comparison<object> comparison;
				if (luaTypes != LuaTypes.LUA_TFUNCTION)
				{
					comparison = (Comparison<object>)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func = ToLua.ToLuaFunction(L, 2);
					comparison = (DelegateFactory.CreateDelegate(typeof(Comparison<object>), func) as Comparison<object>);
				}
				list2.Sort(comparison);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<object>), typeof(IComparer<object>)))
			{
				List<object> list3 = (List<object>)ToLua.ToObject(L, 1);
				IComparer<object> comparer = (IComparer<object>)ToLua.ToObject(L, 2);
				list3.Sort(comparer);
				result = 0;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(List<object>), typeof(int), typeof(int), typeof(IComparer<object>)))
			{
				List<object> list4 = (List<object>)ToLua.ToObject(L, 1);
				int index = (int)LuaDLL.lua_tonumber(L, 2);
				int count = (int)LuaDLL.lua_tonumber(L, 3);
				IComparer<object> comparer2 = (IComparer<object>)ToLua.ToObject(L, 4);
				list4.Sort(index, count, comparer2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<object>.Sort");
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
			List<object> list = (List<object>)ToLua.CheckObject(L, 1, typeof(List<object>));
			object[] array = list.ToArray();
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
			List<object> list = (List<object>)ToLua.CheckObject(L, 1, typeof(List<object>));
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
			List<object> list = (List<object>)ToLua.CheckObject(L, 1, typeof(List<object>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Predicate<object> match;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				match = (Predicate<object>)ToLua.CheckObject(L, 2, typeof(Predicate<object>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				match = (DelegateFactory.CreateDelegate(typeof(Predicate<object>), func) as Predicate<object>);
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
			List<object> list = (List<object>)ToLua.CheckObject(L, 1, typeof(List<object>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			object obj = list[index];
			ToLua.Push(L, obj);
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
			List<object> list = (List<object>)ToLua.CheckObject(L, 1, typeof(List<object>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			object value = ToLua.ToVarObject(L, 3);
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
			List<object> list = (List<object>)obj;
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
			List<object> list = (List<object>)obj;
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
			List<object> list = (List<object>)obj;
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
