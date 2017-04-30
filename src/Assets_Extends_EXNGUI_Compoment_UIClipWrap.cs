using Assets.Extends.EXNGUI.Compoment;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Extends_EXNGUI_Compoment_UIClipWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIClip), typeof(MonoBehaviour), null);
		L.RegFunction("Init", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIClipWrap.Init));
		L.RegFunction("GoToAndPlay", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIClipWrap.GoToAndPlay));
		L.RegFunction("GoToAndStop", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIClipWrap.GoToAndStop));
		L.RegFunction("Play", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIClipWrap.Play));
		L.RegFunction("Stop", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIClipWrap.Stop));
		L.RegFunction("RebuildSpriteList", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIClipWrap.RebuildSpriteList));
		L.RegFunction("SnapFrame", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIClipWrap.SnapFrame));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIClipWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("playStyle", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIClipWrap.get_playStyle), new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIClipWrap.set_playStyle));
		L.RegVar("clipName", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIClipWrap.get_clipName), new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIClipWrap.set_clipName));
		L.RegVar("suffix", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIClipWrap.get_suffix), new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIClipWrap.set_suffix));
		L.RegVar("frameTime", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIClipWrap.get_frameTime), new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIClipWrap.set_frameTime));
		L.RegVar("fromIndex", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIClipWrap.get_fromIndex), new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIClipWrap.set_fromIndex));
		L.RegVar("toIndex", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIClipWrap.get_toIndex), new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIClipWrap.set_toIndex));
		L.RegVar("indexParse", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIClipWrap.get_indexParse), new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIClipWrap.set_indexParse));
		L.RegVar("adjustSize", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIClipWrap.get_adjustSize), new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIClipWrap.set_adjustSize));
		L.RegVar("sizeScale", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIClipWrap.get_sizeScale), new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIClipWrap.set_sizeScale));
		L.RegVar("autoStart", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIClipWrap.get_autoStart), new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIClipWrap.set_autoStart));
		L.RegVar("stopOnDisable", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIClipWrap.get_stopOnDisable), new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIClipWrap.set_stopOnDisable));
		L.RegVar("onPlayEndSignal", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIClipWrap.get_onPlayEndSignal), new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIClipWrap.set_onPlayEndSignal));
		L.RegVar("isPlaying", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIClipWrap.get_isPlaying), null);
		L.RegVar("currFrame", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIClipWrap.get_currFrame), null);
		L.RegVar("totalFrame", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIClipWrap.get_totalFrame), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Init(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIClip uIClip = (UIClip)ToLua.CheckObject(L, 1, typeof(UIClip));
			uIClip.Init();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GoToAndPlay(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIClip uIClip = (UIClip)ToLua.CheckObject(L, 1, typeof(UIClip));
			int frame = (int)LuaDLL.luaL_checknumber(L, 2);
			uIClip.GoToAndPlay(frame);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GoToAndStop(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIClip uIClip = (UIClip)ToLua.CheckObject(L, 1, typeof(UIClip));
			int frame = (int)LuaDLL.luaL_checknumber(L, 2);
			uIClip.GoToAndStop(frame);
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
			UIClip uIClip = (UIClip)ToLua.CheckObject(L, 1, typeof(UIClip));
			uIClip.Play();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Stop(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIClip uIClip = (UIClip)ToLua.CheckObject(L, 1, typeof(UIClip));
			uIClip.Stop();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RebuildSpriteList(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIClip uIClip = (UIClip)ToLua.CheckObject(L, 1, typeof(UIClip));
			uIClip.RebuildSpriteList();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SnapFrame(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIClip uIClip = (UIClip)ToLua.CheckObject(L, 1, typeof(UIClip));
			uIClip.SnapFrame();
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
	private static int get_playStyle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIClip uIClip = (UIClip)obj;
			UIClip.Style playStyle = uIClip.playStyle;
			ToLua.Push(L, playStyle);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index playStyle on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_clipName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIClip uIClip = (UIClip)obj;
			string clipName = uIClip.clipName;
			LuaDLL.lua_pushstring(L, clipName);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index clipName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_suffix(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIClip uIClip = (UIClip)obj;
			string suffix = uIClip.suffix;
			LuaDLL.lua_pushstring(L, suffix);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index suffix on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_frameTime(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIClip uIClip = (UIClip)obj;
			float frameTime = uIClip.frameTime;
			LuaDLL.lua_pushnumber(L, (double)frameTime);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index frameTime on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fromIndex(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIClip uIClip = (UIClip)obj;
			int fromIndex = uIClip.fromIndex;
			LuaDLL.lua_pushinteger(L, fromIndex);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fromIndex on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_toIndex(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIClip uIClip = (UIClip)obj;
			int toIndex = uIClip.toIndex;
			LuaDLL.lua_pushinteger(L, toIndex);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index toIndex on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_indexParse(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIClip uIClip = (UIClip)obj;
			string indexParse = uIClip.indexParse;
			LuaDLL.lua_pushstring(L, indexParse);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index indexParse on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_adjustSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIClip uIClip = (UIClip)obj;
			bool adjustSize = uIClip.adjustSize;
			LuaDLL.lua_pushboolean(L, adjustSize);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index adjustSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sizeScale(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIClip uIClip = (UIClip)obj;
			float sizeScale = uIClip.sizeScale;
			LuaDLL.lua_pushnumber(L, (double)sizeScale);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sizeScale on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_autoStart(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIClip uIClip = (UIClip)obj;
			bool autoStart = uIClip.autoStart;
			LuaDLL.lua_pushboolean(L, autoStart);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index autoStart on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_stopOnDisable(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIClip uIClip = (UIClip)obj;
			bool stopOnDisable = uIClip.stopOnDisable;
			LuaDLL.lua_pushboolean(L, stopOnDisable);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index stopOnDisable on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onPlayEndSignal(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIClip uIClip = (UIClip)obj;
			Action<UIClip> onPlayEndSignal = uIClip.onPlayEndSignal;
			ToLua.Push(L, onPlayEndSignal);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onPlayEndSignal on a nil value");
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
			UIClip uIClip = (UIClip)obj;
			bool isPlaying = uIClip.isPlaying;
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
	private static int get_currFrame(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIClip uIClip = (UIClip)obj;
			int currFrame = uIClip.currFrame;
			LuaDLL.lua_pushinteger(L, currFrame);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index currFrame on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_totalFrame(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIClip uIClip = (UIClip)obj;
			int totalFrame = uIClip.totalFrame;
			LuaDLL.lua_pushinteger(L, totalFrame);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index totalFrame on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_playStyle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIClip uIClip = (UIClip)obj;
			UIClip.Style playStyle = (UIClip.Style)((int)ToLua.CheckObject(L, 2, typeof(UIClip.Style)));
			uIClip.playStyle = playStyle;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index playStyle on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_clipName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIClip uIClip = (UIClip)obj;
			string clipName = ToLua.CheckString(L, 2);
			uIClip.clipName = clipName;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index clipName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_suffix(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIClip uIClip = (UIClip)obj;
			string suffix = ToLua.CheckString(L, 2);
			uIClip.suffix = suffix;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index suffix on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_frameTime(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIClip uIClip = (UIClip)obj;
			float frameTime = (float)LuaDLL.luaL_checknumber(L, 2);
			uIClip.frameTime = frameTime;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index frameTime on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fromIndex(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIClip uIClip = (UIClip)obj;
			int fromIndex = (int)LuaDLL.luaL_checknumber(L, 2);
			uIClip.fromIndex = fromIndex;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fromIndex on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_toIndex(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIClip uIClip = (UIClip)obj;
			int toIndex = (int)LuaDLL.luaL_checknumber(L, 2);
			uIClip.toIndex = toIndex;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index toIndex on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_indexParse(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIClip uIClip = (UIClip)obj;
			string indexParse = ToLua.CheckString(L, 2);
			uIClip.indexParse = indexParse;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index indexParse on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_adjustSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIClip uIClip = (UIClip)obj;
			bool adjustSize = LuaDLL.luaL_checkboolean(L, 2);
			uIClip.adjustSize = adjustSize;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index adjustSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sizeScale(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIClip uIClip = (UIClip)obj;
			float sizeScale = (float)LuaDLL.luaL_checknumber(L, 2);
			uIClip.sizeScale = sizeScale;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sizeScale on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_autoStart(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIClip uIClip = (UIClip)obj;
			bool autoStart = LuaDLL.luaL_checkboolean(L, 2);
			uIClip.autoStart = autoStart;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index autoStart on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_stopOnDisable(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIClip uIClip = (UIClip)obj;
			bool stopOnDisable = LuaDLL.luaL_checkboolean(L, 2);
			uIClip.stopOnDisable = stopOnDisable;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index stopOnDisable on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onPlayEndSignal(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIClip uIClip = (UIClip)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action<UIClip> onPlayEndSignal;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onPlayEndSignal = (Action<UIClip>)ToLua.CheckObject(L, 2, typeof(Action<UIClip>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onPlayEndSignal = (DelegateFactory.CreateDelegate(typeof(Action<UIClip>), func) as Action<UIClip>);
			}
			uIClip.onPlayEndSignal = onPlayEndSignal;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onPlayEndSignal on a nil value");
		}
		return result;
	}
}
