using System;
using UnityEngine;

namespace Assets.Tools.Script.File
{
	public class LoadPath
	{
		public static string streamingAssetsPath;

		public static string saveLoadPath;

		public static string readLoadPath;

		static LoadPath()
		{
			LoadPath.saveLoadPath = Application.persistentDataPath + "/";
			LoadPath.readLoadPath = "file://" + Application.persistentDataPath + "/";
			LoadPath.streamingAssetsPath = "jar:file://" + Application.dataPath + "!/assets/";
		}

		public static string replace(string FilePath)
		{
			return FilePath;
		}
	}
}
