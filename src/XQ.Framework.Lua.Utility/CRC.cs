using System;

namespace XQ.Framework.Lua.Utility
{
	public class CRC
	{
		public static readonly uint[] Table;

		private uint _value = 4294967295u;

		static CRC()
		{
			CRC.Table = new uint[256];
			for (uint num = 0u; num < 256u; num += 1u)
			{
				uint num2 = num;
				for (int i = 0; i < 8; i++)
				{
					if ((num2 & 1u) != 0u)
					{
						num2 = (num2 >> 1 ^ 3988292384u);
					}
					else
					{
						num2 >>= 1;
					}
				}
				CRC.Table[(int)((UIntPtr)num)] = num2;
			}
		}

		private void UpdateByte(byte b)
		{
			this._value = (CRC.Table[(int)((byte)this._value ^ b)] ^ this._value >> 8);
		}

		internal void Update(byte[] data, uint offset, int size)
		{
			uint num = 0u;
			while ((ulong)num < (ulong)((long)size))
			{
				this._value = (CRC.Table[(int)((byte)this._value ^ data[(int)((UIntPtr)(offset + num))])] ^ this._value >> 8);
				num += 1u;
			}
		}

		internal uint GetDigest()
		{
			return this._value ^ 4294967295u;
		}
	}
}
