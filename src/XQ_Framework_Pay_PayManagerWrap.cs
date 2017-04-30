using LuaInterface;
using System;
using XQ.Framework.Pay;

public class XQ_Framework_Pay_PayManagerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginStaticLibs("PayManager");
		L.RegFunction("Pay", new LuaCSFunction(XQ_Framework_Pay_PayManagerWrap.Pay));
		L.EndStaticLibs();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Pay(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			string orderId = ToLua.CheckString(L, 1);
			string orderInfo = ToLua.CheckString(L, 2);
			string payMethod = ToLua.CheckString(L, 3);
			LuaFunction luaFunc = ToLua.CheckLuaFunction(L, 4);
			PayManager.Pay(orderId, orderInfo, payMethod, luaFunc);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
