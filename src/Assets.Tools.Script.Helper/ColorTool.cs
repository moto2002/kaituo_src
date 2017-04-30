using System;
using System.Globalization;
using UnityEngine;

namespace Assets.Tools.Script.Helper
{
	public static class ColorTool
	{
		public static Color Golden
		{
			get;
			private set;
		}

		public static string GoldenStr
		{
			get;
			private set;
		}

		static ColorTool()
		{
			ColorTool.GoldenStr = "f4f07f";
			ColorTool.Golden = ColorTool.GetColorFromRGBHexadecimal(ColorTool.GoldenStr);
		}

		public static string SetBBCodeColor(string src, string color)
		{
			return string.Format("[{0}]{1}[-]", color, src);
		}

		public static string SetBBCodeColor(string src, Color color)
		{
			return ColorTool.SetBBCodeColor(src, color.GetRGBHexadecimal());
		}

		public static string GetRGBHexadecimal(this Color color)
		{
			return string.Format("{0}{1}{2}", ((int)(color.r * 255f)).ToString("X2"), ((int)(color.g * 255f)).ToString("X2"), ((int)(color.b * 255f)).ToString("X2"));
		}

		public static string GetRGBHexadecimal(float r, float g, float b, float a)
		{
			return string.Format("{0}{1}{2}{3}", new object[]
			{
				((int)(r * 255f)).ToString("X2"),
				((int)(g * 255f)).ToString("X2"),
				((int)(b * 255f)).ToString("X2"),
				((int)(a * 255f)).ToString("X2")
			});
		}

		public static Color GetColorFromRGBHexadecimal(string colorStr)
		{
			string s = colorStr.Substring(0, 2);
			string s2 = colorStr.Substring(2, 2);
			string s3 = colorStr.Substring(4, 2);
			uint num = uint.Parse(s, NumberStyles.AllowHexSpecifier);
			uint num2 = uint.Parse(s2, NumberStyles.AllowHexSpecifier);
			uint num3 = uint.Parse(s3, NumberStyles.AllowHexSpecifier);
			Color result = new Color(num / 255f, num2 / 255f, num3 / 255f);
			return result;
		}
	}
}
