using System;

namespace XQ.Framework.Network.Skynet
{
	public class SprotoStreamEx
	{
		public static class TestSite
		{
			public static void TestAll()
			{
				SprotoStreamEx.TestSite.TestWrite();
				SprotoStreamEx.TestSite.TestWriteBuffer();
				SprotoStreamEx.TestSite.TestReadWrite();
				SprotoStreamEx.TestSite.TestMultipleReadWrite();
			}

			public static void TestWrite()
			{
				SprotoStreamEx sprotoStreamEx = new SprotoStreamEx(256);
				byte b = 128;
				sprotoStreamEx.WriteMessageSize((int)b);
				for (int i = 0; i < (int)(b - 1); i++)
				{
					sprotoStreamEx.WriteByte((byte)i);
				}
				sprotoStreamEx.WriteByte(b - 1);
			}

			public static void TestWriteBuffer()
			{
				SprotoStreamEx sprotoStreamEx = new SprotoStreamEx(200);
				byte b = 128;
				sprotoStreamEx.WriteMessageSize((int)b);
				byte[] array = new byte[(int)(b - 1)];
				for (int i = 0; i < array.Length - 1; i++)
				{
					array[i] = (byte)i;
				}
				sprotoStreamEx.Write(array, 0, array.Length);
				sprotoStreamEx.WriteByte(b - 1);
				bool flag = sprotoStreamEx.Write(array, 0, array.Length);
			}

			public static void TestReadWrite()
			{
				SprotoStreamEx sprotoStreamEx = new SprotoStreamEx(200);
				byte b = 128;
				sprotoStreamEx.WriteMessageSize((int)b);
				byte[] array = new byte[(int)b];
				for (int i = 0; i < array.Length - 1; i++)
				{
					array[i] = (byte)i;
				}
				sprotoStreamEx.Write(array, 0, array.Length);
				byte[] data = new byte[(int)b];
				int num = 0;
				bool flag = sprotoStreamEx.ReadMessage(data, 0, out num);
				for (int j = 0; j < array.Length; j++)
				{
				}
			}

			public static void TestMultipleReadWrite()
			{
				SprotoStreamEx sprotoStreamEx = new SprotoStreamEx(512);
				SprotoStreamEx.TestSite.WriteStream(sprotoStreamEx, 128);
				SprotoStreamEx.TestSite.WriteStream(sprotoStreamEx, 64);
				SprotoStreamEx.TestSite.WriteStream(sprotoStreamEx, 63);
				SprotoStreamEx.TestSite.WriteStream(sprotoStreamEx, 62);
				SprotoStreamEx.TestSite.WriteStream(sprotoStreamEx, 61);
				SprotoStreamEx.TestSite.WriteStream(sprotoStreamEx, 60);
				int num = 450;
				byte[] array = new byte[512];
				int num2 = 0;
				int num3 = 128;
				bool flag = sprotoStreamEx.ReadMessage(array, 0, out num2);
				SprotoStreamEx.TestSite.AssertByteArrayValue(array, num3);
				num -= num3 + 2;
				num3 = 64;
				flag = sprotoStreamEx.ReadMessage(array, 0, out num2);
				SprotoStreamEx.TestSite.AssertByteArrayValue(array, num3);
				num -= num3 + 2;
				num3 = 63;
				flag = sprotoStreamEx.ReadMessage(array, 0, out num2);
				SprotoStreamEx.TestSite.AssertByteArrayValue(array, num3);
				num -= num3 + 2;
				num3 = 62;
				flag = sprotoStreamEx.ReadMessage(array, 0, out num2);
				SprotoStreamEx.TestSite.AssertByteArrayValue(array, num3);
				num -= num3 + 2;
				num3 = 61;
				flag = sprotoStreamEx.ReadMessage(array, 0, out num2);
				SprotoStreamEx.TestSite.AssertByteArrayValue(array, num3);
				num -= num3 + 2;
				num3 = 60;
				flag = sprotoStreamEx.ReadMessage(array, 0, out num2);
				SprotoStreamEx.TestSite.AssertByteArrayValue(array, num3);
				num -= num3 + 2;
			}

			private static void WriteStream(SprotoStreamEx stream, ushort buffSize)
			{
				byte[] array = new byte[(int)buffSize];
				for (int i = 0; i < (int)buffSize; i++)
				{
					array[i] = (byte)i;
				}
				stream.WriteMessageSize((int)buffSize);
				stream.Write(array, 0, (int)buffSize);
			}

			private static void AssertByteArray(byte[] buff1, byte[] buff2)
			{
				for (int i = 0; i < buff1.Length; i++)
				{
				}
			}

			private static void AssertByteArrayValue(byte[] buff, int size)
			{
				for (int i = 0; i < size; i++)
				{
				}
			}
		}

		private int _head;

		private int _tail;

		private int _msgSize;

		private byte[] _buffer;

		private int _capacity;

		public int MessageSize
		{
			get
			{
				this.CheckMessageSize();
				return this._msgSize;
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
				this.CheckMessageSize();
				return this._tail - this._head >= this._msgSize + 2;
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
				if (i < 0 || i >= this._msgSize)
				{
					throw new Exception("invalid idx:" + i + "@get");
				}
				return this._buffer[i];
			}
			set
			{
				if (i < 0 || i >= this._msgSize)
				{
					throw new Exception("invalid idx:" + i + "@set");
				}
				this._buffer[i] = value;
			}
		}

		public SprotoStreamEx(int capacity = 128)
		{
			this._head = 0;
			this._tail = 0;
			this._msgSize = -1;
			this._capacity = capacity;
			this._buffer = new byte[capacity];
		}

		public void Reset()
		{
			this._head = 0;
			this._tail = 0;
			this._msgSize = -1;
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
				return true;
			}
			return false;
		}

		public bool WriteMessageSize(int size)
		{
			if (this.CheckFreeSize(2))
			{
				this._buffer[this._tail++] = (byte)(size >> 8);
				this._buffer[this._tail++] = (byte)size;
				return true;
			}
			return false;
		}

		public bool Write(byte[] data, int offset, int count)
		{
			if (data != null && offset >= 0 && data.Length >= count && this.CheckFreeSize(count))
			{
				Array.Copy(data, offset, this._buffer, this._tail, count);
				this._tail += count;
				return true;
			}
			return false;
		}

		public bool ReadMessage(byte[] data, int offset, out int count)
		{
			count = -1;
			if (data != null && offset >= 0 && data.Length >= count && this.IsMessageAvailable)
			{
				this._head += 2;
				count = this._msgSize;
				Array.Copy(this._buffer, this._head, data, offset, this._msgSize);
				this._head += count;
				this._msgSize = -1;
				this.TryMoveForward();
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

		private void CheckMessageSize()
		{
			if (this._msgSize < 0 && this._tail - this._head >= 2)
			{
				this._msgSize = ((int)this._buffer[this._head] << 8) + (int)this._buffer[this._head + 1];
			}
		}

		private void TryMoveForward()
		{
			if (this._head == this._tail)
			{
				this.Reset();
			}
			else if (this._msgSize < 0 && this._tail - this._head == 1)
			{
				this._buffer[0] = this._buffer[this._head];
				this._head = 0;
				this._tail = 1;
			}
			else if (!this.CheckFreeSize(this.MessageSize + 2))
			{
				int num = this._tail - this._head;
				int i = 0;
				int num2 = this._head;
				while (i < num)
				{
					this._buffer[i] = this._buffer[num2];
					i++;
					num2++;
				}
				this._head = 0;
				this._tail -= num;
			}
		}
	}
}
