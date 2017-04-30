using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

public static class StaticExtebsion
{
	public unsafe static byte[] StringToBytes(this string source)
	{
		if (source.IsNullOrEmpty())
		{
			return null;
		}
		byte[] array = new byte[source.Length << 1];
		fixed (string text = source)
		{
			fixed (char* ptr = text + RuntimeHelpers.OffsetToStringData / 2)
			{
				fixed (byte* ptr2 = (array != null && array.Length != 0) ? ref array[0] : ref *null)
				{
					byte* ptr3 = (byte*)ptr;
					int i = 0;
					int num = array.Length;
					while (i < num)
					{
						ptr2[i] = ptr3[i];
						i++;
					}
				}
				text = null;
				return array;
			}
		}
	}

	public unsafe static int StringToBytes(this string source, byte[] bytes, int offset)
	{
		int num = source.Length << 1;
		fixed (string text = source)
		{
			fixed (char* ptr = text + RuntimeHelpers.OffsetToStringData / 2)
			{
				fixed (byte* ptr2 = (bytes != null && bytes.Length != 0) ? ref bytes[0] : ref *null)
				{
					byte* ptr3 = (byte*)ptr;
					int i = offset;
					int num2 = offset + num;
					while (i < num2)
					{
						ptr2[i] = ptr3[i];
						i++;
					}
				}
				text = null;
				return num;
			}
		}
	}

	public unsafe static string BytesToString(this byte[] source)
	{
		if (source.IsNullOrEmpty<byte>())
		{
			return string.Empty;
		}
		char[] array = new char[source.Length >> 1];
		fixed (char* ptr = (array != null && array.Length != 0) ? ref array[0] : ref *null)
		{
			fixed (byte* ptr2 = (source != null && source.Length != 0) ? ref source[0] : ref *null)
			{
				byte* ptr3 = (byte*)ptr;
				for (int i = 0; i < source.Length; i++)
				{
					ptr3[i] = ptr2[i];
				}
			}
		}
		return new string(array);
	}

	public static bool IsNullOrEmpty(this string value)
	{
		return string.IsNullOrEmpty(value);
	}

	public static bool IsNOTNullOrEmpty(this string value)
	{
		return !string.IsNullOrEmpty(value);
	}

	public static void TryClear<T>(this List<T> value)
	{
		if (value != null)
		{
			value.Clear();
		}
	}

	public static string MD5BIT16(this string value, bool confusion = false)
	{
		MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
		byte[] array = mD5CryptoServiceProvider.ComputeHash(value.StringToBytes());
		int num = 4;
		char[] array2 = new char[16];
		for (int i = 0; i < 16; i += 2)
		{
			byte b = (!confusion) ? array[num++] : (array[num++] ^ 244);
			array2[i] = StaticExtebsion.GetHexValue(b >> 4);
			array2[i + 1] = StaticExtebsion.GetHexValue((int)(b % 16));
		}
		return new string(array2, 0, array2.Length);
	}

	public static string MD5(this string value, bool confusion = false)
	{
		MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
		byte[] array = value.StringToBytes();
		if (confusion)
		{
			for (int i = 0; i < array.Length; i++)
			{
				array[i] ^= 244;
			}
		}
		array = mD5CryptoServiceProvider.ComputeHash(array);
		StringBuilder stringBuilder = new StringBuilder(32);
		for (int j = 0; j < array.Length; j++)
		{
			stringBuilder.Append(array[j].ToString("x2"));
		}
		return stringBuilder.ToString();
	}

	private static char GetHexValue(int i)
	{
		if (i < 10)
		{
			return (char)(i + 48);
		}
		return (char)(i - 10 + 97);
	}

	public static bool Contains(this StringBuilder sb, string value)
	{
		return sb.IndexOf(value) != -1;
	}

	public static int IndexOf(this StringBuilder sb, string value)
	{
		if (value.Length == 0)
		{
			return 0;
		}
		if (value.Length == 1)
		{
			char c = value[0];
			for (int num = 0; num != sb.Length; num++)
			{
				if (sb[num] == c)
				{
					return num;
				}
			}
			return -1;
		}
		int num2 = 0;
		int num3 = 0;
		int[] array = StaticExtebsion.KMPTable(value);
		while (num2 + num3 < sb.Length)
		{
			if (value[num3] == sb[num2 + num3])
			{
				if (num3 == value.Length - 1)
				{
					return (num2 != value.Length) ? num2 : -1;
				}
				num3++;
			}
			else
			{
				num2 = num2 + num3 - array[num3];
				num3 = ((array[num3] <= -1) ? 0 : array[num3]);
			}
		}
		return -1;
	}

	private static int[] KMPTable(string sought)
	{
		int[] array = new int[sought.Length];
		int i = 2;
		int num = 0;
		array[0] = -1;
		array[1] = 0;
		while (i < array.Length)
		{
			if (sought[i - 1] == sought[num])
			{
				num = (array[i++] = num + 1);
			}
			else if (num > 0)
			{
				num = array[num];
			}
			else
			{
				array[i++] = 0;
			}
		}
		return array;
	}

	public static bool IsDiskFull(this Exception ex)
	{
		int num = Marshal.GetHRForException(ex) & 65535;
		return num == 39 || num == 112;
	}
}
