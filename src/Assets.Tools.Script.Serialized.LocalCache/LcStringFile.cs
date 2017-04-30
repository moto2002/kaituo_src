using Assets.Tools.Script.File;
using Assets.Tools.Script.Serialized.LocalCache.Core;
using System;
using System.IO;

namespace Assets.Tools.Script.Serialized.LocalCache
{
	public class LcStringFile : UnityLocalESFileCache<string>
	{
		public LcStringFile(string name) : base(name, ".txt")
		{
		}

		protected override string GetLocalCache()
		{
			return ESFile.LoadString(base.fileName);
		}

		protected override void SaveLocalCache(string value)
		{
			ESFile.Save(value, base.fileName, FileMode.Create);
		}
	}
}
