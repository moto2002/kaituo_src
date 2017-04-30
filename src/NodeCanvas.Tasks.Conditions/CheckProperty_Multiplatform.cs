using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization;
using System;
using System.Reflection;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("✫ Script Control/Multiplatform"), Description("Check a property on a script and return if it's equal or not to the check value"), Name("Check Property (mp)")]
	public class CheckProperty_Multiplatform : ConditionTask
	{
		[SerializeField]
		private SerializedMethodInfo method;

		[SerializeField]
		private BBObjectParameter checkValue;

		[SerializeField]
		private CompareMethod comparison;

		private MethodInfo targetMethod
		{
			get
			{
				return (this.method == null || this.method.Get() == null) ? null : this.method.Get();
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
				if (this.method == null)
				{
					return "No Property Selected";
				}
				if (this.targetMethod == null)
				{
					return string.Format("<color=#ff6457>* {0} *</color>", this.method.GetMethodString());
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
			return null;
		}

		protected override bool OnCheck()
		{
			if (this.checkValue.varType == typeof(float))
			{
				return OperationTools.Compare((float)this.targetMethod.Invoke(base.agent, null), (float)this.checkValue.value, this.comparison, 0.05f);
			}
			if (this.checkValue.varType == typeof(int))
			{
				return OperationTools.Compare((int)this.targetMethod.Invoke(base.agent, null), (int)this.checkValue.value, this.comparison);
			}
			return object.Equals(this.targetMethod.Invoke(base.agent, null), this.checkValue.value);
		}
	}
}
