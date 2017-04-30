using Assets.Tools.Script.Sound;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Tools_Script_Sound_SoundUtilitiesWrap
{
	public static void Register(LuaState L)
	{
		L.BeginStaticLibs("SoundUtilities");
		L.RegFunction("PlaySound", new LuaCSFunction(Assets_Tools_Script_Sound_SoundUtilitiesWrap.PlaySound));
		L.RegFunction("SetTimeScaleable", new LuaCSFunction(Assets_Tools_Script_Sound_SoundUtilitiesWrap.SetTimeScaleable));
		L.RegFunction("StopSound", new LuaCSFunction(Assets_Tools_Script_Sound_SoundUtilitiesWrap.StopSound));
		L.RegFunction("PauseSound", new LuaCSFunction(Assets_Tools_Script_Sound_SoundUtilitiesWrap.PauseSound));
		L.RegFunction("UnPauseSound", new LuaCSFunction(Assets_Tools_Script_Sound_SoundUtilitiesWrap.UnPauseSound));
		L.RegFunction("FindSound", new LuaCSFunction(Assets_Tools_Script_Sound_SoundUtilitiesWrap.FindSound));
		L.RegFunction("LoadFromStreamingAssets", new LuaCSFunction(Assets_Tools_Script_Sound_SoundUtilitiesWrap.LoadFromStreamingAssets));
		L.RegVar("volumeCentre", new LuaCSFunction(Assets_Tools_Script_Sound_SoundUtilitiesWrap.get_volumeCentre), new LuaCSFunction(Assets_Tools_Script_Sound_SoundUtilitiesWrap.set_volumeCentre));
		L.RegVar("Soundlistener", new LuaCSFunction(Assets_Tools_Script_Sound_SoundUtilitiesWrap.get_Soundlistener), null);
		L.EndStaticLibs();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlaySound(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			AudioClip clip = (AudioClip)ToLua.CheckUnityObject(L, 1, typeof(AudioClip));
			float volume = (float)LuaDLL.luaL_checknumber(L, 2);
			bool loop = LuaDLL.luaL_checkboolean(L, 3);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 4);
			Action onEnd;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onEnd = (Action)ToLua.CheckObject(L, 4, typeof(Action));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 4);
				onEnd = (DelegateFactory.CreateDelegate(typeof(Action), func) as Action);
			}
			AudioSource obj = SoundUtilities.PlaySound(clip, volume, loop, onEnd);
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
	private static int SetTimeScaleable(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			AudioSource audioSource = (AudioSource)ToLua.CheckUnityObject(L, 1, typeof(AudioSource));
			bool ignoreTimeScale = LuaDLL.luaL_checkboolean(L, 2);
			SoundUtilities.SetTimeScaleable(audioSource, ignoreTimeScale);
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
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(string)))
			{
				string audioName = ToLua.ToString(L, 1);
				SoundUtilities.StopSound(audioName);
				result = 0;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(AudioSource)))
			{
				AudioSource audioSource = (AudioSource)ToLua.ToObject(L, 1);
				SoundUtilities.StopSound(audioSource);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: Assets.Tools.Script.Sound.SoundUtilities.StopSound");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PauseSound(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(string)))
			{
				string audioName = ToLua.ToString(L, 1);
				SoundUtilities.PauseSound(audioName);
				result = 0;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(AudioSource)))
			{
				AudioSource audioSource = (AudioSource)ToLua.ToObject(L, 1);
				SoundUtilities.PauseSound(audioSource);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: Assets.Tools.Script.Sound.SoundUtilities.PauseSound");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UnPauseSound(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(string)))
			{
				string audioName = ToLua.ToString(L, 1);
				SoundUtilities.UnPauseSound(audioName);
				result = 0;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(AudioSource)))
			{
				AudioSource audioSource = (AudioSource)ToLua.ToObject(L, 1);
				SoundUtilities.UnPauseSound(audioSource);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: Assets.Tools.Script.Sound.SoundUtilities.UnPauseSound");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FindSound(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string audioName = ToLua.CheckString(L, 1);
			AudioSource obj = SoundUtilities.FindSound(audioName);
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
	private static int LoadFromStreamingAssets(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string path = ToLua.CheckString(L, 1);
			AudioClip obj = SoundUtilities.LoadFromStreamingAssets(path);
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
	private static int get_volumeCentre(IntPtr L)
	{
		int result;
		try
		{
			ToLua.PushObject(L, SoundUtilities.volumeCentre);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Soundlistener(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, SoundUtilities.Soundlistener);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_volumeCentre(IntPtr L)
	{
		int result;
		try
		{
			IGameVolume volumeCentre = (IGameVolume)ToLua.CheckObject(L, 2, typeof(IGameVolume));
			SoundUtilities.volumeCentre = volumeCentre;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
