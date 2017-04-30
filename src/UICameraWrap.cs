using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UICameraWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UICamera), typeof(MonoBehaviour), null);
		L.RegFunction("IsPressed", new LuaCSFunction(UICameraWrap.IsPressed));
		L.RegFunction("CountInputSources", new LuaCSFunction(UICameraWrap.CountInputSources));
		L.RegFunction("Raycast", new LuaCSFunction(UICameraWrap.Raycast));
		L.RegFunction("IsHighlighted", new LuaCSFunction(UICameraWrap.IsHighlighted));
		L.RegFunction("FindCameraForLayer", new LuaCSFunction(UICameraWrap.FindCameraForLayer));
		L.RegFunction("Notify", new LuaCSFunction(UICameraWrap.Notify));
		L.RegFunction("ProcessMouse", new LuaCSFunction(UICameraWrap.ProcessMouse));
		L.RegFunction("ProcessTouches", new LuaCSFunction(UICameraWrap.ProcessTouches));
		L.RegFunction("ProcessOthers", new LuaCSFunction(UICameraWrap.ProcessOthers));
		L.RegFunction("ProcessTouch", new LuaCSFunction(UICameraWrap.ProcessTouch));
		L.RegFunction("CancelNextTooltip", new LuaCSFunction(UICameraWrap.CancelNextTooltip));
		L.RegFunction("ShowTooltip", new LuaCSFunction(UICameraWrap.ShowTooltip));
		L.RegFunction("HideTooltip", new LuaCSFunction(UICameraWrap.HideTooltip));
		L.RegFunction("__eq", new LuaCSFunction(UICameraWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("list", new LuaCSFunction(UICameraWrap.get_list), new LuaCSFunction(UICameraWrap.set_list));
		L.RegVar("GetKeyDown", new LuaCSFunction(UICameraWrap.get_GetKeyDown), new LuaCSFunction(UICameraWrap.set_GetKeyDown));
		L.RegVar("GetKeyUp", new LuaCSFunction(UICameraWrap.get_GetKeyUp), new LuaCSFunction(UICameraWrap.set_GetKeyUp));
		L.RegVar("GetKey", new LuaCSFunction(UICameraWrap.get_GetKey), new LuaCSFunction(UICameraWrap.set_GetKey));
		L.RegVar("GetAxis", new LuaCSFunction(UICameraWrap.get_GetAxis), new LuaCSFunction(UICameraWrap.set_GetAxis));
		L.RegVar("GetAnyKeyDown", new LuaCSFunction(UICameraWrap.get_GetAnyKeyDown), new LuaCSFunction(UICameraWrap.set_GetAnyKeyDown));
		L.RegVar("GetMouse", new LuaCSFunction(UICameraWrap.get_GetMouse), new LuaCSFunction(UICameraWrap.set_GetMouse));
		L.RegVar("GetTouch", new LuaCSFunction(UICameraWrap.get_GetTouch), new LuaCSFunction(UICameraWrap.set_GetTouch));
		L.RegVar("RemoveTouch", new LuaCSFunction(UICameraWrap.get_RemoveTouch), new LuaCSFunction(UICameraWrap.set_RemoveTouch));
		L.RegVar("onScreenResize", new LuaCSFunction(UICameraWrap.get_onScreenResize), new LuaCSFunction(UICameraWrap.set_onScreenResize));
		L.RegVar("eventType", new LuaCSFunction(UICameraWrap.get_eventType), new LuaCSFunction(UICameraWrap.set_eventType));
		L.RegVar("eventsGoToColliders", new LuaCSFunction(UICameraWrap.get_eventsGoToColliders), new LuaCSFunction(UICameraWrap.set_eventsGoToColliders));
		L.RegVar("eventReceiverMask", new LuaCSFunction(UICameraWrap.get_eventReceiverMask), new LuaCSFunction(UICameraWrap.set_eventReceiverMask));
		L.RegVar("processEventsIn", new LuaCSFunction(UICameraWrap.get_processEventsIn), new LuaCSFunction(UICameraWrap.set_processEventsIn));
		L.RegVar("debug", new LuaCSFunction(UICameraWrap.get_debug), new LuaCSFunction(UICameraWrap.set_debug));
		L.RegVar("useMouse", new LuaCSFunction(UICameraWrap.get_useMouse), new LuaCSFunction(UICameraWrap.set_useMouse));
		L.RegVar("useTouch", new LuaCSFunction(UICameraWrap.get_useTouch), new LuaCSFunction(UICameraWrap.set_useTouch));
		L.RegVar("allowMultiTouch", new LuaCSFunction(UICameraWrap.get_allowMultiTouch), new LuaCSFunction(UICameraWrap.set_allowMultiTouch));
		L.RegVar("useKeyboard", new LuaCSFunction(UICameraWrap.get_useKeyboard), new LuaCSFunction(UICameraWrap.set_useKeyboard));
		L.RegVar("useController", new LuaCSFunction(UICameraWrap.get_useController), new LuaCSFunction(UICameraWrap.set_useController));
		L.RegVar("stickyTooltip", new LuaCSFunction(UICameraWrap.get_stickyTooltip), new LuaCSFunction(UICameraWrap.set_stickyTooltip));
		L.RegVar("tooltipDelay", new LuaCSFunction(UICameraWrap.get_tooltipDelay), new LuaCSFunction(UICameraWrap.set_tooltipDelay));
		L.RegVar("longPressTooltip", new LuaCSFunction(UICameraWrap.get_longPressTooltip), new LuaCSFunction(UICameraWrap.set_longPressTooltip));
		L.RegVar("mouseDragThreshold", new LuaCSFunction(UICameraWrap.get_mouseDragThreshold), new LuaCSFunction(UICameraWrap.set_mouseDragThreshold));
		L.RegVar("mouseClickThreshold", new LuaCSFunction(UICameraWrap.get_mouseClickThreshold), new LuaCSFunction(UICameraWrap.set_mouseClickThreshold));
		L.RegVar("touchDragThreshold", new LuaCSFunction(UICameraWrap.get_touchDragThreshold), new LuaCSFunction(UICameraWrap.set_touchDragThreshold));
		L.RegVar("touchClickThreshold", new LuaCSFunction(UICameraWrap.get_touchClickThreshold), new LuaCSFunction(UICameraWrap.set_touchClickThreshold));
		L.RegVar("rangeDistance", new LuaCSFunction(UICameraWrap.get_rangeDistance), new LuaCSFunction(UICameraWrap.set_rangeDistance));
		L.RegVar("horizontalAxisName", new LuaCSFunction(UICameraWrap.get_horizontalAxisName), new LuaCSFunction(UICameraWrap.set_horizontalAxisName));
		L.RegVar("verticalAxisName", new LuaCSFunction(UICameraWrap.get_verticalAxisName), new LuaCSFunction(UICameraWrap.set_verticalAxisName));
		L.RegVar("horizontalPanAxisName", new LuaCSFunction(UICameraWrap.get_horizontalPanAxisName), new LuaCSFunction(UICameraWrap.set_horizontalPanAxisName));
		L.RegVar("verticalPanAxisName", new LuaCSFunction(UICameraWrap.get_verticalPanAxisName), new LuaCSFunction(UICameraWrap.set_verticalPanAxisName));
		L.RegVar("scrollAxisName", new LuaCSFunction(UICameraWrap.get_scrollAxisName), new LuaCSFunction(UICameraWrap.set_scrollAxisName));
		L.RegVar("commandClick", new LuaCSFunction(UICameraWrap.get_commandClick), new LuaCSFunction(UICameraWrap.set_commandClick));
		L.RegVar("submitKey0", new LuaCSFunction(UICameraWrap.get_submitKey0), new LuaCSFunction(UICameraWrap.set_submitKey0));
		L.RegVar("submitKey1", new LuaCSFunction(UICameraWrap.get_submitKey1), new LuaCSFunction(UICameraWrap.set_submitKey1));
		L.RegVar("cancelKey0", new LuaCSFunction(UICameraWrap.get_cancelKey0), new LuaCSFunction(UICameraWrap.set_cancelKey0));
		L.RegVar("cancelKey1", new LuaCSFunction(UICameraWrap.get_cancelKey1), new LuaCSFunction(UICameraWrap.set_cancelKey1));
		L.RegVar("autoHideCursor", new LuaCSFunction(UICameraWrap.get_autoHideCursor), new LuaCSFunction(UICameraWrap.set_autoHideCursor));
		L.RegVar("onCustomInput", new LuaCSFunction(UICameraWrap.get_onCustomInput), new LuaCSFunction(UICameraWrap.set_onCustomInput));
		L.RegVar("showTooltips", new LuaCSFunction(UICameraWrap.get_showTooltips), new LuaCSFunction(UICameraWrap.set_showTooltips));
		L.RegVar("ignoreControllerInput", new LuaCSFunction(UICameraWrap.get_ignoreControllerInput), new LuaCSFunction(UICameraWrap.set_ignoreControllerInput));
		L.RegVar("lastWorldPosition", new LuaCSFunction(UICameraWrap.get_lastWorldPosition), new LuaCSFunction(UICameraWrap.set_lastWorldPosition));
		L.RegVar("lastHit", new LuaCSFunction(UICameraWrap.get_lastHit), new LuaCSFunction(UICameraWrap.set_lastHit));
		L.RegVar("current", new LuaCSFunction(UICameraWrap.get_current), new LuaCSFunction(UICameraWrap.set_current));
		L.RegVar("currentCamera", new LuaCSFunction(UICameraWrap.get_currentCamera), new LuaCSFunction(UICameraWrap.set_currentCamera));
		L.RegVar("onSchemeChange", new LuaCSFunction(UICameraWrap.get_onSchemeChange), new LuaCSFunction(UICameraWrap.set_onSchemeChange));
		L.RegVar("currentTouchID", new LuaCSFunction(UICameraWrap.get_currentTouchID), new LuaCSFunction(UICameraWrap.set_currentTouchID));
		L.RegVar("currentTouch", new LuaCSFunction(UICameraWrap.get_currentTouch), new LuaCSFunction(UICameraWrap.set_currentTouch));
		L.RegVar("fallThrough", new LuaCSFunction(UICameraWrap.get_fallThrough), new LuaCSFunction(UICameraWrap.set_fallThrough));
		L.RegVar("onClick", new LuaCSFunction(UICameraWrap.get_onClick), new LuaCSFunction(UICameraWrap.set_onClick));
		L.RegVar("onDoubleClick", new LuaCSFunction(UICameraWrap.get_onDoubleClick), new LuaCSFunction(UICameraWrap.set_onDoubleClick));
		L.RegVar("onHover", new LuaCSFunction(UICameraWrap.get_onHover), new LuaCSFunction(UICameraWrap.set_onHover));
		L.RegVar("onPress", new LuaCSFunction(UICameraWrap.get_onPress), new LuaCSFunction(UICameraWrap.set_onPress));
		L.RegVar("onSelect", new LuaCSFunction(UICameraWrap.get_onSelect), new LuaCSFunction(UICameraWrap.set_onSelect));
		L.RegVar("onScroll", new LuaCSFunction(UICameraWrap.get_onScroll), new LuaCSFunction(UICameraWrap.set_onScroll));
		L.RegVar("onDrag", new LuaCSFunction(UICameraWrap.get_onDrag), new LuaCSFunction(UICameraWrap.set_onDrag));
		L.RegVar("onDragStart", new LuaCSFunction(UICameraWrap.get_onDragStart), new LuaCSFunction(UICameraWrap.set_onDragStart));
		L.RegVar("onDragOver", new LuaCSFunction(UICameraWrap.get_onDragOver), new LuaCSFunction(UICameraWrap.set_onDragOver));
		L.RegVar("onDragOut", new LuaCSFunction(UICameraWrap.get_onDragOut), new LuaCSFunction(UICameraWrap.set_onDragOut));
		L.RegVar("onDragEnd", new LuaCSFunction(UICameraWrap.get_onDragEnd), new LuaCSFunction(UICameraWrap.set_onDragEnd));
		L.RegVar("onDrop", new LuaCSFunction(UICameraWrap.get_onDrop), new LuaCSFunction(UICameraWrap.set_onDrop));
		L.RegVar("onKey", new LuaCSFunction(UICameraWrap.get_onKey), new LuaCSFunction(UICameraWrap.set_onKey));
		L.RegVar("onNavigate", new LuaCSFunction(UICameraWrap.get_onNavigate), new LuaCSFunction(UICameraWrap.set_onNavigate));
		L.RegVar("onPan", new LuaCSFunction(UICameraWrap.get_onPan), new LuaCSFunction(UICameraWrap.set_onPan));
		L.RegVar("onTooltip", new LuaCSFunction(UICameraWrap.get_onTooltip), new LuaCSFunction(UICameraWrap.set_onTooltip));
		L.RegVar("onMouseMove", new LuaCSFunction(UICameraWrap.get_onMouseMove), new LuaCSFunction(UICameraWrap.set_onMouseMove));
		L.RegVar("controller", new LuaCSFunction(UICameraWrap.get_controller), new LuaCSFunction(UICameraWrap.set_controller));
		L.RegVar("activeTouches", new LuaCSFunction(UICameraWrap.get_activeTouches), new LuaCSFunction(UICameraWrap.set_activeTouches));
		L.RegVar("isDragging", new LuaCSFunction(UICameraWrap.get_isDragging), new LuaCSFunction(UICameraWrap.set_isDragging));
		L.RegVar("GetInputTouchCount", new LuaCSFunction(UICameraWrap.get_GetInputTouchCount), new LuaCSFunction(UICameraWrap.set_GetInputTouchCount));
		L.RegVar("GetInputTouch", new LuaCSFunction(UICameraWrap.get_GetInputTouch), new LuaCSFunction(UICameraWrap.set_GetInputTouch));
		L.RegVar("disableController", new LuaCSFunction(UICameraWrap.get_disableController), new LuaCSFunction(UICameraWrap.set_disableController));
		L.RegVar("lastEventPosition", new LuaCSFunction(UICameraWrap.get_lastEventPosition), new LuaCSFunction(UICameraWrap.set_lastEventPosition));
		L.RegVar("first", new LuaCSFunction(UICameraWrap.get_first), null);
		L.RegVar("currentScheme", new LuaCSFunction(UICameraWrap.get_currentScheme), new LuaCSFunction(UICameraWrap.set_currentScheme));
		L.RegVar("currentKey", new LuaCSFunction(UICameraWrap.get_currentKey), new LuaCSFunction(UICameraWrap.set_currentKey));
		L.RegVar("currentRay", new LuaCSFunction(UICameraWrap.get_currentRay), null);
		L.RegVar("inputHasFocus", new LuaCSFunction(UICameraWrap.get_inputHasFocus), null);
		L.RegVar("cachedCamera", new LuaCSFunction(UICameraWrap.get_cachedCamera), null);
		L.RegVar("tooltipObject", new LuaCSFunction(UICameraWrap.get_tooltipObject), null);
		L.RegVar("isOverUI", new LuaCSFunction(UICameraWrap.get_isOverUI), null);
		L.RegVar("hoveredObject", new LuaCSFunction(UICameraWrap.get_hoveredObject), new LuaCSFunction(UICameraWrap.set_hoveredObject));
		L.RegVar("controllerNavigationObject", new LuaCSFunction(UICameraWrap.get_controllerNavigationObject), new LuaCSFunction(UICameraWrap.set_controllerNavigationObject));
		L.RegVar("selectedObject", new LuaCSFunction(UICameraWrap.get_selectedObject), new LuaCSFunction(UICameraWrap.set_selectedObject));
		L.RegVar("dragCount", new LuaCSFunction(UICameraWrap.get_dragCount), null);
		L.RegVar("mainCamera", new LuaCSFunction(UICameraWrap.get_mainCamera), null);
		L.RegVar("eventHandler", new LuaCSFunction(UICameraWrap.get_eventHandler), null);
		L.RegFunction("GetTouchCallback", new LuaCSFunction(UICameraWrap.UICamera_GetTouchCallback));
		L.RegFunction("GetTouchCountCallback", new LuaCSFunction(UICameraWrap.UICamera_GetTouchCountCallback));
		L.RegFunction("MoveDelegate", new LuaCSFunction(UICameraWrap.UICamera_MoveDelegate));
		L.RegFunction("BoolDelegate", new LuaCSFunction(UICameraWrap.UICamera_BoolDelegate));
		L.RegFunction("VectorDelegate", new LuaCSFunction(UICameraWrap.UICamera_VectorDelegate));
		L.RegFunction("KeyCodeDelegate", new LuaCSFunction(UICameraWrap.UICamera_KeyCodeDelegate));
		L.RegFunction("ObjectDelegate", new LuaCSFunction(UICameraWrap.UICamera_ObjectDelegate));
		L.RegFunction("VoidDelegate", new LuaCSFunction(UICameraWrap.UICamera_VoidDelegate));
		L.RegFunction("FloatDelegate", new LuaCSFunction(UICameraWrap.UICamera_FloatDelegate));
		L.RegFunction("OnSchemeChange", new LuaCSFunction(UICameraWrap.UICamera_OnSchemeChange));
		L.RegFunction("OnCustomInput", new LuaCSFunction(UICameraWrap.UICamera_OnCustomInput));
		L.RegFunction("OnScreenResize", new LuaCSFunction(UICameraWrap.UICamera_OnScreenResize));
		L.RegFunction("RemoveTouchDelegate", new LuaCSFunction(UICameraWrap.UICamera_RemoveTouchDelegate));
		L.RegFunction("GetTouchDelegate", new LuaCSFunction(UICameraWrap.UICamera_GetTouchDelegate));
		L.RegFunction("GetMouseDelegate", new LuaCSFunction(UICameraWrap.UICamera_GetMouseDelegate));
		L.RegFunction("GetAnyKeyFunc", new LuaCSFunction(UICameraWrap.UICamera_GetAnyKeyFunc));
		L.RegFunction("GetAxisFunc", new LuaCSFunction(UICameraWrap.UICamera_GetAxisFunc));
		L.RegFunction("GetKeyStateFunc", new LuaCSFunction(UICameraWrap.UICamera_GetKeyStateFunc));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsPressed(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			bool value = UICamera.IsPressed(go);
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
	private static int CountInputSources(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			int n = UICamera.CountInputSources();
			LuaDLL.lua_pushinteger(L, n);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Raycast(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Vector3)))
			{
				Vector3 inPos = ToLua.ToVector3(L, 1);
				bool value = UICamera.Raycast(inPos);
				LuaDLL.lua_pushboolean(L, value);
				result = 1;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(UICamera.MouseOrTouch)))
			{
				UICamera.MouseOrTouch touch = (UICamera.MouseOrTouch)ToLua.ToObject(L, 1);
				UICamera.Raycast(touch);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UICamera.Raycast");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsHighlighted(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			bool value = UICamera.IsHighlighted(go);
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
	private static int FindCameraForLayer(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			int layer = (int)LuaDLL.luaL_checknumber(L, 1);
			UICamera obj = UICamera.FindCameraForLayer(layer);
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
	private static int Notify(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			string funcName = ToLua.CheckString(L, 2);
			object obj = ToLua.ToVarObject(L, 3);
			UICamera.Notify(go, funcName, obj);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ProcessMouse(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UICamera uICamera = (UICamera)ToLua.CheckObject(L, 1, typeof(UICamera));
			uICamera.ProcessMouse();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ProcessTouches(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UICamera uICamera = (UICamera)ToLua.CheckObject(L, 1, typeof(UICamera));
			uICamera.ProcessTouches();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ProcessOthers(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UICamera uICamera = (UICamera)ToLua.CheckObject(L, 1, typeof(UICamera));
			uICamera.ProcessOthers();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ProcessTouch(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UICamera uICamera = (UICamera)ToLua.CheckObject(L, 1, typeof(UICamera));
			bool pressed = LuaDLL.luaL_checkboolean(L, 2);
			bool released = LuaDLL.luaL_checkboolean(L, 3);
			uICamera.ProcessTouch(pressed, released);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CancelNextTooltip(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			UICamera.CancelNextTooltip();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ShowTooltip(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			bool value = UICamera.ShowTooltip(go);
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
	private static int HideTooltip(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			bool value = UICamera.HideTooltip();
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
	private static int get_list(IntPtr L)
	{
		int result;
		try
		{
			ToLua.PushObject(L, UICamera.list);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_GetKeyDown(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.GetKeyDown);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_GetKeyUp(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.GetKeyUp);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_GetKey(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.GetKey);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_GetAxis(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.GetAxis);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_GetAnyKeyDown(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.GetAnyKeyDown);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_GetMouse(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.GetMouse);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_GetTouch(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.GetTouch);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_RemoveTouch(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.RemoveTouch);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onScreenResize(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.onScreenResize);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_eventType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			UICamera.EventType eventType = uICamera.eventType;
			ToLua.Push(L, eventType);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index eventType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_eventsGoToColliders(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			bool eventsGoToColliders = uICamera.eventsGoToColliders;
			LuaDLL.lua_pushboolean(L, eventsGoToColliders);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index eventsGoToColliders on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_eventReceiverMask(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			LayerMask eventReceiverMask = uICamera.eventReceiverMask;
			ToLua.PushLayerMask(L, eventReceiverMask);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index eventReceiverMask on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_processEventsIn(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			UICamera.ProcessEventsIn processEventsIn = uICamera.processEventsIn;
			ToLua.Push(L, processEventsIn);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index processEventsIn on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_debug(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			bool debug = uICamera.debug;
			LuaDLL.lua_pushboolean(L, debug);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index debug on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_useMouse(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			bool useMouse = uICamera.useMouse;
			LuaDLL.lua_pushboolean(L, useMouse);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index useMouse on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_useTouch(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			bool useTouch = uICamera.useTouch;
			LuaDLL.lua_pushboolean(L, useTouch);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index useTouch on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_allowMultiTouch(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			bool allowMultiTouch = uICamera.allowMultiTouch;
			LuaDLL.lua_pushboolean(L, allowMultiTouch);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index allowMultiTouch on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_useKeyboard(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			bool useKeyboard = uICamera.useKeyboard;
			LuaDLL.lua_pushboolean(L, useKeyboard);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index useKeyboard on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_useController(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			bool useController = uICamera.useController;
			LuaDLL.lua_pushboolean(L, useController);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index useController on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_stickyTooltip(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			bool stickyTooltip = uICamera.stickyTooltip;
			LuaDLL.lua_pushboolean(L, stickyTooltip);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index stickyTooltip on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_tooltipDelay(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			float tooltipDelay = uICamera.tooltipDelay;
			LuaDLL.lua_pushnumber(L, (double)tooltipDelay);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index tooltipDelay on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_longPressTooltip(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			bool longPressTooltip = uICamera.longPressTooltip;
			LuaDLL.lua_pushboolean(L, longPressTooltip);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index longPressTooltip on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_mouseDragThreshold(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			float mouseDragThreshold = uICamera.mouseDragThreshold;
			LuaDLL.lua_pushnumber(L, (double)mouseDragThreshold);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index mouseDragThreshold on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_mouseClickThreshold(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			float mouseClickThreshold = uICamera.mouseClickThreshold;
			LuaDLL.lua_pushnumber(L, (double)mouseClickThreshold);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index mouseClickThreshold on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_touchDragThreshold(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			float touchDragThreshold = uICamera.touchDragThreshold;
			LuaDLL.lua_pushnumber(L, (double)touchDragThreshold);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index touchDragThreshold on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_touchClickThreshold(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			float touchClickThreshold = uICamera.touchClickThreshold;
			LuaDLL.lua_pushnumber(L, (double)touchClickThreshold);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index touchClickThreshold on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_rangeDistance(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			float rangeDistance = uICamera.rangeDistance;
			LuaDLL.lua_pushnumber(L, (double)rangeDistance);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index rangeDistance on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_horizontalAxisName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			string horizontalAxisName = uICamera.horizontalAxisName;
			LuaDLL.lua_pushstring(L, horizontalAxisName);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index horizontalAxisName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_verticalAxisName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			string verticalAxisName = uICamera.verticalAxisName;
			LuaDLL.lua_pushstring(L, verticalAxisName);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index verticalAxisName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_horizontalPanAxisName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			string horizontalPanAxisName = uICamera.horizontalPanAxisName;
			LuaDLL.lua_pushstring(L, horizontalPanAxisName);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index horizontalPanAxisName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_verticalPanAxisName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			string verticalPanAxisName = uICamera.verticalPanAxisName;
			LuaDLL.lua_pushstring(L, verticalPanAxisName);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index verticalPanAxisName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_scrollAxisName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			string scrollAxisName = uICamera.scrollAxisName;
			LuaDLL.lua_pushstring(L, scrollAxisName);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index scrollAxisName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_commandClick(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			bool commandClick = uICamera.commandClick;
			LuaDLL.lua_pushboolean(L, commandClick);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index commandClick on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_submitKey0(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			KeyCode submitKey = uICamera.submitKey0;
			ToLua.Push(L, submitKey);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index submitKey0 on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_submitKey1(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			KeyCode submitKey = uICamera.submitKey1;
			ToLua.Push(L, submitKey);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index submitKey1 on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cancelKey0(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			KeyCode cancelKey = uICamera.cancelKey0;
			ToLua.Push(L, cancelKey);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cancelKey0 on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cancelKey1(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			KeyCode cancelKey = uICamera.cancelKey1;
			ToLua.Push(L, cancelKey);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cancelKey1 on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_autoHideCursor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			bool autoHideCursor = uICamera.autoHideCursor;
			LuaDLL.lua_pushboolean(L, autoHideCursor);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index autoHideCursor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onCustomInput(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.onCustomInput);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_showTooltips(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, UICamera.showTooltips);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ignoreControllerInput(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, UICamera.ignoreControllerInput);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_lastWorldPosition(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.lastWorldPosition);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_lastHit(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.lastHit);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_current(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.current);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_currentCamera(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.currentCamera);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onSchemeChange(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.onSchemeChange);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_currentTouchID(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, UICamera.currentTouchID);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_currentTouch(IntPtr L)
	{
		int result;
		try
		{
			ToLua.PushObject(L, UICamera.currentTouch);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fallThrough(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.fallThrough);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onClick(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.onClick);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onDoubleClick(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.onDoubleClick);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onHover(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.onHover);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onPress(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.onPress);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onSelect(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.onSelect);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onScroll(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.onScroll);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onDrag(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.onDrag);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onDragStart(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.onDragStart);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onDragOver(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.onDragOver);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onDragOut(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.onDragOut);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onDragEnd(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.onDragEnd);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onDrop(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.onDrop);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onKey(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.onKey);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onNavigate(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.onNavigate);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onPan(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.onPan);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onTooltip(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.onTooltip);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onMouseMove(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.onMouseMove);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_controller(IntPtr L)
	{
		int result;
		try
		{
			ToLua.PushObject(L, UICamera.controller);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_activeTouches(IntPtr L)
	{
		int result;
		try
		{
			ToLua.PushObject(L, UICamera.activeTouches);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isDragging(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, UICamera.isDragging);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_GetInputTouchCount(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.GetInputTouchCount);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_GetInputTouch(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.GetInputTouch);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_disableController(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, UICamera.disableController);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_lastEventPosition(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.lastEventPosition);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_first(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.first);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_currentScheme(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.currentScheme);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_currentKey(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.currentKey);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_currentRay(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.currentRay);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_inputHasFocus(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, UICamera.inputHasFocus);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cachedCamera(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			Camera cachedCamera = uICamera.cachedCamera;
			ToLua.Push(L, cachedCamera);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cachedCamera on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_tooltipObject(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.tooltipObject);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isOverUI(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, UICamera.isOverUI);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_hoveredObject(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.hoveredObject);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_controllerNavigationObject(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.controllerNavigationObject);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_selectedObject(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.selectedObject);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_dragCount(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, UICamera.dragCount);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_mainCamera(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.mainCamera);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_eventHandler(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UICamera.eventHandler);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_list(IntPtr L)
	{
		int result;
		try
		{
			BetterList<UICamera> list = (BetterList<UICamera>)ToLua.CheckObject(L, 2, typeof(BetterList<UICamera>));
			UICamera.list = list;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_GetKeyDown(IntPtr L)
	{
		int result;
		try
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UICamera.GetKeyStateFunc getKeyDown;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				getKeyDown = (UICamera.GetKeyStateFunc)ToLua.CheckObject(L, 2, typeof(UICamera.GetKeyStateFunc));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				getKeyDown = (DelegateFactory.CreateDelegate(typeof(UICamera.GetKeyStateFunc), func) as UICamera.GetKeyStateFunc);
			}
			UICamera.GetKeyDown = getKeyDown;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_GetKeyUp(IntPtr L)
	{
		int result;
		try
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UICamera.GetKeyStateFunc getKeyUp;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				getKeyUp = (UICamera.GetKeyStateFunc)ToLua.CheckObject(L, 2, typeof(UICamera.GetKeyStateFunc));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				getKeyUp = (DelegateFactory.CreateDelegate(typeof(UICamera.GetKeyStateFunc), func) as UICamera.GetKeyStateFunc);
			}
			UICamera.GetKeyUp = getKeyUp;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_GetKey(IntPtr L)
	{
		int result;
		try
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UICamera.GetKeyStateFunc getKey;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				getKey = (UICamera.GetKeyStateFunc)ToLua.CheckObject(L, 2, typeof(UICamera.GetKeyStateFunc));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				getKey = (DelegateFactory.CreateDelegate(typeof(UICamera.GetKeyStateFunc), func) as UICamera.GetKeyStateFunc);
			}
			UICamera.GetKey = getKey;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_GetAxis(IntPtr L)
	{
		int result;
		try
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UICamera.GetAxisFunc getAxis;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				getAxis = (UICamera.GetAxisFunc)ToLua.CheckObject(L, 2, typeof(UICamera.GetAxisFunc));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				getAxis = (DelegateFactory.CreateDelegate(typeof(UICamera.GetAxisFunc), func) as UICamera.GetAxisFunc);
			}
			UICamera.GetAxis = getAxis;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_GetAnyKeyDown(IntPtr L)
	{
		int result;
		try
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UICamera.GetAnyKeyFunc getAnyKeyDown;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				getAnyKeyDown = (UICamera.GetAnyKeyFunc)ToLua.CheckObject(L, 2, typeof(UICamera.GetAnyKeyFunc));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				getAnyKeyDown = (DelegateFactory.CreateDelegate(typeof(UICamera.GetAnyKeyFunc), func) as UICamera.GetAnyKeyFunc);
			}
			UICamera.GetAnyKeyDown = getAnyKeyDown;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_GetMouse(IntPtr L)
	{
		int result;
		try
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UICamera.GetMouseDelegate getMouse;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				getMouse = (UICamera.GetMouseDelegate)ToLua.CheckObject(L, 2, typeof(UICamera.GetMouseDelegate));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				getMouse = (DelegateFactory.CreateDelegate(typeof(UICamera.GetMouseDelegate), func) as UICamera.GetMouseDelegate);
			}
			UICamera.GetMouse = getMouse;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_GetTouch(IntPtr L)
	{
		int result;
		try
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UICamera.GetTouchDelegate getTouch;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				getTouch = (UICamera.GetTouchDelegate)ToLua.CheckObject(L, 2, typeof(UICamera.GetTouchDelegate));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				getTouch = (DelegateFactory.CreateDelegate(typeof(UICamera.GetTouchDelegate), func) as UICamera.GetTouchDelegate);
			}
			UICamera.GetTouch = getTouch;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_RemoveTouch(IntPtr L)
	{
		int result;
		try
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UICamera.RemoveTouchDelegate removeTouch;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				removeTouch = (UICamera.RemoveTouchDelegate)ToLua.CheckObject(L, 2, typeof(UICamera.RemoveTouchDelegate));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				removeTouch = (DelegateFactory.CreateDelegate(typeof(UICamera.RemoveTouchDelegate), func) as UICamera.RemoveTouchDelegate);
			}
			UICamera.RemoveTouch = removeTouch;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onScreenResize(IntPtr L)
	{
		int result;
		try
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UICamera.OnScreenResize onScreenResize;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onScreenResize = (UICamera.OnScreenResize)ToLua.CheckObject(L, 2, typeof(UICamera.OnScreenResize));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onScreenResize = (DelegateFactory.CreateDelegate(typeof(UICamera.OnScreenResize), func) as UICamera.OnScreenResize);
			}
			UICamera.onScreenResize = onScreenResize;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_eventType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			UICamera.EventType eventType = (UICamera.EventType)LuaDLL.luaL_checknumber(L, 2);
			uICamera.eventType = eventType;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index eventType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_eventsGoToColliders(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			bool eventsGoToColliders = LuaDLL.luaL_checkboolean(L, 2);
			uICamera.eventsGoToColliders = eventsGoToColliders;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index eventsGoToColliders on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_eventReceiverMask(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			LayerMask eventReceiverMask = ToLua.ToLayerMask(L, 2);
			uICamera.eventReceiverMask = eventReceiverMask;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index eventReceiverMask on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_processEventsIn(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			UICamera.ProcessEventsIn processEventsIn = (UICamera.ProcessEventsIn)LuaDLL.luaL_checknumber(L, 2);
			uICamera.processEventsIn = processEventsIn;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index processEventsIn on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_debug(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			bool debug = LuaDLL.luaL_checkboolean(L, 2);
			uICamera.debug = debug;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index debug on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_useMouse(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			bool useMouse = LuaDLL.luaL_checkboolean(L, 2);
			uICamera.useMouse = useMouse;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index useMouse on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_useTouch(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			bool useTouch = LuaDLL.luaL_checkboolean(L, 2);
			uICamera.useTouch = useTouch;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index useTouch on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_allowMultiTouch(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			bool allowMultiTouch = LuaDLL.luaL_checkboolean(L, 2);
			uICamera.allowMultiTouch = allowMultiTouch;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index allowMultiTouch on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_useKeyboard(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			bool useKeyboard = LuaDLL.luaL_checkboolean(L, 2);
			uICamera.useKeyboard = useKeyboard;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index useKeyboard on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_useController(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			bool useController = LuaDLL.luaL_checkboolean(L, 2);
			uICamera.useController = useController;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index useController on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_stickyTooltip(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			bool stickyTooltip = LuaDLL.luaL_checkboolean(L, 2);
			uICamera.stickyTooltip = stickyTooltip;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index stickyTooltip on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_tooltipDelay(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			float tooltipDelay = (float)LuaDLL.luaL_checknumber(L, 2);
			uICamera.tooltipDelay = tooltipDelay;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index tooltipDelay on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_longPressTooltip(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			bool longPressTooltip = LuaDLL.luaL_checkboolean(L, 2);
			uICamera.longPressTooltip = longPressTooltip;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index longPressTooltip on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_mouseDragThreshold(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			float mouseDragThreshold = (float)LuaDLL.luaL_checknumber(L, 2);
			uICamera.mouseDragThreshold = mouseDragThreshold;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index mouseDragThreshold on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_mouseClickThreshold(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			float mouseClickThreshold = (float)LuaDLL.luaL_checknumber(L, 2);
			uICamera.mouseClickThreshold = mouseClickThreshold;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index mouseClickThreshold on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_touchDragThreshold(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			float touchDragThreshold = (float)LuaDLL.luaL_checknumber(L, 2);
			uICamera.touchDragThreshold = touchDragThreshold;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index touchDragThreshold on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_touchClickThreshold(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			float touchClickThreshold = (float)LuaDLL.luaL_checknumber(L, 2);
			uICamera.touchClickThreshold = touchClickThreshold;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index touchClickThreshold on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_rangeDistance(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			float rangeDistance = (float)LuaDLL.luaL_checknumber(L, 2);
			uICamera.rangeDistance = rangeDistance;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index rangeDistance on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_horizontalAxisName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			string horizontalAxisName = ToLua.CheckString(L, 2);
			uICamera.horizontalAxisName = horizontalAxisName;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index horizontalAxisName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_verticalAxisName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			string verticalAxisName = ToLua.CheckString(L, 2);
			uICamera.verticalAxisName = verticalAxisName;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index verticalAxisName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_horizontalPanAxisName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			string horizontalPanAxisName = ToLua.CheckString(L, 2);
			uICamera.horizontalPanAxisName = horizontalPanAxisName;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index horizontalPanAxisName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_verticalPanAxisName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			string verticalPanAxisName = ToLua.CheckString(L, 2);
			uICamera.verticalPanAxisName = verticalPanAxisName;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index verticalPanAxisName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_scrollAxisName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			string scrollAxisName = ToLua.CheckString(L, 2);
			uICamera.scrollAxisName = scrollAxisName;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index scrollAxisName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_commandClick(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			bool commandClick = LuaDLL.luaL_checkboolean(L, 2);
			uICamera.commandClick = commandClick;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index commandClick on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_submitKey0(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			KeyCode submitKey = (KeyCode)LuaDLL.luaL_checknumber(L, 2);
			uICamera.submitKey0 = submitKey;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index submitKey0 on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_submitKey1(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			KeyCode submitKey = (KeyCode)LuaDLL.luaL_checknumber(L, 2);
			uICamera.submitKey1 = submitKey;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index submitKey1 on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_cancelKey0(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			KeyCode cancelKey = (KeyCode)LuaDLL.luaL_checknumber(L, 2);
			uICamera.cancelKey0 = cancelKey;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cancelKey0 on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_cancelKey1(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			KeyCode cancelKey = (KeyCode)LuaDLL.luaL_checknumber(L, 2);
			uICamera.cancelKey1 = cancelKey;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cancelKey1 on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_autoHideCursor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UICamera uICamera = (UICamera)obj;
			bool autoHideCursor = LuaDLL.luaL_checkboolean(L, 2);
			uICamera.autoHideCursor = autoHideCursor;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index autoHideCursor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onCustomInput(IntPtr L)
	{
		int result;
		try
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UICamera.OnCustomInput onCustomInput;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onCustomInput = (UICamera.OnCustomInput)ToLua.CheckObject(L, 2, typeof(UICamera.OnCustomInput));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onCustomInput = (DelegateFactory.CreateDelegate(typeof(UICamera.OnCustomInput), func) as UICamera.OnCustomInput);
			}
			UICamera.onCustomInput = onCustomInput;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_showTooltips(IntPtr L)
	{
		int result;
		try
		{
			bool showTooltips = LuaDLL.luaL_checkboolean(L, 2);
			UICamera.showTooltips = showTooltips;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ignoreControllerInput(IntPtr L)
	{
		int result;
		try
		{
			bool ignoreControllerInput = LuaDLL.luaL_checkboolean(L, 2);
			UICamera.ignoreControllerInput = ignoreControllerInput;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_lastWorldPosition(IntPtr L)
	{
		int result;
		try
		{
			Vector3 lastWorldPosition = ToLua.ToVector3(L, 2);
			UICamera.lastWorldPosition = lastWorldPosition;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_lastHit(IntPtr L)
	{
		int result;
		try
		{
			RaycastHit lastHit = (RaycastHit)ToLua.CheckObject(L, 2, typeof(RaycastHit));
			UICamera.lastHit = lastHit;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_current(IntPtr L)
	{
		int result;
		try
		{
			UICamera current = (UICamera)ToLua.CheckUnityObject(L, 2, typeof(UICamera));
			UICamera.current = current;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_currentCamera(IntPtr L)
	{
		int result;
		try
		{
			Camera currentCamera = (Camera)ToLua.CheckUnityObject(L, 2, typeof(Camera));
			UICamera.currentCamera = currentCamera;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onSchemeChange(IntPtr L)
	{
		int result;
		try
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UICamera.OnSchemeChange onSchemeChange;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onSchemeChange = (UICamera.OnSchemeChange)ToLua.CheckObject(L, 2, typeof(UICamera.OnSchemeChange));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onSchemeChange = (DelegateFactory.CreateDelegate(typeof(UICamera.OnSchemeChange), func) as UICamera.OnSchemeChange);
			}
			UICamera.onSchemeChange = onSchemeChange;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_currentTouchID(IntPtr L)
	{
		int result;
		try
		{
			int currentTouchID = (int)LuaDLL.luaL_checknumber(L, 2);
			UICamera.currentTouchID = currentTouchID;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_currentTouch(IntPtr L)
	{
		int result;
		try
		{
			UICamera.MouseOrTouch currentTouch = (UICamera.MouseOrTouch)ToLua.CheckObject(L, 2, typeof(UICamera.MouseOrTouch));
			UICamera.currentTouch = currentTouch;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fallThrough(IntPtr L)
	{
		int result;
		try
		{
			GameObject fallThrough = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			UICamera.fallThrough = fallThrough;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onClick(IntPtr L)
	{
		int result;
		try
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UICamera.VoidDelegate onClick;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onClick = (UICamera.VoidDelegate)ToLua.CheckObject(L, 2, typeof(UICamera.VoidDelegate));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onClick = (DelegateFactory.CreateDelegate(typeof(UICamera.VoidDelegate), func) as UICamera.VoidDelegate);
			}
			UICamera.onClick = onClick;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onDoubleClick(IntPtr L)
	{
		int result;
		try
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UICamera.VoidDelegate onDoubleClick;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onDoubleClick = (UICamera.VoidDelegate)ToLua.CheckObject(L, 2, typeof(UICamera.VoidDelegate));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onDoubleClick = (DelegateFactory.CreateDelegate(typeof(UICamera.VoidDelegate), func) as UICamera.VoidDelegate);
			}
			UICamera.onDoubleClick = onDoubleClick;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onHover(IntPtr L)
	{
		int result;
		try
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UICamera.BoolDelegate onHover;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onHover = (UICamera.BoolDelegate)ToLua.CheckObject(L, 2, typeof(UICamera.BoolDelegate));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onHover = (DelegateFactory.CreateDelegate(typeof(UICamera.BoolDelegate), func) as UICamera.BoolDelegate);
			}
			UICamera.onHover = onHover;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onPress(IntPtr L)
	{
		int result;
		try
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UICamera.BoolDelegate onPress;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onPress = (UICamera.BoolDelegate)ToLua.CheckObject(L, 2, typeof(UICamera.BoolDelegate));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onPress = (DelegateFactory.CreateDelegate(typeof(UICamera.BoolDelegate), func) as UICamera.BoolDelegate);
			}
			UICamera.onPress = onPress;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onSelect(IntPtr L)
	{
		int result;
		try
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UICamera.BoolDelegate onSelect;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onSelect = (UICamera.BoolDelegate)ToLua.CheckObject(L, 2, typeof(UICamera.BoolDelegate));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onSelect = (DelegateFactory.CreateDelegate(typeof(UICamera.BoolDelegate), func) as UICamera.BoolDelegate);
			}
			UICamera.onSelect = onSelect;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onScroll(IntPtr L)
	{
		int result;
		try
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UICamera.FloatDelegate onScroll;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onScroll = (UICamera.FloatDelegate)ToLua.CheckObject(L, 2, typeof(UICamera.FloatDelegate));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onScroll = (DelegateFactory.CreateDelegate(typeof(UICamera.FloatDelegate), func) as UICamera.FloatDelegate);
			}
			UICamera.onScroll = onScroll;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onDrag(IntPtr L)
	{
		int result;
		try
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UICamera.VectorDelegate onDrag;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onDrag = (UICamera.VectorDelegate)ToLua.CheckObject(L, 2, typeof(UICamera.VectorDelegate));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onDrag = (DelegateFactory.CreateDelegate(typeof(UICamera.VectorDelegate), func) as UICamera.VectorDelegate);
			}
			UICamera.onDrag = onDrag;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onDragStart(IntPtr L)
	{
		int result;
		try
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UICamera.VoidDelegate onDragStart;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onDragStart = (UICamera.VoidDelegate)ToLua.CheckObject(L, 2, typeof(UICamera.VoidDelegate));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onDragStart = (DelegateFactory.CreateDelegate(typeof(UICamera.VoidDelegate), func) as UICamera.VoidDelegate);
			}
			UICamera.onDragStart = onDragStart;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onDragOver(IntPtr L)
	{
		int result;
		try
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UICamera.ObjectDelegate onDragOver;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onDragOver = (UICamera.ObjectDelegate)ToLua.CheckObject(L, 2, typeof(UICamera.ObjectDelegate));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onDragOver = (DelegateFactory.CreateDelegate(typeof(UICamera.ObjectDelegate), func) as UICamera.ObjectDelegate);
			}
			UICamera.onDragOver = onDragOver;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onDragOut(IntPtr L)
	{
		int result;
		try
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UICamera.ObjectDelegate onDragOut;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onDragOut = (UICamera.ObjectDelegate)ToLua.CheckObject(L, 2, typeof(UICamera.ObjectDelegate));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onDragOut = (DelegateFactory.CreateDelegate(typeof(UICamera.ObjectDelegate), func) as UICamera.ObjectDelegate);
			}
			UICamera.onDragOut = onDragOut;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onDragEnd(IntPtr L)
	{
		int result;
		try
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UICamera.VoidDelegate onDragEnd;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onDragEnd = (UICamera.VoidDelegate)ToLua.CheckObject(L, 2, typeof(UICamera.VoidDelegate));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onDragEnd = (DelegateFactory.CreateDelegate(typeof(UICamera.VoidDelegate), func) as UICamera.VoidDelegate);
			}
			UICamera.onDragEnd = onDragEnd;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onDrop(IntPtr L)
	{
		int result;
		try
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UICamera.ObjectDelegate onDrop;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onDrop = (UICamera.ObjectDelegate)ToLua.CheckObject(L, 2, typeof(UICamera.ObjectDelegate));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onDrop = (DelegateFactory.CreateDelegate(typeof(UICamera.ObjectDelegate), func) as UICamera.ObjectDelegate);
			}
			UICamera.onDrop = onDrop;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onKey(IntPtr L)
	{
		int result;
		try
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UICamera.KeyCodeDelegate onKey;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onKey = (UICamera.KeyCodeDelegate)ToLua.CheckObject(L, 2, typeof(UICamera.KeyCodeDelegate));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onKey = (DelegateFactory.CreateDelegate(typeof(UICamera.KeyCodeDelegate), func) as UICamera.KeyCodeDelegate);
			}
			UICamera.onKey = onKey;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onNavigate(IntPtr L)
	{
		int result;
		try
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UICamera.KeyCodeDelegate onNavigate;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onNavigate = (UICamera.KeyCodeDelegate)ToLua.CheckObject(L, 2, typeof(UICamera.KeyCodeDelegate));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onNavigate = (DelegateFactory.CreateDelegate(typeof(UICamera.KeyCodeDelegate), func) as UICamera.KeyCodeDelegate);
			}
			UICamera.onNavigate = onNavigate;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onPan(IntPtr L)
	{
		int result;
		try
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UICamera.VectorDelegate onPan;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onPan = (UICamera.VectorDelegate)ToLua.CheckObject(L, 2, typeof(UICamera.VectorDelegate));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onPan = (DelegateFactory.CreateDelegate(typeof(UICamera.VectorDelegate), func) as UICamera.VectorDelegate);
			}
			UICamera.onPan = onPan;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onTooltip(IntPtr L)
	{
		int result;
		try
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UICamera.BoolDelegate onTooltip;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onTooltip = (UICamera.BoolDelegate)ToLua.CheckObject(L, 2, typeof(UICamera.BoolDelegate));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onTooltip = (DelegateFactory.CreateDelegate(typeof(UICamera.BoolDelegate), func) as UICamera.BoolDelegate);
			}
			UICamera.onTooltip = onTooltip;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onMouseMove(IntPtr L)
	{
		int result;
		try
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UICamera.MoveDelegate onMouseMove;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onMouseMove = (UICamera.MoveDelegate)ToLua.CheckObject(L, 2, typeof(UICamera.MoveDelegate));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onMouseMove = (DelegateFactory.CreateDelegate(typeof(UICamera.MoveDelegate), func) as UICamera.MoveDelegate);
			}
			UICamera.onMouseMove = onMouseMove;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_controller(IntPtr L)
	{
		int result;
		try
		{
			UICamera.MouseOrTouch controller = (UICamera.MouseOrTouch)ToLua.CheckObject(L, 2, typeof(UICamera.MouseOrTouch));
			UICamera.controller = controller;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_activeTouches(IntPtr L)
	{
		int result;
		try
		{
			List<UICamera.MouseOrTouch> activeTouches = (List<UICamera.MouseOrTouch>)ToLua.CheckObject(L, 2, typeof(List<UICamera.MouseOrTouch>));
			UICamera.activeTouches = activeTouches;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_isDragging(IntPtr L)
	{
		int result;
		try
		{
			bool isDragging = LuaDLL.luaL_checkboolean(L, 2);
			UICamera.isDragging = isDragging;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_GetInputTouchCount(IntPtr L)
	{
		int result;
		try
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UICamera.GetTouchCountCallback getInputTouchCount;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				getInputTouchCount = (UICamera.GetTouchCountCallback)ToLua.CheckObject(L, 2, typeof(UICamera.GetTouchCountCallback));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				getInputTouchCount = (DelegateFactory.CreateDelegate(typeof(UICamera.GetTouchCountCallback), func) as UICamera.GetTouchCountCallback);
			}
			UICamera.GetInputTouchCount = getInputTouchCount;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_GetInputTouch(IntPtr L)
	{
		int result;
		try
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UICamera.GetTouchCallback getInputTouch;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				getInputTouch = (UICamera.GetTouchCallback)ToLua.CheckObject(L, 2, typeof(UICamera.GetTouchCallback));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				getInputTouch = (DelegateFactory.CreateDelegate(typeof(UICamera.GetTouchCallback), func) as UICamera.GetTouchCallback);
			}
			UICamera.GetInputTouch = getInputTouch;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_disableController(IntPtr L)
	{
		int result;
		try
		{
			bool disableController = LuaDLL.luaL_checkboolean(L, 2);
			UICamera.disableController = disableController;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_lastEventPosition(IntPtr L)
	{
		int result;
		try
		{
			Vector2 lastEventPosition = ToLua.ToVector2(L, 2);
			UICamera.lastEventPosition = lastEventPosition;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_currentScheme(IntPtr L)
	{
		int result;
		try
		{
			UICamera.ControlScheme currentScheme = (UICamera.ControlScheme)LuaDLL.luaL_checknumber(L, 2);
			UICamera.currentScheme = currentScheme;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_currentKey(IntPtr L)
	{
		int result;
		try
		{
			KeyCode currentKey = (KeyCode)LuaDLL.luaL_checknumber(L, 2);
			UICamera.currentKey = currentKey;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_hoveredObject(IntPtr L)
	{
		int result;
		try
		{
			GameObject hoveredObject = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			UICamera.hoveredObject = hoveredObject;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_controllerNavigationObject(IntPtr L)
	{
		int result;
		try
		{
			GameObject controllerNavigationObject = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			UICamera.controllerNavigationObject = controllerNavigationObject;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_selectedObject(IntPtr L)
	{
		int result;
		try
		{
			GameObject selectedObject = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			UICamera.selectedObject = selectedObject;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UICamera_GetTouchCallback(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICamera.GetTouchCallback), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICamera.GetTouchCallback), func, self);
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
	private static int UICamera_GetTouchCountCallback(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICamera.GetTouchCountCallback), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICamera.GetTouchCountCallback), func, self);
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
	private static int UICamera_MoveDelegate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICamera.MoveDelegate), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICamera.MoveDelegate), func, self);
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
	private static int UICamera_BoolDelegate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICamera.BoolDelegate), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICamera.BoolDelegate), func, self);
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
	private static int UICamera_VectorDelegate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICamera.VectorDelegate), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICamera.VectorDelegate), func, self);
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
	private static int UICamera_KeyCodeDelegate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICamera.KeyCodeDelegate), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICamera.KeyCodeDelegate), func, self);
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
	private static int UICamera_ObjectDelegate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICamera.ObjectDelegate), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICamera.ObjectDelegate), func, self);
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
	private static int UICamera_VoidDelegate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICamera.VoidDelegate), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICamera.VoidDelegate), func, self);
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
	private static int UICamera_FloatDelegate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICamera.FloatDelegate), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICamera.FloatDelegate), func, self);
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
	private static int UICamera_OnSchemeChange(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICamera.OnSchemeChange), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICamera.OnSchemeChange), func, self);
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
	private static int UICamera_OnCustomInput(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICamera.OnCustomInput), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICamera.OnCustomInput), func, self);
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
	private static int UICamera_OnScreenResize(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICamera.OnScreenResize), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICamera.OnScreenResize), func, self);
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
	private static int UICamera_RemoveTouchDelegate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICamera.RemoveTouchDelegate), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICamera.RemoveTouchDelegate), func, self);
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
	private static int UICamera_GetTouchDelegate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICamera.GetTouchDelegate), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICamera.GetTouchDelegate), func, self);
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
	private static int UICamera_GetMouseDelegate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICamera.GetMouseDelegate), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICamera.GetMouseDelegate), func, self);
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
	private static int UICamera_GetAnyKeyFunc(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICamera.GetAnyKeyFunc), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICamera.GetAnyKeyFunc), func, self);
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
	private static int UICamera_GetAxisFunc(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICamera.GetAxisFunc), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICamera.GetAxisFunc), func, self);
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
	private static int UICamera_GetKeyStateFunc(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICamera.GetKeyStateFunc), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICamera.GetKeyStateFunc), func, self);
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
