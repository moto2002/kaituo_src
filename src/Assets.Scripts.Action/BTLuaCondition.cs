using Assets.Scripts.Performance;
using LuaInterface;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;
using XQ.Framework.Lua;

namespace Assets.Scripts.Action
{
	[Category("✫ GOG/ZX"), Name("LuaCondition")]
	public class BTLuaCondition : ConditionTask
	{
		public string LuaTableName;

		public string LuaFunctionName;

		public string[] BlackboardVariables;

		public int[] IntVariables;

		public float[] FloatVariables;

		public string[] StringVariables;

		protected override bool OnCheck()
		{
			if (this.LuaFunctionName.IsNullOrEmpty())
			{
				return false;
			}
			if (this.LuaTableName.IsNullOrEmpty())
			{
				LuaFunction function = GameManager.LuaManager.GetFunction(this.LuaFunctionName, true);
				BTProxy bTProxy = this.GetBTProxy();
				return (bool)function.Call(new object[]
				{
					this.BlackboardVariables,
					this.IntVariables,
					this.FloatVariables,
					this.StringVariables,
					bTProxy
				})[0];
			}
			LuaTable table = GameManager.LuaManager.GetTable(this.LuaTableName, true);
			LuaFunction luaFunction = table.GetLuaFunction(this.LuaFunctionName);
			BTProxy bTProxy2 = this.GetBTProxy();
			return (bool)luaFunction.Call(new object[]
			{
				this.BlackboardVariables,
				this.IntVariables,
				this.FloatVariables,
				this.StringVariables,
				bTProxy2
			})[0];
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
