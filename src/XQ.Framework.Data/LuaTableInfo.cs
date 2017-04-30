using LuaInterface;
using System;
using System.Collections.Generic;
using XQ.Framework.Lua.Utility;

namespace XQ.Framework.Data
{
	public class LuaTableInfo
	{
		public bool TabelIsGlobal;

		public LuaTable Table;

		public string LuaName;

		private readonly List<LuaFunction> _refFunctions = new List<LuaFunction>();

		public virtual void Clear(string fileName)
		{
			if (this._refFunctions.Count > 0)
			{
				this._refFunctions.ForEach(delegate(LuaFunction r)
				{
					r.Dispose();
				});
				this._refFunctions.Clear();
			}
			if (this.Table != null)
			{
				UtilHelper.DestroyLua(this.Table);
				this.Table = null;
			}
		}

		public void SetFunctions(LuaFunction func)
		{
			if (!this._refFunctions.Contains(func))
			{
				this._refFunctions.Add(func);
			}
		}
	}
}
