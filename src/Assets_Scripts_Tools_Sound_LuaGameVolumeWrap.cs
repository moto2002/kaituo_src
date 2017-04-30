using Assets.Scripts.Tools.Sound;
using LuaInterface;
using System;

public class Assets_Scripts_Tools_Sound_LuaGameVolumeWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(LuaGameVolume), typeof(object), null);
		L.RegFunction("UpdateVolume", new LuaCSFunction(Assets_Scripts_Tools_Sound_LuaGameVolumeWrap.UpdateVolume));
		L.RegFunction("New", new LuaCSFunction(Assets_Scripts_Tools_Sound_LuaGameVolumeWrap._CreateAssets_Scripts_Tools_Sound_LuaGameVolume));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("backgroundSound", new LuaCSFunction(Assets_Scripts_Tools_Sound_LuaGameVolumeWrap.get_backgroundSound), new LuaCSFunction(Assets_Scripts_Tools_Sound_LuaGameVolumeWrap.set_backgroundSound));
		L.RegVar("effectSound", new LuaCSFunction(Assets_Scripts_Tools_Sound_LuaGameVolumeWrap.get_effectSound), new LuaCSFunction(Assets_Scripts_Tools_Sound_LuaGameVolumeWrap.set_effectSound));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateAssets_Scripts_Tools_Sound_LuaGameVolume(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				LuaGameVolume o = new LuaGameVolume();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: Assets.Scripts.Tools.Sound.LuaGameVolume.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UpdateVolume(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			LuaGameVolume luaGameVolume = (LuaGameVolume)ToLua.CheckObject(L, 1, typeof(LuaGameVolume));
			float bgmVolume = (float)LuaDLL.luaL_checknumber(L, 2);
			float esVolume = (float)LuaDLL.luaL_checknumber(L, 3);
			luaGameVolume.UpdateVolume(bgmVolume, esVolume);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_backgroundSound(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LuaGameVolume luaGameVolume = (LuaGameVolume)obj;
			float backgroundSound = luaGameVolume.backgroundSound;
			LuaDLL.lua_pushnumber(L, (double)backgroundSound);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index backgroundSound on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_effectSound(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LuaGameVolume luaGameVolume = (LuaGameVolume)obj;
			float effectSound = luaGameVolume.effectSound;
			LuaDLL.lua_pushnumber(L, (double)effectSound);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index effectSound on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_backgroundSound(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LuaGameVolume luaGameVolume = (LuaGameVolume)obj;
			float backgroundSound = (float)LuaDLL.luaL_checknumber(L, 2);
			luaGameVolume.backgroundSound = backgroundSound;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index backgroundSound on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_effectSound(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LuaGameVolume luaGameVolume = (LuaGameVolume)obj;
			float effectSound = (float)LuaDLL.luaL_checknumber(L, 2);
			luaGameVolume.effectSound = effectSound;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index effectSound on a nil value");
		}
		return result;
	}
}
