using System;

namespace Assets.Tools.Script.Serialized.LocalCache.xml
{
	public interface IXMLSerializable
	{
		void BeforSerialize();

		void AfterSerialize();
	}
}
