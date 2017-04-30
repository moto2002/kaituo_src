using LuaInterface;
using System;
using XQ.Framework.Lua;
using XQ.Framework.Lua.Utility;

namespace Assets.Tools.Script.Go
{
	public class UnityCompomentLife : ILuaScriptBase
	{
		public LuaFunction EnableAction;

		public LuaFunction DisableAction;

		public LuaFunction DestroyAction;

		public void OnEnable()
		{
			if (this.EnableAction != null)
			{
				this.EnableAction.Call();
			}
		}

		public void OnDisable()
		{
			if (this.DisableAction != null)
			{
				this.DisableAction.Call();
			}
		}

		public override void OnAwake()
		{
		}

		public override void OnDestroyNow()
		{
			if (this.DestroyAction != null)
			{
				this.DestroyAction.Call();
			}
			this.Dispose();
		}

		private void Dispose()
		{
			UtilHelper.DestroyLua(this.EnableAction);
			UtilHelper.DestroyLua(this.DisableAction);
			UtilHelper.DestroyLua(this.DestroyAction);
			this.EnableAction = null;
			this.DisableAction = null;
			this.DestroyAction = null;
		}
	}
}
