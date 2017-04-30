using Assets.Scripts.Tools.Component;
using LuaInterface;
using System;
using UnityEngine;

public class Assets_Scripts_Tools_Component_ProjectileLineWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(ProjectileLine), typeof(MonoBehaviour), null);
		L.RegFunction("DisposeProjectileLine", new LuaCSFunction(Assets_Scripts_Tools_Component_ProjectileLineWrap.DisposeProjectileLine));
		L.RegFunction("SetTargetLocalPosition", new LuaCSFunction(Assets_Scripts_Tools_Component_ProjectileLineWrap.SetTargetLocalPosition));
		L.RegFunction("SetTargetPosition", new LuaCSFunction(Assets_Scripts_Tools_Component_ProjectileLineWrap.SetTargetPosition));
		L.RegFunction("Refresh", new LuaCSFunction(Assets_Scripts_Tools_Component_ProjectileLineWrap.Refresh));
		L.RegFunction("__eq", new LuaCSFunction(Assets_Scripts_Tools_Component_ProjectileLineWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Coordinate", new LuaCSFunction(Assets_Scripts_Tools_Component_ProjectileLineWrap.get_Coordinate), new LuaCSFunction(Assets_Scripts_Tools_Component_ProjectileLineWrap.set_Coordinate));
		L.RegVar("Arrows", new LuaCSFunction(Assets_Scripts_Tools_Component_ProjectileLineWrap.get_Arrows), new LuaCSFunction(Assets_Scripts_Tools_Component_ProjectileLineWrap.set_Arrows));
		L.RegVar("Target", new LuaCSFunction(Assets_Scripts_Tools_Component_ProjectileLineWrap.get_Target), new LuaCSFunction(Assets_Scripts_Tools_Component_ProjectileLineWrap.set_Target));
		L.RegVar("LintRoot", new LuaCSFunction(Assets_Scripts_Tools_Component_ProjectileLineWrap.get_LintRoot), new LuaCSFunction(Assets_Scripts_Tools_Component_ProjectileLineWrap.set_LintRoot));
		L.RegVar("LineItemPrefab", new LuaCSFunction(Assets_Scripts_Tools_Component_ProjectileLineWrap.get_LineItemPrefab), new LuaCSFunction(Assets_Scripts_Tools_Component_ProjectileLineWrap.set_LineItemPrefab));
		L.RegVar("LineItemWidth", new LuaCSFunction(Assets_Scripts_Tools_Component_ProjectileLineWrap.get_LineItemWidth), new LuaCSFunction(Assets_Scripts_Tools_Component_ProjectileLineWrap.set_LineItemWidth));
		L.RegVar("Speed", new LuaCSFunction(Assets_Scripts_Tools_Component_ProjectileLineWrap.get_Speed), new LuaCSFunction(Assets_Scripts_Tools_Component_ProjectileLineWrap.set_Speed));
		L.RegVar("Height", new LuaCSFunction(Assets_Scripts_Tools_Component_ProjectileLineWrap.get_Height), new LuaCSFunction(Assets_Scripts_Tools_Component_ProjectileLineWrap.set_Height));
		L.RegVar("HeightCoefficient", new LuaCSFunction(Assets_Scripts_Tools_Component_ProjectileLineWrap.get_HeightCoefficient), new LuaCSFunction(Assets_Scripts_Tools_Component_ProjectileLineWrap.set_HeightCoefficient));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DisposeProjectileLine(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			ProjectileLine.DisposeProjectileLine();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetTargetLocalPosition(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			ProjectileLine projectileLine = (ProjectileLine)ToLua.CheckObject(L, 1, typeof(ProjectileLine));
			Vector3 targetLocalPosition = ToLua.ToVector3(L, 2);
			projectileLine.SetTargetLocalPosition(targetLocalPosition);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetTargetPosition(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			ProjectileLine projectileLine = (ProjectileLine)ToLua.CheckObject(L, 1, typeof(ProjectileLine));
			Vector3 targetPosition = ToLua.ToVector3(L, 2);
			projectileLine.SetTargetPosition(targetPosition);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Refresh(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			ProjectileLine projectileLine = (ProjectileLine)ToLua.CheckObject(L, 1, typeof(ProjectileLine));
			projectileLine.Refresh();
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
	private static int get_Coordinate(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ProjectileLine projectileLine = (ProjectileLine)obj;
			Transform coordinate = projectileLine.Coordinate;
			ToLua.Push(L, coordinate);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Coordinate on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Arrows(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ProjectileLine projectileLine = (ProjectileLine)obj;
			GameObject arrows = projectileLine.Arrows;
			ToLua.Push(L, arrows);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Arrows on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Target(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ProjectileLine projectileLine = (ProjectileLine)obj;
			Transform target = projectileLine.Target;
			ToLua.Push(L, target);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Target on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_LintRoot(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ProjectileLine projectileLine = (ProjectileLine)obj;
			Transform lintRoot = projectileLine.LintRoot;
			ToLua.Push(L, lintRoot);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index LintRoot on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_LineItemPrefab(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ProjectileLine projectileLine = (ProjectileLine)obj;
			GameObject lineItemPrefab = projectileLine.LineItemPrefab;
			ToLua.Push(L, lineItemPrefab);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index LineItemPrefab on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_LineItemWidth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ProjectileLine projectileLine = (ProjectileLine)obj;
			float lineItemWidth = projectileLine.LineItemWidth;
			LuaDLL.lua_pushnumber(L, (double)lineItemWidth);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index LineItemWidth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Speed(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ProjectileLine projectileLine = (ProjectileLine)obj;
			float speed = projectileLine.Speed;
			LuaDLL.lua_pushnumber(L, (double)speed);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Speed on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Height(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ProjectileLine projectileLine = (ProjectileLine)obj;
			float height = projectileLine.Height;
			LuaDLL.lua_pushnumber(L, (double)height);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Height on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_HeightCoefficient(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ProjectileLine projectileLine = (ProjectileLine)obj;
			float heightCoefficient = projectileLine.HeightCoefficient;
			LuaDLL.lua_pushnumber(L, (double)heightCoefficient);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index HeightCoefficient on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Coordinate(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ProjectileLine projectileLine = (ProjectileLine)obj;
			Transform coordinate = (Transform)ToLua.CheckUnityObject(L, 2, typeof(Transform));
			projectileLine.Coordinate = coordinate;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Coordinate on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Arrows(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ProjectileLine projectileLine = (ProjectileLine)obj;
			GameObject arrows = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			projectileLine.Arrows = arrows;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Arrows on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Target(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ProjectileLine projectileLine = (ProjectileLine)obj;
			Transform target = (Transform)ToLua.CheckUnityObject(L, 2, typeof(Transform));
			projectileLine.Target = target;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Target on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_LintRoot(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ProjectileLine projectileLine = (ProjectileLine)obj;
			Transform lintRoot = (Transform)ToLua.CheckUnityObject(L, 2, typeof(Transform));
			projectileLine.LintRoot = lintRoot;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index LintRoot on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_LineItemPrefab(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ProjectileLine projectileLine = (ProjectileLine)obj;
			GameObject lineItemPrefab = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			projectileLine.LineItemPrefab = lineItemPrefab;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index LineItemPrefab on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_LineItemWidth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ProjectileLine projectileLine = (ProjectileLine)obj;
			float lineItemWidth = (float)LuaDLL.luaL_checknumber(L, 2);
			projectileLine.LineItemWidth = lineItemWidth;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index LineItemWidth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Speed(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ProjectileLine projectileLine = (ProjectileLine)obj;
			float speed = (float)LuaDLL.luaL_checknumber(L, 2);
			projectileLine.Speed = speed;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Speed on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Height(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ProjectileLine projectileLine = (ProjectileLine)obj;
			float height = (float)LuaDLL.luaL_checknumber(L, 2);
			projectileLine.Height = height;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Height on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_HeightCoefficient(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ProjectileLine projectileLine = (ProjectileLine)obj;
			float heightCoefficient = (float)LuaDLL.luaL_checknumber(L, 2);
			projectileLine.HeightCoefficient = heightCoefficient;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index HeightCoefficient on a nil value");
		}
		return result;
	}
}
