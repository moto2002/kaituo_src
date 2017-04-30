using Assets.Scripts.Tools.Sound;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Scripts_Tools_Sound_BattleEffectSoundWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(BattleEffectSound), typeof(MonoBehaviour), null);
		L.RegFunction("Play", new LuaCSFunction(Assets_Scripts_Tools_Sound_BattleEffectSoundWrap.Play));
		L.RegFunction("Start", new LuaCSFunction(Assets_Scripts_Tools_Sound_BattleEffectSoundWrap.Start));
		L.RegFunction("OnEnable", new LuaCSFunction(Assets_Scripts_Tools_Sound_BattleEffectSoundWrap.OnEnable));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Tools_Sound_BattleEffectSoundWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("EffectSoundName", new LuaCSFunction(Assets_Scripts_Tools_Sound_BattleEffectSoundWrap.get_EffectSoundName), new LuaCSFunction(Assets_Scripts_Tools_Sound_BattleEffectSoundWrap.set_EffectSoundName));
		L.RegVar("PlayType", new LuaCSFunction(Assets_Scripts_Tools_Sound_BattleEffectSoundWrap.get_PlayType), new LuaCSFunction(Assets_Scripts_Tools_Sound_BattleEffectSoundWrap.set_PlayType));
		L.RegVar("IgnoreTimeScale", new LuaCSFunction(Assets_Scripts_Tools_Sound_BattleEffectSoundWrap.get_IgnoreTimeScale), new LuaCSFunction(Assets_Scripts_Tools_Sound_BattleEffectSoundWrap.set_IgnoreTimeScale));
		L.RegVar("PlayGlobalSESound", new LuaCSFunction(Assets_Scripts_Tools_Sound_BattleEffectSoundWrap.get_PlayGlobalSESound), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Play(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			string soundName = ToLua.CheckString(L, 1);
			bool ignoreTimeScale = LuaDLL.luaL_checkboolean(L, 2);
			BattleEffectSound.Play(soundName, ignoreTimeScale);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Start(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			BattleEffectSound battleEffectSound = (BattleEffectSound)ToLua.CheckObject(L, 1, typeof(BattleEffectSound));
			battleEffectSound.Start();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnEnable(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			BattleEffectSound battleEffectSound = (BattleEffectSound)ToLua.CheckObject(L, 1, typeof(BattleEffectSound));
			battleEffectSound.OnEnable();
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
	private static int get_EffectSoundName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BattleEffectSound battleEffectSound = (BattleEffectSound)obj;
			string effectSoundName = battleEffectSound.EffectSoundName;
			LuaDLL.lua_pushstring(L, effectSoundName);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index EffectSoundName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_PlayType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BattleEffectSound battleEffectSound = (BattleEffectSound)obj;
			BattleEffectSound.BattleEffectSoundType playType = battleEffectSound.PlayType;
			ToLua.Push(L, playType);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index PlayType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IgnoreTimeScale(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BattleEffectSound battleEffectSound = (BattleEffectSound)obj;
			bool ignoreTimeScale = battleEffectSound.IgnoreTimeScale;
			LuaDLL.lua_pushboolean(L, ignoreTimeScale);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IgnoreTimeScale on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_PlayGlobalSESound(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, BattleEffectSound.PlayGlobalSESound);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_EffectSoundName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BattleEffectSound battleEffectSound = (BattleEffectSound)obj;
			string effectSoundName = ToLua.CheckString(L, 2);
			battleEffectSound.EffectSoundName = effectSoundName;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index EffectSoundName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_PlayType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BattleEffectSound battleEffectSound = (BattleEffectSound)obj;
			BattleEffectSound.BattleEffectSoundType playType = (BattleEffectSound.BattleEffectSoundType)LuaDLL.luaL_checknumber(L, 2);
			battleEffectSound.PlayType = playType;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index PlayType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_IgnoreTimeScale(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			BattleEffectSound battleEffectSound = (BattleEffectSound)obj;
			bool ignoreTimeScale = LuaDLL.luaL_checkboolean(L, 2);
			battleEffectSound.IgnoreTimeScale = ignoreTimeScale;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IgnoreTimeScale on a nil value");
		}
		return result;
	}
}
