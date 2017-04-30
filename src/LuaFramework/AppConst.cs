using System;
using UnityEngine;

namespace LuaFramework
{
	public class AppConst
	{
		public const bool DebugMode = false;

		public const bool ExampleMode = true;

		public const bool LuaByteMode = false;

		public const int TimerInterval = 1;

		public const string AppName = "LuaFramework";

		public const string LuaTempDir = "Lua/";

		public const string ExtName = ".unity3d";

		public static string FrameworkRoot
		{
			get
			{
				return Application.dataPath + "/LuaFramework";
			}
		}
	}
}
