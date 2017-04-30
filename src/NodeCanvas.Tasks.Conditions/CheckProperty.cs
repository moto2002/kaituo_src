using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion;
using ParadoxNotion.Design;
using System;
using System.Reflection;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("✫ Script Control/Standalone Only"), Description("Check a property on a script and return if it's equal or not to the check value")]
	public class CheckProperty : ConditionTask
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
					return "No Property Selected";
				}
				if (this.targetMethod == null)
				{
					return string.Format("<color=#ff6457>* {0} *</color>", this.functionWrapper.GetMethodString());
				}
				return string.Format("{0}.{1}{2}", base.agentInfo, this.targetMethod.Name, OperationTools.GetCompareString(this.comparison) + this.checkValue.ToString());
			}
		}

		protected override string OnInit()
		{
			if (this.targetMethod == null)
			{
				return "CheckProperty Error";
			}
			string result;
			try
			{
				this.functionWrapper.Init(base.agent);
				result = null;
			}
			catch
			{
				result = "CheckProperty Error";
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
