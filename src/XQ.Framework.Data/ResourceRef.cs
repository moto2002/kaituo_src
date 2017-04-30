using System;
using System.Collections.Generic;

namespace XQ.Framework.Data
{
	public abstract class ResourceRef
	{
		public enum ResFormat
		{
			None,
			Prefab,
			UIAtlas,
			UIFont,
			Texture
		}

		public string FullFileName;

		public ResourceRef.ResFormat ResType;

		public Dictionary<string, LuaTableInfo> TableInfo = new Dictionary<string, LuaTableInfo>();

		public virtual void Clear(string objectKey)
		{
			LuaTableInfo luaTableInfo;
			if (!this.TableInfo.TryGetValue(objectKey, out luaTableInfo))
			{
				return;
			}
			this.TableInfo.Remove(objectKey);
			luaTableInfo.Clear(this.FullFileName);
		}

		public LuaTableInfo GetLuaTableInfo(string objectKey)
		{
			LuaTableInfo result;
			this.TableInfo.TryGetValue(objectKey, out result);
			return result;
		}

		public bool IsPrefab()
		{
			return this.ResType > ResourceRef.ResFormat.None && this.ResType < ResourceRef.ResFormat.Texture;
		}
	}
}
