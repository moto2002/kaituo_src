using LuaInterface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class System_Collections_Generic_List_UIRootWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(List<UIRoot>), typeof(object), "List_UIRoot");
		L.RegFunction("Add", new LuaCSFunction(System_Collections_Generic_List_UIRootWrap.Add));
		L.RegFunction("AddRange", new LuaCSFunction(System_Collections_Generic_List_UIRootWrap.AddRange));
		L.RegFunction("AsReadOnly", new LuaCSFunction(System_Collections_Generic_List_UIRootWrap.AsReadOnly));
		L.RegFunction("BinarySearch", new LuaCSFunction(System_Collections_Generic_List_UIRootWrap.BinarySearch));
		L.RegFunction("Clear", new LuaCSFunction(System_Collections_Generic_List_UIRootWrap.Clear));
		L.RegFunction("Contains", new LuaCSFunction(System_Collections_Generic_List_UIRootWrap.Contains));
		L.RegFunction("CopyTo", new LuaCSFunction(System_Collections_Generic_List_UIRootWrap.CopyTo));
		L.RegFunction("Exists", new LuaCSFunction(System_Collections_Generic_List_UIRootWrap.Exists));
		L.RegFunction("Find", new LuaCSFunction(System_Collections_Generic_List_UIRootWrap.Find));
		L.RegFunction("FindAll", new LuaCSFunction(System_Collections_Generic_List_UIRootWrap.FindAll));
		L.RegFunction("FindIndex", new LuaCSFunction(System_Collections_Generic_List_UIRootWrap.FindIndex));
		L.RegFunction("FindLast", new LuaCSFunction(System_Collections_Generic_List_UIRootWrap.FindLast));
		L.RegFunction("FindLastIndex", new LuaCSFunction(System_Collections_Generic_List_UIRootWrap.FindLastIndex));
		L.RegFunction("ForEach", new LuaCSFunction(System_Collections_Generic_List_UIRootWrap.ForEach));
		L.RegFunction("GetEnumerator", new LuaCSFunction(System_Collections_Generic_List_UIRootWrap.GetEnumerator));
		L.RegFunction("GetRange", new LuaCSFunction(System_Collections_Generic_List_UIRootWrap.GetRange));
		L.RegFunction("IndexOf", new LuaCSFunction(System_Collections_Generic_List_UIRootWrap.IndexOf));
		L.RegFunction("Insert", new LuaCSFunction(System_Collections_Generic_List_UIRootWrap.Insert));
		L.RegFunction("InsertRange", new LuaCSFunction(System_Collections_Generic_List_UIRootWrap.InsertRange));
		L.RegFunction("LastIndexOf", new LuaCSFunction(System_Collections_Generic_List_UIRootWrap.LastIndexOf));
		L.RegFunction("Remove", new LuaCSFunction(System_Collections_Generic_List_UIRootWrap.Remove));
		L.RegFunction("RemoveAll", new LuaCSFunction(System_Collections_Generic_List_UIRootWrap.RemoveAll));
		L.RegFunction("RemoveAt", new LuaCSFunction(System_Collections_Generic_List_UIRootWrap.RemoveAt));
		L.RegFunction("RemoveRange", new LuaCSFunction(System_Collections_Generic_List_UIRootWrap.RemoveRange));
		L.RegFunction("Reverse", new LuaCSFunction(System_Collections_Generic_List_UIRootWrap.Reverse));
		L.RegFunction("Sort", new LuaCSFunction(System_Collections_Generic_List_UIRootWrap.Sort));
		L.RegFunction("ToArray", new LuaCSFunction(System_Collections_Generic_List_UIRootWrap.ToArray));
		L.RegFunction("TrimExcess", new LuaCSFunction(System_Collections_Generic_List_UIRootWrap.TrimExcess));
		L.RegFunction("TrueForAll", new LuaCSFunction(System_Collections_Generic_List_UIRootWrap.TrueForAll));
		L.RegFunction(".geti", new LuaCSFunction(System_Collections_Generic_List_UIRootWrap.get_Item));
		L.RegFunction("get_Item", new LuaCSFunction(System_Collections_Generic_List_UIRootWrap.get_Item));
		L.RegFunction(".seti", new LuaCSFunction(System_Collections_Generic_List_UIRootWrap.set_Item));
		L.RegFunction("set_Item", new LuaCSFunction(System_Collections_Generic_List_UIRootWrap.set_Item));
		L.RegFunction("New", new LuaCSFunction(System_Collections_Generic_List_UIRootWrap._CreateSystem_Collections_Generic_List_UIRoot));
		L.RegVar("this", new LuaCSFunction(System_Collections_Generic_List_UIRootWrap._this), null);
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Capacity", new LuaCSFunction(System_Collections_Generic_List_UIRootWrap.get_Capacity), new LuaCSFunction(System_Collections_Generic_List_UIRootWrap.set_Capacity));
		L.RegVar("Count", new LuaCSFunction(System_Collections_Generic_List_UIRootWrap.get_Count), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateSystem_Collections_Generic_List_UIRoot(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 0)
			{
				List<UIRoot> o = new List<UIRoot>();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(int)))
			{
				int capacity = (int)LuaDLL.luaL_checknumber(L, 1);
				List<UIRoot> o2 = new List<UIRoot>(capacity);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(IEnumerable<UIRoot>)))
			{
				IEnumerable<UIRoot> collection = (IEnumerable<UIRoot>)ToLua.CheckObject(L, 1, typeof(IEnumerable<UIRoot>));
				List<UIRoot> o3 = new List<UIRoot>(collection);
				ToLua.PushObject(L, o3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: System.Collections.Generic.List<UIRoot>.New");
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
			List<UIRoot> list = (List<UIRoot>)ToLua.CheckObject(L, 1, typeof(List<UIRoot>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			UIRoot obj = list[index];
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
			List<UIRoot> list = (List<UIRoot>)ToLua.CheckObject(L, 1, typeof(List<UIRoot>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			UIRoot value = (UIRoot)ToLua.CheckUnityObject(L, 3, typeof(UIRoot));
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
			LuaDLL.tolua_bindthis(L, new LuaCSFunction(System_Collections_Generic_List_UIRootWrap._get_this), new LuaCSFunction(System_Collections_Generic_List_UIRootWrap._set_this));
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
			List<UIRoot> list = (List<UIRoot>)ToLua.CheckObject(L, 1, typeof(List<UIRoot>));
			UIRoot item = (UIRoot)ToLua.CheckUnityObject(L, 2, typeof(UIRoot));
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
			List<UIRoot> list = (List<UIRoot>)ToLua.CheckObject(L, 1, typeof(List<UIRoot>));
			IEnumerable<UIRoot> collection = (IEnumerable<UIRoot>)ToLua.CheckObject(L, 2, typeof(IEnumerable<UIRoot>));
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
			List<UIRoot> list = (List<UIRoot>)ToLua.CheckObject(L, 1, typeof(List<UIRoot>));
			ReadOnlyCollection<UIRoot> o = list.AsReadOnly();
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
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<UIRoot>), typeof(UIRoot)))
			{
				List<UIRoot> list = (List<UIRoot>)ToLua.ToObject(L, 1);
				UIRoot item = (UIRoot)ToLua.ToObject(L, 2);
				int n = list.BinarySearch(item);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<UIRoot>), typeof(UIRoot), typeof(IComparer<UIRoot>)))
			{
				List<UIRoot> list2 = (List<UIRoot>)ToLua.ToObject(L, 1);
				UIRoot item2 = (UIRoot)ToLua.ToObject(L, 2);
				IComparer<UIRoot> comparer = (IComparer<UIRoot>)ToLua.ToObject(L, 3);
				int n2 = list2.BinarySearch(item2, comparer);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(List<UIRoot>), typeof(int), typeof(int), typeof(UIRoot), typeof(IComparer<UIRoot>)))
			{
				List<UIRoot> list3 = (List<UIRoot>)ToLua.ToObject(L, 1);
				int index = (int)LuaDLL.lua_tonumber(L, 2);
				int count = (int)LuaDLL.lua_tonumber(L, 3);
				UIRoot item3 = (UIRoot)ToLua.ToObject(L, 4);
				IComparer<UIRoot> comparer2 = (IComparer<UIRoot>)ToLua.ToObject(L, 5);
				int n3 = list3.BinarySearch(index, count, item3, comparer2);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<UIRoot>.BinarySearch");
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
			List<UIRoot> list = (List<UIRoot>)ToLua.CheckObject(L, 1, typeof(List<UIRoot>));
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
			List<UIRoot> list = (List<UIRoot>)ToLua.CheckObject(L, 1, typeof(List<UIRoot>));
			UIRoot item = (UIRoot)ToLua.CheckUnityObject(L, 2, typeof(UIRoot));
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
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<UIRoot>), typeof(UIRoot[])))
			{
				List<UIRoot> list = (List<UIRoot>)ToLua.ToObject(L, 1);
				UIRoot[] array = ToLua.CheckObjectArray<UIRoot>(L, 2);
				list.CopyTo(array);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<UIRoot>), typeof(UIRoot[]), typeof(int)))
			{
				List<UIRoot> list2 = (List<UIRoot>)ToLua.ToObject(L, 1);
				UIRoot[] array2 = ToLua.CheckObjectArray<UIRoot>(L, 2);
				int arrayIndex = (int)LuaDLL.lua_tonumber(L, 3);
				list2.CopyTo(array2, arrayIndex);
				result = 0;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(List<UIRoot>), typeof(int), typeof(UIRoot[]), typeof(int), typeof(int)))
			{
				List<UIRoot> list3 = (List<UIRoot>)ToLua.ToObject(L, 1);
				int index = (int)LuaDLL.lua_tonumber(L, 2);
				UIRoot[] array3 = ToLua.CheckObjectArray<UIRoot>(L, 3);
				int arrayIndex2 = (int)LuaDLL.lua_tonumber(L, 4);
				int count = (int)LuaDLL.lua_tonumber(L, 5);
				list3.CopyTo(index, array3, arrayIndex2, count);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<UIRoot>.CopyTo");
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
			List<UIRoot> list = (List<UIRoot>)ToLua.CheckObject(L, 1, typeof(List<UIRoot>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Predicate<UIRoot> match;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				match = (Predicate<UIRoot>)ToLua.CheckObject(L, 2, typeof(Predicate<UIRoot>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				match = (DelegateFactory.CreateDelegate(typeof(Predicate<UIRoot>), func) as Predicate<UIRoot>);
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
			List<UIRoot> list = (List<UIRoot>)ToLua.CheckObject(L, 1, typeof(List<UIRoot>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Predicate<UIRoot> match;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				match = (Predicate<UIRoot>)ToLua.CheckObject(L, 2, typeof(Predicate<UIRoot>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				match = (DelegateFactory.CreateDelegate(typeof(Predicate<UIRoot>), func) as Predicate<UIRoot>);
			}
			UIRoot obj = list.Find(match);
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
			List<UIRoot> list = (List<UIRoot>)ToLua.CheckObject(L, 1, typeof(List<UIRoot>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Predicate<UIRoot> match;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				match = (Predicate<UIRoot>)ToLua.CheckObject(L, 2, typeof(Predicate<UIRoot>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				match = (DelegateFactory.CreateDelegate(typeof(Predicate<UIRoot>), func) as Predicate<UIRoot>);
			}
			List<UIRoot> o = list.FindAll(match);
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
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<UIRoot>), typeof(Predicate<UIRoot>)))
			{
				List<UIRoot> list = (List<UIRoot>)ToLua.ToObject(L, 1);
				LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
				Predicate<UIRoot> match;
				if (luaTypes != LuaTypes.LUA_TFUNCTION)
				{
					match = (Predicate<UIRoot>)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func = ToLua.ToLuaFunction(L, 2);
					match = (DelegateFactory.CreateDelegate(typeof(Predicate<UIRoot>), func) as Predicate<UIRoot>);
				}
				int n = list.FindIndex(match);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<UIRoot>), typeof(int), typeof(Predicate<UIRoot>)))
			{
				List<UIRoot> list2 = (List<UIRoot>)ToLua.ToObject(L, 1);
				int startIndex = (int)LuaDLL.lua_tonumber(L, 2);
				LuaTypes luaTypes2 = LuaDLL.lua_type(L, 3);
				Predicate<UIRoot> match2;
				if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
				{
					match2 = (Predicate<UIRoot>)ToLua.ToObject(L, 3);
				}
				else
				{
					LuaFunction func2 = ToLua.ToLuaFunction(L, 3);
					match2 = (DelegateFactory.CreateDelegate(typeof(Predicate<UIRoot>), func2) as Predicate<UIRoot>);
				}
				int n2 = list2.FindIndex(startIndex, match2);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(List<UIRoot>), typeof(int), typeof(int), typeof(Predicate<UIRoot>)))
			{
				List<UIRoot> list3 = (List<UIRoot>)ToLua.ToObject(L, 1);
				int startIndex2 = (int)LuaDLL.lua_tonumber(L, 2);
				int count = (int)LuaDLL.lua_tonumber(L, 3);
				LuaTypes luaTypes3 = LuaDLL.lua_type(L, 4);
				Predicate<UIRoot> match3;
				if (luaTypes3 != LuaTypes.LUA_TFUNCTION)
				{
					match3 = (Predicate<UIRoot>)ToLua.ToObject(L, 4);
				}
				else
				{
					LuaFunction func3 = ToLua.ToLuaFunction(L, 4);
					match3 = (DelegateFactory.CreateDelegate(typeof(Predicate<UIRoot>), func3) as Predicate<UIRoot>);
				}
				int n3 = list3.FindIndex(startIndex2, count, match3);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<UIRoot>.FindIndex");
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
			List<UIRoot> list = (List<UIRoot>)ToLua.CheckObject(L, 1, typeof(List<UIRoot>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Predicate<UIRoot> match;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				match = (Predicate<UIRoot>)ToLua.CheckObject(L, 2, typeof(Predicate<UIRoot>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				match = (DelegateFactory.CreateDelegate(typeof(Predicate<UIRoot>), func) as Predicate<UIRoot>);
			}
			UIRoot obj = list.FindLast(match);
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
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<UIRoot>), typeof(Predicate<UIRoot>)))
			{
				List<UIRoot> list = (List<UIRoot>)ToLua.ToObject(L, 1);
				LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
				Predicate<UIRoot> match;
				if (luaTypes != LuaTypes.LUA_TFUNCTION)
				{
					match = (Predicate<UIRoot>)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func = ToLua.ToLuaFunction(L, 2);
					match = (DelegateFactory.CreateDelegate(typeof(Predicate<UIRoot>), func) as Predicate<UIRoot>);
				}
				int n = list.FindLastIndex(match);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<UIRoot>), typeof(int), typeof(Predicate<UIRoot>)))
			{
				List<UIRoot> list2 = (List<UIRoot>)ToLua.ToObject(L, 1);
				int startIndex = (int)LuaDLL.lua_tonumber(L, 2);
				LuaTypes luaTypes2 = LuaDLL.lua_type(L, 3);
				Predicate<UIRoot> match2;
				if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
				{
					match2 = (Predicate<UIRoot>)ToLua.ToObject(L, 3);
				}
				else
				{
					LuaFunction func2 = ToLua.ToLuaFunction(L, 3);
					match2 = (DelegateFactory.CreateDelegate(typeof(Predicate<UIRoot>), func2) as Predicate<UIRoot>);
				}
				int n2 = list2.FindLastIndex(startIndex, match2);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(List<UIRoot>), typeof(int), typeof(int), typeof(Predicate<UIRoot>)))
			{
				List<UIRoot> list3 = (List<UIRoot>)ToLua.ToObject(L, 1);
				int startIndex2 = (int)LuaDLL.lua_tonumber(L, 2);
				int count = (int)LuaDLL.lua_tonumber(L, 3);
				LuaTypes luaTypes3 = LuaDLL.lua_type(L, 4);
				Predicate<UIRoot> match3;
				if (luaTypes3 != LuaTypes.LUA_TFUNCTION)
				{
					match3 = (Predicate<UIRoot>)ToLua.ToObject(L, 4);
				}
				else
				{
					LuaFunction func3 = ToLua.ToLuaFunction(L, 4);
					match3 = (DelegateFactory.CreateDelegate(typeof(Predicate<UIRoot>), func3) as Predicate<UIRoot>);
				}
				int n3 = list3.FindLastIndex(startIndex2, count, match3);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<UIRoot>.FindLastIndex");
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
			List<UIRoot> list = (List<UIRoot>)ToLua.CheckObject(L, 1, typeof(List<UIRoot>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action<UIRoot> action;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				action = (Action<UIRoot>)ToLua.CheckObject(L, 2, typeof(Action<UIRoot>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				action = (DelegateFactory.CreateDelegate(typeof(Action<UIRoot>), func) as Action<UIRoot>);
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
			List<UIRoot> list = (List<UIRoot>)ToLua.CheckObject(L, 1, typeof(List<UIRoot>));
			List<UIRoot>.Enumerator enumerator = list.GetEnumerator();
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
			List<UIRoot> list = (List<UIRoot>)ToLua.CheckObject(L, 1, typeof(List<UIRoot>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			int count = (int)LuaDLL.luaL_checknumber(L, 3);
			List<UIRoot> range = list.GetRange(index, count);
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
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<UIRoot>), typeof(UIRoot)))
			{
				List<UIRoot> list = (List<UIRoot>)ToLua.ToObject(L, 1);
				UIRoot item = (UIRoot)ToLua.ToObject(L, 2);
				int n = list.IndexOf(item);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<UIRoot>), typeof(UIRoot), typeof(int)))
			{
				List<UIRoot> list2 = (List<UIRoot>)ToLua.ToObject(L, 1);
				UIRoot item2 = (UIRoot)ToLua.ToObject(L, 2);
				int index = (int)LuaDLL.lua_tonumber(L, 3);
				int n2 = list2.IndexOf(item2, index);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(List<UIRoot>), typeof(UIRoot), typeof(int), typeof(int)))
			{
				List<UIRoot> list3 = (List<UIRoot>)ToLua.ToObject(L, 1);
				UIRoot item3 = (UIRoot)ToLua.ToObject(L, 2);
				int index2 = (int)LuaDLL.lua_tonumber(L, 3);
				int count = (int)LuaDLL.lua_tonumber(L, 4);
				int n3 = list3.IndexOf(item3, index2, count);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<UIRoot>.IndexOf");
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
			List<UIRoot> list = (List<UIRoot>)ToLua.CheckObject(L, 1, typeof(List<UIRoot>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			UIRoot item = (UIRoot)ToLua.CheckUnityObject(L, 3, typeof(UIRoot));
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
			List<UIRoot> list = (List<UIRoot>)ToLua.CheckObject(L, 1, typeof(List<UIRoot>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			IEnumerable<UIRoot> collection = (IEnumerable<UIRoot>)ToLua.CheckObject(L, 3, typeof(IEnumerable<UIRoot>));
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
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<UIRoot>), typeof(UIRoot)))
			{
				List<UIRoot> list = (List<UIRoot>)ToLua.ToObject(L, 1);
				UIRoot item = (UIRoot)ToLua.ToObject(L, 2);
				int n = list.LastIndexOf(item);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<UIRoot>), typeof(UIRoot), typeof(int)))
			{
				List<UIRoot> list2 = (List<UIRoot>)ToLua.ToObject(L, 1);
				UIRoot item2 = (UIRoot)ToLua.ToObject(L, 2);
				int index = (int)LuaDLL.lua_tonumber(L, 3);
				int n2 = list2.LastIndexOf(item2, index);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(List<UIRoot>), typeof(UIRoot), typeof(int), typeof(int)))
			{
				List<UIRoot> list3 = (List<UIRoot>)ToLua.ToObject(L, 1);
				UIRoot item3 = (UIRoot)ToLua.ToObject(L, 2);
				int index2 = (int)LuaDLL.lua_tonumber(L, 3);
				int count = (int)LuaDLL.lua_tonumber(L, 4);
				int n3 = list3.LastIndexOf(item3, index2, count);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<UIRoot>.LastIndexOf");
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
			List<UIRoot> list = (List<UIRoot>)ToLua.CheckObject(L, 1, typeof(List<UIRoot>));
			UIRoot item = (UIRoot)ToLua.CheckUnityObject(L, 2, typeof(UIRoot));
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
			List<UIRoot> list = (List<UIRoot>)ToLua.CheckObject(L, 1, typeof(List<UIRoot>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Predicate<UIRoot> match;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				match = (Predicate<UIRoot>)ToLua.CheckObject(L, 2, typeof(Predicate<UIRoot>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				match = (DelegateFactory.CreateDelegate(typeof(Predicate<UIRoot>), func) as Predicate<UIRoot>);
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
			List<UIRoot> list = (List<UIRoot>)ToLua.CheckObject(L, 1, typeof(List<UIRoot>));
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
			List<UIRoot> list = (List<UIRoot>)ToLua.CheckObject(L, 1, typeof(List<UIRoot>));
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
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(List<UIRoot>)))
			{
				List<UIRoot> list = (List<UIRoot>)ToLua.ToObject(L, 1);
				list.Reverse();
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<UIRoot>), typeof(int), typeof(int)))
			{
				List<UIRoot> list2 = (List<UIRoot>)ToLua.ToObject(L, 1);
				int index = (int)LuaDLL.lua_tonumber(L, 2);
				int count = (int)LuaDLL.lua_tonumber(L, 3);
				list2.Reverse(index, count);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<UIRoot>.Reverse");
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
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(List<UIRoot>)))
			{
				List<UIRoot> list = (List<UIRoot>)ToLua.ToObject(L, 1);
				list.Sort();
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<UIRoot>), typeof(Comparison<UIRoot>)))
			{
				List<UIRoot> list2 = (List<UIRoot>)ToLua.ToObject(L, 1);
				LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
				Comparison<UIRoot> comparison;
				if (luaTypes != LuaTypes.LUA_TFUNCTION)
				{
					comparison = (Comparison<UIRoot>)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func = ToLua.ToLuaFunction(L, 2);
					comparison = (DelegateFactory.CreateDelegate(typeof(Comparison<UIRoot>), func) as Comparison<UIRoot>);
				}
				list2.Sort(comparison);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<UIRoot>), typeof(IComparer<UIRoot>)))
			{
				List<UIRoot> list3 = (List<UIRoot>)ToLua.ToObject(L, 1);
				IComparer<UIRoot> comparer = (IComparer<UIRoot>)ToLua.ToObject(L, 2);
				list3.Sort(comparer);
				result = 0;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(List<UIRoot>), typeof(int), typeof(int), typeof(IComparer<UIRoot>)))
			{
				List<UIRoot> list4 = (List<UIRoot>)ToLua.ToObject(L, 1);
				int index = (int)LuaDLL.lua_tonumber(L, 2);
				int count = (int)LuaDLL.lua_tonumber(L, 3);
				IComparer<UIRoot> comparer2 = (IComparer<UIRoot>)ToLua.ToObject(L, 4);
				list4.Sort(index, count, comparer2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<UIRoot>.Sort");
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
			List<UIRoot> list = (List<UIRoot>)ToLua.CheckObject(L, 1, typeof(List<UIRoot>));
			UIRoot[] array = list.ToArray();
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
			List<UIRoot> list = (List<UIRoot>)ToLua.CheckObject(L, 1, typeof(List<UIRoot>));
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
			List<UIRoot> list = (List<UIRoot>)ToLua.CheckObject(L, 1, typeof(List<UIRoot>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Predicate<UIRoot> match;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				match = (Predicate<UIRoot>)ToLua.CheckObject(L, 2, typeof(Predicate<UIRoot>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				match = (DelegateFactory.CreateDelegate(typeof(Predicate<UIRoot>), func) as Predicate<UIRoot>);
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
			List<UIRoot> list = (List<UIRoot>)ToLua.CheckObject(L, 1, typeof(List<UIRoot>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			UIRoot obj = list[index];
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
			List<UIRoot> list = (List<UIRoot>)ToLua.CheckObject(L, 1, typeof(List<UIRoot>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			UIRoot value = (UIRoot)ToLua.CheckUnityObject(L, 3, typeof(UIRoot));
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
			List<UIRoot> list = (List<UIRoot>)obj;
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
			List<UIRoot> list = (List<UIRoot>)obj;
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
			List<UIRoot> list = (List<UIRoot>)obj;
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
