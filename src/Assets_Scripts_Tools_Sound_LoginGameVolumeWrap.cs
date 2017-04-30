using Assets.Scripts.Tools.Sound;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Scripts_Tools_Sound_LoginGameVolumeWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(LoginGameVolume), typeof(MonoBehaviour), null);
		L.RegFunction("PlaySound", new LuaCSFunction(Assets_Scripts_Tools_Sound_LoginGameVolumeWrap.PlaySound));
		L.RegFunction("StopSound", new LuaCSFunction(Assets_Scripts_Tools_Sound_LoginGameVolumeWrap.StopSound));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Tools_Sound_LoginGameVolumeWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("BGM", new LuaCSFunction(Assets_Scripts_Tools_Sound_LoginGameVolumeWrap.get_BGM), new LuaCSFunction(Assets_Scripts_Tools_Sound_LoginGameVolumeWrap.set_BGM));
		L.RegVar("DefaultBGMVolume", new LuaCSFunction(Assets_Scripts_Tools_Sound_LoginGameVolumeWrap.get_DefaultBGMVolume), new LuaCSFunction(Assets_Scripts_Tools_Sound_LoginGameVolumeWrap.set_DefaultBGMVolume));
		L.RegVar("DefaultESVolume", new LuaCSFunction(Assets_Scripts_Tools_Sound_LoginGameVolumeWrap.get_DefaultESVolume), new LuaCSFunction(Assets_Scripts_Tools_Sound_LoginGameVolumeWrap.set_DefaultESVolume));
		L.RegVar("backgroundSound", new LuaCSFunction(Assets_Scripts_Tools_Sound_LoginGameVolumeWrap.get_backgroundSound), new LuaCSFunction(Assets_Scripts_Tools_Sound_LoginGameVolumeWrap.set_backgroundSound));
		L.RegVar("effectSound", new LuaCSFunction(Assets_Scripts_Tools_Sound_LoginGameVolumeWrap.get_effectSound), new LuaCSFunction(Assets_Scripts_Tools_Sound_LoginGameVolumeWrap.set_effectSound));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlaySound(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			LoginGameVolume loginGameVolume = (LoginGameVolume)ToLua.CheckObject(L, 1, typeof(LoginGameVolume));
			loginGameVolume.PlaySound();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StopSound(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			LoginGameVolume.StopSound();
			result = 0;
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
			UnityEngine.Object x = (UnityEngine.Object)ToLua.ToObject(L, 1);
			UnityEngine.Object y = (UnityEngine.Object)ToLua.ToObject(L, 2);
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

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_BGM(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LoginGameVolume loginGameVolume = (LoginGameVolume)obj;
			AudioClip bGM = loginGameVolume.BGM;
			ToLua.Push(L, bGM);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index BGM on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_DefaultBGMVolume(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LoginGameVolume loginGameVolume = (LoginGameVolume)obj;
			float defaultBGMVolume = loginGameVolume.DefaultBGMVolume;
			LuaDLL.lua_pushnumber(L, (double)defaultBGMVolume);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index DefaultBGMVolume on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_DefaultESVolume(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LoginGameVolume loginGameVolume = (LoginGameVolume)obj;
			float defaultESVolume = loginGameVolume.DefaultESVolume;
			LuaDLL.lua_pushnumber(L, (double)defaultESVolume);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index DefaultESVolume on a nil value");
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
			LoginGameVolume loginGameVolume = (LoginGameVolume)obj;
			float backgroundSound = loginGameVolume.backgroundSound;
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
			LoginGameVolume loginGameVolume = (LoginGameVolume)obj;
			float effectSound = loginGameVolume.effectSound;
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
	private static int set_BGM(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LoginGameVolume loginGameVolume = (LoginGameVolume)obj;
			AudioClip bGM = (AudioClip)ToLua.CheckUnityObject(L, 2, typeof(AudioClip));
			loginGameVolume.BGM = bGM;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index BGM on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_DefaultBGMVolume(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LoginGameVolume loginGameVolume = (LoginGameVolume)obj;
			float defaultBGMVolume = (float)LuaDLL.luaL_checknumber(L, 2);
			loginGameVolume.DefaultBGMVolume = defaultBGMVolume;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index DefaultBGMVolume on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_DefaultESVolume(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LoginGameVolume loginGameVolume = (LoginGameVolume)obj;
			float defaultESVolume = (float)LuaDLL.luaL_checknumber(L, 2);
			loginGameVolume.DefaultESVolume = defaultESVolume;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index DefaultESVolume on a nil value");
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
			LoginGameVolume loginGameVolume = (LoginGameVolume)obj;
			float backgroundSound = (float)LuaDLL.luaL_checknumber(L, 2);
			loginGameVolume.backgroundSound = backgroundSound;
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
			LoginGameVolume loginGameVolume = (LoginGameVolume)obj;
			float effectSound = (float)LuaDLL.luaL_checknumber(L, 2);
			loginGameVolume.effectSound = effectSound;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index effectSound on a nil value");
		}
		return result;
	}
}
