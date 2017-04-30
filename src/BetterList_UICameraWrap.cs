using LuaInterface;
using System;
using System.Collections.Generic;

public class BetterList_UICameraWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(BetterList<UICamera>), typeof(object), "BetterList_UICamera");
		L.RegFunction("GetEnumerator", new LuaCSFunction(BetterList_UICameraWrap.GetEnumerator));
		L.RegFunction(".geti", new LuaCSFunction(BetterList_UICameraWrap.get_Item));
		L.RegFunction("get_Item", new LuaCSFunction(BetterList_UICameraWrap.get_Item));
		L.RegFunction(".seti", new LuaCSFunction(BetterList_UICameraWrap.set_Item));
		L.RegFunction("set_Item", new LuaCSFunction(BetterList_UICameraWrap.set_Item));
		L.RegFunction("Clear", new LuaCSFunction(BetterList_UICameraWrap.Clear));
		L.RegFunction("Release", new LuaCSFunction(BetterList_UICameraWrap.Release));
		L.RegFunction("Add", new LuaCSFunction(BetterList_UICameraWrap.Add));
		L.RegFunction("Insert", new LuaCSFunction(BetterList_UICameraWrap.Insert));
		L.RegFunction("Contains", new LuaCSFunction(BetterList_UICameraWrap.Contains));
		L.RegFunction("IndexOf", new LuaCSFunction(BetterList_UICameraWrap.IndexOf));
		L.RegFunction("Remove", new LuaCSFunction(BetterList_UICameraWrap.Remove));
		L.RegFunction("RemoveAt", new LuaCSFunction(BetterList_UICameraWrap.RemoveAt));
		L.RegFunction("Pop", new LuaCSFunction(BetterList_UICameraWrap.Pop));
		L.RegFunction("ToArray", new LuaCSFunction(BetterList_UICameraWrap.ToArray));
		L.RegFunction("Sort", new LuaCSFunction(BetterList_UICameraWrap.Sort));
		L.RegFunction("New", new LuaCSFunction(BetterList_UICameraWrap._CreateBetterList_UICamera));
		L.RegVar("this", new LuaCSFunction(BetterList_UICameraWrap._this), null);
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("buffer", new LuaCSFunction(BetterList_UICameraWrap.get_buffer), new LuaCSFunction(BetterList_UICameraWrap.set_buffer));
		L.RegVar("size", new LuaCSFunction(BetterList_UICameraWrap.get_size), new LuaCSFunction(BetterList_UICameraWrap.set_size));
		L.RegFunction("CompareFunc", new LuaCSFunction(BetterList_UICameraWrap.BetterList_UICamera_CompareFunc));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateBetterList_UICamera(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				BetterList<UICamera> o = new BetterList<UICamera>();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: BetterList<UICamera>.New");
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
			BetterList<UICamera> betterList = (BetterList<UICamera>)ToLua.CheckObject(L, 1, typeof(BetterList<UICamera>));
			int i = (int)LuaDLL.luaL_checknumber(L, 2);
			UICamera obj = betterList[i];
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
			BetterList<UICamera> betterList = (BetterList<UICamera>)ToLua.CheckObject(L, 1, typeof(BetterList<UICamera>));
			int i = (int)LuaDLL.luaL_checknumber(L, 2);
			UICamera value = (UICamera)ToLua.CheckUnityObject(L, 3, typeof(UICamera));
			betterList[i] = value;
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
			LuaDLL.tolua_bindthis(L, new LuaCSFunction(BetterList_UICameraWrap._get_this), new LuaCSFunction(BetterList_UICameraWrap._set_this));
			result = 1;
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
			BetterList<UICamera> betterList = (BetterList<UICamera>)ToLua.CheckObject(L, 1, typeof(BetterList<UICamera>));
			IEnumerator<UICamera> enumerator = betterList.GetEnumerator();
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
	private static int get_Item(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			BetterList<UICamera> betterList = (BetterList<UICamera>)ToLua.CheckObject(L, 1, typeof(BetterList<UICamera>));
			int i = (int)LuaDLL.luaL_checknumber(L, 2);
			UICamera obj = betterList[i];
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
			BetterList<UICamera> betterList = (BetterList<UICamera>)ToLua.CheckObject(L, 1, typeof(BetterList<UICamera>));
			int i = (int)LuaDLL.luaL_checknumber(L, 2);
			UICamera value = (UICamera)ToLua.CheckUnityObject(L, 3, typeof(UICamera));
			betterList[i] = value;
			result = 0;
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
			BetterList<UICamera> betterList = (BetterList<UICamera>)ToLua.CheckObject(L, 1, typeof(BetterList<UICamera>));
			betterList.Clear();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Release(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			BetterList<UICamera> betterList = (BetterList<UICamera>)ToLua.CheckObject(L, 1, typeof(BetterList<UICamera>));
			betterList.Release();
			result = 0;
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
			BetterList<UICamera> betterList = (BetterList<UICamera>)ToLua.CheckObject(L, 1, typeof(BetterList<UICamera>));
			UICamera item = (UICamera)ToLua.CheckUnityObject(L, 2, typeof(UICamera));
			betterList.Add(item);
			result = 0;
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
			BetterList<UICamera> betterList = (BetterList<UICamera>)ToLua.CheckObject(L, 1, typeof(BetterList<UICamera>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			UICamera item = (UICamera)ToLua.CheckUnityObject(L, 3, typeof(UICamera));
			betterList.Insert(index, item);
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
			BetterList<UICamera> betterList = (BetterList<UICamera>)ToLua.CheckObject(L, 1, typeof(BetterList<UICamera>));
			UICamera item = (UICamera)ToLua.CheckUnityObject(L, 2, typeof(UICamera));
			bool value = betterList.Contains(item);
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
	private static int IndexOf(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			BetterList<UICamera> betterList = (BetterList<UICamera>)ToLua.CheckObject(L, 1, typeof(BetterList<UICamera>));
			UICamera item = (UICamera)ToLua.CheckUnityObject(L, 2, typeof(UICamera));
			int n = betterList.IndexOf(item);
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
	private static int Remove(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			BetterList<UICamera> betterList = (BetterList<UICamera>)ToLua.CheckObject(L, 1, typeof(BetterList<UICamera>));
			UICamera item = (UICamera)ToLua.CheckUnityObject(L, 2, typeof(UICamera));
			bool value = betterList.Remove(item);
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
	private static int RemoveAt(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			BetterList<UICamera> betterList = (BetterList<UICamera>)ToLua.CheckObject(L, 1, typeof(BetterList<UICamera>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			betterList.RemoveAt(index);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Pop(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			BetterList<UICamera> betterList = (BetterList<UICamera>)ToLua.CheckObject(L, 1, typeof(BetterList<UICamera>));
			UICamera obj = betterList.Pop();
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
	private static int ToArray(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			BetterList<UICamera> betterList = (BetterList<UICamera>)ToLua.CheckObject(L, 1, typeof(BetterList<UICamera>));
			UICamera[] array = betterList.ToArray();
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
	private static int Sort(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			BetterList<UICamera> betterList = (BetterList<UICamera>)ToLua.CheckObject(L, 1, typeof(BetterList<UICamera>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			BetterList<UICamera>.CompareFunc comparer;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				comparer = (BetterList<UICamera>.CompareFunc)ToLua.CheckObject(L, 2, typeof(BetterList<UICamera>.CompareFunc));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				comparer = (DelegateFactory.CreateDelegate(typeof(BetterList<UICamera>.CompareFunc), func) as BetterList<UICamera>.CompareFunc);
			}
			betterList.Sort(comparer);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_buffer(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BetterList<UICamera> betterList = (BetterList<UICamera>)obj;
			UICamera[] buffer = betterList.buffer;
			ToLua.Push(L, buffer);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index buffer on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_size(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BetterList<UICamera> betterList = (BetterList<UICamera>)obj;
			int size = betterList.size;
			LuaDLL.lua_pushinteger(L, size);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index size on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_buffer(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BetterList<UICamera> betterList = (BetterList<UICamera>)obj;
			UICamera[] buffer = ToLua.CheckObjectArray<UICamera>(L, 2);
			betterList.buffer = buffer;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index buffer on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_size(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BetterList<UICamera> betterList = (BetterList<UICamera>)obj;
			int size = (int)LuaDLL.luaL_checknumber(L, 2);
			betterList.size = size;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index size on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int BetterList_UICamera_CompareFunc(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(BetterList<UICamera>.CompareFunc), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(BetterList<UICamera>.CompareFunc), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
