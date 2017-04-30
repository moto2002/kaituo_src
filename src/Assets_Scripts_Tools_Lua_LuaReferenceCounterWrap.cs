using Assets.Scripts.Tools.Lua;
using LuaInterface;
using System;

public class Assets_Scripts_Tools_Lua_LuaReferenceCounterWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(LuaReferenceCounter), typeof(object), null);
		L.RegFunction("Mark", new LuaCSFunction(Assets_Scripts_Tools_Lua_LuaReferenceCounterWrap.Mark));
		L.RegFunction("GC", new LuaCSFunction(Assets_Scripts_Tools_Lua_LuaReferenceCounterWrap.GC));
		L.RegFunction("MarkAll", new LuaCSFunction(Assets_Scripts_Tools_Lua_LuaReferenceCounterWrap.MarkAll));
		L.RegFunction("Snapshoot", new LuaCSFunction(Assets_Scripts_Tools_Lua_LuaReferenceCounterWrap.Snapshoot));
		L.RegFunction("New", new LuaCSFunction(Assets_Scripts_Tools_Lua_LuaReferenceCounterWrap._CreateAssets_Scripts_Tools_Lua_LuaReferenceCounter));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateAssets_Scripts_Tools_Lua_LuaReferenceCounter(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				LuaReferenceCounter o = new LuaReferenceCounter();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: Assets.Scripts.Tools.Lua.LuaReferenceCounter.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Mark(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			string typeName = ToLua.CheckString(L, 1);
			string table = ToLua.CheckString(L, 2);
			string tableName = ToLua.CheckString(L, 3);
			LuaReferenceCounter.Mark(typeName, table, tableName);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GC(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			LuaReferenceCounter.GC();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MarkAll(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			LuaReferenceCounter.MarkAll();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Snapshoot(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			LuaReferenceCounter.Snapshoot();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
