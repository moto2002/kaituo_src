using System;
using System.IO;

namespace Sproto
{
	public class SprotoPack
	{
		private MemoryStream buffer;

		private byte[] tmp;

		public SprotoPack()
		{
			this.buffer = new MemoryStream();
			this.tmp = new byte[8];
		}

		private void write_ff(byte[] src, int offset, long pos, int n)
		{
			int num = n + 7 & -8;
			long position = this.buffer.Position;
			this.buffer.Seek(pos, SeekOrigin.Begin);
			this.buffer.WriteByte(255);
			this.buffer.WriteByte((byte)(num / 8 - 1));
			this.buffer.Write(src, offset, n);
			for (int i = 0; i < num - n; i++)
			{
				this.buffer.WriteByte(0);
			}
			this.buffer.Seek(position, SeekOrigin.Begin);
		}

		private int pack_seg(byte[] src, long offset, int ff_n)
		{
			byte b = 0;
			int num = 0;
			long position = this.buffer.Position;
			this.buffer.Seek(1L, SeekOrigin.Current);
			for (int i = 0; i < 8; i++)
			{
				if (src[(int)(checked((IntPtr)(unchecked(offset + (long)i))))] != 0)
				{
					num++;
					b |= (byte)(1 << i);
					this.buffer.WriteByte(src[(int)(checked((IntPtr)(unchecked(offset + (long)i))))]);
				}
			}
			if ((num == 7 || num == 6) && ff_n > 0)
			{
				num = 8;
			}
			if (num != 8)
			{
				this.buffer.Seek(position, SeekOrigin.Begin);
				this.buffer.WriteByte(b);
				this.buffer.Seek(position, SeekOrigin.Begin);
				return num + 1;
			}
			if (ff_n > 0)
			{
				this.buffer.Seek(position, SeekOrigin.Begin);
				return 8;
			}
			this.buffer.Seek(position, SeekOrigin.Begin);
			return 10;
		}

		public byte[] pack(byte[] data, int len = 0)
		{
			this.clear();
			int num = (len != 0) ? len : data.Length;
			byte[] array = null;
			int num2 = 0;
			long pos = 0L;
			int num3 = 0;
			byte[] array2 = data;
			for (int i = 0; i < num; i += 8)
			{
				int num4 = i;
				int num5 = i + 8 - num;
				if (num5 > 0)
				{
					for (int j = 0; j < 8 - num5; j++)
					{
						this.tmp[j] = array2[i + j];
					}
					for (int k = 0; k < num5; k++)
					{
						this.tmp[7 - k] = 0;
					}
					array2 = this.tmp;
					num4 = 0;
				}
				int num6 = this.pack_seg(array2, (long)num4, num3);
				if (num6 == 10)
				{
					array = array2;
					num2 = num4;
					pos = this.buffer.Position;
					num3 = 1;
				}
				else if (num6 == 8 && num3 > 0)
				{
					num3++;
					if (num3 == 256)
					{
						this.write_ff(array, num2, pos, 2048);
						num3 = 0;
					}
				}
				else if (num3 > 0)
				{
					this.write_ff(array, num2, pos, num3 * 8);
					num3 = 0;
				}
				this.buffer.Seek((long)num6, SeekOrigin.Current);
			}
			if (num3 == 1)
			{
				this.write_ff(array, num2, pos, 8);
			}
			else if (num3 > 1)
			{
				int num7 = (array != data) ? array.Length : num;
				this.write_ff(array, num2, pos, num7 - num2);
			}
			long num8 = (long)((num + 2047) / 2048 * 2 + num + 2);
			if (num8 < this.buffer.Position)
			{
				SprotoTypeSize.error("packing error, return size=" + this.buffer.Position);
			}
			byte[] array3 = new byte[this.buffer.Position];
			this.buffer.Seek(0L, SeekOrigin.Begin);
			this.buffer.Read(array3, 0, array3.Length);
			return array3;
		}

		public byte[] unpack(byte[] data, int len = 0)
		{
			this.clear();
			len = ((len != 0) ? len : data.Length);
			int i = len;
			while (i > 0)
			{
				byte b = data[len - i];
				i--;
				if (b == 255)
				{
					if (i < 0)
					{
						SprotoTypeSize.error("invalid unpack stream.");
					}
					int num = (int)((data[len - i] + 1) * 8);
					if (i < num + 1)
					{
						SprotoTypeSize.error("invalid unpack stream.");
					}
					this.buffer.Write(data, len - i + 1, num);
					i -= num + 1;
				}
				else
				{
					for (int j = 0; j < 8; j++)
					{
						int num2 = b >> j & 1;
						if (num2 == 1)
						{
							if (i < 0)
							{
								SprotoTypeSize.error("invalid unpack stream.");
							}
							this.buffer.WriteByte(data[len - i]);
							i--;
						}
						else
						{
							this.buffer.WriteByte(0);
						}
					}
				}
			}
			byte[] array = new byte[this.buffer.Position];
			this.buffer.Seek(0L, SeekOrigin.Begin);
			this.buffer.Read(array, 0, array.Length);
			return array;
		}

		private void clear()
		{
			this.buffer.Seek(0L, SeekOrigin.Begin);
			for (int i = 0; i < this.tmp.Length; i++)
			{
				this.tmp[i] = 0;
			}
		}
	}
}
