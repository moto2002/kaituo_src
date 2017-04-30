using System;
using System.Collections.Generic;

namespace XQ.Framework.Lua
{
	public class ConfigResource
	{
		public bool IsPatch;

		public bool UseDataDir;

		public string PKGFile;

		public string FilePath;

		public Dictionary<string, string> ConfigFiles;

		public static ConfigResource New()
		{
			return new ConfigResource
			{
				ConfigFiles = new Dictionary<string, string>()
			};
		}
	}
}
