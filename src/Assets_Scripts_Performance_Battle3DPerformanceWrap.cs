using Assets.Scripts.Performance;
using LuaInterface;
using System;

public class Assets_Scripts_Performance_Battle3DPerformanceWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Battle3DPerformance), typeof(object), null);
		L.RegFunction("Play", new LuaCSFunction(Assets_Scripts_Performance_Battle3DPerformanceWrap.Play));
		L.RegFunction("New", new LuaCSFunction(Assets_Scripts_Performance_Battle3DPerformanceWrap._CreateAssets_Scripts_Performance_Battle3DPerformance));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateAssets_Scripts_Performance_Battle3DPerformance(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				Battle3DPerformance o = new Battle3DPerformance();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: Assets.Scripts.Performance.Battle3DPerformance.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Play(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string jsonData = ToLua.CheckString(L, 1);
			Battle3DPerformance.Play(jsonData);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
