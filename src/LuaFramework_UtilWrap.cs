using LuaFramework;
using LuaInterface;
using System;
using UnityEngine;

public class LuaFramework_UtilWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Util), typeof(object), null);
		L.RegFunction("Int", new LuaCSFunction(LuaFramework_UtilWrap.Int));
		L.RegFunction("Float", new LuaCSFunction(LuaFramework_UtilWrap.Float));
		L.RegFunction("Long", new LuaCSFunction(LuaFramework_UtilWrap.Long));
		L.RegFunction("Random", new LuaCSFunction(LuaFramework_UtilWrap.Random));
		L.RegFunction("Uid", new LuaCSFunction(LuaFramework_UtilWrap.Uid));
		L.RegFunction("GetTime", new LuaCSFunction(LuaFramework_UtilWrap.GetTime));
		L.RegFunction("Child", new LuaCSFunction(LuaFramework_UtilWrap.Child));
		L.RegFunction("Peer", new LuaCSFunction(LuaFramework_UtilWrap.Peer));
		L.RegFunction("md5", new LuaCSFunction(LuaFramework_UtilWrap.md5));
		L.RegFunction("md5file", new LuaCSFunction(LuaFramework_UtilWrap.md5file));
		L.RegFunction("ClearChild", new LuaCSFunction(LuaFramework_UtilWrap.ClearChild));
		L.RegFunction("Log", new LuaCSFunction(LuaFramework_UtilWrap.Log));
		L.RegFunction("LogWarning", new LuaCSFunction(LuaFramework_UtilWrap.LogWarning));
		L.RegFunction("LogError", new LuaCSFunction(LuaFramework_UtilWrap.LogError));
		L.RegFunction("AddComponent", new LuaCSFunction(LuaFramework_UtilWrap.AddComponent));
		L.RegFunction("CheckEnvironment", new LuaCSFunction(LuaFramework_UtilWrap.CheckEnvironment));
		L.RegFunction("New", new LuaCSFunction(LuaFramework_UtilWrap._CreateLuaFramework_Util));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateLuaFramework_Util(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				Util o = new Util();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: LuaFramework.Util.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Int(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			object o = ToLua.ToVarObject(L, 1);
			int n = Util.Int(o);
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
	private static int Float(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			object o = ToLua.ToVarObject(L, 1);
			float num = Util.Float(o);
			LuaDLL.lua_pushnumber(L, (double)num);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Long(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			object o = ToLua.ToVarObject(L, 1);
			long n = Util.Long(o);
			LuaDLL.tolua_pushint64(L, n);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Random(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(float), typeof(float)))
			{
				float min = (float)LuaDLL.lua_tonumber(L, 1);
				float max = (float)LuaDLL.lua_tonumber(L, 2);
				float num2 = Util.Random(min, max);
				LuaDLL.lua_pushnumber(L, (double)num2);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(int)))
			{
				int min2 = (int)LuaDLL.lua_tonumber(L, 1);
				int max2 = (int)LuaDLL.lua_tonumber(L, 2);
				int n = Util.Random(min2, max2);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: LuaFramework.Util.Random");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Uid(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string uid = ToLua.CheckString(L, 1);
			string str = Util.Uid(uid);
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
	private static int GetTime(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			long time = Util.GetTime();
			LuaDLL.tolua_pushint64(L, time);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Child(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(string)))
			{
				Transform go = (Transform)ToLua.ToObject(L, 1);
				string subnode = ToLua.ToString(L, 2);
				GameObject obj = Util.Child(go, subnode);
				ToLua.Push(L, obj);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(string)))
			{
				GameObject go2 = (GameObject)ToLua.ToObject(L, 1);
				string subnode2 = ToLua.ToString(L, 2);
				GameObject obj2 = Util.Child(go2, subnode2);
				ToLua.Push(L, obj2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: LuaFramework.Util.Child");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Peer(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(string)))
			{
				Transform go = (Transform)ToLua.ToObject(L, 1);
				string subnode = ToLua.ToString(L, 2);
				GameObject obj = Util.Peer(go, subnode);
				ToLua.Push(L, obj);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(string)))
			{
				GameObject go2 = (GameObject)ToLua.ToObject(L, 1);
				string subnode2 = ToLua.ToString(L, 2);
				GameObject obj2 = Util.Peer(go2, subnode2);
				ToLua.Push(L, obj2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: LuaFramework.Util.Peer");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int md5(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string source = ToLua.CheckString(L, 1);
			string str = Util.md5(source);
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
	private static int md5file(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string file = ToLua.CheckString(L, 1);
			string str = Util.md5file(file);
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
	private static int ClearChild(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Transform go = (Transform)ToLua.CheckUnityObject(L, 1, typeof(Transform));
			Util.ClearChild(go);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Log(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string str = ToLua.CheckString(L, 1);
			Util.Log(str);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LogWarning(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string str = ToLua.CheckString(L, 1);
			Util.LogWarning(str);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LogError(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string str = ToLua.CheckString(L, 1);
			Util.LogError(str);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddComponent(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			string assembly = ToLua.CheckString(L, 2);
			string classname = ToLua.CheckString(L, 3);
			Component obj = Util.AddComponent(go, assembly, classname);
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
	private static int CheckEnvironment(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			bool value = Util.CheckEnvironment();
			LuaDLL.lua_pushboolean(L, value);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
