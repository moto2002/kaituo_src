using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assets.Tools.Script.Helper
{
	public static class SeralizeHelper
	{
		public static byte[] ToByteArray(this object obj)
		{
			if (obj == null)
			{
				return new byte[0];
			}
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				binaryFormatter.Serialize(memoryStream, obj);
				result = memoryStream.ToArray();
			}
			return result;
		}

		public static object FromByteArray(this byte[] barray)
		{
			if (barray.Length == 0)
			{
				return null;
			}
			object result;
			using (MemoryStream memoryStream = new MemoryStream(barray))
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				result = binaryFormatter.Deserialize(memoryStream);
			}
			return result;
		}

		public static string ToByteString(this object obj)
		{
			byte[] inArray = obj.ToByteArray();
			return Convert.ToBase64String(inArray);
		}

		public static T FromByteString<T>(this string bytestring) where T : class
		{
			byte[] barray = Convert.FromBase64String(bytestring);
			return barray.FromByteArray() as T;
		}
	}
}
