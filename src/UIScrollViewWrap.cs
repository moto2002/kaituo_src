using LuaInterface;
using System;
using UnityEngine;

public class UIScrollViewWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIScrollView), typeof(MonoBehaviour), null);
		L.RegFunction("RestrictWithinBounds", new LuaCSFunction(UIScrollViewWrap.RestrictWithinBounds));
		L.RegFunction("DisableSpring", new LuaCSFunction(UIScrollViewWrap.DisableSpring));
		L.RegFunction("UpdateScrollbars", new LuaCSFunction(UIScrollViewWrap.UpdateScrollbars));
		L.RegFunction("SetDragAmount", new LuaCSFunction(UIScrollViewWrap.SetDragAmount));
		L.RegFunction("InvalidateBounds", new LuaCSFunction(UIScrollViewWrap.InvalidateBounds));
		L.RegFunction("ResetPosition", new LuaCSFunction(UIScrollViewWrap.ResetPosition));
		L.RegFunction("UpdatePosition", new LuaCSFunction(UIScrollViewWrap.UpdatePosition));
		L.RegFunction("OnScrollBar", new LuaCSFunction(UIScrollViewWrap.OnScrollBar));
		L.RegFunction("MoveRelative", new LuaCSFunction(UIScrollViewWrap.MoveRelative));
		L.RegFunction("MoveAbsolute", new LuaCSFunction(UIScrollViewWrap.MoveAbsolute));
		L.RegFunction("Press", new LuaCSFunction(UIScrollViewWrap.Press));
		L.RegFunction("Drag", new LuaCSFunction(UIScrollViewWrap.Drag));
		L.RegFunction("Scroll", new LuaCSFunction(UIScrollViewWrap.Scroll));
		L.RegFunction("OnPan", new LuaCSFunction(UIScrollViewWrap.OnPan));
		L.RegFunction("__eq", new LuaCSFunction(UIScrollViewWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("list", new LuaCSFunction(UIScrollViewWrap.get_list), new LuaCSFunction(UIScrollViewWrap.set_list));
		L.RegVar("accelerate", new LuaCSFunction(UIScrollViewWrap.get_accelerate), new LuaCSFunction(UIScrollViewWrap.set_accelerate));
		L.RegVar("movement", new LuaCSFunction(UIScrollViewWrap.get_movement), new LuaCSFunction(UIScrollViewWrap.set_movement));
		L.RegVar("dragEffect", new LuaCSFunction(UIScrollViewWrap.get_dragEffect), new LuaCSFunction(UIScrollViewWrap.set_dragEffect));
		L.RegVar("restrictWithinPanel", new LuaCSFunction(UIScrollViewWrap.get_restrictWithinPanel), new LuaCSFunction(UIScrollViewWrap.set_restrictWithinPanel));
		L.RegVar("constrainOnDrag", new LuaCSFunction(UIScrollViewWrap.get_constrainOnDrag), new LuaCSFunction(UIScrollViewWrap.set_constrainOnDrag));
		L.RegVar("disableDragIfFits", new LuaCSFunction(UIScrollViewWrap.get_disableDragIfFits), new LuaCSFunction(UIScrollViewWrap.set_disableDragIfFits));
		L.RegVar("smoothDragStart", new LuaCSFunction(UIScrollViewWrap.get_smoothDragStart), new LuaCSFunction(UIScrollViewWrap.set_smoothDragStart));
		L.RegVar("iOSDragEmulation", new LuaCSFunction(UIScrollViewWrap.get_iOSDragEmulation), new LuaCSFunction(UIScrollViewWrap.set_iOSDragEmulation));
		L.RegVar("scrollWheelFactor", new LuaCSFunction(UIScrollViewWrap.get_scrollWheelFactor), new LuaCSFunction(UIScrollViewWrap.set_scrollWheelFactor));
		L.RegVar("momentumAmount", new LuaCSFunction(UIScrollViewWrap.get_momentumAmount), new LuaCSFunction(UIScrollViewWrap.set_momentumAmount));
		L.RegVar("dampenStrength", new LuaCSFunction(UIScrollViewWrap.get_dampenStrength), new LuaCSFunction(UIScrollViewWrap.set_dampenStrength));
		L.RegVar("horizontalScrollBar", new LuaCSFunction(UIScrollViewWrap.get_horizontalScrollBar), new LuaCSFunction(UIScrollViewWrap.set_horizontalScrollBar));
		L.RegVar("verticalScrollBar", new LuaCSFunction(UIScrollViewWrap.get_verticalScrollBar), new LuaCSFunction(UIScrollViewWrap.set_verticalScrollBar));
		L.RegVar("showScrollBars", new LuaCSFunction(UIScrollViewWrap.get_showScrollBars), new LuaCSFunction(UIScrollViewWrap.set_showScrollBars));
		L.RegVar("customMovement", new LuaCSFunction(UIScrollViewWrap.get_customMovement), new LuaCSFunction(UIScrollViewWrap.set_customMovement));
		L.RegVar("contentPivot", new LuaCSFunction(UIScrollViewWrap.get_contentPivot), new LuaCSFunction(UIScrollViewWrap.set_contentPivot));
		L.RegVar("onDragStarted", new LuaCSFunction(UIScrollViewWrap.get_onDragStarted), new LuaCSFunction(UIScrollViewWrap.set_onDragStarted));
		L.RegVar("onDragFinished", new LuaCSFunction(UIScrollViewWrap.get_onDragFinished), new LuaCSFunction(UIScrollViewWrap.set_onDragFinished));
		L.RegVar("onMomentumMove", new LuaCSFunction(UIScrollViewWrap.get_onMomentumMove), new LuaCSFunction(UIScrollViewWrap.set_onMomentumMove));
		L.RegVar("onStoppedMoving", new LuaCSFunction(UIScrollViewWrap.get_onStoppedMoving), new LuaCSFunction(UIScrollViewWrap.set_onStoppedMoving));
		L.RegVar("centerOnChild", new LuaCSFunction(UIScrollViewWrap.get_centerOnChild), new LuaCSFunction(UIScrollViewWrap.set_centerOnChild));
		L.RegVar("panel", new LuaCSFunction(UIScrollViewWrap.get_panel), null);
		L.RegVar("isDragging", new LuaCSFunction(UIScrollViewWrap.get_isDragging), null);
		L.RegVar("bounds", new LuaCSFunction(UIScrollViewWrap.get_bounds), null);
		L.RegVar("canMoveHorizontally", new LuaCSFunction(UIScrollViewWrap.get_canMoveHorizontally), null);
		L.RegVar("canMoveVertically", new LuaCSFunction(UIScrollViewWrap.get_canMoveVertically), null);
		L.RegVar("shouldMoveHorizontally", new LuaCSFunction(UIScrollViewWrap.get_shouldMoveHorizontally), null);
		L.RegVar("shouldMoveVertically", new LuaCSFunction(UIScrollViewWrap.get_shouldMoveVertically), null);
		L.RegVar("currentMomentum", new LuaCSFunction(UIScrollViewWrap.get_currentMomentum), new LuaCSFunction(UIScrollViewWrap.set_currentMomentum));
		L.RegFunction("OnDragNotification", new LuaCSFunction(UIScrollViewWrap.UIScrollView_OnDragNotification));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RestrictWithinBounds(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(UIScrollView), typeof(bool)))
			{
				UIScrollView uIScrollView = (UIScrollView)ToLua.ToObject(L, 1);
				bool instant = LuaDLL.lua_toboolean(L, 2);
				bool value = uIScrollView.RestrictWithinBounds(instant);
				LuaDLL.lua_pushboolean(L, value);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(UIScrollView), typeof(bool), typeof(bool), typeof(bool)))
			{
				UIScrollView uIScrollView2 = (UIScrollView)ToLua.ToObject(L, 1);
				bool instant2 = LuaDLL.lua_toboolean(L, 2);
				bool horizontal = LuaDLL.lua_toboolean(L, 3);
				bool vertical = LuaDLL.lua_toboolean(L, 4);
				bool value2 = uIScrollView2.RestrictWithinBounds(instant2, horizontal, vertical);
				LuaDLL.lua_pushboolean(L, value2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UIScrollView.RestrictWithinBounds");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DisableSpring(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIScrollView uIScrollView = (UIScrollView)ToLua.CheckObject(L, 1, typeof(UIScrollView));
			uIScrollView.DisableSpring();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UpdateScrollbars(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(UIScrollView)))
			{
				UIScrollView uIScrollView = (UIScrollView)ToLua.ToObject(L, 1);
				uIScrollView.UpdateScrollbars();
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(UIScrollView), typeof(bool)))
			{
				UIScrollView uIScrollView2 = (UIScrollView)ToLua.ToObject(L, 1);
				bool recalculateBounds = LuaDLL.lua_toboolean(L, 2);
				uIScrollView2.UpdateScrollbars(recalculateBounds);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UIScrollView.UpdateScrollbars");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetDragAmount(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			UIScrollView uIScrollView = (UIScrollView)ToLua.CheckObject(L, 1, typeof(UIScrollView));
			float x = (float)LuaDLL.luaL_checknumber(L, 2);
			float y = (float)LuaDLL.luaL_checknumber(L, 3);
			bool updateScrollbars = LuaDLL.luaL_checkboolean(L, 4);
			uIScrollView.SetDragAmount(x, y, updateScrollbars);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int InvalidateBounds(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIScrollView uIScrollView = (UIScrollView)ToLua.CheckObject(L, 1, typeof(UIScrollView));
			uIScrollView.InvalidateBounds();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ResetPosition(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIScrollView uIScrollView = (UIScrollView)ToLua.CheckObject(L, 1, typeof(UIScrollView));
			uIScrollView.ResetPosition();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UpdatePosition(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIScrollView uIScrollView = (UIScrollView)ToLua.CheckObject(L, 1, typeof(UIScrollView));
			uIScrollView.UpdatePosition();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnScrollBar(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIScrollView uIScrollView = (UIScrollView)ToLua.CheckObject(L, 1, typeof(UIScrollView));
			uIScrollView.OnScrollBar();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MoveRelative(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIScrollView uIScrollView = (UIScrollView)ToLua.CheckObject(L, 1, typeof(UIScrollView));
			Vector3 relative = ToLua.ToVector3(L, 2);
			uIScrollView.MoveRelative(relative);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MoveAbsolute(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIScrollView uIScrollView = (UIScrollView)ToLua.CheckObject(L, 1, typeof(UIScrollView));
			Vector3 absolute = ToLua.ToVector3(L, 2);
			uIScrollView.MoveAbsolute(absolute);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Press(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIScrollView uIScrollView = (UIScrollView)ToLua.CheckObject(L, 1, typeof(UIScrollView));
			bool pressed = LuaDLL.luaL_checkboolean(L, 2);
			uIScrollView.Press(pressed);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Drag(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIScrollView uIScrollView = (UIScrollView)ToLua.CheckObject(L, 1, typeof(UIScrollView));
			uIScrollView.Drag();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Scroll(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIScrollView uIScrollView = (UIScrollView)ToLua.CheckObject(L, 1, typeof(UIScrollView));
			float delta = (float)LuaDLL.luaL_checknumber(L, 2);
			uIScrollView.Scroll(delta);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnPan(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIScrollView uIScrollView = (UIScrollView)ToLua.CheckObject(L, 1, typeof(UIScrollView));
			Vector2 delta = ToLua.ToVector2(L, 2);
			uIScrollView.OnPan(delta);
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
	private static int get_list(IntPtr L)
	{
		int result;
		try
		{
			ToLua.PushObject(L, UIScrollView.list);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_accelerate(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			float accelerate = uIScrollView.accelerate;
			LuaDLL.lua_pushnumber(L, (double)accelerate);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index accelerate on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_movement(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			UIScrollView.Movement movement = uIScrollView.movement;
			ToLua.Push(L, movement);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index movement on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_dragEffect(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			UIScrollView.DragEffect dragEffect = uIScrollView.dragEffect;
			ToLua.Push(L, dragEffect);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index dragEffect on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_restrictWithinPanel(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			bool restrictWithinPanel = uIScrollView.restrictWithinPanel;
			LuaDLL.lua_pushboolean(L, restrictWithinPanel);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index restrictWithinPanel on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_constrainOnDrag(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			bool constrainOnDrag = uIScrollView.constrainOnDrag;
			LuaDLL.lua_pushboolean(L, constrainOnDrag);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index constrainOnDrag on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_disableDragIfFits(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			bool disableDragIfFits = uIScrollView.disableDragIfFits;
			LuaDLL.lua_pushboolean(L, disableDragIfFits);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index disableDragIfFits on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_smoothDragStart(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			bool smoothDragStart = uIScrollView.smoothDragStart;
			LuaDLL.lua_pushboolean(L, smoothDragStart);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index smoothDragStart on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_iOSDragEmulation(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			bool iOSDragEmulation = uIScrollView.iOSDragEmulation;
			LuaDLL.lua_pushboolean(L, iOSDragEmulation);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index iOSDragEmulation on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_scrollWheelFactor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			float scrollWheelFactor = uIScrollView.scrollWheelFactor;
			LuaDLL.lua_pushnumber(L, (double)scrollWheelFactor);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index scrollWheelFactor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_momentumAmount(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			float momentumAmount = uIScrollView.momentumAmount;
			LuaDLL.lua_pushnumber(L, (double)momentumAmount);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index momentumAmount on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_dampenStrength(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			float dampenStrength = uIScrollView.dampenStrength;
			LuaDLL.lua_pushnumber(L, (double)dampenStrength);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index dampenStrength on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_horizontalScrollBar(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			UIProgressBar horizontalScrollBar = uIScrollView.horizontalScrollBar;
			ToLua.Push(L, horizontalScrollBar);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index horizontalScrollBar on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_verticalScrollBar(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			UIProgressBar verticalScrollBar = uIScrollView.verticalScrollBar;
			ToLua.Push(L, verticalScrollBar);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index verticalScrollBar on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_showScrollBars(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			UIScrollView.ShowCondition showScrollBars = uIScrollView.showScrollBars;
			ToLua.Push(L, showScrollBars);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index showScrollBars on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_customMovement(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			Vector2 customMovement = uIScrollView.customMovement;
			ToLua.Push(L, customMovement);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index customMovement on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_contentPivot(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			UIWidget.Pivot contentPivot = uIScrollView.contentPivot;
			ToLua.Push(L, contentPivot);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index contentPivot on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onDragStarted(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			UIScrollView.OnDragNotification onDragStarted = uIScrollView.onDragStarted;
			ToLua.Push(L, onDragStarted);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onDragStarted on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onDragFinished(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			UIScrollView.OnDragNotification onDragFinished = uIScrollView.onDragFinished;
			ToLua.Push(L, onDragFinished);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onDragFinished on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onMomentumMove(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			UIScrollView.OnDragNotification onMomentumMove = uIScrollView.onMomentumMove;
			ToLua.Push(L, onMomentumMove);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onMomentumMove on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onStoppedMoving(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			UIScrollView.OnDragNotification onStoppedMoving = uIScrollView.onStoppedMoving;
			ToLua.Push(L, onStoppedMoving);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onStoppedMoving on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_centerOnChild(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			UICenterOnChild centerOnChild = uIScrollView.centerOnChild;
			ToLua.Push(L, centerOnChild);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index centerOnChild on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_panel(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			UIPanel panel = uIScrollView.panel;
			ToLua.Push(L, panel);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index panel on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isDragging(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			bool isDragging = uIScrollView.isDragging;
			LuaDLL.lua_pushboolean(L, isDragging);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isDragging on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_bounds(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			Bounds bounds = uIScrollView.bounds;
			ToLua.Push(L, bounds);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index bounds on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_canMoveHorizontally(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			bool canMoveHorizontally = uIScrollView.canMoveHorizontally;
			LuaDLL.lua_pushboolean(L, canMoveHorizontally);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index canMoveHorizontally on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_canMoveVertically(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			bool canMoveVertically = uIScrollView.canMoveVertically;
			LuaDLL.lua_pushboolean(L, canMoveVertically);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index canMoveVertically on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_shouldMoveHorizontally(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			bool shouldMoveHorizontally = uIScrollView.shouldMoveHorizontally;
			LuaDLL.lua_pushboolean(L, shouldMoveHorizontally);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shouldMoveHorizontally on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_shouldMoveVertically(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			bool shouldMoveVertically = uIScrollView.shouldMoveVertically;
			LuaDLL.lua_pushboolean(L, shouldMoveVertically);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shouldMoveVertically on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_currentMomentum(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			Vector3 currentMomentum = uIScrollView.currentMomentum;
			ToLua.Push(L, currentMomentum);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index currentMomentum on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_list(IntPtr L)
	{
		int result;
		try
		{
			BetterList<UIScrollView> list = (BetterList<UIScrollView>)ToLua.CheckObject(L, 2, typeof(BetterList<UIScrollView>));
			UIScrollView.list = list;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_accelerate(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			float accelerate = (float)LuaDLL.luaL_checknumber(L, 2);
			uIScrollView.accelerate = accelerate;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index accelerate on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_movement(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			UIScrollView.Movement movement = (UIScrollView.Movement)LuaDLL.luaL_checknumber(L, 2);
			uIScrollView.movement = movement;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index movement on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_dragEffect(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			UIScrollView.DragEffect dragEffect = (UIScrollView.DragEffect)LuaDLL.luaL_checknumber(L, 2);
			uIScrollView.dragEffect = dragEffect;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index dragEffect on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_restrictWithinPanel(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			bool restrictWithinPanel = LuaDLL.luaL_checkboolean(L, 2);
			uIScrollView.restrictWithinPanel = restrictWithinPanel;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index restrictWithinPanel on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_constrainOnDrag(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			bool constrainOnDrag = LuaDLL.luaL_checkboolean(L, 2);
			uIScrollView.constrainOnDrag = constrainOnDrag;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index constrainOnDrag on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_disableDragIfFits(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			bool disableDragIfFits = LuaDLL.luaL_checkboolean(L, 2);
			uIScrollView.disableDragIfFits = disableDragIfFits;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index disableDragIfFits on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_smoothDragStart(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			bool smoothDragStart = LuaDLL.luaL_checkboolean(L, 2);
			uIScrollView.smoothDragStart = smoothDragStart;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index smoothDragStart on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_iOSDragEmulation(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			bool iOSDragEmulation = LuaDLL.luaL_checkboolean(L, 2);
			uIScrollView.iOSDragEmulation = iOSDragEmulation;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index iOSDragEmulation on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_scrollWheelFactor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			float scrollWheelFactor = (float)LuaDLL.luaL_checknumber(L, 2);
			uIScrollView.scrollWheelFactor = scrollWheelFactor;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index scrollWheelFactor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_momentumAmount(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			float momentumAmount = (float)LuaDLL.luaL_checknumber(L, 2);
			uIScrollView.momentumAmount = momentumAmount;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index momentumAmount on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_dampenStrength(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			float dampenStrength = (float)LuaDLL.luaL_checknumber(L, 2);
			uIScrollView.dampenStrength = dampenStrength;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index dampenStrength on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_horizontalScrollBar(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			UIProgressBar horizontalScrollBar = (UIProgressBar)ToLua.CheckUnityObject(L, 2, typeof(UIProgressBar));
			uIScrollView.horizontalScrollBar = horizontalScrollBar;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index horizontalScrollBar on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_verticalScrollBar(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			UIProgressBar verticalScrollBar = (UIProgressBar)ToLua.CheckUnityObject(L, 2, typeof(UIProgressBar));
			uIScrollView.verticalScrollBar = verticalScrollBar;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index verticalScrollBar on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_showScrollBars(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			UIScrollView.ShowCondition showScrollBars = (UIScrollView.ShowCondition)LuaDLL.luaL_checknumber(L, 2);
			uIScrollView.showScrollBars = showScrollBars;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index showScrollBars on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_customMovement(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			Vector2 customMovement = ToLua.ToVector2(L, 2);
			uIScrollView.customMovement = customMovement;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index customMovement on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_contentPivot(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			UIWidget.Pivot contentPivot = (UIWidget.Pivot)((int)ToLua.CheckObject(L, 2, typeof(UIWidget.Pivot)));
			uIScrollView.contentPivot = contentPivot;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index contentPivot on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onDragStarted(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UIScrollView.OnDragNotification onDragStarted;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onDragStarted = (UIScrollView.OnDragNotification)ToLua.CheckObject(L, 2, typeof(UIScrollView.OnDragNotification));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onDragStarted = (DelegateFactory.CreateDelegate(typeof(UIScrollView.OnDragNotification), func) as UIScrollView.OnDragNotification);
			}
			uIScrollView.onDragStarted = onDragStarted;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onDragStarted on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onDragFinished(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UIScrollView.OnDragNotification onDragFinished;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onDragFinished = (UIScrollView.OnDragNotification)ToLua.CheckObject(L, 2, typeof(UIScrollView.OnDragNotification));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onDragFinished = (DelegateFactory.CreateDelegate(typeof(UIScrollView.OnDragNotification), func) as UIScrollView.OnDragNotification);
			}
			uIScrollView.onDragFinished = onDragFinished;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onDragFinished on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onMomentumMove(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UIScrollView.OnDragNotification onMomentumMove;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onMomentumMove = (UIScrollView.OnDragNotification)ToLua.CheckObject(L, 2, typeof(UIScrollView.OnDragNotification));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onMomentumMove = (DelegateFactory.CreateDelegate(typeof(UIScrollView.OnDragNotification), func) as UIScrollView.OnDragNotification);
			}
			uIScrollView.onMomentumMove = onMomentumMove;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onMomentumMove on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onStoppedMoving(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UIScrollView.OnDragNotification onStoppedMoving;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onStoppedMoving = (UIScrollView.OnDragNotification)ToLua.CheckObject(L, 2, typeof(UIScrollView.OnDragNotification));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onStoppedMoving = (DelegateFactory.CreateDelegate(typeof(UIScrollView.OnDragNotification), func) as UIScrollView.OnDragNotification);
			}
			uIScrollView.onStoppedMoving = onStoppedMoving;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onStoppedMoving on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_centerOnChild(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			UICenterOnChild centerOnChild = (UICenterOnChild)ToLua.CheckUnityObject(L, 2, typeof(UICenterOnChild));
			uIScrollView.centerOnChild = centerOnChild;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index centerOnChild on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_currentMomentum(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIScrollView uIScrollView = (UIScrollView)obj;
			Vector3 currentMomentum = ToLua.ToVector3(L, 2);
			uIScrollView.currentMomentum = currentMomentum;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index currentMomentum on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIScrollView_OnDragNotification(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIScrollView.OnDragNotification), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIScrollView.OnDragNotification), func, self);
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
