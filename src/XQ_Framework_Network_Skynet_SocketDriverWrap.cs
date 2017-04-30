using LuaInterface;
using System;
using XQ.Framework.Network.Skynet;

public class XQ_Framework_Network_Skynet_SocketDriverWrap
{
	public static void Register(LuaState L)
	{
		L.BeginStaticLibs("SocketDriver");
		L.RegFunction("Start", new LuaCSFunction(XQ_Framework_Network_Skynet_SocketDriverWrap.Start));
		L.RegFunction("Stop", new LuaCSFunction(XQ_Framework_Network_Skynet_SocketDriverWrap.Stop));
		L.RegFunction("NewChannel", new LuaCSFunction(XQ_Framework_Network_Skynet_SocketDriverWrap.NewChannel));
		L.RegFunction("NewChannelL", new LuaCSFunction(XQ_Framework_Network_Skynet_SocketDriverWrap.NewChannelL));
		L.RegFunction("DeleteChannel", new LuaCSFunction(XQ_Framework_Network_Skynet_SocketDriverWrap.DeleteChannel));
		L.EndStaticLibs();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Start(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			LuaTable args = ToLua.CheckLuaTable(L, 1);
			SocketDriver.Start(args);
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
			ToLua.CheckArgsCount(L, 0);
			SocketDriver.Stop();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int NewChannel(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string id = ToLua.CheckString(L, 1);
			SocketChannel o = SocketDriver.NewChannel(id);
			ToLua.PushObject(L, o);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int NewChannelL(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string id = ToLua.CheckString(L, 1);
			SocketChannelL o = SocketDriver.NewChannelL(id);
			ToLua.PushObject(L, o);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DeleteChannel(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string id = ToLua.CheckString(L, 1);
			SocketDriver.DeleteChannel(id);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
