using LuaInterface;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

public class System_Collections_Generic_Dictionary_string_stringWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Dictionary<string, string>), typeof(object), "Dictionary_string_string");
		L.RegFunction("get_Item", new LuaCSFunction(System_Collections_Generic_Dictionary_string_stringWrap.get_Item));
		L.RegFunction("set_Item", new LuaCSFunction(System_Collections_Generic_Dictionary_string_stringWrap.set_Item));
		L.RegFunction("Add", new LuaCSFunction(System_Collections_Generic_Dictionary_string_stringWrap.Add));
		L.RegFunction("Clear", new LuaCSFunction(System_Collections_Generic_Dictionary_string_stringWrap.Clear));
		L.RegFunction("ContainsKey", new LuaCSFunction(System_Collections_Generic_Dictionary_string_stringWrap.ContainsKey));
		L.RegFunction("ContainsValue", new LuaCSFunction(System_Collections_Generic_Dictionary_string_stringWrap.ContainsValue));
		L.RegFunction("GetObjectData", new LuaCSFunction(System_Collections_Generic_Dictionary_string_stringWrap.GetObjectData));
		L.RegFunction("OnDeserialization", new LuaCSFunction(System_Collections_Generic_Dictionary_string_stringWrap.OnDeserialization));
		L.RegFunction("Remove", new LuaCSFunction(System_Collections_Generic_Dictionary_string_stringWrap.Remove));
		L.RegFunction("TryGetValue", new LuaCSFunction(System_Collections_Generic_Dictionary_string_stringWrap.TryGetValue));
		L.RegFunction("GetEnumerator", new LuaCSFunction(System_Collections_Generic_Dictionary_string_stringWrap.GetEnumerator));
		L.RegFunction("New", new LuaCSFunction(System_Collections_Generic_Dictionary_string_stringWrap._CreateSystem_Collections_Generic_Dictionary_string_string));
		L.RegVar("this", new LuaCSFunction(System_Collections_Generic_Dictionary_string_stringWrap._this), null);
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Count", new LuaCSFunction(System_Collections_Generic_Dictionary_string_stringWrap.get_Count), null);
		L.RegVar("Comparer", new LuaCSFunction(System_Collections_Generic_Dictionary_string_stringWrap.get_Comparer), null);
		L.RegVar("Keys", new LuaCSFunction(System_Collections_Generic_Dictionary_string_stringWrap.get_Keys), null);
		L.RegVar("Values", new LuaCSFunction(System_Collections_Generic_Dictionary_string_stringWrap.get_Values), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateSystem_Collections_Generic_Dictionary_string_string(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 0)
			{
				Dictionary<string, string> o = new Dictionary<string, string>();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(int)))
			{
				int capacity = (int)LuaDLL.luaL_checknumber(L, 1);
				Dictionary<string, string> o2 = new Dictionary<string, string>(capacity);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(IDictionary<string, string>)))
			{
				IDictionary<string, string> dictionary = (IDictionary<string, string>)ToLua.CheckObject(L, 1, typeof(IDictionary<string, string>));
				Dictionary<string, string> o3 = new Dictionary<string, string>(dictionary);
				ToLua.PushObject(L, o3);
				result = 1;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(IEqualityComparer<string>)))
			{
				IEqualityComparer<string> comparer = (IEqualityComparer<string>)ToLua.CheckObject(L, 1, typeof(IEqualityComparer<string>));
				Dictionary<string, string> o4 = new Dictionary<string, string>(comparer);
				ToLua.PushObject(L, o4);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(IEqualityComparer<string>)))
			{
				int capacity2 = (int)LuaDLL.luaL_checknumber(L, 1);
				IEqualityComparer<string> comparer2 = (IEqualityComparer<string>)ToLua.CheckObject(L, 2, typeof(IEqualityComparer<string>));
				Dictionary<string, string> o5 = new Dictionary<string, string>(capacity2, comparer2);
				ToLua.PushObject(L, o5);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(IDictionary<string, string>), typeof(IEqualityComparer<string>)))
			{
				IDictionary<string, string> dictionary2 = (IDictionary<string, string>)ToLua.CheckObject(L, 1, typeof(IDictionary<string, string>));
				IEqualityComparer<string> comparer3 = (IEqualityComparer<string>)ToLua.CheckObject(L, 2, typeof(IEqualityComparer<string>));
				Dictionary<string, string> o6 = new Dictionary<string, string>(dictionary2, comparer3);
				ToLua.PushObject(L, o6);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: System.Collections.Generic.Dictionary<string,string>.New");
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
			Dictionary<string, string> dictionary = (Dictionary<string, string>)ToLua.CheckObject(L, 1, typeof(Dictionary<string, string>));
			string key = ToLua.CheckString(L, 2);
			string str = dictionary[key];
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
			Dictionary<string, string> dictionary = (Dictionary<string, string>)ToLua.CheckObject(L, 1, typeof(Dictionary<string, string>));
			string key = ToLua.CheckString(L, 2);
			string value = ToLua.CheckString(L, 3);
			dictionary[key] = value;
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
			LuaDLL.tolua_bindthis(L, new LuaCSFunction(System_Collections_Generic_Dictionary_string_stringWrap._get_this), new LuaCSFunction(System_Collections_Generic_Dictionary_string_stringWrap._set_this));
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
			Dictionary<string, string> dictionary = (Dictionary<string, string>)ToLua.CheckObject(L, 1, typeof(Dictionary<string, string>));
			string key = ToLua.CheckString(L, 2);
			string str = dictionary[key];
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
			Dictionary<string, string> dictionary = (Dictionary<string, string>)ToLua.CheckObject(L, 1, typeof(Dictionary<string, string>));
			string key = ToLua.CheckString(L, 2);
			string value = ToLua.CheckString(L, 3);
			dictionary[key] = value;
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
			ToLua.CheckArgsCount(L, 3);
			Dictionary<string, string> dictionary = (Dictionary<string, string>)ToLua.CheckObject(L, 1, typeof(Dictionary<string, string>));
			string key = ToLua.CheckString(L, 2);
			string value = ToLua.CheckString(L, 3);
			dictionary.Add(key, value);
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
			Dictionary<string, string> dictionary = (Dictionary<string, string>)ToLua.CheckObject(L, 1, typeof(Dictionary<string, string>));
			dictionary.Clear();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ContainsKey(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Dictionary<string, string> dictionary = (Dictionary<string, string>)ToLua.CheckObject(L, 1, typeof(Dictionary<string, string>));
			string key = ToLua.CheckString(L, 2);
			bool value = dictionary.ContainsKey(key);
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
	private static int ContainsValue(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Dictionary<string, string> dictionary = (Dictionary<string, string>)ToLua.CheckObject(L, 1, typeof(Dictionary<string, string>));
			string value = ToLua.CheckString(L, 2);
			bool value2 = dictionary.ContainsValue(value);
			LuaDLL.lua_pushboolean(L, value2);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetObjectData(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Dictionary<string, string> dictionary = (Dictionary<string, string>)ToLua.CheckObject(L, 1, typeof(Dictionary<string, string>));
			SerializationInfo info = (SerializationInfo)ToLua.CheckObject(L, 2, typeof(SerializationInfo));
			StreamingContext context = (StreamingContext)ToLua.CheckObject(L, 3, typeof(StreamingContext));
			dictionary.GetObjectData(info, context);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnDeserialization(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Dictionary<string, string> dictionary = (Dictionary<string, string>)ToLua.CheckObject(L, 1, typeof(Dictionary<string, string>));
			object sender = ToLua.ToVarObject(L, 2);
			dictionary.OnDeserialization(sender);
			result = 0;
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
			Dictionary<string, string> dictionary = (Dictionary<string, string>)ToLua.CheckObject(L, 1, typeof(Dictionary<string, string>));
			string key = ToLua.CheckString(L, 2);
			bool value = dictionary.Remove(key);
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
	private static int TryGetValue(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Dictionary<string, string> dictionary = (Dictionary<string, string>)ToLua.CheckObject(L, 1, typeof(Dictionary<string, string>));
			string key = ToLua.CheckString(L, 2);
			string str = null;
			bool value = dictionary.TryGetValue(key, out str);
			LuaDLL.lua_pushboolean(L, value);
			LuaDLL.lua_pushstring(L, str);
			result = 2;
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
			Dictionary<string, string> dictionary = (Dictionary<string, string>)ToLua.CheckObject(L, 1, typeof(Dictionary<string, string>));
			Dictionary<string, string>.Enumerator enumerator = dictionary.GetEnumerator();
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
	private static int get_Count(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Dictionary<string, string> dictionary = (Dictionary<string, string>)obj;
			int count = dictionary.Count;
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
	private static int get_Comparer(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Dictionary<string, string> dictionary = (Dictionary<string, string>)obj;
			IEqualityComparer<string> comparer = dictionary.Comparer;
			ToLua.PushObject(L, comparer);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Comparer on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Keys(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Dictionary<string, string> dictionary = (Dictionary<string, string>)obj;
			Dictionary<string, string>.KeyCollection keys = dictionary.Keys;
			ToLua.PushObject(L, keys);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Keys on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Values(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Dictionary<string, string> dictionary = (Dictionary<string, string>)obj;
			Dictionary<string, string>.ValueCollection values = dictionary.Values;
			ToLua.PushObject(L, values);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Values on a nil value");
		}
		return result;
	}
}
