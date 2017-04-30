using Assets.Tools.Script.Debug.Console;
using LuaInterface;
using System;

public class DebugConsoleWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(DebugConsole), typeof(object), null);
		L.RegFunction("SetActive", new LuaCSFunction(DebugConsoleWrap.SetActive));
		L.RegFunction("AddTopString", new LuaCSFunction(DebugConsoleWrap.AddTopString));
		L.RegFunction("RemoveTopString", new LuaCSFunction(DebugConsoleWrap.RemoveTopString));
		L.RegFunction("AddButton", new LuaCSFunction(DebugConsoleWrap.AddButton));
		L.RegFunction("RemoveButton", new LuaCSFunction(DebugConsoleWrap.RemoveButton));
		L.RegFunction("LogStackTrace", new LuaCSFunction(DebugConsoleWrap.LogStackTrace));
		L.RegFunction("Log", new LuaCSFunction(DebugConsoleWrap.Log));
		L.RegFunction("LogToChannel", new LuaCSFunction(DebugConsoleWrap.LogToChannel));
		L.RegFunction("DebugBreak", new LuaCSFunction(DebugConsoleWrap.DebugBreak));
		L.RegFunction("Clear", new LuaCSFunction(DebugConsoleWrap.Clear));
		L.RegFunction("GetText", new LuaCSFunction(DebugConsoleWrap.GetText));
		L.RegFunction("New", new LuaCSFunction(DebugConsoleWrap._CreateDebugConsole));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("consoleImpl", new LuaCSFunction(DebugConsoleWrap.get_consoleImpl), new LuaCSFunction(DebugConsoleWrap.set_consoleImpl));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateDebugConsole(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				DebugConsole o = new DebugConsole();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: DebugConsole.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetActive(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			bool active = LuaDLL.luaL_checkboolean(L, 1);
			DebugConsole.SetActive(active);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddTopString(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			string stringName = ToLua.CheckString(L, 1);
			string content = ToLua.CheckString(L, 2);
			DebugConsole.AddTopString(stringName, content);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveTopString(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string stringName = ToLua.CheckString(L, 1);
			DebugConsole.RemoveTopString(stringName);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddButton(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			string btnName = ToLua.CheckString(L, 1);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action clickHandler;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				clickHandler = (Action)ToLua.CheckObject(L, 2, typeof(Action));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				clickHandler = (DelegateFactory.CreateDelegate(typeof(Action), func) as Action);
			}
			DebugConsole.AddButton(btnName, clickHandler);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveButton(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string btnName = ToLua.CheckString(L, 1);
			DebugConsole.RemoveButton(btnName);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LogStackTrace(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			DebugConsole.LogStackTrace();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Log(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(string)))
			{
				string msg = ToLua.ToString(L, 1);
				DebugConsole.Log(msg);
				result = 0;
			}
			else if (TypeChecker.CheckParamsType(L, typeof(object), 1, num))
			{
				object[] msgs = ToLua.ToParamsObject(L, 1, num);
				DebugConsole.Log(msgs);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: DebugConsole.Log");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LogToChannel(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(string)))
			{
				int channel = (int)LuaDLL.lua_tonumber(L, 1);
				string msg = ToLua.ToString(L, 2);
				DebugConsole.LogToChannel(channel, msg);
				result = 0;
			}
			else if (TypeChecker.CheckTypes(L, 1, typeof(int)) && TypeChecker.CheckParamsType(L, typeof(object), 2, num - 1))
			{
				int channel2 = (int)LuaDLL.lua_tonumber(L, 1);
				object[] msgs = ToLua.ToParamsObject(L, 2, num - 1);
				DebugConsole.LogToChannel(channel2, msgs);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: DebugConsole.LogToChannel");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DebugBreak(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			DebugConsole.DebugBreak();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Clear(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			int level = (int)LuaDLL.luaL_checknumber(L, 1);
			DebugConsole.Clear(level);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetText(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			string text = DebugConsole.GetText();
			LuaDLL.lua_pushstring(L, text);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_consoleImpl(IntPtr L)
	{
		int result;
		try
		{
			ToLua.PushObject(L, DebugConsole.consoleImpl);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_consoleImpl(IntPtr L)
	{
		int result;
		try
		{
			IDebugConsole consoleImpl = (IDebugConsole)ToLua.CheckObject(L, 2, typeof(IDebugConsole));
			DebugConsole.consoleImpl = consoleImpl;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
