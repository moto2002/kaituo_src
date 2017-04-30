using System;

namespace Sproto
{
	public class SprotoTypeReader
	{
		private byte[] buffer;

		private int begin;

		private int pos;

		private int size;

		public byte[] Buffer
		{
			get
			{
				return this.buffer;
			}
		}

		public int Position
		{
			get
			{
				return this.pos - this.begin;
			}
		}

		public int Offset
		{
			get
			{
				return this.pos;
			}
		}

		public int Length
		{
			get
			{
				return this.size - this.begin;
			}
		}

		public SprotoTypeReader(byte[] buffer, int offset, int size)
		{
			this.Init(buffer, offset, size);
		}

		public SprotoTypeReader()
		{
		}

		public void Init(byte[] buffer, int offset, int size)
		{
			this.begin = offset;
			this.pos = offset;
			this.buffer = buffer;
			this.size = offset + size;
			this.check();
		}

		private void check()
		{
			if (this.pos > this.size || this.begin > this.pos)
			{
				SprotoTypeSize.error("invalid pos.");
			}
		}

		public byte ReadByte()
		{
			this.check();
			return this.buffer[this.pos++];
		}

		public void Seek(int offset)
		{
			this.pos = this.begin + offset;
			this.check();
		}

		public void Read(byte[] data, int offset, int size)
		{
			int num = this.pos;
			this.pos += size;
			this.check();
			for (int i = num; i < this.pos; i++)
			{
				data[offset + i - num] = this.buffer[i];
			}
		}
	}
}
