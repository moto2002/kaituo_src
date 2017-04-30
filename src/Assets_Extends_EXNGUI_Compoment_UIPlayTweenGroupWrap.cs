using Assets.Extends.EXNGUI.Compoment;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Extends_EXNGUI_Compoment_UIPlayTweenGroupWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIPlayTweenGroup), typeof(MonoBehaviour), null);
		L.RegFunction("StopAllTweenGroup", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIPlayTweenGroupWrap.StopAllTweenGroup));
		L.RegFunction("RefreshTweener", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIPlayTweenGroupWrap.RefreshTweener));
		L.RegFunction("HasGroup", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIPlayTweenGroupWrap.HasGroup));
		L.RegFunction("PlayWithEnd", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIPlayTweenGroupWrap.PlayWithEnd));
		L.RegFunction("Play", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIPlayTweenGroupWrap.Play));
		L.RegFunction("Stop", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIPlayTweenGroupWrap.Stop));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIPlayTweenGroupWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("IncludeChildren", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIPlayTweenGroupWrap.get_IncludeChildren), new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIPlayTweenGroupWrap.set_IncludeChildren));
		L.RegVar("Group", new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIPlayTweenGroupWrap.get_Group), new LuaCSFunction(Assets_Extends_EXNGUI_Compoment_UIPlayTweenGroupWrap.set_Group));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StopAllTweenGroup(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			UIPlayTweenGroup.StopAllTweenGroup();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RefreshTweener(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIPlayTweenGroup uIPlayTweenGroup = (UIPlayTweenGroup)ToLua.CheckObject(L, 1, typeof(UIPlayTweenGroup));
			uIPlayTweenGroup.RefreshTweener();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int HasGroup(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIPlayTweenGroup uIPlayTweenGroup = (UIPlayTweenGroup)ToLua.CheckObject(L, 1, typeof(UIPlayTweenGroup));
			int group = (int)LuaDLL.luaL_checknumber(L, 2);
			bool value = uIPlayTweenGroup.HasGroup(group);
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
	private static int PlayWithEnd(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UIPlayTweenGroup uIPlayTweenGroup = (UIPlayTweenGroup)ToLua.CheckObject(L, 1, typeof(UIPlayTweenGroup));
			int group = (int)LuaDLL.luaL_checknumber(L, 2);
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
			uIPlayTweenGroup.PlayWithEnd(group, onEnd);
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
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(UIPlayTweenGroup)))
			{
				UIPlayTweenGroup uIPlayTweenGroup = (UIPlayTweenGroup)ToLua.ToObject(L, 1);
				uIPlayTweenGroup.Play();
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(UIPlayTweenGroup), typeof(int)))
			{
				UIPlayTweenGroup uIPlayTweenGroup2 = (UIPlayTweenGroup)ToLua.ToObject(L, 1);
				int group = (int)LuaDLL.lua_tonumber(L, 2);
				uIPlayTweenGroup2.Play(group);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: Assets.Extends.EXNGUI.Compoment.UIPlayTweenGroup.Play");
			}
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
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(UIPlayTweenGroup)))
			{
				UIPlayTweenGroup uIPlayTweenGroup = (UIPlayTweenGroup)ToLua.ToObject(L, 1);
				uIPlayTweenGroup.Stop();
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(UIPlayTweenGroup), typeof(int)))
			{
				UIPlayTweenGroup uIPlayTweenGroup2 = (UIPlayTweenGroup)ToLua.ToObject(L, 1);
				int group = (int)LuaDLL.lua_tonumber(L, 2);
				uIPlayTweenGroup2.Stop(group);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: Assets.Extends.EXNGUI.Compoment.UIPlayTweenGroup.Stop");
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
	private static int get_IncludeChildren(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPlayTweenGroup uIPlayTweenGroup = (UIPlayTweenGroup)obj;
			bool includeChildren = uIPlayTweenGroup.IncludeChildren;
			LuaDLL.lua_pushboolean(L, includeChildren);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IncludeChildren on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Group(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPlayTweenGroup uIPlayTweenGroup = (UIPlayTweenGroup)obj;
			int group = uIPlayTweenGroup.Group;
			LuaDLL.lua_pushinteger(L, group);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Group on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_IncludeChildren(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPlayTweenGroup uIPlayTweenGroup = (UIPlayTweenGroup)obj;
			bool includeChildren = LuaDLL.luaL_checkboolean(L, 2);
			uIPlayTweenGroup.IncludeChildren = includeChildren;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IncludeChildren on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Group(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPlayTweenGroup uIPlayTweenGroup = (UIPlayTweenGroup)obj;
			int group = (int)LuaDLL.luaL_checknumber(L, 2);
			uIPlayTweenGroup.Group = group;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Group on a nil value");
		}
		return result;
	}
}
