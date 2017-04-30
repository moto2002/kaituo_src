using LuaInterface;
using System;

public class SdkCallbackManagerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginStaticLibs("SdkCallbackManager");
		L.RegFunction("SetSDKCallBackLua", new LuaCSFunction(SdkCallbackManagerWrap.SetSDKCallBackLua));
		L.RegFunction("CallSdk", new LuaCSFunction(SdkCallbackManagerWrap.CallSdk));
		L.EndStaticLibs();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetSDKCallBackLua(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			string funcName = ToLua.CheckString(L, 1);
			LuaFunction function = ToLua.CheckLuaFunction(L, 2);
			SdkCallbackManager.SetSDKCallBackLua(funcName, function);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CallSdk(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			string method = ToLua.CheckString(L, 1);
			object[] args = ToLua.ToParamsObject(L, 2, num - 1);
			SdkCallbackManager.CallSdk(method, args);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
