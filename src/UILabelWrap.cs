using LuaInterface;
using System;
using UnityEngine;

public class UILabelWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UILabel), typeof(UIWidget), null);
		L.RegFunction("GetSides", new LuaCSFunction(UILabelWrap.GetSides));
		L.RegFunction("MarkAsChanged", new LuaCSFunction(UILabelWrap.MarkAsChanged));
		L.RegFunction("ProcessText", new LuaCSFunction(UILabelWrap.ProcessText));
		L.RegFunction("MakePixelPerfect", new LuaCSFunction(UILabelWrap.MakePixelPerfect));
		L.RegFunction("AssumeNaturalSize", new LuaCSFunction(UILabelWrap.AssumeNaturalSize));
		L.RegFunction("GetCharacterIndexAtPosition", new LuaCSFunction(UILabelWrap.GetCharacterIndexAtPosition));
		L.RegFunction("GetWordAtPosition", new LuaCSFunction(UILabelWrap.GetWordAtPosition));
		L.RegFunction("GetWordAtCharacterIndex", new LuaCSFunction(UILabelWrap.GetWordAtCharacterIndex));
		L.RegFunction("GetUrlAtPosition", new LuaCSFunction(UILabelWrap.GetUrlAtPosition));
		L.RegFunction("GetUrlAtCharacterIndex", new LuaCSFunction(UILabelWrap.GetUrlAtCharacterIndex));
		L.RegFunction("GetCharacterIndex", new LuaCSFunction(UILabelWrap.GetCharacterIndex));
		L.RegFunction("PrintOverlay", new LuaCSFunction(UILabelWrap.PrintOverlay));
		L.RegFunction("OnFill", new LuaCSFunction(UILabelWrap.OnFill));
		L.RegFunction("ApplyOffset", new LuaCSFunction(UILabelWrap.ApplyOffset));
		L.RegFunction("ApplyShadow", new LuaCSFunction(UILabelWrap.ApplyShadow));
		L.RegFunction("CalculateOffsetToFit", new LuaCSFunction(UILabelWrap.CalculateOffsetToFit));
		L.RegFunction("SetCurrentProgress", new LuaCSFunction(UILabelWrap.SetCurrentProgress));
		L.RegFunction("SetCurrentPercent", new LuaCSFunction(UILabelWrap.SetCurrentPercent));
		L.RegFunction("SetCurrentSelection", new LuaCSFunction(UILabelWrap.SetCurrentSelection));
		L.RegFunction("Wrap", new LuaCSFunction(UILabelWrap.Wrap));
		L.RegFunction("UpdateNGUIText", new LuaCSFunction(UILabelWrap.UpdateNGUIText));
		L.RegFunction("__eq", new LuaCSFunction(UILabelWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("keepCrispWhenShrunk", new LuaCSFunction(UILabelWrap.get_keepCrispWhenShrunk), new LuaCSFunction(UILabelWrap.set_keepCrispWhenShrunk));
		L.RegVar("customModifier", new LuaCSFunction(UILabelWrap.get_customModifier), new LuaCSFunction(UILabelWrap.set_customModifier));
		L.RegVar("finalFontSize", new LuaCSFunction(UILabelWrap.get_finalFontSize), null);
		L.RegVar("isAnchoredHorizontally", new LuaCSFunction(UILabelWrap.get_isAnchoredHorizontally), null);
		L.RegVar("isAnchoredVertically", new LuaCSFunction(UILabelWrap.get_isAnchoredVertically), null);
		L.RegVar("material", new LuaCSFunction(UILabelWrap.get_material), new LuaCSFunction(UILabelWrap.set_material));
		L.RegVar("bitmapFont", new LuaCSFunction(UILabelWrap.get_bitmapFont), new LuaCSFunction(UILabelWrap.set_bitmapFont));
		L.RegVar("trueTypeFont", new LuaCSFunction(UILabelWrap.get_trueTypeFont), new LuaCSFunction(UILabelWrap.set_trueTypeFont));
		L.RegVar("ambigiousFont", new LuaCSFunction(UILabelWrap.get_ambigiousFont), new LuaCSFunction(UILabelWrap.set_ambigiousFont));
		L.RegVar("text", new LuaCSFunction(UILabelWrap.get_text), new LuaCSFunction(UILabelWrap.set_text));
		L.RegVar("defaultFontSize", new LuaCSFunction(UILabelWrap.get_defaultFontSize), null);
		L.RegVar("fontSize", new LuaCSFunction(UILabelWrap.get_fontSize), new LuaCSFunction(UILabelWrap.set_fontSize));
		L.RegVar("fontStyle", new LuaCSFunction(UILabelWrap.get_fontStyle), new LuaCSFunction(UILabelWrap.set_fontStyle));
		L.RegVar("alignment", new LuaCSFunction(UILabelWrap.get_alignment), new LuaCSFunction(UILabelWrap.set_alignment));
		L.RegVar("applyGradient", new LuaCSFunction(UILabelWrap.get_applyGradient), new LuaCSFunction(UILabelWrap.set_applyGradient));
		L.RegVar("gradientTop", new LuaCSFunction(UILabelWrap.get_gradientTop), new LuaCSFunction(UILabelWrap.set_gradientTop));
		L.RegVar("gradientBottom", new LuaCSFunction(UILabelWrap.get_gradientBottom), new LuaCSFunction(UILabelWrap.set_gradientBottom));
		L.RegVar("spacingX", new LuaCSFunction(UILabelWrap.get_spacingX), new LuaCSFunction(UILabelWrap.set_spacingX));
		L.RegVar("spacingY", new LuaCSFunction(UILabelWrap.get_spacingY), new LuaCSFunction(UILabelWrap.set_spacingY));
		L.RegVar("useFloatSpacing", new LuaCSFunction(UILabelWrap.get_useFloatSpacing), new LuaCSFunction(UILabelWrap.set_useFloatSpacing));
		L.RegVar("floatSpacingX", new LuaCSFunction(UILabelWrap.get_floatSpacingX), new LuaCSFunction(UILabelWrap.set_floatSpacingX));
		L.RegVar("floatSpacingY", new LuaCSFunction(UILabelWrap.get_floatSpacingY), new LuaCSFunction(UILabelWrap.set_floatSpacingY));
		L.RegVar("effectiveSpacingY", new LuaCSFunction(UILabelWrap.get_effectiveSpacingY), null);
		L.RegVar("effectiveSpacingX", new LuaCSFunction(UILabelWrap.get_effectiveSpacingX), null);
		L.RegVar("overflowEllipsis", new LuaCSFunction(UILabelWrap.get_overflowEllipsis), new LuaCSFunction(UILabelWrap.set_overflowEllipsis));
		L.RegVar("overflowWidth", new LuaCSFunction(UILabelWrap.get_overflowWidth), new LuaCSFunction(UILabelWrap.set_overflowWidth));
		L.RegVar("supportEncoding", new LuaCSFunction(UILabelWrap.get_supportEncoding), new LuaCSFunction(UILabelWrap.set_supportEncoding));
		L.RegVar("symbolStyle", new LuaCSFunction(UILabelWrap.get_symbolStyle), new LuaCSFunction(UILabelWrap.set_symbolStyle));
		L.RegVar("overflowMethod", new LuaCSFunction(UILabelWrap.get_overflowMethod), new LuaCSFunction(UILabelWrap.set_overflowMethod));
		L.RegVar("multiLine", new LuaCSFunction(UILabelWrap.get_multiLine), new LuaCSFunction(UILabelWrap.set_multiLine));
		L.RegVar("localCorners", new LuaCSFunction(UILabelWrap.get_localCorners), null);
		L.RegVar("worldCorners", new LuaCSFunction(UILabelWrap.get_worldCorners), null);
		L.RegVar("drawingDimensions", new LuaCSFunction(UILabelWrap.get_drawingDimensions), null);
		L.RegVar("maxLineCount", new LuaCSFunction(UILabelWrap.get_maxLineCount), new LuaCSFunction(UILabelWrap.set_maxLineCount));
		L.RegVar("effectStyle", new LuaCSFunction(UILabelWrap.get_effectStyle), new LuaCSFunction(UILabelWrap.set_effectStyle));
		L.RegVar("effectColor", new LuaCSFunction(UILabelWrap.get_effectColor), new LuaCSFunction(UILabelWrap.set_effectColor));
		L.RegVar("effectDistance", new LuaCSFunction(UILabelWrap.get_effectDistance), new LuaCSFunction(UILabelWrap.set_effectDistance));
		L.RegVar("processedText", new LuaCSFunction(UILabelWrap.get_processedText), null);
		L.RegVar("printedSize", new LuaCSFunction(UILabelWrap.get_printedSize), null);
		L.RegVar("localSize", new LuaCSFunction(UILabelWrap.get_localSize), null);
		L.RegVar("modifier", new LuaCSFunction(UILabelWrap.get_modifier), new LuaCSFunction(UILabelWrap.set_modifier));
		L.RegVar("printedText", new LuaCSFunction(UILabelWrap.get_printedText), null);
		L.RegFunction("ModifierFunc", new LuaCSFunction(UILabelWrap.UILabel_ModifierFunc));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetSides(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UILabel uILabel = (UILabel)ToLua.CheckObject(L, 1, typeof(UILabel));
			Transform relativeTo = (Transform)ToLua.CheckUnityObject(L, 2, typeof(Transform));
			Vector3[] sides = uILabel.GetSides(relativeTo);
			ToLua.Push(L, sides);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MarkAsChanged(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UILabel uILabel = (UILabel)ToLua.CheckObject(L, 1, typeof(UILabel));
			uILabel.MarkAsChanged();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ProcessText(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UILabel uILabel = (UILabel)ToLua.CheckObject(L, 1, typeof(UILabel));
			uILabel.ProcessText();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MakePixelPerfect(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UILabel uILabel = (UILabel)ToLua.CheckObject(L, 1, typeof(UILabel));
			uILabel.MakePixelPerfect();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AssumeNaturalSize(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UILabel uILabel = (UILabel)ToLua.CheckObject(L, 1, typeof(UILabel));
			uILabel.AssumeNaturalSize();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetCharacterIndexAtPosition(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(UILabel), typeof(Vector2), typeof(bool)))
			{
				UILabel uILabel = (UILabel)ToLua.ToObject(L, 1);
				Vector2 localPos = ToLua.ToVector2(L, 2);
				bool precise = LuaDLL.lua_toboolean(L, 3);
				int characterIndexAtPosition = uILabel.GetCharacterIndexAtPosition(localPos, precise);
				LuaDLL.lua_pushinteger(L, characterIndexAtPosition);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(UILabel), typeof(Vector3), typeof(bool)))
			{
				UILabel uILabel2 = (UILabel)ToLua.ToObject(L, 1);
				Vector3 worldPos = ToLua.ToVector3(L, 2);
				bool precise2 = LuaDLL.lua_toboolean(L, 3);
				int characterIndexAtPosition2 = uILabel2.GetCharacterIndexAtPosition(worldPos, precise2);
				LuaDLL.lua_pushinteger(L, characterIndexAtPosition2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UILabel.GetCharacterIndexAtPosition");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetWordAtPosition(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(UILabel), typeof(Vector2)))
			{
				UILabel uILabel = (UILabel)ToLua.ToObject(L, 1);
				Vector2 localPos = ToLua.ToVector2(L, 2);
				string wordAtPosition = uILabel.GetWordAtPosition(localPos);
				LuaDLL.lua_pushstring(L, wordAtPosition);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(UILabel), typeof(Vector3)))
			{
				UILabel uILabel2 = (UILabel)ToLua.ToObject(L, 1);
				Vector3 worldPos = ToLua.ToVector3(L, 2);
				string wordAtPosition2 = uILabel2.GetWordAtPosition(worldPos);
				LuaDLL.lua_pushstring(L, wordAtPosition2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UILabel.GetWordAtPosition");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetWordAtCharacterIndex(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UILabel uILabel = (UILabel)ToLua.CheckObject(L, 1, typeof(UILabel));
			int characterIndex = (int)LuaDLL.luaL_checknumber(L, 2);
			string wordAtCharacterIndex = uILabel.GetWordAtCharacterIndex(characterIndex);
			LuaDLL.lua_pushstring(L, wordAtCharacterIndex);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetUrlAtPosition(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(UILabel), typeof(Vector2)))
			{
				UILabel uILabel = (UILabel)ToLua.ToObject(L, 1);
				Vector2 localPos = ToLua.ToVector2(L, 2);
				string urlAtPosition = uILabel.GetUrlAtPosition(localPos);
				LuaDLL.lua_pushstring(L, urlAtPosition);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(UILabel), typeof(Vector3)))
			{
				UILabel uILabel2 = (UILabel)ToLua.ToObject(L, 1);
				Vector3 worldPos = ToLua.ToVector3(L, 2);
				string urlAtPosition2 = uILabel2.GetUrlAtPosition(worldPos);
				LuaDLL.lua_pushstring(L, urlAtPosition2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UILabel.GetUrlAtPosition");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetUrlAtCharacterIndex(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UILabel uILabel = (UILabel)ToLua.CheckObject(L, 1, typeof(UILabel));
			int characterIndex = (int)LuaDLL.luaL_checknumber(L, 2);
			string urlAtCharacterIndex = uILabel.GetUrlAtCharacterIndex(characterIndex);
			LuaDLL.lua_pushstring(L, urlAtCharacterIndex);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetCharacterIndex(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UILabel uILabel = (UILabel)ToLua.CheckObject(L, 1, typeof(UILabel));
			int currentIndex = (int)LuaDLL.luaL_checknumber(L, 2);
			KeyCode key = (KeyCode)LuaDLL.luaL_checknumber(L, 3);
			int characterIndex = uILabel.GetCharacterIndex(currentIndex, key);
			LuaDLL.lua_pushinteger(L, characterIndex);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PrintOverlay(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 7);
			UILabel uILabel = (UILabel)ToLua.CheckObject(L, 1, typeof(UILabel));
			int start = (int)LuaDLL.luaL_checknumber(L, 2);
			int end = (int)LuaDLL.luaL_checknumber(L, 3);
			UIGeometry caret = (UIGeometry)ToLua.CheckObject(L, 4, typeof(UIGeometry));
			UIGeometry highlight = (UIGeometry)ToLua.CheckObject(L, 5, typeof(UIGeometry));
			Color caretColor = ToLua.ToColor(L, 6);
			Color highlightColor = ToLua.ToColor(L, 7);
			uILabel.PrintOverlay(start, end, caret, highlight, caretColor, highlightColor);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnFill(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			UILabel uILabel = (UILabel)ToLua.CheckObject(L, 1, typeof(UILabel));
			BetterList<Vector3> verts = (BetterList<Vector3>)ToLua.CheckObject(L, 2, typeof(BetterList<Vector3>));
			BetterList<Vector2> uvs = (BetterList<Vector2>)ToLua.CheckObject(L, 3, typeof(BetterList<Vector2>));
			BetterList<Color> cols = (BetterList<Color>)ToLua.CheckObject(L, 4, typeof(BetterList<Color>));
			uILabel.OnFill(verts, uvs, cols);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ApplyOffset(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UILabel uILabel = (UILabel)ToLua.CheckObject(L, 1, typeof(UILabel));
			BetterList<Vector3> verts = (BetterList<Vector3>)ToLua.CheckObject(L, 2, typeof(BetterList<Vector3>));
			int start = (int)LuaDLL.luaL_checknumber(L, 3);
			Vector2 v = uILabel.ApplyOffset(verts, start);
			ToLua.Push(L, v);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ApplyShadow(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 8);
			UILabel uILabel = (UILabel)ToLua.CheckObject(L, 1, typeof(UILabel));
			BetterList<Vector3> verts = (BetterList<Vector3>)ToLua.CheckObject(L, 2, typeof(BetterList<Vector3>));
			BetterList<Vector2> uvs = (BetterList<Vector2>)ToLua.CheckObject(L, 3, typeof(BetterList<Vector2>));
			BetterList<Color> cols = (BetterList<Color>)ToLua.CheckObject(L, 4, typeof(BetterList<Color>));
			int start = (int)LuaDLL.luaL_checknumber(L, 5);
			int end = (int)LuaDLL.luaL_checknumber(L, 6);
			float x = (float)LuaDLL.luaL_checknumber(L, 7);
			float y = (float)LuaDLL.luaL_checknumber(L, 8);
			uILabel.ApplyShadow(verts, uvs, cols, start, end, x, y);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CalculateOffsetToFit(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UILabel uILabel = (UILabel)ToLua.CheckObject(L, 1, typeof(UILabel));
			string text = ToLua.CheckString(L, 2);
			int n = uILabel.CalculateOffsetToFit(text);
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
	private static int SetCurrentProgress(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UILabel uILabel = (UILabel)ToLua.CheckObject(L, 1, typeof(UILabel));
			uILabel.SetCurrentProgress();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetCurrentPercent(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UILabel uILabel = (UILabel)ToLua.CheckObject(L, 1, typeof(UILabel));
			uILabel.SetCurrentPercent();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetCurrentSelection(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UILabel uILabel = (UILabel)ToLua.CheckObject(L, 1, typeof(UILabel));
			uILabel.SetCurrentSelection();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Wrap(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(UILabel), typeof(string), typeof(LuaOut<string>)))
			{
				UILabel uILabel = (UILabel)ToLua.ToObject(L, 1);
				string text = ToLua.ToString(L, 2);
				string str = null;
				bool value = uILabel.Wrap(text, out str);
				LuaDLL.lua_pushboolean(L, value);
				LuaDLL.lua_pushstring(L, str);
				result = 2;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(UILabel), typeof(string), typeof(LuaOut<string>), typeof(int)))
			{
				UILabel uILabel2 = (UILabel)ToLua.ToObject(L, 1);
				string text2 = ToLua.ToString(L, 2);
				string str2 = null;
				int height = (int)LuaDLL.lua_tonumber(L, 4);
				bool value2 = uILabel2.Wrap(text2, out str2, height);
				LuaDLL.lua_pushboolean(L, value2);
				LuaDLL.lua_pushstring(L, str2);
				result = 2;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UILabel.Wrap");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UpdateNGUIText(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UILabel uILabel = (UILabel)ToLua.CheckObject(L, 1, typeof(UILabel));
			uILabel.UpdateNGUIText();
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
	private static int get_keepCrispWhenShrunk(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			UILabel.Crispness keepCrispWhenShrunk = uILabel.keepCrispWhenShrunk;
			ToLua.Push(L, keepCrispWhenShrunk);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index keepCrispWhenShrunk on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_customModifier(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			UILabel.ModifierFunc customModifier = uILabel.customModifier;
			ToLua.Push(L, customModifier);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index customModifier on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_finalFontSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			int finalFontSize = uILabel.finalFontSize;
			LuaDLL.lua_pushinteger(L, finalFontSize);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index finalFontSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isAnchoredHorizontally(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			bool isAnchoredHorizontally = uILabel.isAnchoredHorizontally;
			LuaDLL.lua_pushboolean(L, isAnchoredHorizontally);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isAnchoredHorizontally on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isAnchoredVertically(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			bool isAnchoredVertically = uILabel.isAnchoredVertically;
			LuaDLL.lua_pushboolean(L, isAnchoredVertically);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isAnchoredVertically on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_material(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			Material material = uILabel.material;
			ToLua.Push(L, material);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index material on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_bitmapFont(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			UIFont bitmapFont = uILabel.bitmapFont;
			ToLua.Push(L, bitmapFont);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index bitmapFont on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_trueTypeFont(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			Font trueTypeFont = uILabel.trueTypeFont;
			ToLua.Push(L, trueTypeFont);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index trueTypeFont on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ambigiousFont(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			UnityEngine.Object ambigiousFont = uILabel.ambigiousFont;
			ToLua.Push(L, ambigiousFont);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ambigiousFont on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_text(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			string text = uILabel.text;
			LuaDLL.lua_pushstring(L, text);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index text on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_defaultFontSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			int defaultFontSize = uILabel.defaultFontSize;
			LuaDLL.lua_pushinteger(L, defaultFontSize);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index defaultFontSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fontSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			int fontSize = uILabel.fontSize;
			LuaDLL.lua_pushinteger(L, fontSize);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fontSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fontStyle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			FontStyle fontStyle = uILabel.fontStyle;
			ToLua.Push(L, fontStyle);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fontStyle on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_alignment(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			NGUIText.Alignment alignment = uILabel.alignment;
			ToLua.Push(L, alignment);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index alignment on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_applyGradient(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			bool applyGradient = uILabel.applyGradient;
			LuaDLL.lua_pushboolean(L, applyGradient);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index applyGradient on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_gradientTop(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			Color gradientTop = uILabel.gradientTop;
			ToLua.Push(L, gradientTop);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index gradientTop on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_gradientBottom(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			Color gradientBottom = uILabel.gradientBottom;
			ToLua.Push(L, gradientBottom);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index gradientBottom on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_spacingX(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			int spacingX = uILabel.spacingX;
			LuaDLL.lua_pushinteger(L, spacingX);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index spacingX on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_spacingY(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			int spacingY = uILabel.spacingY;
			LuaDLL.lua_pushinteger(L, spacingY);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index spacingY on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_useFloatSpacing(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			bool useFloatSpacing = uILabel.useFloatSpacing;
			LuaDLL.lua_pushboolean(L, useFloatSpacing);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index useFloatSpacing on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_floatSpacingX(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			float floatSpacingX = uILabel.floatSpacingX;
			LuaDLL.lua_pushnumber(L, (double)floatSpacingX);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index floatSpacingX on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_floatSpacingY(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			float floatSpacingY = uILabel.floatSpacingY;
			LuaDLL.lua_pushnumber(L, (double)floatSpacingY);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index floatSpacingY on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_effectiveSpacingY(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			float effectiveSpacingY = uILabel.effectiveSpacingY;
			LuaDLL.lua_pushnumber(L, (double)effectiveSpacingY);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index effectiveSpacingY on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_effectiveSpacingX(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			float effectiveSpacingX = uILabel.effectiveSpacingX;
			LuaDLL.lua_pushnumber(L, (double)effectiveSpacingX);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index effectiveSpacingX on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_overflowEllipsis(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			bool overflowEllipsis = uILabel.overflowEllipsis;
			LuaDLL.lua_pushboolean(L, overflowEllipsis);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index overflowEllipsis on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_overflowWidth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			int overflowWidth = uILabel.overflowWidth;
			LuaDLL.lua_pushinteger(L, overflowWidth);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index overflowWidth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_supportEncoding(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			bool supportEncoding = uILabel.supportEncoding;
			LuaDLL.lua_pushboolean(L, supportEncoding);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index supportEncoding on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_symbolStyle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			NGUIText.SymbolStyle symbolStyle = uILabel.symbolStyle;
			ToLua.Push(L, symbolStyle);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index symbolStyle on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_overflowMethod(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			UILabel.Overflow overflowMethod = uILabel.overflowMethod;
			ToLua.Push(L, overflowMethod);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index overflowMethod on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_multiLine(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			bool multiLine = uILabel.multiLine;
			LuaDLL.lua_pushboolean(L, multiLine);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index multiLine on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_localCorners(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			Vector3[] localCorners = uILabel.localCorners;
			ToLua.Push(L, localCorners);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index localCorners on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_worldCorners(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			Vector3[] worldCorners = uILabel.worldCorners;
			ToLua.Push(L, worldCorners);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index worldCorners on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_drawingDimensions(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			Vector4 drawingDimensions = uILabel.drawingDimensions;
			ToLua.Push(L, drawingDimensions);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index drawingDimensions on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_maxLineCount(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			int maxLineCount = uILabel.maxLineCount;
			LuaDLL.lua_pushinteger(L, maxLineCount);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index maxLineCount on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_effectStyle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			UILabel.Effect effectStyle = uILabel.effectStyle;
			ToLua.Push(L, effectStyle);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index effectStyle on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_effectColor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			Color effectColor = uILabel.effectColor;
			ToLua.Push(L, effectColor);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index effectColor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_effectDistance(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			Vector2 effectDistance = uILabel.effectDistance;
			ToLua.Push(L, effectDistance);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index effectDistance on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_processedText(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			string processedText = uILabel.processedText;
			LuaDLL.lua_pushstring(L, processedText);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index processedText on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_printedSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			Vector2 printedSize = uILabel.printedSize;
			ToLua.Push(L, printedSize);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index printedSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_localSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			Vector2 localSize = uILabel.localSize;
			ToLua.Push(L, localSize);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index localSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_modifier(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			UILabel.Modifier modifier = uILabel.modifier;
			ToLua.Push(L, modifier);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index modifier on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_printedText(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			string printedText = uILabel.printedText;
			LuaDLL.lua_pushstring(L, printedText);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index printedText on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_keepCrispWhenShrunk(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			UILabel.Crispness keepCrispWhenShrunk = (UILabel.Crispness)LuaDLL.luaL_checknumber(L, 2);
			uILabel.keepCrispWhenShrunk = keepCrispWhenShrunk;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index keepCrispWhenShrunk on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_customModifier(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UILabel.ModifierFunc customModifier;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				customModifier = (UILabel.ModifierFunc)ToLua.CheckObject(L, 2, typeof(UILabel.ModifierFunc));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				customModifier = (DelegateFactory.CreateDelegate(typeof(UILabel.ModifierFunc), func) as UILabel.ModifierFunc);
			}
			uILabel.customModifier = customModifier;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index customModifier on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_material(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			Material material = (Material)ToLua.CheckUnityObject(L, 2, typeof(Material));
			uILabel.material = material;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index material on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_bitmapFont(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			UIFont bitmapFont = (UIFont)ToLua.CheckUnityObject(L, 2, typeof(UIFont));
			uILabel.bitmapFont = bitmapFont;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index bitmapFont on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_trueTypeFont(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			Font trueTypeFont = (Font)ToLua.CheckUnityObject(L, 2, typeof(Font));
			uILabel.trueTypeFont = trueTypeFont;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index trueTypeFont on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ambigiousFont(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			UnityEngine.Object ambigiousFont = ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Object));
			uILabel.ambigiousFont = ambigiousFont;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ambigiousFont on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_text(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			string text = ToLua.CheckString(L, 2);
			uILabel.text = text;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index text on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fontSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			int fontSize = (int)LuaDLL.luaL_checknumber(L, 2);
			uILabel.fontSize = fontSize;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fontSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fontStyle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			FontStyle fontStyle = (FontStyle)((int)ToLua.CheckObject(L, 2, typeof(FontStyle)));
			uILabel.fontStyle = fontStyle;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fontStyle on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_alignment(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			NGUIText.Alignment alignment = (NGUIText.Alignment)LuaDLL.luaL_checknumber(L, 2);
			uILabel.alignment = alignment;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index alignment on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_applyGradient(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			bool applyGradient = LuaDLL.luaL_checkboolean(L, 2);
			uILabel.applyGradient = applyGradient;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index applyGradient on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_gradientTop(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			Color gradientTop = ToLua.ToColor(L, 2);
			uILabel.gradientTop = gradientTop;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index gradientTop on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_gradientBottom(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			Color gradientBottom = ToLua.ToColor(L, 2);
			uILabel.gradientBottom = gradientBottom;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index gradientBottom on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_spacingX(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			int spacingX = (int)LuaDLL.luaL_checknumber(L, 2);
			uILabel.spacingX = spacingX;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index spacingX on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_spacingY(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			int spacingY = (int)LuaDLL.luaL_checknumber(L, 2);
			uILabel.spacingY = spacingY;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index spacingY on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_useFloatSpacing(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			bool useFloatSpacing = LuaDLL.luaL_checkboolean(L, 2);
			uILabel.useFloatSpacing = useFloatSpacing;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index useFloatSpacing on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_floatSpacingX(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			float floatSpacingX = (float)LuaDLL.luaL_checknumber(L, 2);
			uILabel.floatSpacingX = floatSpacingX;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index floatSpacingX on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_floatSpacingY(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			float floatSpacingY = (float)LuaDLL.luaL_checknumber(L, 2);
			uILabel.floatSpacingY = floatSpacingY;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index floatSpacingY on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_overflowEllipsis(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			bool overflowEllipsis = LuaDLL.luaL_checkboolean(L, 2);
			uILabel.overflowEllipsis = overflowEllipsis;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index overflowEllipsis on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_overflowWidth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			int overflowWidth = (int)LuaDLL.luaL_checknumber(L, 2);
			uILabel.overflowWidth = overflowWidth;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index overflowWidth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_supportEncoding(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			bool supportEncoding = LuaDLL.luaL_checkboolean(L, 2);
			uILabel.supportEncoding = supportEncoding;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index supportEncoding on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_symbolStyle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			NGUIText.SymbolStyle symbolStyle = (NGUIText.SymbolStyle)LuaDLL.luaL_checknumber(L, 2);
			uILabel.symbolStyle = symbolStyle;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index symbolStyle on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_overflowMethod(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			UILabel.Overflow overflowMethod = (UILabel.Overflow)LuaDLL.luaL_checknumber(L, 2);
			uILabel.overflowMethod = overflowMethod;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index overflowMethod on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_multiLine(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			bool multiLine = LuaDLL.luaL_checkboolean(L, 2);
			uILabel.multiLine = multiLine;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index multiLine on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_maxLineCount(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			int maxLineCount = (int)LuaDLL.luaL_checknumber(L, 2);
			uILabel.maxLineCount = maxLineCount;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index maxLineCount on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_effectStyle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			UILabel.Effect effectStyle = (UILabel.Effect)LuaDLL.luaL_checknumber(L, 2);
			uILabel.effectStyle = effectStyle;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index effectStyle on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_effectColor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			Color effectColor = ToLua.ToColor(L, 2);
			uILabel.effectColor = effectColor;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index effectColor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_effectDistance(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			Vector2 effectDistance = ToLua.ToVector2(L, 2);
			uILabel.effectDistance = effectDistance;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index effectDistance on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_modifier(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UILabel uILabel = (UILabel)obj;
			UILabel.Modifier modifier = (UILabel.Modifier)LuaDLL.luaL_checknumber(L, 2);
			uILabel.modifier = modifier;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index modifier on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UILabel_ModifierFunc(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UILabel.ModifierFunc), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UILabel.ModifierFunc), func, self);
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
