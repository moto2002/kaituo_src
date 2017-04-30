using System;
using System.IO;

namespace Sproto
{
	public class SprotoStream
	{
		private int size;

		private int pos;

		private byte[] buffer;

		public int Position
		{
			get
			{
				return this.pos;
			}
		}

		public byte[] Buffer
		{
			get
			{
				return this.buffer;
			}
		}

		public byte this[int i]
		{
			get
			{
				if (i < 0 || i >= this.size)
				{
					throw new Exception("invalid idx:" + i + "@get");
				}
				return this.buffer[i];
			}
			set
			{
				if (i < 0 || i >= this.size)
				{
					throw new Exception("invalid idx:" + i + "@set");
				}
				this.buffer[i] = value;
			}
		}

		public SprotoStream() : this(128)
		{
		}

		public SprotoStream(int capacity)
		{
			this.size = capacity;
			this.pos = 0;
			this.buffer = new byte[this.size];
		}

		public void WriteByte(byte v)
		{
			this.Expand(1);
			this.buffer[this.pos++] = v;
		}

		public void Write(byte[] data, int offset, int count)
		{
			this.Expand(count);
			for (int i = 0; i < count; i++)
			{
				this.buffer[this.pos++] = data[offset + i];
			}
		}

		public int Seek(int offset, SeekOrigin loc)
		{
			switch (loc)
			{
			case SeekOrigin.Begin:
				this.pos = offset;
				break;
			case SeekOrigin.Current:
				this.pos += offset;
				break;
			case SeekOrigin.End:
				this.pos = this.size + offset;
				break;
			}
			this.Expand(0);
			return this.pos;
		}

		public void Read(byte[] buffer, int offset, int count)
		{
			for (int i = 0; i < count; i++)
			{
				buffer[offset + i] = this.buffer[this.pos++];
			}
		}

		public void MoveUp(int position, int up_count)
		{
			if (up_count <= 0)
			{
				return;
			}
			long num = (long)(this.pos - position);
			int num2 = 0;
			while ((long)num2 < num)
			{
				this.buffer[position - up_count + num2] = this.buffer[position + num2];
				num2++;
			}
			this.pos -= up_count;
		}

		private void Expand(int sz = 0)
		{
			if (this.size - this.pos < sz)
			{
				long num = (long)this.size;
				while (this.size - this.pos < sz)
				{
					this.size *= 2;
				}
				if (this.size >= SprotoTypeSize.encode_max_size)
				{
					SprotoTypeSize.error("object is too large (>" + SprotoTypeSize.encode_max_size + ")");
				}
				byte[] array = new byte[this.size];
				for (long num2 = 0L; num2 < num; num2 += 1L)
				{
					checked
					{
						array[(int)((IntPtr)num2)] = this.buffer[(int)((IntPtr)num2)];
					}
				}
				this.buffer = array;
			}
		}
	}
}
