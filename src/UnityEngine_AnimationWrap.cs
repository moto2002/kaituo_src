using LuaInterface;
using System;
using System.Collections;
using UnityEngine;

public class UnityEngine_AnimationWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Animation), typeof(Behaviour), null);
		L.RegFunction("Stop", new LuaCSFunction(UnityEngine_AnimationWrap.Stop));
		L.RegFunction("Rewind", new LuaCSFunction(UnityEngine_AnimationWrap.Rewind));
		L.RegFunction("Sample", new LuaCSFunction(UnityEngine_AnimationWrap.Sample));
		L.RegFunction("IsPlaying", new LuaCSFunction(UnityEngine_AnimationWrap.IsPlaying));
		L.RegFunction("get_Item", new LuaCSFunction(UnityEngine_AnimationWrap.get_Item));
		L.RegFunction("Play", new LuaCSFunction(UnityEngine_AnimationWrap.Play));
		L.RegFunction("CrossFade", new LuaCSFunction(UnityEngine_AnimationWrap.CrossFade));
		L.RegFunction("Blend", new LuaCSFunction(UnityEngine_AnimationWrap.Blend));
		L.RegFunction("CrossFadeQueued", new LuaCSFunction(UnityEngine_AnimationWrap.CrossFadeQueued));
		L.RegFunction("PlayQueued", new LuaCSFunction(UnityEngine_AnimationWrap.PlayQueued));
		L.RegFunction("AddClip", new LuaCSFunction(UnityEngine_AnimationWrap.AddClip));
		L.RegFunction("RemoveClip", new LuaCSFunction(UnityEngine_AnimationWrap.RemoveClip));
		L.RegFunction("GetClipCount", new LuaCSFunction(UnityEngine_AnimationWrap.GetClipCount));
		L.RegFunction("SyncLayer", new LuaCSFunction(UnityEngine_AnimationWrap.SyncLayer));
		L.RegFunction("GetEnumerator", new LuaCSFunction(UnityEngine_AnimationWrap.GetEnumerator));
		L.RegFunction("GetClip", new LuaCSFunction(UnityEngine_AnimationWrap.GetClip));
		L.RegFunction("New", new LuaCSFunction(UnityEngine_AnimationWrap._CreateUnityEngine_Animation));
		L.RegVar("this", new LuaCSFunction(UnityEngine_AnimationWrap._this), null);
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_AnimationWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("clip", new LuaCSFunction(UnityEngine_AnimationWrap.get_clip), new LuaCSFunction(UnityEngine_AnimationWrap.set_clip));
		L.RegVar("playAutomatically", new LuaCSFunction(UnityEngine_AnimationWrap.get_playAutomatically), new LuaCSFunction(UnityEngine_AnimationWrap.set_playAutomatically));
		L.RegVar("wrapMode", new LuaCSFunction(UnityEngine_AnimationWrap.get_wrapMode), new LuaCSFunction(UnityEngine_AnimationWrap.set_wrapMode));
		L.RegVar("isPlaying", new LuaCSFunction(UnityEngine_AnimationWrap.get_isPlaying), null);
		L.RegVar("animatePhysics", new LuaCSFunction(UnityEngine_AnimationWrap.get_animatePhysics), new LuaCSFunction(UnityEngine_AnimationWrap.set_animatePhysics));
		L.RegVar("cullingType", new LuaCSFunction(UnityEngine_AnimationWrap.get_cullingType), new LuaCSFunction(UnityEngine_AnimationWrap.set_cullingType));
		L.RegVar("localBounds", new LuaCSFunction(UnityEngine_AnimationWrap.get_localBounds), new LuaCSFunction(UnityEngine_AnimationWrap.set_localBounds));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUnityEngine_Animation(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				Animation obj = new Animation();
				ToLua.Push(L, obj);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.Animation.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _get_this(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Animation animation = (Animation)ToLua.CheckObject(L, 1, typeof(Animation));
			string name = ToLua.CheckString(L, 2);
			AnimationState obj = animation[name];
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
	private static int _this(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushvalue(L, 1);
			LuaDLL.tolua_bindthis(L, new LuaCSFunction(UnityEngine_AnimationWrap._get_this), null);
			result = 1;
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
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Animation)))
			{
				Animation animation = (Animation)ToLua.ToObject(L, 1);
				animation.Stop();
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Animation), typeof(string)))
			{
				Animation animation2 = (Animation)ToLua.ToObject(L, 1);
				string name = ToLua.ToString(L, 2);
				animation2.Stop(name);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Animation.Stop");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Rewind(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Animation)))
			{
				Animation animation = (Animation)ToLua.ToObject(L, 1);
				animation.Rewind();
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Animation), typeof(string)))
			{
				Animation animation2 = (Animation)ToLua.ToObject(L, 1);
				string name = ToLua.ToString(L, 2);
				animation2.Rewind(name);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Animation.Rewind");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Sample(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Animation animation = (Animation)ToLua.CheckObject(L, 1, typeof(Animation));
			animation.Sample();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsPlaying(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Animation animation = (Animation)ToLua.CheckObject(L, 1, typeof(Animation));
			string name = ToLua.CheckString(L, 2);
			bool value = animation.IsPlaying(name);
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
	private static int get_Item(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Animation animation = (Animation)ToLua.CheckObject(L, 1, typeof(Animation));
			string name = ToLua.CheckString(L, 2);
			AnimationState obj = animation[name];
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
	private static int Play(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Animation)))
			{
				Animation animation = (Animation)ToLua.ToObject(L, 1);
				bool value = animation.Play();
				LuaDLL.lua_pushboolean(L, value);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Animation), typeof(string)))
			{
				Animation animation2 = (Animation)ToLua.ToObject(L, 1);
				string animation3 = ToLua.ToString(L, 2);
				bool value2 = animation2.Play(animation3);
				LuaDLL.lua_pushboolean(L, value2);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Animation), typeof(PlayMode)))
			{
				Animation animation4 = (Animation)ToLua.ToObject(L, 1);
				PlayMode mode = (PlayMode)((int)ToLua.ToObject(L, 2));
				bool value3 = animation4.Play(mode);
				LuaDLL.lua_pushboolean(L, value3);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Animation), typeof(string), typeof(PlayMode)))
			{
				Animation animation5 = (Animation)ToLua.ToObject(L, 1);
				string animation6 = ToLua.ToString(L, 2);
				PlayMode mode2 = (PlayMode)((int)ToLua.ToObject(L, 3));
				bool value4 = animation5.Play(animation6, mode2);
				LuaDLL.lua_pushboolean(L, value4);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Animation.Play");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CrossFade(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Animation), typeof(string)))
			{
				Animation animation = (Animation)ToLua.ToObject(L, 1);
				string animation2 = ToLua.ToString(L, 2);
				animation.CrossFade(animation2);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Animation), typeof(string), typeof(float)))
			{
				Animation animation3 = (Animation)ToLua.ToObject(L, 1);
				string animation4 = ToLua.ToString(L, 2);
				float fadeLength = (float)LuaDLL.lua_tonumber(L, 3);
				animation3.CrossFade(animation4, fadeLength);
				result = 0;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Animation), typeof(string), typeof(float), typeof(PlayMode)))
			{
				Animation animation5 = (Animation)ToLua.ToObject(L, 1);
				string animation6 = ToLua.ToString(L, 2);
				float fadeLength2 = (float)LuaDLL.lua_tonumber(L, 3);
				PlayMode mode = (PlayMode)((int)ToLua.ToObject(L, 4));
				animation5.CrossFade(animation6, fadeLength2, mode);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Animation.CrossFade");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Blend(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Animation), typeof(string)))
			{
				Animation animation = (Animation)ToLua.ToObject(L, 1);
				string animation2 = ToLua.ToString(L, 2);
				animation.Blend(animation2);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Animation), typeof(string), typeof(float)))
			{
				Animation animation3 = (Animation)ToLua.ToObject(L, 1);
				string animation4 = ToLua.ToString(L, 2);
				float targetWeight = (float)LuaDLL.lua_tonumber(L, 3);
				animation3.Blend(animation4, targetWeight);
				result = 0;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Animation), typeof(string), typeof(float), typeof(float)))
			{
				Animation animation5 = (Animation)ToLua.ToObject(L, 1);
				string animation6 = ToLua.ToString(L, 2);
				float targetWeight2 = (float)LuaDLL.lua_tonumber(L, 3);
				float fadeLength = (float)LuaDLL.lua_tonumber(L, 4);
				animation5.Blend(animation6, targetWeight2, fadeLength);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Animation.Blend");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CrossFadeQueued(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Animation), typeof(string)))
			{
				Animation animation = (Animation)ToLua.ToObject(L, 1);
				string animation2 = ToLua.ToString(L, 2);
				AnimationState obj = animation.CrossFadeQueued(animation2);
				ToLua.Push(L, obj);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Animation), typeof(string), typeof(float)))
			{
				Animation animation3 = (Animation)ToLua.ToObject(L, 1);
				string animation4 = ToLua.ToString(L, 2);
				float fadeLength = (float)LuaDLL.lua_tonumber(L, 3);
				AnimationState obj2 = animation3.CrossFadeQueued(animation4, fadeLength);
				ToLua.Push(L, obj2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Animation), typeof(string), typeof(float), typeof(QueueMode)))
			{
				Animation animation5 = (Animation)ToLua.ToObject(L, 1);
				string animation6 = ToLua.ToString(L, 2);
				float fadeLength2 = (float)LuaDLL.lua_tonumber(L, 3);
				QueueMode queue = (QueueMode)((int)ToLua.ToObject(L, 4));
				AnimationState obj3 = animation5.CrossFadeQueued(animation6, fadeLength2, queue);
				ToLua.Push(L, obj3);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Animation), typeof(string), typeof(float), typeof(QueueMode), typeof(PlayMode)))
			{
				Animation animation7 = (Animation)ToLua.ToObject(L, 1);
				string animation8 = ToLua.ToString(L, 2);
				float fadeLength3 = (float)LuaDLL.lua_tonumber(L, 3);
				QueueMode queue2 = (QueueMode)((int)ToLua.ToObject(L, 4));
				PlayMode mode = (PlayMode)((int)ToLua.ToObject(L, 5));
				AnimationState obj4 = animation7.CrossFadeQueued(animation8, fadeLength3, queue2, mode);
				ToLua.Push(L, obj4);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Animation.CrossFadeQueued");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlayQueued(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Animation), typeof(string)))
			{
				Animation animation = (Animation)ToLua.ToObject(L, 1);
				string animation2 = ToLua.ToString(L, 2);
				AnimationState obj = animation.PlayQueued(animation2);
				ToLua.Push(L, obj);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Animation), typeof(string), typeof(QueueMode)))
			{
				Animation animation3 = (Animation)ToLua.ToObject(L, 1);
				string animation4 = ToLua.ToString(L, 2);
				QueueMode queue = (QueueMode)((int)ToLua.ToObject(L, 3));
				AnimationState obj2 = animation3.PlayQueued(animation4, queue);
				ToLua.Push(L, obj2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Animation), typeof(string), typeof(QueueMode), typeof(PlayMode)))
			{
				Animation animation5 = (Animation)ToLua.ToObject(L, 1);
				string animation6 = ToLua.ToString(L, 2);
				QueueMode queue2 = (QueueMode)((int)ToLua.ToObject(L, 3));
				PlayMode mode = (PlayMode)((int)ToLua.ToObject(L, 4));
				AnimationState obj3 = animation5.PlayQueued(animation6, queue2, mode);
				ToLua.Push(L, obj3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Animation.PlayQueued");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddClip(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Animation), typeof(AnimationClip), typeof(string)))
			{
				Animation animation = (Animation)ToLua.ToObject(L, 1);
				AnimationClip clip = (AnimationClip)ToLua.ToObject(L, 2);
				string newName = ToLua.ToString(L, 3);
				animation.AddClip(clip, newName);
				result = 0;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Animation), typeof(AnimationClip), typeof(string), typeof(int), typeof(int)))
			{
				Animation animation2 = (Animation)ToLua.ToObject(L, 1);
				AnimationClip clip2 = (AnimationClip)ToLua.ToObject(L, 2);
				string newName2 = ToLua.ToString(L, 3);
				int firstFrame = (int)LuaDLL.lua_tonumber(L, 4);
				int lastFrame = (int)LuaDLL.lua_tonumber(L, 5);
				animation2.AddClip(clip2, newName2, firstFrame, lastFrame);
				result = 0;
			}
			else if (num == 6 && TypeChecker.CheckTypes(L, 1, typeof(Animation), typeof(AnimationClip), typeof(string), typeof(int), typeof(int), typeof(bool)))
			{
				Animation animation3 = (Animation)ToLua.ToObject(L, 1);
				AnimationClip clip3 = (AnimationClip)ToLua.ToObject(L, 2);
				string newName3 = ToLua.ToString(L, 3);
				int firstFrame2 = (int)LuaDLL.lua_tonumber(L, 4);
				int lastFrame2 = (int)LuaDLL.lua_tonumber(L, 5);
				bool addLoopFrame = LuaDLL.lua_toboolean(L, 6);
				animation3.AddClip(clip3, newName3, firstFrame2, lastFrame2, addLoopFrame);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Animation.AddClip");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveClip(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Animation), typeof(string)))
			{
				Animation animation = (Animation)ToLua.ToObject(L, 1);
				string clipName = ToLua.ToString(L, 2);
				animation.RemoveClip(clipName);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Animation), typeof(AnimationClip)))
			{
				Animation animation2 = (Animation)ToLua.ToObject(L, 1);
				AnimationClip clip = (AnimationClip)ToLua.ToObject(L, 2);
				animation2.RemoveClip(clip);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Animation.RemoveClip");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClipCount(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Animation animation = (Animation)ToLua.CheckObject(L, 1, typeof(Animation));
			int clipCount = animation.GetClipCount();
			LuaDLL.lua_pushinteger(L, clipCount);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SyncLayer(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Animation animation = (Animation)ToLua.CheckObject(L, 1, typeof(Animation));
			int layer = (int)LuaDLL.luaL_checknumber(L, 2);
			animation.SyncLayer(layer);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetEnumerator(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Animation animation = (Animation)ToLua.CheckObject(L, 1, typeof(Animation));
			IEnumerator enumerator = animation.GetEnumerator();
			ToLua.Push(L, enumerator);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClip(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Animation animation = (Animation)ToLua.CheckObject(L, 1, typeof(Animation));
			string name = ToLua.CheckString(L, 2);
			AnimationClip clip = animation.GetClip(name);
			ToLua.Push(L, clip);
			result = 1;
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
	private static int get_clip(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animation animation = (Animation)obj;
			AnimationClip clip = animation.clip;
			ToLua.Push(L, clip);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index clip on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_playAutomatically(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animation animation = (Animation)obj;
			bool playAutomatically = animation.playAutomatically;
			LuaDLL.lua_pushboolean(L, playAutomatically);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index playAutomatically on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_wrapMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animation animation = (Animation)obj;
			WrapMode wrapMode = animation.wrapMode;
			ToLua.Push(L, wrapMode);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index wrapMode on a nil value");
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
			Animation animation = (Animation)obj;
			bool isPlaying = animation.isPlaying;
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
	private static int get_animatePhysics(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animation animation = (Animation)obj;
			bool animatePhysics = animation.animatePhysics;
			LuaDLL.lua_pushboolean(L, animatePhysics);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index animatePhysics on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cullingType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animation animation = (Animation)obj;
			AnimationCullingType cullingType = animation.cullingType;
			ToLua.Push(L, cullingType);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cullingType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_localBounds(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animation animation = (Animation)obj;
			Bounds localBounds = animation.localBounds;
			ToLua.Push(L, localBounds);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index localBounds on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_clip(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animation animation = (Animation)obj;
			AnimationClip clip = (AnimationClip)ToLua.CheckUnityObject(L, 2, typeof(AnimationClip));
			animation.clip = clip;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index clip on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_playAutomatically(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animation animation = (Animation)obj;
			bool playAutomatically = LuaDLL.luaL_checkboolean(L, 2);
			animation.playAutomatically = playAutomatically;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index playAutomatically on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_wrapMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animation animation = (Animation)obj;
			WrapMode wrapMode = (WrapMode)((int)ToLua.CheckObject(L, 2, typeof(WrapMode)));
			animation.wrapMode = wrapMode;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index wrapMode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_animatePhysics(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animation animation = (Animation)obj;
			bool animatePhysics = LuaDLL.luaL_checkboolean(L, 2);
			animation.animatePhysics = animatePhysics;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index animatePhysics on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_cullingType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animation animation = (Animation)obj;
			AnimationCullingType cullingType = (AnimationCullingType)LuaDLL.luaL_checknumber(L, 2);
			animation.cullingType = cullingType;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cullingType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_localBounds(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Animation animation = (Animation)obj;
			Bounds localBounds = ToLua.ToBounds(L, 2);
			animation.localBounds = localBounds;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index localBounds on a nil value");
		}
		return result;
	}
}
