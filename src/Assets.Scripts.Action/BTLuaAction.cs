using Assets.Scripts.Performance;
using LuaInterface;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;
using XQ.Framework.Lua;

namespace Assets.Scripts.Action
{
	[Category("✫ GOG/ZX"), Name("LuaAction")]
	public class BTLuaAction : ActionTask
	{
		public bool IgnoreTimeScale;

		public string LuaName;

		public string[] BlackboardVariables;

		public int[] IntVariables;

		public float[] FloatVariables;

		public string[] StringVariables;

		private LuaFunction luaOnExecute;

		private LuaFunction luaOnUpdate;

		private LuaFunction luaOnPause;

		private DateTime startDateTime;

		private LuaTable lua;

		public LuaTable Lua
		{
			get
			{
				if (this.lua == null)
				{
					try
					{
						LuaFunction function = GameManager.LuaManager.GetFunction("XQRequireRedo", true);
						this.lua = (LuaTable)function.Call(new object[]
						{
							this.LuaName
						})[0];
						LuaFunction luaFunction = this.lua.GetLuaFunction("Init");
						BTProxy bTProxy = this.GetBTProxy();
						luaFunction.CallNoRet(new object[]
						{
							this.BlackboardVariables,
							this.IntVariables,
							this.FloatVariables,
							this.StringVariables,
							bTProxy
						});
						this.luaOnExecute = this.lua.GetLuaFunction("OnExecute");
						this.luaOnUpdate = this.lua.GetLuaFunction("OnUpdate");
						this.luaOnPause = this.lua.GetLuaFunction("OnPause");
					}
					catch (Exception ex)
					{
						DebugConsole.Log(new object[]
						{
							ex
						});
					}
				}
				return this.lua;
			}
		}

		protected override void OnExecute()
		{
			LuaTable a = this.Lua;
			if (a == null)
			{
				base.EndAction();
			}
			else
			{
				if (this.IgnoreTimeScale)
				{
					this.startDateTime = DateTime.Now;
				}
				bool flag = (bool)this.luaOnExecute.Call(new object[]
				{
					0
				})[0];
				if (flag)
				{
					this.EndLuaAction();
				}
			}
		}

		protected override void OnPause()
		{
			if (this.luaOnPause != null)
			{
				this.luaOnPause.Call();
			}
		}

		protected override void OnUpdate()
		{
			float runTime = this.GetRunTime();
			if (this.luaOnUpdate != null)
			{
				bool flag = (bool)this.luaOnUpdate.Call(new object[]
				{
					runTime
				})[0];
				if (flag)
				{
					this.EndLuaAction();
				}
			}
		}

		protected override void OnStop()
		{
			this.DisposeLua();
		}

		private void EndLuaAction()
		{
			bool value = this.DisposeLua();
			base.EndAction(new bool?(value));
		}

		private bool DisposeLua()
		{
			if (this.lua != null)
			{
				LuaFunction luaFunction = this.Lua.GetLuaFunction("Dispose");
				bool result = (bool)luaFunction.Call(new object[]
				{
					0
				})[0];
				this.luaOnExecute.Dispose();
				this.luaOnExecute = null;
				if (this.luaOnUpdate != null)
				{
					this.luaOnUpdate.Dispose();
					this.luaOnUpdate = null;
				}
				if (this.luaOnPause != null)
				{
					this.luaOnPause.Dispose();
					this.luaOnPause = null;
				}
				this.lua.Dispose();
				this.lua = null;
				return result;
			}
			return true;
		}

		private float GetRunTime()
		{
			if (this.IgnoreTimeScale)
			{
				return (float)(DateTime.Now - this.startDateTime).TotalSeconds;
			}
			return base.elapsedTime;
		}

		private BTProxy GetBTProxy()
		{
			BTProxy bTProxy = null;
			Transform transform = base.agent.transform;
			while (bTProxy == null && transform != null)
			{
				bTProxy = transform.gameObject.GetComponent<BTProxy>();
				transform = transform.parent;
			}
			return bTProxy;
		}
	}
}
