using Assets.Tools.Script.Helper;
using System;
using UnityEngine;

namespace Assets.Tools.Script.Editor.Tool
{
	public static class GUIEditorTool
	{
		public static string SetColor(this string str, string color)
		{
			return string.Format("<color=#" + color + ">{0}</color>", str);
		}

		public static string SetColor(this string str, Color color)
		{
			return string.Format("<color=#" + color.GetRGBHexadecimal() + ">{0}</color>", str);
		}

		public static string SetSize(this string str, int size, bool bold = false)
		{
			if (bold)
			{
				return string.Format("<b><size=" + size + ">{0}</size></b>", str);
			}
			return string.Format("<size=" + size + ">{0}</size>", str);
		}

		public static string SetBold(this string str)
		{
			return string.Format("<b>{0}</b>", str);
		}
	}
}
