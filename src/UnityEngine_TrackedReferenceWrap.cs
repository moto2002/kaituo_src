using LuaInterface;
using System;
using UnityEngine;

public class UnityEngine_TrackedReferenceWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(TrackedReference), typeof(object), null);
		L.RegFunction("Equals", new LuaCSFunction(UnityEngine_TrackedReferenceWrap.Equals));
		L.RegFunction("GetHashCode", new LuaCSFunction(UnityEngine_TrackedReferenceWrap.GetHashCode));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_TrackedReferenceWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Equals(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			TrackedReference trackedReference = (TrackedReference)ToLua.CheckObject(L, 1, typeof(TrackedReference));
			object obj = ToLua.ToVarObject(L, 2);
			bool value = (!(trackedReference != null)) ? (obj == null) : trackedReference.Equals(obj);
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
	private static int GetHashCode(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			TrackedReference trackedReference = (TrackedReference)ToLua.CheckObject(L, 1, typeof(TrackedReference));
			int hashCode = trackedReference.GetHashCode();
			LuaDLL.lua_pushinteger(L, hashCode);
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
			TrackedReference x = (TrackedReference)ToLua.ToObject(L, 1);
			TrackedReference y = (TrackedReference)ToLua.ToObject(L, 2);
			bool value = x == y;
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
