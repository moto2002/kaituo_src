using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Tools.Script.Helper
{
	public static class StringHelper
	{
		public static string Joint(this string[] src, string separator)
		{
			if (src == null || src.Length == 0)
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < src.Length; i++)
			{
				stringBuilder.Append(src[i]);
				stringBuilder.Append(separator);
			}
			stringBuilder.Remove(stringBuilder.Length - separator.Length, separator.Length);
			return stringBuilder.ToString();
		}

		public static string Joint(this List<string> src, string separator)
		{
			if (src == null || src.Count == 0)
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < src.Count; i++)
			{
				stringBuilder.Append(src[i]);
				stringBuilder.Append(separator);
			}
			stringBuilder.Remove(stringBuilder.Length - 1, 1);
			return stringBuilder.ToString();
		}

		public static Vector3 GetVector3FromString(string str)
		{
			string[] array = str.Split(new char[]
			{
				','
			});
			Vector3 result;
			result.x = (float)Convert.ToDouble(array[0]);
			result.y = (float)Convert.ToDouble(array[1]);
			result.z = (float)Convert.ToDouble(array[2]);
			return result;
		}

		public static Quaternion GetQuaternionFromString(string str)
		{
			Quaternion result = default(Quaternion);
			Vector3 vector3FromString = StringHelper.GetVector3FromString(str);
			result.eulerAngles = vector3FromString;
			return result;
		}

		public static List<string> SplitHump(this string str)
		{
			List<string> list = new List<string>();
			if (str == null || str.Length == 0)
			{
				return list;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < str.Length; i++)
			{
				char c = str[i];
				if (c >= 'A' && c <= 'Z' && stringBuilder.Length > 0)
				{
					list.Add(stringBuilder.ToString());
					stringBuilder = new StringBuilder();
				}
				stringBuilder.Append(c);
			}
			if (stringBuilder.Length > 0)
			{
				list.Add(stringBuilder.ToString());
				stringBuilder = new StringBuilder();
			}
			return list;
		}
	}
}
