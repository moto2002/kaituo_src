using Assets.Extends.EXNGUI.Compoment;
using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;
using XQ.Game.Util.Unity;

public class XQ_Game_Util_Unity_AnimationPlayerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(AnimationPlayer), typeof(MonoBehaviour), null);
		L.RegFunction("StopAllAnimationPlayer", new LuaCSFunction(XQ_Game_Util_Unity_AnimationPlayerWrap.StopAllAnimationPlayer));
		L.RegFunction("PlayWithEnd", new LuaCSFunction(XQ_Game_Util_Unity_AnimationPlayerWrap.PlayWithEnd));
		L.RegFunction("Play", new LuaCSFunction(XQ_Game_Util_Unity_AnimationPlayerWrap.Play));
		L.RegFunction("Stop", new LuaCSFunction(XQ_Game_Util_Unity_AnimationPlayerWrap.Stop));
		L.RegFunction("Has", new LuaCSFunction(XQ_Game_Util_Unity_AnimationPlayerWrap.Has));
		L.RegFunction("__eq", new LuaCSFunction(XQ_Game_Util_Unity_AnimationPlayerWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("ShowChildrenLabel", new LuaCSFunction(XQ_Game_Util_Unity_AnimationPlayerWrap.get_ShowChildrenLabel), new LuaCSFunction(XQ_Game_Util_Unity_AnimationPlayerWrap.set_ShowChildrenLabel));
		L.RegVar("Animation", new LuaCSFunction(XQ_Game_Util_Unity_AnimationPlayerWrap.get_Animation), new LuaCSFunction(XQ_Game_Util_Unity_AnimationPlayerWrap.set_Animation));
		L.RegVar("TweenGroup", new LuaCSFunction(XQ_Game_Util_Unity_AnimationPlayerWrap.get_TweenGroup), new LuaCSFunction(XQ_Game_Util_Unity_AnimationPlayerWrap.set_TweenGroup));
		L.RegVar("TweenGroupNames", new LuaCSFunction(XQ_Game_Util_Unity_AnimationPlayerWrap.get_TweenGroupNames), new LuaCSFunction(XQ_Game_Util_Unity_AnimationPlayerWrap.set_TweenGroupNames));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StopAllAnimationPlayer(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			AnimationPlayer.StopAllAnimationPlayer();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlayWithEnd(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			AnimationPlayer animationPlayer = (AnimationPlayer)ToLua.CheckObject(L, 1, typeof(AnimationPlayer));
			string animName = ToLua.CheckString(L, 2);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 3);
			Action onEnd;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onEnd = (Action)ToLua.CheckObject(L, 3, typeof(Action));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 3);
				onEnd = (DelegateFactory.CreateDelegate(typeof(Action), func) as Action);
			}
			animationPlayer.PlayWithEnd(animName, onEnd);
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
			ToLua.CheckArgsCount(L, 2);
			AnimationPlayer animationPlayer = (AnimationPlayer)ToLua.CheckObject(L, 1, typeof(AnimationPlayer));
			string animName = ToLua.CheckString(L, 2);
			animationPlayer.Play(animName);
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
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(AnimationPlayer)))
			{
				AnimationPlayer animationPlayer = (AnimationPlayer)ToLua.ToObject(L, 1);
				animationPlayer.Stop();
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(AnimationPlayer), typeof(string)))
			{
				AnimationPlayer animationPlayer2 = (AnimationPlayer)ToLua.ToObject(L, 1);
				string animName = ToLua.ToString(L, 2);
				animationPlayer2.Stop(animName);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: XQ.Game.Util.Unity.AnimationPlayer.Stop");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Has(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			AnimationPlayer animationPlayer = (AnimationPlayer)ToLua.CheckObject(L, 1, typeof(AnimationPlayer));
			string animName = ToLua.CheckString(L, 2);
			bool value = animationPlayer.Has(animName);
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
	private static int get_ShowChildrenLabel(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AnimationPlayer animationPlayer = (AnimationPlayer)obj;
			bool showChildrenLabel = animationPlayer.ShowChildrenLabel;
			LuaDLL.lua_pushboolean(L, showChildrenLabel);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ShowChildrenLabel on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Animation(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AnimationPlayer animationPlayer = (AnimationPlayer)obj;
			Animation animation = animationPlayer.Animation;
			ToLua.Push(L, animation);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Animation on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_TweenGroup(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AnimationPlayer animationPlayer = (AnimationPlayer)obj;
			UIPlayTweenGroup tweenGroup = animationPlayer.TweenGroup;
			ToLua.Push(L, tweenGroup);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index TweenGroup on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_TweenGroupNames(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AnimationPlayer animationPlayer = (AnimationPlayer)obj;
			List<AnimationPlayerGroupName> tweenGroupNames = animationPlayer.TweenGroupNames;
			ToLua.PushObject(L, tweenGroupNames);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index TweenGroupNames on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ShowChildrenLabel(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AnimationPlayer animationPlayer = (AnimationPlayer)obj;
			bool showChildrenLabel = LuaDLL.luaL_checkboolean(L, 2);
			animationPlayer.ShowChildrenLabel = showChildrenLabel;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ShowChildrenLabel on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Animation(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AnimationPlayer animationPlayer = (AnimationPlayer)obj;
			Animation animation = (Animation)ToLua.CheckUnityObject(L, 2, typeof(Animation));
			animationPlayer.Animation = animation;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Animation on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_TweenGroup(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AnimationPlayer animationPlayer = (AnimationPlayer)obj;
			UIPlayTweenGroup tweenGroup = (UIPlayTweenGroup)ToLua.CheckUnityObject(L, 2, typeof(UIPlayTweenGroup));
			animationPlayer.TweenGroup = tweenGroup;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index TweenGroup on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_TweenGroupNames(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AnimationPlayer animationPlayer = (AnimationPlayer)obj;
			List<AnimationPlayerGroupName> tweenGroupNames = (List<AnimationPlayerGroupName>)ToLua.CheckObject(L, 2, typeof(List<AnimationPlayerGroupName>));
			animationPlayer.TweenGroupNames = tweenGroupNames;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index TweenGroupNames on a nil value");
		}
		return result;
	}
}
