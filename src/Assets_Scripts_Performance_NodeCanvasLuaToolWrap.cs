using Assets.Scripts.Performance;
using LuaInterface;
using System;

public class Assets_Scripts_Performance_NodeCanvasLuaToolWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(NodeCanvasLuaTool), typeof(object), null);
		L.RegFunction("CacheBeforePlay", new LuaCSFunction(Assets_Scripts_Performance_NodeCanvasLuaToolWrap.CacheBeforePlay));
		L.RegFunction("RestoreAfterPlay", new LuaCSFunction(Assets_Scripts_Performance_NodeCanvasLuaToolWrap.RestoreAfterPlay));
		L.RegFunction("ClearNodeCanvas", new LuaCSFunction(Assets_Scripts_Performance_NodeCanvasLuaToolWrap.ClearNodeCanvas));
		L.RegFunction("New", new LuaCSFunction(Assets_Scripts_Performance_NodeCanvasLuaToolWrap._CreateAssets_Scripts_Performance_NodeCanvasLuaTool));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateAssets_Scripts_Performance_NodeCanvasLuaTool(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				NodeCanvasLuaTool o = new NodeCanvasLuaTool();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: Assets.Scripts.Performance.NodeCanvasLuaTool.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CacheBeforePlay(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			NodeCanvasLuaTool.CacheBeforePlay();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RestoreAfterPlay(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			NodeCanvasLuaTool.RestoreAfterPlay();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ClearNodeCanvas(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			NodeCanvasLuaTool.ClearNodeCanvas();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
