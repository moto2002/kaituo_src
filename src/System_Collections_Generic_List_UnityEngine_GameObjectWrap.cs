using LuaInterface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class System_Collections_Generic_List_UnityEngine_GameObjectWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(List<GameObject>), typeof(object), "List_UnityEngine_GameObject");
		L.RegFunction("Add", new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap.Add));
		L.RegFunction("AddRange", new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap.AddRange));
		L.RegFunction("AsReadOnly", new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap.AsReadOnly));
		L.RegFunction("BinarySearch", new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap.BinarySearch));
		L.RegFunction("Clear", new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap.Clear));
		L.RegFunction("Contains", new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap.Contains));
		L.RegFunction("CopyTo", new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap.CopyTo));
		L.RegFunction("Exists", new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap.Exists));
		L.RegFunction("Find", new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap.Find));
		L.RegFunction("FindAll", new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap.FindAll));
		L.RegFunction("FindIndex", new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap.FindIndex));
		L.RegFunction("FindLast", new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap.FindLast));
		L.RegFunction("FindLastIndex", new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap.FindLastIndex));
		L.RegFunction("ForEach", new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap.ForEach));
		L.RegFunction("GetEnumerator", new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap.GetEnumerator));
		L.RegFunction("GetRange", new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap.GetRange));
		L.RegFunction("IndexOf", new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap.IndexOf));
		L.RegFunction("Insert", new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap.Insert));
		L.RegFunction("InsertRange", new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap.InsertRange));
		L.RegFunction("LastIndexOf", new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap.LastIndexOf));
		L.RegFunction("Remove", new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap.Remove));
		L.RegFunction("RemoveAll", new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap.RemoveAll));
		L.RegFunction("RemoveAt", new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap.RemoveAt));
		L.RegFunction("RemoveRange", new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap.RemoveRange));
		L.RegFunction("Reverse", new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap.Reverse));
		L.RegFunction("Sort", new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap.Sort));
		L.RegFunction("ToArray", new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap.ToArray));
		L.RegFunction("TrimExcess", new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap.TrimExcess));
		L.RegFunction("TrueForAll", new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap.TrueForAll));
		L.RegFunction(".geti", new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap.get_Item));
		L.RegFunction("get_Item", new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap.get_Item));
		L.RegFunction(".seti", new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap.set_Item));
		L.RegFunction("set_Item", new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap.set_Item));
		L.RegFunction("New", new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap._CreateSystem_Collections_Generic_List_UnityEngine_GameObject));
		L.RegVar("this", new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap._this), null);
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Capacity", new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap.get_Capacity), new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap.set_Capacity));
		L.RegVar("Count", new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap.get_Count), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateSystem_Collections_Generic_List_UnityEngine_GameObject(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 0)
			{
				List<GameObject> o = new List<GameObject>();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(int)))
			{
				int capacity = (int)LuaDLL.luaL_checknumber(L, 1);
				List<GameObject> o2 = new List<GameObject>(capacity);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(IEnumerable<GameObject>)))
			{
				IEnumerable<GameObject> collection = (IEnumerable<GameObject>)ToLua.CheckObject(L, 1, typeof(IEnumerable<GameObject>));
				List<GameObject> o3 = new List<GameObject>(collection);
				ToLua.PushObject(L, o3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: System.Collections.Generic.List<UnityEngine.GameObject>.New");
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
			List<GameObject> list = (List<GameObject>)ToLua.CheckObject(L, 1, typeof(List<GameObject>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			GameObject obj = list[index];
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
			List<GameObject> list = (List<GameObject>)ToLua.CheckObject(L, 1, typeof(List<GameObject>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			GameObject value = (GameObject)ToLua.CheckUnityObject(L, 3, typeof(GameObject));
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
			LuaDLL.tolua_bindthis(L, new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap._get_this), new LuaCSFunction(System_Collections_Generic_List_UnityEngine_GameObjectWrap._set_this));
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
			List<GameObject> list = (List<GameObject>)ToLua.CheckObject(L, 1, typeof(List<GameObject>));
			GameObject item = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
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
			List<GameObject> list = (List<GameObject>)ToLua.CheckObject(L, 1, typeof(List<GameObject>));
			IEnumerable<GameObject> collection = (IEnumerable<GameObject>)ToLua.CheckObject(L, 2, typeof(IEnumerable<GameObject>));
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
			List<GameObject> list = (List<GameObject>)ToLua.CheckObject(L, 1, typeof(List<GameObject>));
			ReadOnlyCollection<GameObject> o = list.AsReadOnly();
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
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<GameObject>), typeof(GameObject)))
			{
				List<GameObject> list = (List<GameObject>)ToLua.ToObject(L, 1);
				GameObject item = (GameObject)ToLua.ToObject(L, 2);
				int n = list.BinarySearch(item);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<GameObject>), typeof(GameObject), typeof(IComparer<GameObject>)))
			{
				List<GameObject> list2 = (List<GameObject>)ToLua.ToObject(L, 1);
				GameObject item2 = (GameObject)ToLua.ToObject(L, 2);
				IComparer<GameObject> comparer = (IComparer<GameObject>)ToLua.ToObject(L, 3);
				int n2 = list2.BinarySearch(item2, comparer);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(List<GameObject>), typeof(int), typeof(int), typeof(GameObject), typeof(IComparer<GameObject>)))
			{
				List<GameObject> list3 = (List<GameObject>)ToLua.ToObject(L, 1);
				int index = (int)LuaDLL.lua_tonumber(L, 2);
				int count = (int)LuaDLL.lua_tonumber(L, 3);
				GameObject item3 = (GameObject)ToLua.ToObject(L, 4);
				IComparer<GameObject> comparer2 = (IComparer<GameObject>)ToLua.ToObject(L, 5);
				int n3 = list3.BinarySearch(index, count, item3, comparer2);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<UnityEngine.GameObject>.BinarySearch");
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
			List<GameObject> list = (List<GameObject>)ToLua.CheckObject(L, 1, typeof(List<GameObject>));
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
			List<GameObject> list = (List<GameObject>)ToLua.CheckObject(L, 1, typeof(List<GameObject>));
			GameObject item = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
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
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<GameObject>), typeof(GameObject[])))
			{
				List<GameObject> list = (List<GameObject>)ToLua.ToObject(L, 1);
				GameObject[] array = ToLua.CheckObjectArray<GameObject>(L, 2);
				list.CopyTo(array);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<GameObject>), typeof(GameObject[]), typeof(int)))
			{
				List<GameObject> list2 = (List<GameObject>)ToLua.ToObject(L, 1);
				GameObject[] array2 = ToLua.CheckObjectArray<GameObject>(L, 2);
				int arrayIndex = (int)LuaDLL.lua_tonumber(L, 3);
				list2.CopyTo(array2, arrayIndex);
				result = 0;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(List<GameObject>), typeof(int), typeof(GameObject[]), typeof(int), typeof(int)))
			{
				List<GameObject> list3 = (List<GameObject>)ToLua.ToObject(L, 1);
				int index = (int)LuaDLL.lua_tonumber(L, 2);
				GameObject[] array3 = ToLua.CheckObjectArray<GameObject>(L, 3);
				int arrayIndex2 = (int)LuaDLL.lua_tonumber(L, 4);
				int count = (int)LuaDLL.lua_tonumber(L, 5);
				list3.CopyTo(index, array3, arrayIndex2, count);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<UnityEngine.GameObject>.CopyTo");
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
			List<GameObject> list = (List<GameObject>)ToLua.CheckObject(L, 1, typeof(List<GameObject>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Predicate<GameObject> match;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				match = (Predicate<GameObject>)ToLua.CheckObject(L, 2, typeof(Predicate<GameObject>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				match = (DelegateFactory.CreateDelegate(typeof(Predicate<GameObject>), func) as Predicate<GameObject>);
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
			List<GameObject> list = (List<GameObject>)ToLua.CheckObject(L, 1, typeof(List<GameObject>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Predicate<GameObject> match;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				match = (Predicate<GameObject>)ToLua.CheckObject(L, 2, typeof(Predicate<GameObject>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				match = (DelegateFactory.CreateDelegate(typeof(Predicate<GameObject>), func) as Predicate<GameObject>);
			}
			GameObject obj = list.Find(match);
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
			List<GameObject> list = (List<GameObject>)ToLua.CheckObject(L, 1, typeof(List<GameObject>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Predicate<GameObject> match;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				match = (Predicate<GameObject>)ToLua.CheckObject(L, 2, typeof(Predicate<GameObject>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				match = (DelegateFactory.CreateDelegate(typeof(Predicate<GameObject>), func) as Predicate<GameObject>);
			}
			List<GameObject> o = list.FindAll(match);
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
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<GameObject>), typeof(Predicate<GameObject>)))
			{
				List<GameObject> list = (List<GameObject>)ToLua.ToObject(L, 1);
				LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
				Predicate<GameObject> match;
				if (luaTypes != LuaTypes.LUA_TFUNCTION)
				{
					match = (Predicate<GameObject>)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func = ToLua.ToLuaFunction(L, 2);
					match = (DelegateFactory.CreateDelegate(typeof(Predicate<GameObject>), func) as Predicate<GameObject>);
				}
				int n = list.FindIndex(match);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<GameObject>), typeof(int), typeof(Predicate<GameObject>)))
			{
				List<GameObject> list2 = (List<GameObject>)ToLua.ToObject(L, 1);
				int startIndex = (int)LuaDLL.lua_tonumber(L, 2);
				LuaTypes luaTypes2 = LuaDLL.lua_type(L, 3);
				Predicate<GameObject> match2;
				if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
				{
					match2 = (Predicate<GameObject>)ToLua.ToObject(L, 3);
				}
				else
				{
					LuaFunction func2 = ToLua.ToLuaFunction(L, 3);
					match2 = (DelegateFactory.CreateDelegate(typeof(Predicate<GameObject>), func2) as Predicate<GameObject>);
				}
				int n2 = list2.FindIndex(startIndex, match2);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(List<GameObject>), typeof(int), typeof(int), typeof(Predicate<GameObject>)))
			{
				List<GameObject> list3 = (List<GameObject>)ToLua.ToObject(L, 1);
				int startIndex2 = (int)LuaDLL.lua_tonumber(L, 2);
				int count = (int)LuaDLL.lua_tonumber(L, 3);
				LuaTypes luaTypes3 = LuaDLL.lua_type(L, 4);
				Predicate<GameObject> match3;
				if (luaTypes3 != LuaTypes.LUA_TFUNCTION)
				{
					match3 = (Predicate<GameObject>)ToLua.ToObject(L, 4);
				}
				else
				{
					LuaFunction func3 = ToLua.ToLuaFunction(L, 4);
					match3 = (DelegateFactory.CreateDelegate(typeof(Predicate<GameObject>), func3) as Predicate<GameObject>);
				}
				int n3 = list3.FindIndex(startIndex2, count, match3);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<UnityEngine.GameObject>.FindIndex");
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
			List<GameObject> list = (List<GameObject>)ToLua.CheckObject(L, 1, typeof(List<GameObject>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Predicate<GameObject> match;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				match = (Predicate<GameObject>)ToLua.CheckObject(L, 2, typeof(Predicate<GameObject>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				match = (DelegateFactory.CreateDelegate(typeof(Predicate<GameObject>), func) as Predicate<GameObject>);
			}
			GameObject obj = list.FindLast(match);
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
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<GameObject>), typeof(Predicate<GameObject>)))
			{
				List<GameObject> list = (List<GameObject>)ToLua.ToObject(L, 1);
				LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
				Predicate<GameObject> match;
				if (luaTypes != LuaTypes.LUA_TFUNCTION)
				{
					match = (Predicate<GameObject>)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func = ToLua.ToLuaFunction(L, 2);
					match = (DelegateFactory.CreateDelegate(typeof(Predicate<GameObject>), func) as Predicate<GameObject>);
				}
				int n = list.FindLastIndex(match);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<GameObject>), typeof(int), typeof(Predicate<GameObject>)))
			{
				List<GameObject> list2 = (List<GameObject>)ToLua.ToObject(L, 1);
				int startIndex = (int)LuaDLL.lua_tonumber(L, 2);
				LuaTypes luaTypes2 = LuaDLL.lua_type(L, 3);
				Predicate<GameObject> match2;
				if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
				{
					match2 = (Predicate<GameObject>)ToLua.ToObject(L, 3);
				}
				else
				{
					LuaFunction func2 = ToLua.ToLuaFunction(L, 3);
					match2 = (DelegateFactory.CreateDelegate(typeof(Predicate<GameObject>), func2) as Predicate<GameObject>);
				}
				int n2 = list2.FindLastIndex(startIndex, match2);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(List<GameObject>), typeof(int), typeof(int), typeof(Predicate<GameObject>)))
			{
				List<GameObject> list3 = (List<GameObject>)ToLua.ToObject(L, 1);
				int startIndex2 = (int)LuaDLL.lua_tonumber(L, 2);
				int count = (int)LuaDLL.lua_tonumber(L, 3);
				LuaTypes luaTypes3 = LuaDLL.lua_type(L, 4);
				Predicate<GameObject> match3;
				if (luaTypes3 != LuaTypes.LUA_TFUNCTION)
				{
					match3 = (Predicate<GameObject>)ToLua.ToObject(L, 4);
				}
				else
				{
					LuaFunction func3 = ToLua.ToLuaFunction(L, 4);
					match3 = (DelegateFactory.CreateDelegate(typeof(Predicate<GameObject>), func3) as Predicate<GameObject>);
				}
				int n3 = list3.FindLastIndex(startIndex2, count, match3);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<UnityEngine.GameObject>.FindLastIndex");
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
			List<GameObject> list = (List<GameObject>)ToLua.CheckObject(L, 1, typeof(List<GameObject>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action<GameObject> action;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				action = (Action<GameObject>)ToLua.CheckObject(L, 2, typeof(Action<GameObject>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				action = (DelegateFactory.CreateDelegate(typeof(Action<GameObject>), func) as Action<GameObject>);
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
			List<GameObject> list = (List<GameObject>)ToLua.CheckObject(L, 1, typeof(List<GameObject>));
			List<GameObject>.Enumerator enumerator = list.GetEnumerator();
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
			List<GameObject> list = (List<GameObject>)ToLua.CheckObject(L, 1, typeof(List<GameObject>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			int count = (int)LuaDLL.luaL_checknumber(L, 3);
			List<GameObject> range = list.GetRange(index, count);
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
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<GameObject>), typeof(GameObject)))
			{
				List<GameObject> list = (List<GameObject>)ToLua.ToObject(L, 1);
				GameObject item = (GameObject)ToLua.ToObject(L, 2);
				int n = list.IndexOf(item);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<GameObject>), typeof(GameObject), typeof(int)))
			{
				List<GameObject> list2 = (List<GameObject>)ToLua.ToObject(L, 1);
				GameObject item2 = (GameObject)ToLua.ToObject(L, 2);
				int index = (int)LuaDLL.lua_tonumber(L, 3);
				int n2 = list2.IndexOf(item2, index);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(List<GameObject>), typeof(GameObject), typeof(int), typeof(int)))
			{
				List<GameObject> list3 = (List<GameObject>)ToLua.ToObject(L, 1);
				GameObject item3 = (GameObject)ToLua.ToObject(L, 2);
				int index2 = (int)LuaDLL.lua_tonumber(L, 3);
				int count = (int)LuaDLL.lua_tonumber(L, 4);
				int n3 = list3.IndexOf(item3, index2, count);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<UnityEngine.GameObject>.IndexOf");
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
			List<GameObject> list = (List<GameObject>)ToLua.CheckObject(L, 1, typeof(List<GameObject>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			GameObject item = (GameObject)ToLua.CheckUnityObject(L, 3, typeof(GameObject));
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
			List<GameObject> list = (List<GameObject>)ToLua.CheckObject(L, 1, typeof(List<GameObject>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			IEnumerable<GameObject> collection = (IEnumerable<GameObject>)ToLua.CheckObject(L, 3, typeof(IEnumerable<GameObject>));
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
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<GameObject>), typeof(GameObject)))
			{
				List<GameObject> list = (List<GameObject>)ToLua.ToObject(L, 1);
				GameObject item = (GameObject)ToLua.ToObject(L, 2);
				int n = list.LastIndexOf(item);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<GameObject>), typeof(GameObject), typeof(int)))
			{
				List<GameObject> list2 = (List<GameObject>)ToLua.ToObject(L, 1);
				GameObject item2 = (GameObject)ToLua.ToObject(L, 2);
				int index = (int)LuaDLL.lua_tonumber(L, 3);
				int n2 = list2.LastIndexOf(item2, index);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(List<GameObject>), typeof(GameObject), typeof(int), typeof(int)))
			{
				List<GameObject> list3 = (List<GameObject>)ToLua.ToObject(L, 1);
				GameObject item3 = (GameObject)ToLua.ToObject(L, 2);
				int index2 = (int)LuaDLL.lua_tonumber(L, 3);
				int count = (int)LuaDLL.lua_tonumber(L, 4);
				int n3 = list3.LastIndexOf(item3, index2, count);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<UnityEngine.GameObject>.LastIndexOf");
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
			List<GameObject> list = (List<GameObject>)ToLua.CheckObject(L, 1, typeof(List<GameObject>));
			GameObject item = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
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
			List<GameObject> list = (List<GameObject>)ToLua.CheckObject(L, 1, typeof(List<GameObject>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Predicate<GameObject> match;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				match = (Predicate<GameObject>)ToLua.CheckObject(L, 2, typeof(Predicate<GameObject>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				match = (DelegateFactory.CreateDelegate(typeof(Predicate<GameObject>), func) as Predicate<GameObject>);
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
			List<GameObject> list = (List<GameObject>)ToLua.CheckObject(L, 1, typeof(List<GameObject>));
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
			List<GameObject> list = (List<GameObject>)ToLua.CheckObject(L, 1, typeof(List<GameObject>));
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
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(List<GameObject>)))
			{
				List<GameObject> list = (List<GameObject>)ToLua.ToObject(L, 1);
				list.Reverse();
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<GameObject>), typeof(int), typeof(int)))
			{
				List<GameObject> list2 = (List<GameObject>)ToLua.ToObject(L, 1);
				int index = (int)LuaDLL.lua_tonumber(L, 2);
				int count = (int)LuaDLL.lua_tonumber(L, 3);
				list2.Reverse(index, count);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<UnityEngine.GameObject>.Reverse");
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
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(List<GameObject>)))
			{
				List<GameObject> list = (List<GameObject>)ToLua.ToObject(L, 1);
				list.Sort();
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<GameObject>), typeof(Comparison<GameObject>)))
			{
				List<GameObject> list2 = (List<GameObject>)ToLua.ToObject(L, 1);
				LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
				Comparison<GameObject> comparison;
				if (luaTypes != LuaTypes.LUA_TFUNCTION)
				{
					comparison = (Comparison<GameObject>)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func = ToLua.ToLuaFunction(L, 2);
					comparison = (DelegateFactory.CreateDelegate(typeof(Comparison<GameObject>), func) as Comparison<GameObject>);
				}
				list2.Sort(comparison);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<GameObject>), typeof(IComparer<GameObject>)))
			{
				List<GameObject> list3 = (List<GameObject>)ToLua.ToObject(L, 1);
				IComparer<GameObject> comparer = (IComparer<GameObject>)ToLua.ToObject(L, 2);
				list3.Sort(comparer);
				result = 0;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(List<GameObject>), typeof(int), typeof(int), typeof(IComparer<GameObject>)))
			{
				List<GameObject> list4 = (List<GameObject>)ToLua.ToObject(L, 1);
				int index = (int)LuaDLL.lua_tonumber(L, 2);
				int count = (int)LuaDLL.lua_tonumber(L, 3);
				IComparer<GameObject> comparer2 = (IComparer<GameObject>)ToLua.ToObject(L, 4);
				list4.Sort(index, count, comparer2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<UnityEngine.GameObject>.Sort");
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
			List<GameObject> list = (List<GameObject>)ToLua.CheckObject(L, 1, typeof(List<GameObject>));
			GameObject[] array = list.ToArray();
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
			List<GameObject> list = (List<GameObject>)ToLua.CheckObject(L, 1, typeof(List<GameObject>));
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
			List<GameObject> list = (List<GameObject>)ToLua.CheckObject(L, 1, typeof(List<GameObject>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Predicate<GameObject> match;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				match = (Predicate<GameObject>)ToLua.CheckObject(L, 2, typeof(Predicate<GameObject>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				match = (DelegateFactory.CreateDelegate(typeof(Predicate<GameObject>), func) as Predicate<GameObject>);
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
			List<GameObject> list = (List<GameObject>)ToLua.CheckObject(L, 1, typeof(List<GameObject>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			GameObject obj = list[index];
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
			List<GameObject> list = (List<GameObject>)ToLua.CheckObject(L, 1, typeof(List<GameObject>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			GameObject value = (GameObject)ToLua.CheckUnityObject(L, 3, typeof(GameObject));
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
			List<GameObject> list = (List<GameObject>)obj;
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
			List<GameObject> list = (List<GameObject>)obj;
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
			List<GameObject> list = (List<GameObject>)obj;
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
