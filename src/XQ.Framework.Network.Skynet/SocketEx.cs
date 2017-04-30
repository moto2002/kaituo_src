using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;

namespace XQ.Framework.Network.Skynet
{
	public class SocketEx : Socket
	{
		private const int TIMER_INTERVAL_MS = 1000;

		private const int SOCKET_POLL_TIMEOUT_US = 1000;

		private readonly Timer timer;

		private readonly List<SocketEventHandler> onCloseHandlers = new List<SocketEventHandler>();

		public event SocketEventHandler SocketClosed
		{
			add
			{
				this.onCloseHandlers.Add(value);
			}
			remove
			{
				this.onCloseHandlers.Remove(value);
			}
		}

		public bool CheckDisconnectEnabled
		{
			set
			{
				if (value)
				{
					this.timer.Change(0, 1000);
				}
				else
				{
					this.timer.Change(TimeSpan.MinValue, TimeSpan.MaxValue);
				}
			}
		}

		public new bool Connected
		{
			get
			{
				bool flag = base.Poll(1000, SelectMode.SelectRead);
				bool flag2 = base.Available == 0;
				return !(flag & flag2);
			}
		}

		public SocketEx(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType) : base(addressFamily, socketType, protocolType)
		{
			this.timer = new Timer(new TimerCallback(this.TimerTick), null, TimeSpan.MinValue, TimeSpan.MaxValue);
		}

		public SocketEx(SocketInformation socketInformation) : base(socketInformation)
		{
			this.timer = new Timer(new TimerCallback(this.TimerTick), null, TimeSpan.MinValue, TimeSpan.MaxValue);
		}

		private void TimerTick(object state)
		{
			if (!this.Connected)
			{
				foreach (SocketEventHandler current in this.onCloseHandlers)
				{
					current(this);
				}
				this.CheckDisconnectEnabled = false;
			}
		}
	}
}
