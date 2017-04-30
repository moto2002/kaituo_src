using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UIInputWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIInput), typeof(MonoBehaviour), null);
		L.RegFunction("AddOnChange", new LuaCSFunction(UIInputWrap.AddOnChange));
		L.RegFunction("RemoveOnChange", new LuaCSFunction(UIInputWrap.RemoveOnChange));
		L.RegFunction("Set", new LuaCSFunction(UIInputWrap.Set));
		L.RegFunction("Validate", new LuaCSFunction(UIInputWrap.Validate));
		L.RegFunction("Start", new LuaCSFunction(UIInputWrap.Start));
		L.RegFunction("Submit", new LuaCSFunction(UIInputWrap.Submit));
		L.RegFunction("UpdateLabel", new LuaCSFunction(UIInputWrap.UpdateLabel));
		L.RegFunction("RemoveFocus", new LuaCSFunction(UIInputWrap.RemoveFocus));
		L.RegFunction("SaveValue", new LuaCSFunction(UIInputWrap.SaveValue));
		L.RegFunction("LoadValue", new LuaCSFunction(UIInputWrap.LoadValue));
		L.RegFunction("__eq", new LuaCSFunction(UIInputWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("current", new LuaCSFunction(UIInputWrap.get_current), new LuaCSFunction(UIInputWrap.set_current));
		L.RegVar("selection", new LuaCSFunction(UIInputWrap.get_selection), new LuaCSFunction(UIInputWrap.set_selection));
		L.RegVar("label", new LuaCSFunction(UIInputWrap.get_label), new LuaCSFunction(UIInputWrap.set_label));
		L.RegVar("inputType", new LuaCSFunction(UIInputWrap.get_inputType), new LuaCSFunction(UIInputWrap.set_inputType));
		L.RegVar("onReturnKey", new LuaCSFunction(UIInputWrap.get_onReturnKey), new LuaCSFunction(UIInputWrap.set_onReturnKey));
		L.RegVar("keyboardType", new LuaCSFunction(UIInputWrap.get_keyboardType), new LuaCSFunction(UIInputWrap.set_keyboardType));
		L.RegVar("hideInput", new LuaCSFunction(UIInputWrap.get_hideInput), new LuaCSFunction(UIInputWrap.set_hideInput));
		L.RegVar("selectAllTextOnFocus", new LuaCSFunction(UIInputWrap.get_selectAllTextOnFocus), new LuaCSFunction(UIInputWrap.set_selectAllTextOnFocus));
		L.RegVar("validation", new LuaCSFunction(UIInputWrap.get_validation), new LuaCSFunction(UIInputWrap.set_validation));
		L.RegVar("characterLimit", new LuaCSFunction(UIInputWrap.get_characterLimit), new LuaCSFunction(UIInputWrap.set_characterLimit));
		L.RegVar("utf8LimitCheck", new LuaCSFunction(UIInputWrap.get_utf8LimitCheck), new LuaCSFunction(UIInputWrap.set_utf8LimitCheck));
		L.RegVar("savedAs", new LuaCSFunction(UIInputWrap.get_savedAs), new LuaCSFunction(UIInputWrap.set_savedAs));
		L.RegVar("activeTextColor", new LuaCSFunction(UIInputWrap.get_activeTextColor), new LuaCSFunction(UIInputWrap.set_activeTextColor));
		L.RegVar("caretColor", new LuaCSFunction(UIInputWrap.get_caretColor), new LuaCSFunction(UIInputWrap.set_caretColor));
		L.RegVar("selectionColor", new LuaCSFunction(UIInputWrap.get_selectionColor), new LuaCSFunction(UIInputWrap.set_selectionColor));
		L.RegVar("onSubmit", new LuaCSFunction(UIInputWrap.get_onSubmit), new LuaCSFunction(UIInputWrap.set_onSubmit));
		L.RegVar("onChange", new LuaCSFunction(UIInputWrap.get_onChange), new LuaCSFunction(UIInputWrap.set_onChange));
		L.RegVar("onValidate", new LuaCSFunction(UIInputWrap.get_onValidate), new LuaCSFunction(UIInputWrap.set_onValidate));
		L.RegVar("defaultText", new LuaCSFunction(UIInputWrap.get_defaultText), new LuaCSFunction(UIInputWrap.set_defaultText));
		L.RegVar("defaultColor", new LuaCSFunction(UIInputWrap.get_defaultColor), new LuaCSFunction(UIInputWrap.set_defaultColor));
		L.RegVar("inputShouldBeHidden", new LuaCSFunction(UIInputWrap.get_inputShouldBeHidden), null);
		L.RegVar("value", new LuaCSFunction(UIInputWrap.get_value), new LuaCSFunction(UIInputWrap.set_value));
		L.RegVar("isSelected", new LuaCSFunction(UIInputWrap.get_isSelected), new LuaCSFunction(UIInputWrap.set_isSelected));
		L.RegVar("cursorPosition", new LuaCSFunction(UIInputWrap.get_cursorPosition), new LuaCSFunction(UIInputWrap.set_cursorPosition));
		L.RegVar("selectionStart", new LuaCSFunction(UIInputWrap.get_selectionStart), new LuaCSFunction(UIInputWrap.set_selectionStart));
		L.RegVar("selectionEnd", new LuaCSFunction(UIInputWrap.get_selectionEnd), new LuaCSFunction(UIInputWrap.set_selectionEnd));
		L.RegVar("caret", new LuaCSFunction(UIInputWrap.get_caret), null);
		L.RegFunction("OnValidate", new LuaCSFunction(UIInputWrap.UIInput_OnValidate));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddOnChange(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(UIInput), typeof(EventDelegate)))
			{
				UIInput uIInput = (UIInput)ToLua.ToObject(L, 1);
				EventDelegate del = (EventDelegate)ToLua.ToObject(L, 2);
				uIInput.AddOnChange(del);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(UIInput), typeof(EventDelegate.Callback)))
			{
				UIInput uIInput2 = (UIInput)ToLua.ToObject(L, 1);
				LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
				EventDelegate.Callback del2;
				if (luaTypes != LuaTypes.LUA_TFUNCTION)
				{
					del2 = (EventDelegate.Callback)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func = ToLua.ToLuaFunction(L, 2);
					del2 = (DelegateFactory.CreateDelegate(typeof(EventDelegate.Callback), func) as EventDelegate.Callback);
				}
				uIInput2.AddOnChange(del2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UIInput.AddOnChange");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveOnChange(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIInput uIInput = (UIInput)ToLua.CheckObject(L, 1, typeof(UIInput));
			EventDelegate del = (EventDelegate)ToLua.CheckObject(L, 2, typeof(EventDelegate));
			uIInput.RemoveOnChange(del);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Set(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UIInput uIInput = (UIInput)ToLua.CheckObject(L, 1, typeof(UIInput));
			string value = ToLua.CheckString(L, 2);
			bool notify = LuaDLL.luaL_checkboolean(L, 3);
			uIInput.Set(value, notify);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Validate(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIInput uIInput = (UIInput)ToLua.CheckObject(L, 1, typeof(UIInput));
			string val = ToLua.CheckString(L, 2);
			string str = uIInput.Validate(val);
			LuaDLL.lua_pushstring(L, str);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Start(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIInput uIInput = (UIInput)ToLua.CheckObject(L, 1, typeof(UIInput));
			uIInput.Start();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Submit(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIInput uIInput = (UIInput)ToLua.CheckObject(L, 1, typeof(UIInput));
			uIInput.Submit();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UpdateLabel(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIInput uIInput = (UIInput)ToLua.CheckObject(L, 1, typeof(UIInput));
			uIInput.UpdateLabel();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveFocus(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIInput uIInput = (UIInput)ToLua.CheckObject(L, 1, typeof(UIInput));
			uIInput.RemoveFocus();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SaveValue(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIInput uIInput = (UIInput)ToLua.CheckObject(L, 1, typeof(UIInput));
			uIInput.SaveValue();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadValue(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIInput uIInput = (UIInput)ToLua.CheckObject(L, 1, typeof(UIInput));
			uIInput.LoadValue();
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
	private static int get_current(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UIInput.current);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_selection(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UIInput.selection);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_label(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			UILabel label = uIInput.label;
			ToLua.Push(L, label);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index label on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_inputType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			UIInput.InputType inputType = uIInput.inputType;
			ToLua.Push(L, inputType);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index inputType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onReturnKey(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			UIInput.OnReturnKey onReturnKey = uIInput.onReturnKey;
			ToLua.Push(L, onReturnKey);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onReturnKey on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_keyboardType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			UIInput.KeyboardType keyboardType = uIInput.keyboardType;
			ToLua.Push(L, keyboardType);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index keyboardType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_hideInput(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			bool hideInput = uIInput.hideInput;
			LuaDLL.lua_pushboolean(L, hideInput);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index hideInput on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_selectAllTextOnFocus(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			bool selectAllTextOnFocus = uIInput.selectAllTextOnFocus;
			LuaDLL.lua_pushboolean(L, selectAllTextOnFocus);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index selectAllTextOnFocus on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_validation(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			UIInput.Validation validation = uIInput.validation;
			ToLua.Push(L, validation);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index validation on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_characterLimit(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			int characterLimit = uIInput.characterLimit;
			LuaDLL.lua_pushinteger(L, characterLimit);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index characterLimit on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_utf8LimitCheck(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			bool utf8LimitCheck = uIInput.utf8LimitCheck;
			LuaDLL.lua_pushboolean(L, utf8LimitCheck);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index utf8LimitCheck on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_savedAs(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			string savedAs = uIInput.savedAs;
			LuaDLL.lua_pushstring(L, savedAs);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index savedAs on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_activeTextColor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			Color activeTextColor = uIInput.activeTextColor;
			ToLua.Push(L, activeTextColor);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index activeTextColor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_caretColor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			Color caretColor = uIInput.caretColor;
			ToLua.Push(L, caretColor);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index caretColor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_selectionColor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			Color selectionColor = uIInput.selectionColor;
			ToLua.Push(L, selectionColor);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index selectionColor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onSubmit(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			List<EventDelegate> onSubmit = uIInput.onSubmit;
			ToLua.PushObject(L, onSubmit);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onSubmit on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onChange(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			List<EventDelegate> onChange = uIInput.onChange;
			ToLua.PushObject(L, onChange);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onChange on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onValidate(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			UIInput.OnValidate onValidate = uIInput.onValidate;
			ToLua.Push(L, onValidate);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onValidate on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_defaultText(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			string defaultText = uIInput.defaultText;
			LuaDLL.lua_pushstring(L, defaultText);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index defaultText on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_defaultColor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			Color defaultColor = uIInput.defaultColor;
			ToLua.Push(L, defaultColor);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index defaultColor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_inputShouldBeHidden(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			bool inputShouldBeHidden = uIInput.inputShouldBeHidden;
			LuaDLL.lua_pushboolean(L, inputShouldBeHidden);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index inputShouldBeHidden on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_value(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			string value = uIInput.value;
			LuaDLL.lua_pushstring(L, value);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index value on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isSelected(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			bool isSelected = uIInput.isSelected;
			LuaDLL.lua_pushboolean(L, isSelected);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isSelected on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cursorPosition(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			int cursorPosition = uIInput.cursorPosition;
			LuaDLL.lua_pushinteger(L, cursorPosition);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cursorPosition on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_selectionStart(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			int selectionStart = uIInput.selectionStart;
			LuaDLL.lua_pushinteger(L, selectionStart);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index selectionStart on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_selectionEnd(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			int selectionEnd = uIInput.selectionEnd;
			LuaDLL.lua_pushinteger(L, selectionEnd);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index selectionEnd on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_caret(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			UITexture caret = uIInput.caret;
			ToLua.Push(L, caret);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index caret on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_current(IntPtr L)
	{
		int result;
		try
		{
			UIInput current = (UIInput)ToLua.CheckUnityObject(L, 2, typeof(UIInput));
			UIInput.current = current;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_selection(IntPtr L)
	{
		int result;
		try
		{
			UIInput selection = (UIInput)ToLua.CheckUnityObject(L, 2, typeof(UIInput));
			UIInput.selection = selection;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_label(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			UILabel label = (UILabel)ToLua.CheckUnityObject(L, 2, typeof(UILabel));
			uIInput.label = label;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index label on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_inputType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			UIInput.InputType inputType = (UIInput.InputType)LuaDLL.luaL_checknumber(L, 2);
			uIInput.inputType = inputType;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index inputType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onReturnKey(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			UIInput.OnReturnKey onReturnKey = (UIInput.OnReturnKey)LuaDLL.luaL_checknumber(L, 2);
			uIInput.onReturnKey = onReturnKey;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onReturnKey on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_keyboardType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			UIInput.KeyboardType keyboardType = (UIInput.KeyboardType)LuaDLL.luaL_checknumber(L, 2);
			uIInput.keyboardType = keyboardType;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index keyboardType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_hideInput(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			bool hideInput = LuaDLL.luaL_checkboolean(L, 2);
			uIInput.hideInput = hideInput;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index hideInput on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_selectAllTextOnFocus(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			bool selectAllTextOnFocus = LuaDLL.luaL_checkboolean(L, 2);
			uIInput.selectAllTextOnFocus = selectAllTextOnFocus;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index selectAllTextOnFocus on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_validation(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			UIInput.Validation validation = (UIInput.Validation)LuaDLL.luaL_checknumber(L, 2);
			uIInput.validation = validation;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index validation on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_characterLimit(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			int characterLimit = (int)LuaDLL.luaL_checknumber(L, 2);
			uIInput.characterLimit = characterLimit;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index characterLimit on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_utf8LimitCheck(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			bool utf8LimitCheck = LuaDLL.luaL_checkboolean(L, 2);
			uIInput.utf8LimitCheck = utf8LimitCheck;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index utf8LimitCheck on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_savedAs(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			string savedAs = ToLua.CheckString(L, 2);
			uIInput.savedAs = savedAs;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index savedAs on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_activeTextColor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			Color activeTextColor = ToLua.ToColor(L, 2);
			uIInput.activeTextColor = activeTextColor;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index activeTextColor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_caretColor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			Color caretColor = ToLua.ToColor(L, 2);
			uIInput.caretColor = caretColor;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index caretColor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_selectionColor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			Color selectionColor = ToLua.ToColor(L, 2);
			uIInput.selectionColor = selectionColor;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index selectionColor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onSubmit(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			List<EventDelegate> onSubmit = (List<EventDelegate>)ToLua.CheckObject(L, 2, typeof(List<EventDelegate>));
			uIInput.onSubmit = onSubmit;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onSubmit on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onChange(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			List<EventDelegate> onChange = (List<EventDelegate>)ToLua.CheckObject(L, 2, typeof(List<EventDelegate>));
			uIInput.onChange = onChange;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onChange on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onValidate(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UIInput.OnValidate onValidate;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onValidate = (UIInput.OnValidate)ToLua.CheckObject(L, 2, typeof(UIInput.OnValidate));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onValidate = (DelegateFactory.CreateDelegate(typeof(UIInput.OnValidate), func) as UIInput.OnValidate);
			}
			uIInput.onValidate = onValidate;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onValidate on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_defaultText(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			string defaultText = ToLua.CheckString(L, 2);
			uIInput.defaultText = defaultText;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index defaultText on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_defaultColor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			Color defaultColor = ToLua.ToColor(L, 2);
			uIInput.defaultColor = defaultColor;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index defaultColor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_value(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			string value = ToLua.CheckString(L, 2);
			uIInput.value = value;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index value on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_isSelected(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			bool isSelected = LuaDLL.luaL_checkboolean(L, 2);
			uIInput.isSelected = isSelected;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isSelected on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_cursorPosition(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			int cursorPosition = (int)LuaDLL.luaL_checknumber(L, 2);
			uIInput.cursorPosition = cursorPosition;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cursorPosition on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_selectionStart(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			int selectionStart = (int)LuaDLL.luaL_checknumber(L, 2);
			uIInput.selectionStart = selectionStart;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index selectionStart on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_selectionEnd(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIInput uIInput = (UIInput)obj;
			int selectionEnd = (int)LuaDLL.luaL_checknumber(L, 2);
			uIInput.selectionEnd = selectionEnd;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index selectionEnd on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIInput_OnValidate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIInput.OnValidate), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIInput.OnValidate), func, self);
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
