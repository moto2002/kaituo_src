using System;

namespace XQ.Framework.Data
{
	public class LuaFileRef : ResourceRef
	{
		public LuaFileRef InitTableInfo(string key)
		{
			this.TableInfo.Add(key, new LuaTableInfo());
			return this;
		}
	}
}
