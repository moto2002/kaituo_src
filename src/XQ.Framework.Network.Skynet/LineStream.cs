using System;
using System.Collections.Generic;
using System.Text;

namespace XQ.Framework.Network.Skynet
{
	public class LineStream
	{
		public static class TestSite
		{
			private static Random random = new Random();

			public static void TestAll()
			{
				LineStream.TestSite.TestReadWrite();
			}

			public static void TestReadWrite()
			{
				byte[] bytes = Encoding.Default.GetBytes("\r\n");
				LineStream stream = new LineStream(bytes, 8192, 65536);
				List<string> list = new List<string>();
				for (int i = 0; i < 128; i++)
				{
					string item = LineStream.TestSite.RandomString(1024);
					list.Add(item);
				}
				List<string> list2 = new List<string>();
				byte[] bytes2 = new byte[8192];
				int count = 0;
				foreach (string current in list)
				{
					int num = LineStream.TestSite.WriteString(stream, current);
					string @string = Encoding.UTF8.GetString(bytes2, 0, count);
				}
			}

			private static int WriteString(LineStream stream, string message)
			{
				byte[] bytes = Encoding.UTF8.GetBytes(message);
				stream.WriteLine(bytes, 0, bytes.Length);
				return bytes.Length;
			}

			public static string RandomString(int length)
			{
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < length; i++)
				{
					stringBuilder.Append("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"[LineStream.TestSite.random.Next(0, "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".Length)]);
				}
				return stringBuilder.ToString();
			}
		}

		private int _head;

		private int _tail;

		private byte[] _sepBytes;

		private int _sepSearchIndex;

		private int _maxMsgSize;

		private int _msgSize;

		private bool _msgAvailable;

		private byte[] _buffer;

		private int _capacity;

		public int MessageSize
		{
			get
			{
				return (!this._msgAvailable) ? 0 : this._msgSize;
			}
		}

		public int AvailableSize
		{
			get
			{
				return this._tail - this._head;
			}
		}

		public int FreeSize
		{
			get
			{
				return this._capacity - this._tail;
			}
		}

		public bool IsMessageAvailable
		{
			get
			{
				return this._msgAvailable;
			}
		}

		public byte[] Buffer
		{
			get
			{
				return this._buffer;
			}
		}

		public int Head
		{
			get
			{
				return this._head;
			}
		}

		public int Tail
		{
			get
			{
				return this._tail;
			}
		}

		public byte this[int i]
		{
			get
			{
				if (i < 0 || i >= this._buffer.Length)
				{
					throw new Exception("invalid idx:" + i + "@get");
				}
				return this._buffer[i];
			}
			set
			{
				if (i < 0 || i >= this._buffer.Length)
				{
					throw new Exception("invalid idx:" + i + "@set");
				}
				this._buffer[i] = value;
			}
		}

		public LineStream(byte[] sep, int maxMessageSize = 8192, int capacity = 65536)
		{
			this._head = 0;
			this._tail = 0;
			this._maxMsgSize = maxMessageSize;
			this._msgSize = -1;
			this._msgAvailable = false;
			this._sepBytes = sep;
			this._capacity = capacity;
			this._buffer = new byte[capacity];
		}

		public void Reset()
		{
			this._head = 0;
			this._tail = 0;
			this._msgSize = -1;
			this._msgAvailable = false;
			this._sepSearchIndex = 0;
		}

		public bool WriteByte(byte v)
		{
			if (this.CheckFreeSize(1))
			{
				this._buffer[this._tail++] = v;
				return true;
			}
			return false;
		}

		public bool AddMessageSize(int size)
		{
			if (this.CheckFreeSize(size))
			{
				this._tail += size;
				this.CheckLine();
				return true;
			}
			return false;
		}

		public bool WriteLine(byte[] data, int offset, int count)
		{
			if (data != null && offset >= 0 && data.Length >= count && this.CheckFreeSize(count + this._sepBytes.Length))
			{
				Array.Copy(data, offset, this._buffer, this._tail, count);
				this._tail += count;
				Array.Copy(this._sepBytes, 0, this._buffer, this._tail, this._sepBytes.Length);
				this._tail += this._sepBytes.Length;
				this.CheckLine();
				return true;
			}
			return false;
		}

		public bool ReadLine(byte[] data, int offset, out int count)
		{
			count = -1;
			if (data != null && offset >= 0 && data.Length >= count && this._msgAvailable)
			{
				Array.Copy(this._buffer, this._head, data, offset, this._msgSize);
				count = this._msgSize;
				this._head += count + this._sepBytes.Length;
				this._sepSearchIndex = this._head;
				this.TryMoveForward();
				this.CheckLine();
				return true;
			}
			return false;
		}

		private bool CheckAvailableSize(int count)
		{
			return this._tail - this._head >= count;
		}

		private bool CheckFreeSize(int count)
		{
			return this._tail - this._head + count <= this._capacity;
		}

		private void TryMoveForward()
		{
			if (this._head == this._tail)
			{
				this.Reset();
			}
			else if (!this.CheckFreeSize(this._maxMsgSize + this._sepBytes.Length))
			{
				int num = this._tail - this._head;
				int num2 = 4;
				System.Buffer.BlockCopy(this._buffer, this._head * num2, this._buffer, 0, num * num2);
				this._head = 0;
				this._tail -= num;
				this._sepSearchIndex = 0;
			}
		}

		private bool CheckLine()
		{
			if (!this._msgAvailable)
			{
				int num = this.Search(this._buffer, this._sepSearchIndex, this._sepBytes);
				this._msgAvailable = (num >= 0);
				this._msgSize = num - this._head;
			}
			return this._msgAvailable;
		}

		private int Search(byte[] src, int srcIndex, byte[] pattern)
		{
			int num = src.Length - pattern.Length + 1;
			int num2 = srcIndex + num;
			for (int i = srcIndex; i < num2; i++)
			{
				if (src[i] == pattern[0])
				{
					int num3 = pattern.Length - 1;
					while (num3 >= 1 && src[i + num3] == pattern[num3])
					{
						num3--;
					}
					if (num3 == 0)
					{
						return i;
					}
				}
			}
			return -1;
		}
	}
}
