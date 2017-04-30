using System;
using UnityEngine;

namespace Assets.Tools.Script.File
{
	public class ResSafeFileUtil
	{
		public static string ReadFile(string path)
		{
			TextAsset textAsset = Resources.Load<TextAsset>(path);
			return textAsset.text;
		}

		public static bool DirectoryExists(string path)
		{
			return true;
		}

		public static bool FileExists(string path)
		{
			return true;
		}

		public static string GetSuffix(string suffix)
		{
			return string.Empty;
		}
	}
}
