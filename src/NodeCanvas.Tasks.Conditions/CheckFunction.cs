using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion;
using ParadoxNotion.Design;
using System;
using System.Reflection;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("✫ Script Control/Standalone Only"), Description("Call a function with none or up to 3 parameters on a component and return whether or not the return value is equal to the check value")]
	public class CheckFunction : ConditionTask
	{
		[IncludeParseVariables, SerializeField]
		private ReflectedFunctionWrapper functionWrapper;

		[SerializeField]
		private BBParameter checkValue;

		[SerializeField]
		private CompareMethod comparison;

		private MethodInfo targetMethod
		{
			get
			{
				return (this.functionWrapper == null || this.functionWrapper.GetMethod() == null) ? null : this.functionWrapper.GetMethod();
			}
		}

		public override Type agentType
		{
			get
			{
				return (this.targetMethod == null) ? typeof(Transform) : this.targetMethod.RTReflectedType();
			}
		}

		protected override string info
		{
			get
			{
				if (this.functionWrapper == null)
				{
					return "No Method Selected";
				}
				if (this.targetMethod == null)
				{
					return string.Format("<color=#ff6457>* {0} *</color>", this.functionWrapper.GetMethodString());
				}
				BBParameter[] variables = this.functionWrapper.GetVariables();
				string text = string.Empty;
				for (int i = 1; i < variables.Length; i++)
				{
					text = text + ((i == 1) ? string.Empty : ", ") + variables[i].ToString();
				}
				return string.Format("{0}.{1}({2}){3}", new object[]
				{
					base.agentInfo,
					this.targetMethod.Name,
					text,
					OperationTools.GetCompareString(this.comparison) + this.checkValue
				});
			}
		}

		protected override string OnInit()
		{
			if (this.targetMethod == null)
			{
				return "CheckFunction Error";
			}
			string result;
			try
			{
				this.functionWrapper.Init(base.agent);
				result = null;
			}
			catch
			{
				result = "CheckFunction Error";
			}
			return result;
		}

		protected override bool OnCheck()
		{
			if (this.functionWrapper == null)
			{
				return true;
			}
			if (this.checkValue.varType == typeof(float))
			{
				return OperationTools.Compare((float)this.functionWrapper.Call(), (float)this.checkValue.value, this.comparison, 0.05f);
			}
			if (this.checkValue.varType == typeof(int))
			{
				return OperationTools.Compare((int)this.functionWrapper.Call(), (int)this.checkValue.value, this.comparison);
			}
			return object.Equals(this.functionWrapper.Call(), this.checkValue.value);
		}
	}
}
