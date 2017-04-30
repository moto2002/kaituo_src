using LuaInterface;
using System;
using XQ.Framework.Network.Skynet;

public class XQ_Framework_Network_Skynet_SocketChannelWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(SocketChannel), typeof(object), null);
		L.RegFunction("TryReceiveCommand", new LuaCSFunction(XQ_Framework_Network_Skynet_SocketChannelWrap.TryReceiveCommand));
		L.RegFunction("Echo", new LuaCSFunction(XQ_Framework_Network_Skynet_SocketChannelWrap.Echo));
		L.RegFunction("Send", new LuaCSFunction(XQ_Framework_Network_Skynet_SocketChannelWrap.Send));
		L.RegFunction("TryReceive", new LuaCSFunction(XQ_Framework_Network_Skynet_SocketChannelWrap.TryReceive));
		L.RegFunction("TotalReceived", new LuaCSFunction(XQ_Framework_Network_Skynet_SocketChannelWrap.TotalReceived));
		L.RegFunction("CheckConnected", new LuaCSFunction(XQ_Framework_Network_Skynet_SocketChannelWrap.CheckConnected));
		L.RegFunction("IsConnected", new LuaCSFunction(XQ_Framework_Network_Skynet_SocketChannelWrap.IsConnected));
		L.RegFunction("Connect", new LuaCSFunction(XQ_Framework_Network_Skynet_SocketChannelWrap.Connect));
		L.RegFunction("Disconnect", new LuaCSFunction(XQ_Framework_Network_Skynet_SocketChannelWrap.Disconnect));
		L.RegFunction("New", new LuaCSFunction(XQ_Framework_Network_Skynet_SocketChannelWrap._CreateXQ_Framework_Network_Skynet_SocketChannel));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("CONNECT_TIMEOUT_MS", new LuaCSFunction(XQ_Framework_Network_Skynet_SocketChannelWrap.get_CONNECT_TIMEOUT_MS), new LuaCSFunction(XQ_Framework_Network_Skynet_SocketChannelWrap.set_CONNECT_TIMEOUT_MS));
		L.RegVar("CLOSE_TIMEOUT_MS", new LuaCSFunction(XQ_Framework_Network_Skynet_SocketChannelWrap.get_CLOSE_TIMEOUT_MS), new LuaCSFunction(XQ_Framework_Network_Skynet_SocketChannelWrap.set_CLOSE_TIMEOUT_MS));
		L.RegVar("SEND_BUFFER_SIZE", new LuaCSFunction(XQ_Framework_Network_Skynet_SocketChannelWrap.get_SEND_BUFFER_SIZE), new LuaCSFunction(XQ_Framework_Network_Skynet_SocketChannelWrap.set_SEND_BUFFER_SIZE));
		L.RegVar("RECV_BUFFER_SIZE", new LuaCSFunction(XQ_Framework_Network_Skynet_SocketChannelWrap.get_RECV_BUFFER_SIZE), new LuaCSFunction(XQ_Framework_Network_Skynet_SocketChannelWrap.set_RECV_BUFFER_SIZE));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateXQ_Framework_Network_Skynet_SocketChannel(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1)
			{
				string id = ToLua.CheckString(L, 1);
				SocketChannel o = new SocketChannel(id);
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: XQ.Framework.Network.Skynet.SocketChannel.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TryReceiveCommand(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SocketChannel socketChannel = (SocketChannel)ToLua.CheckObject(L, 1, typeof(SocketChannel));
			LuaByteBuffer bb = socketChannel.TryReceiveCommand();
			ToLua.Push(L, bb);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Echo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SocketChannel socketChannel = (SocketChannel)ToLua.CheckObject(L, 1, typeof(SocketChannel));
			LuaByteBuffer message = new LuaByteBuffer(ToLua.CheckByteBuffer(L, 2));
			LuaByteBuffer bb = socketChannel.Echo(message);
			ToLua.Push(L, bb);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Send(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SocketChannel socketChannel = (SocketChannel)ToLua.CheckObject(L, 1, typeof(SocketChannel));
			LuaByteBuffer message = new LuaByteBuffer(ToLua.CheckByteBuffer(L, 2));
			bool value = socketChannel.Send(message);
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
	private static int TryReceive(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SocketChannel socketChannel = (SocketChannel)ToLua.CheckObject(L, 1, typeof(SocketChannel));
			LuaByteBuffer bb = socketChannel.TryReceive();
			ToLua.Push(L, bb);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TotalReceived(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SocketChannel socketChannel = (SocketChannel)ToLua.CheckObject(L, 1, typeof(SocketChannel));
			int n = socketChannel.TotalReceived();
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
	private static int CheckConnected(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SocketChannel socketChannel = (SocketChannel)ToLua.CheckObject(L, 1, typeof(SocketChannel));
			bool value = socketChannel.CheckConnected();
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
	private static int IsConnected(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SocketChannel socketChannel = (SocketChannel)ToLua.CheckObject(L, 1, typeof(SocketChannel));
			bool value = socketChannel.IsConnected();
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
	private static int Connect(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			SocketChannel socketChannel = (SocketChannel)ToLua.CheckObject(L, 1, typeof(SocketChannel));
			string host = ToLua.CheckString(L, 2);
			int port = (int)LuaDLL.luaL_checknumber(L, 3);
			socketChannel.Connect(host, port);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Disconnect(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SocketChannel socketChannel = (SocketChannel)ToLua.CheckObject(L, 1, typeof(SocketChannel));
			socketChannel.Disconnect();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_CONNECT_TIMEOUT_MS(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, SocketChannel.CONNECT_TIMEOUT_MS);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_CLOSE_TIMEOUT_MS(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, SocketChannel.CLOSE_TIMEOUT_MS);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_SEND_BUFFER_SIZE(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, SocketChannel.SEND_BUFFER_SIZE);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_RECV_BUFFER_SIZE(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, SocketChannel.RECV_BUFFER_SIZE);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_CONNECT_TIMEOUT_MS(IntPtr L)
	{
		int result;
		try
		{
			int cONNECT_TIMEOUT_MS = (int)LuaDLL.luaL_checknumber(L, 2);
			SocketChannel.CONNECT_TIMEOUT_MS = cONNECT_TIMEOUT_MS;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_CLOSE_TIMEOUT_MS(IntPtr L)
	{
		int result;
		try
		{
			int cLOSE_TIMEOUT_MS = (int)LuaDLL.luaL_checknumber(L, 2);
			SocketChannel.CLOSE_TIMEOUT_MS = cLOSE_TIMEOUT_MS;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_SEND_BUFFER_SIZE(IntPtr L)
	{
		int result;
		try
		{
			int sEND_BUFFER_SIZE = (int)LuaDLL.luaL_checknumber(L, 2);
			SocketChannel.SEND_BUFFER_SIZE = sEND_BUFFER_SIZE;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_RECV_BUFFER_SIZE(IntPtr L)
	{
		int result;
		try
		{
			int rECV_BUFFER_SIZE = (int)LuaDLL.luaL_checknumber(L, 2);
			SocketChannel.RECV_BUFFER_SIZE = rECV_BUFFER_SIZE;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
