using LuaInterface;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using XQ.Framework.Threading;

namespace XQ.Framework.Network.Skynet
{
	public class SocketChannel : ISocketChannel
	{
		public static int CONNECT_TIMEOUT_MS = 3000;

		public static int CLOSE_TIMEOUT_MS = 3000;

		public static int SEND_BUFFER_SIZE = 131072;

		public static int RECV_BUFFER_SIZE = 131072;

		private static int MAX_PACK_LEN = 65535;

		private string _id;

		private string _host;

		private int _port;

		private Socket _socket;

		private ConcurrentQueue<LuaByteBuffer> _commandQueue;

		private ConcurrentQueue<LuaByteBuffer> _recvMessageQueue;

		private LuaByteBuffer _nullBuffer;

		private SprotoStreamEx _recvStream;

		private SprotoStreamEx _sendStream;

		private AsyncCallback _connectCallback;

		private AsyncCallback _receiveCallback;

		public SocketChannel(string id)
		{
			if (string.IsNullOrEmpty(id))
			{
				throw new Exception("id cannot be null or empty");
			}
			this._id = id;
			this._commandQueue = new ConcurrentQueue<LuaByteBuffer>();
			this._recvMessageQueue = new ConcurrentQueue<LuaByteBuffer>();
			this._nullBuffer = new LuaByteBuffer(new byte[0]);
			this._recvStream = new SprotoStreamEx(SocketChannel.RECV_BUFFER_SIZE);
			this._sendStream = new SprotoStreamEx(SocketChannel.SEND_BUFFER_SIZE);
			this._connectCallback = new AsyncCallback(this.OnConnected);
			this._receiveCallback = new AsyncCallback(this.OnReceive);
		}

		public LuaByteBuffer TryReceiveCommand()
		{
			LuaByteBuffer result = null;
			if (!this._commandQueue.TryDequeue(out result))
			{
				result = this._nullBuffer;
			}
			return result;
		}

		public LuaByteBuffer Echo(LuaByteBuffer message)
		{
			return message;
		}

		public bool Send(LuaByteBuffer message)
		{
			bool result = false;
			if (this.IsConnected() && message != null && message.buffer.Length > 0)
			{
				SprotoStreamEx sendStream = this._sendStream;
				lock (sendStream)
				{
					byte[] buffer = message.buffer;
					int num = buffer.Length;
					if (num > SocketChannel.MAX_PACK_LEN)
					{
						this.SendCommand("SOCKET_TOO_MANY_DATA");
					}
					else
					{
						this._sendStream.Reset();
						this._sendStream.WriteMessageSize(num);
						this._sendStream.Write(buffer, 0, num);
						try
						{
							this._socket.Send(this._sendStream.Buffer, this._sendStream.AvailableSize, SocketFlags.None);
							result = true;
						}
						catch (Exception exception)
						{
							Debug.LogException(exception);
						}
					}
				}
			}
			return result;
		}

		public LuaByteBuffer TryReceive()
		{
			LuaByteBuffer result = null;
			if (!this._recvMessageQueue.TryDequeue(out result))
			{
				result = this._nullBuffer;
			}
			return result;
		}

		public int TotalReceived()
		{
			return this._recvMessageQueue.Count;
		}

		public bool CheckConnected()
		{
			bool result;
			try
			{
				if (this._socket != null)
				{
					bool flag = this._socket.Poll(1000, SelectMode.SelectRead) && this._socket.Available == 0;
					if (flag)
					{
						this._socket.Close();
						this._socket = null;
					}
					result = (!flag && this._socket.Connected);
				}
				else
				{
					result = false;
				}
			}
			catch (SocketException)
			{
				if (this._socket != null)
				{
					this._socket.Close();
					this._socket = null;
				}
				result = false;
			}
			return result;
		}

		public bool IsConnected()
		{
			return this._socket != null && this._socket.Connected;
		}

		public void Connect(string host, int port)
		{
			try
			{
				this.Disconnect();
				this._socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				this._socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
				this._host = host;
				this._port = port;
				this._socket.BeginConnect(host, port, this._connectCallback, this._socket);
			}
			catch (Exception ex)
			{
				Debug.Log(ex.ToString());
			}
		}

		private void OnConnected(IAsyncResult ar)
		{
			try
			{
				this._socket.EndConnect(ar);
				this.SendCommand("SOCKET_CONNECTED");
				IPEndPoint iPEndPoint = (IPEndPoint)this._socket.RemoteEndPoint;
				Debug.Log(string.Format("SocketDriver connected to {0}:{1}", iPEndPoint.Address, iPEndPoint.Port));
				this._recvStream.Reset();
				this._socket.BeginReceive(this._recvStream.Buffer, 0, this._recvStream.Buffer.Length, SocketFlags.None, this._receiveCallback, null);
			}
			catch (Exception exception)
			{
				this.Disconnect();
				Debug.LogException(exception);
			}
		}

		public void Disconnect()
		{
			try
			{
				if (this._socket != null)
				{
					this._socket.Shutdown(SocketShutdown.Both);
					this._socket.Close();
				}
			}
			catch
			{
			}
			this.SendCommand("SOCKET_DISCONNECTED");
			Debug.Log("SocketDriver notify disconnected");
		}

		private void OnReceive(IAsyncResult ar)
		{
			if (!this.IsConnected())
			{
				return;
			}
			if (ar != null)
			{
				try
				{
					int size = this._socket.EndReceive(ar);
					this._recvStream.AddMessageSize(size);
				}
				catch (Exception ex)
				{
					this.Disconnect();
					Debug.LogWarning(ex.ToString());
				}
			}
			while (this._recvStream.IsMessageAvailable)
			{
				int messageSize = this._recvStream.MessageSize;
				byte[] array = new byte[messageSize];
				this._recvStream.ReadMessage(array, 0, out messageSize);
				this._recvMessageQueue.Enqueue(new LuaByteBuffer(array));
			}
			try
			{
				this._socket.BeginReceive(this._recvStream.Buffer, this._recvStream.Tail, this._recvStream.FreeSize, SocketFlags.None, this._receiveCallback, this._socket);
			}
			catch (Exception ex2)
			{
				this.Disconnect();
				Debug.LogWarning(ex2.ToString());
			}
		}

		private void SendCommand(string command)
		{
			if (!string.IsNullOrEmpty(command))
			{
				byte[] bytes = Encoding.UTF8.GetBytes(command);
				this._commandQueue.Enqueue(new LuaByteBuffer(bytes));
			}
		}
	}
}
