using LuaInterface;
using System;
using UnityEngine;

public class UnityEngine_AudioClipWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(AudioClip), typeof(UnityEngine.Object), null);
		L.RegFunction("LoadAudioData", new LuaCSFunction(UnityEngine_AudioClipWrap.LoadAudioData));
		L.RegFunction("UnloadAudioData", new LuaCSFunction(UnityEngine_AudioClipWrap.UnloadAudioData));
		L.RegFunction("GetData", new LuaCSFunction(UnityEngine_AudioClipWrap.GetData));
		L.RegFunction("SetData", new LuaCSFunction(UnityEngine_AudioClipWrap.SetData));
		L.RegFunction("Create", new LuaCSFunction(UnityEngine_AudioClipWrap.Create));
		L.RegFunction("New", new LuaCSFunction(UnityEngine_AudioClipWrap._CreateUnityEngine_AudioClip));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_AudioClipWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("length", new LuaCSFunction(UnityEngine_AudioClipWrap.get_length), null);
		L.RegVar("samples", new LuaCSFunction(UnityEngine_AudioClipWrap.get_samples), null);
		L.RegVar("channels", new LuaCSFunction(UnityEngine_AudioClipWrap.get_channels), null);
		L.RegVar("frequency", new LuaCSFunction(UnityEngine_AudioClipWrap.get_frequency), null);
		L.RegVar("loadType", new LuaCSFunction(UnityEngine_AudioClipWrap.get_loadType), null);
		L.RegVar("preloadAudioData", new LuaCSFunction(UnityEngine_AudioClipWrap.get_preloadAudioData), null);
		L.RegVar("loadState", new LuaCSFunction(UnityEngine_AudioClipWrap.get_loadState), null);
		L.RegVar("loadInBackground", new LuaCSFunction(UnityEngine_AudioClipWrap.get_loadInBackground), null);
		L.RegFunction("PCMReaderCallback", new LuaCSFunction(UnityEngine_AudioClipWrap.UnityEngine_AudioClip_PCMReaderCallback));
		L.RegFunction("PCMSetPositionCallback", new LuaCSFunction(UnityEngine_AudioClipWrap.UnityEngine_AudioClip_PCMSetPositionCallback));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUnityEngine_AudioClip(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				AudioClip obj = new AudioClip();
				ToLua.Push(L, obj);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.AudioClip.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadAudioData(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			AudioClip audioClip = (AudioClip)ToLua.CheckObject(L, 1, typeof(AudioClip));
			bool value = audioClip.LoadAudioData();
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
	private static int UnloadAudioData(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			AudioClip audioClip = (AudioClip)ToLua.CheckObject(L, 1, typeof(AudioClip));
			bool value = audioClip.UnloadAudioData();
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
	private static int GetData(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			AudioClip audioClip = (AudioClip)ToLua.CheckObject(L, 1, typeof(AudioClip));
			float[] data = ToLua.CheckNumberArray<float>(L, 2);
			int offsetSamples = (int)LuaDLL.luaL_checknumber(L, 3);
			bool data2 = audioClip.GetData(data, offsetSamples);
			LuaDLL.lua_pushboolean(L, data2);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetData(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			AudioClip audioClip = (AudioClip)ToLua.CheckObject(L, 1, typeof(AudioClip));
			float[] data = ToLua.CheckNumberArray<float>(L, 2);
			int offsetSamples = (int)LuaDLL.luaL_checknumber(L, 3);
			bool value = audioClip.SetData(data, offsetSamples);
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
	private static int Create(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(int), typeof(int), typeof(int), typeof(bool)))
			{
				string name = ToLua.ToString(L, 1);
				int lengthSamples = (int)LuaDLL.lua_tonumber(L, 2);
				int channels = (int)LuaDLL.lua_tonumber(L, 3);
				int frequency = (int)LuaDLL.lua_tonumber(L, 4);
				bool stream = LuaDLL.lua_toboolean(L, 5);
				AudioClip obj = AudioClip.Create(name, lengthSamples, channels, frequency, stream);
				ToLua.Push(L, obj);
				result = 1;
			}
			else if (num == 6 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(int), typeof(int), typeof(int), typeof(bool), typeof(AudioClip.PCMReaderCallback)))
			{
				string name2 = ToLua.ToString(L, 1);
				int lengthSamples2 = (int)LuaDLL.lua_tonumber(L, 2);
				int channels2 = (int)LuaDLL.lua_tonumber(L, 3);
				int frequency2 = (int)LuaDLL.lua_tonumber(L, 4);
				bool stream2 = LuaDLL.lua_toboolean(L, 5);
				LuaTypes luaTypes = LuaDLL.lua_type(L, 6);
				AudioClip.PCMReaderCallback pcmreadercallback;
				if (luaTypes != LuaTypes.LUA_TFUNCTION)
				{
					pcmreadercallback = (AudioClip.PCMReaderCallback)ToLua.ToObject(L, 6);
				}
				else
				{
					LuaFunction func = ToLua.ToLuaFunction(L, 6);
					pcmreadercallback = (DelegateFactory.CreateDelegate(typeof(AudioClip.PCMReaderCallback), func) as AudioClip.PCMReaderCallback);
				}
				AudioClip obj2 = AudioClip.Create(name2, lengthSamples2, channels2, frequency2, stream2, pcmreadercallback);
				ToLua.Push(L, obj2);
				result = 1;
			}
			else if (num == 7 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(int), typeof(int), typeof(int), typeof(bool), typeof(AudioClip.PCMReaderCallback), typeof(AudioClip.PCMSetPositionCallback)))
			{
				string name3 = ToLua.ToString(L, 1);
				int lengthSamples3 = (int)LuaDLL.lua_tonumber(L, 2);
				int channels3 = (int)LuaDLL.lua_tonumber(L, 3);
				int frequency3 = (int)LuaDLL.lua_tonumber(L, 4);
				bool stream3 = LuaDLL.lua_toboolean(L, 5);
				LuaTypes luaTypes2 = LuaDLL.lua_type(L, 6);
				AudioClip.PCMReaderCallback pcmreadercallback2;
				if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
				{
					pcmreadercallback2 = (AudioClip.PCMReaderCallback)ToLua.ToObject(L, 6);
				}
				else
				{
					LuaFunction func2 = ToLua.ToLuaFunction(L, 6);
					pcmreadercallback2 = (DelegateFactory.CreateDelegate(typeof(AudioClip.PCMReaderCallback), func2) as AudioClip.PCMReaderCallback);
				}
				LuaTypes luaTypes3 = LuaDLL.lua_type(L, 7);
				AudioClip.PCMSetPositionCallback pcmsetpositioncallback;
				if (luaTypes3 != LuaTypes.LUA_TFUNCTION)
				{
					pcmsetpositioncallback = (AudioClip.PCMSetPositionCallback)ToLua.ToObject(L, 7);
				}
				else
				{
					LuaFunction func3 = ToLua.ToLuaFunction(L, 7);
					pcmsetpositioncallback = (DelegateFactory.CreateDelegate(typeof(AudioClip.PCMSetPositionCallback), func3) as AudioClip.PCMSetPositionCallback);
				}
				AudioClip obj3 = AudioClip.Create(name3, lengthSamples3, channels3, frequency3, stream3, pcmreadercallback2, pcmsetpositioncallback);
				ToLua.Push(L, obj3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.AudioClip.Create");
			}
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
	private static int get_length(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioClip audioClip = (AudioClip)obj;
			float length = audioClip.length;
			LuaDLL.lua_pushnumber(L, (double)length);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index length on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_samples(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioClip audioClip = (AudioClip)obj;
			int samples = audioClip.samples;
			LuaDLL.lua_pushinteger(L, samples);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index samples on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_channels(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioClip audioClip = (AudioClip)obj;
			int channels = audioClip.channels;
			LuaDLL.lua_pushinteger(L, channels);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index channels on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_frequency(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioClip audioClip = (AudioClip)obj;
			int frequency = audioClip.frequency;
			LuaDLL.lua_pushinteger(L, frequency);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index frequency on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_loadType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioClip audioClip = (AudioClip)obj;
			AudioClipLoadType loadType = audioClip.loadType;
			ToLua.Push(L, loadType);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index loadType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_preloadAudioData(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioClip audioClip = (AudioClip)obj;
			bool preloadAudioData = audioClip.preloadAudioData;
			LuaDLL.lua_pushboolean(L, preloadAudioData);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index preloadAudioData on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_loadState(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioClip audioClip = (AudioClip)obj;
			AudioDataLoadState loadState = audioClip.loadState;
			ToLua.Push(L, loadState);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index loadState on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_loadInBackground(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AudioClip audioClip = (AudioClip)obj;
			bool loadInBackground = audioClip.loadInBackground;
			LuaDLL.lua_pushboolean(L, loadInBackground);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index loadInBackground on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UnityEngine_AudioClip_PCMReaderCallback(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(AudioClip.PCMReaderCallback), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(AudioClip.PCMReaderCallback), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UnityEngine_AudioClip_PCMSetPositionCallback(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(AudioClip.PCMSetPositionCallback), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(AudioClip.PCMSetPositionCallback), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
