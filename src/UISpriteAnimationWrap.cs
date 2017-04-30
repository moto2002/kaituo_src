using LuaInterface;
using System;
using UnityEngine;

public class UISpriteAnimationWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UISpriteAnimation), typeof(MonoBehaviour), null);
		L.RegFunction("RebuildSpriteList", new LuaCSFunction(UISpriteAnimationWrap.RebuildSpriteList));
		L.RegFunction("Play", new LuaCSFunction(UISpriteAnimationWrap.Play));
		L.RegFunction("Pause", new LuaCSFunction(UISpriteAnimationWrap.Pause));
		L.RegFunction("ResetToBeginning", new LuaCSFunction(UISpriteAnimationWrap.ResetToBeginning));
		L.RegFunction("__eq", new LuaCSFunction(UISpriteAnimationWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("frameIndex", new LuaCSFunction(UISpriteAnimationWrap.get_frameIndex), new LuaCSFunction(UISpriteAnimationWrap.set_frameIndex));
		L.RegVar("frames", new LuaCSFunction(UISpriteAnimationWrap.get_frames), null);
		L.RegVar("framesPerSecond", new LuaCSFunction(UISpriteAnimationWrap.get_framesPerSecond), new LuaCSFunction(UISpriteAnimationWrap.set_framesPerSecond));
		L.RegVar("namePrefix", new LuaCSFunction(UISpriteAnimationWrap.get_namePrefix), new LuaCSFunction(UISpriteAnimationWrap.set_namePrefix));
		L.RegVar("loop", new LuaCSFunction(UISpriteAnimationWrap.get_loop), new LuaCSFunction(UISpriteAnimationWrap.set_loop));
		L.RegVar("isPlaying", new LuaCSFunction(UISpriteAnimationWrap.get_isPlaying), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RebuildSpriteList(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UISpriteAnimation uISpriteAnimation = (UISpriteAnimation)ToLua.CheckObject(L, 1, typeof(UISpriteAnimation));
			uISpriteAnimation.RebuildSpriteList();
			result = 0;
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
			UISpriteAnimation uISpriteAnimation = (UISpriteAnimation)ToLua.CheckObject(L, 1, typeof(UISpriteAnimation));
			uISpriteAnimation.Play();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Pause(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UISpriteAnimation uISpriteAnimation = (UISpriteAnimation)ToLua.CheckObject(L, 1, typeof(UISpriteAnimation));
			uISpriteAnimation.Pause();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ResetToBeginning(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UISpriteAnimation uISpriteAnimation = (UISpriteAnimation)ToLua.CheckObject(L, 1, typeof(UISpriteAnimation));
			uISpriteAnimation.ResetToBeginning();
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
	private static int get_frameIndex(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISpriteAnimation uISpriteAnimation = (UISpriteAnimation)obj;
			int frameIndex = uISpriteAnimation.frameIndex;
			LuaDLL.lua_pushinteger(L, frameIndex);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index frameIndex on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_frames(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISpriteAnimation uISpriteAnimation = (UISpriteAnimation)obj;
			int frames = uISpriteAnimation.frames;
			LuaDLL.lua_pushinteger(L, frames);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index frames on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_framesPerSecond(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISpriteAnimation uISpriteAnimation = (UISpriteAnimation)obj;
			int framesPerSecond = uISpriteAnimation.framesPerSecond;
			LuaDLL.lua_pushinteger(L, framesPerSecond);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index framesPerSecond on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_namePrefix(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISpriteAnimation uISpriteAnimation = (UISpriteAnimation)obj;
			string namePrefix = uISpriteAnimation.namePrefix;
			LuaDLL.lua_pushstring(L, namePrefix);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index namePrefix on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_loop(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISpriteAnimation uISpriteAnimation = (UISpriteAnimation)obj;
			bool loop = uISpriteAnimation.loop;
			LuaDLL.lua_pushboolean(L, loop);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index loop on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isPlaying(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISpriteAnimation uISpriteAnimation = (UISpriteAnimation)obj;
			bool isPlaying = uISpriteAnimation.isPlaying;
			LuaDLL.lua_pushboolean(L, isPlaying);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isPlaying on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_frameIndex(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISpriteAnimation uISpriteAnimation = (UISpriteAnimation)obj;
			int frameIndex = (int)LuaDLL.luaL_checknumber(L, 2);
			uISpriteAnimation.frameIndex = frameIndex;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index frameIndex on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_framesPerSecond(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISpriteAnimation uISpriteAnimation = (UISpriteAnimation)obj;
			int framesPerSecond = (int)LuaDLL.luaL_checknumber(L, 2);
			uISpriteAnimation.framesPerSecond = framesPerSecond;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index framesPerSecond on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_namePrefix(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISpriteAnimation uISpriteAnimation = (UISpriteAnimation)obj;
			string namePrefix = ToLua.CheckString(L, 2);
			uISpriteAnimation.namePrefix = namePrefix;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index namePrefix on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_loop(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UISpriteAnimation uISpriteAnimation = (UISpriteAnimation)obj;
			bool loop = LuaDLL.luaL_checkboolean(L, 2);
			uISpriteAnimation.loop = loop;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index loop on a nil value");
		}
		return result;
	}
}
