using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace XQ.Framework.Network.Skynet
{
	public static class SocketDriver
	{
		internal static SocketDriverMono SDMono;

		private static Dictionary<string, ISocketChannel> _channelDict = new Dictionary<string, ISocketChannel>(8);

		public static void Start(LuaTable args)
		{
			Debug.Log("SocketDriver.Starting ...");
			Application.runInBackground = true;
			GameObject gameObject = new GameObject();
			SocketDriver.SDMono = gameObject.AddComponent<SocketDriverMono>();
			SocketDriver.SDMono.name = "SocketDriverMono";
			SocketDriver.SDMono.hideFlags = HideFlags.HideInHierarchy;
			Debug.Log("SocketDriver.Started");
		}

		public static void Stop()
		{
			Debug.Log("SocketDriver.Stopping ...");
			SocketDriver.DisconnectAll();
			Debug.Log("SocketDriver.Stopped");
		}

		public static SocketChannel NewChannel(string id)
		{
			ISocketChannel socketChannel = null;
			SocketChannel socketChannel2 = null;
			if (!SocketDriver._channelDict.TryGetValue(id, out socketChannel))
			{
				socketChannel2 = new SocketChannel(id);
				SocketDriver._channelDict[id] = socketChannel2;
			}
			return socketChannel2;
		}

		public static SocketChannelL NewChannelL(string id)
		{
			ISocketChannel socketChannel = null;
			SocketChannelL socketChannelL = null;
			if (!SocketDriver._channelDict.TryGetValue(id, out socketChannel))
			{
				socketChannelL = new SocketChannelL(id);
				SocketDriver._channelDict[id] = socketChannelL;
			}
			return socketChannelL;
		}

		public static void DeleteChannel(string id)
		{
			ISocketChannel socketChannel = null;
			if (SocketDriver._channelDict.TryGetValue(id, out socketChannel))
			{
				socketChannel.Disconnect();
				SocketDriver._channelDict.Remove(id);
			}
		}

		private static void DisconnectAll()
		{
			foreach (ISocketChannel current in SocketDriver._channelDict.Values)
			{
				current.Disconnect();
			}
			SocketDriver._channelDict.Clear();
		}
	}
}
