using System;
using System.Text;

namespace XQ.Framework.Lua.Utility
{
	public static class CRCExt
	{
		private static byte[] bytebuffer = new byte[524288];

		public static bool HasEqual(this string data, uint digest)
		{
			return data.CRCHash(false, 1012) == digest;
		}

		public static uint CRCHash(this string value, bool confusion = false, int factor = 1012)
		{
			if (value.IsNullOrEmpty())
			{
				return 0u;
			}
			byte[] array = CRCExt.bytebuffer;
			int count = value.StringToBytes(array, 0);
			array = Encoding.Convert(Encoding.Unicode, Encoding.UTF8, array, 0, count);
			if (confusion)
			{
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = (byte)((int)array[i] ^ (factor & 255));
				}
			}
			CRC cRC = new CRC();
			cRC.Update(array, 0u, array.Length);
			return cRC.GetDigest();
		}

		public static uint CRCHash(this byte[] data, bool confusion = false, int factor = 1012)
		{
			if (confusion)
			{
				for (int i = 0; i < data.Length; i++)
				{
					data[i] = (byte)((int)data[i] ^ (factor & 255));
				}
			}
			CRC cRC = new CRC();
			cRC.Update(data, 0u, data.Length);
			return cRC.GetDigest();
		}
	}
}
