using Assets.Tools.Script.File;
using Assets.Tools.Script.Serialized.LocalCache.Core;
using System;

namespace Assets.Tools.Script.Serialized.LocalCache.xml
{
	public class LcXMLFile<T> : UnityLocalESFileCache<T> where T : class
	{
		public LcXMLFile(string fileName) : base(fileName, ".txt")
		{
		}

		protected override T GetLocalCache()
		{
			T t = ESFile.LoadXMLObject<T>(base.fileName);
			if (t is IXMLSerializable)
			{
				(t as IXMLSerializable).AfterSerialize();
			}
			return t;
		}

		protected override void SaveLocalCache(T value)
		{
			if (value is IXMLSerializable)
			{
				(value as IXMLSerializable).BeforSerialize();
			}
			ESFile.SaveXMLObject(base.fileName, value);
		}
	}
}
