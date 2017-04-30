using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("✫ Script Control/Multiplatform"), Description("Call a function with none or up to 3 parameters on a component and return whether or not the return value is equal to the check value"), Name("Check Function (mp)")]
	public class CheckFunction_Multiplatform : ConditionTask
	{
		[SerializeField]
		private SerializedMethodInfo method;

		[SerializeField]
		private List<BBObjectParameter> parameters = new List<BBObjectParameter>();

		[BlackboardOnly, SerializeField]
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
					return "No Method Selected";
				}
				if (this.targetMethod == null)
				{
					return string.Format("<color=#ff6457>* {0} *</color>", this.method.GetMethodString());
				}
				string text = string.Empty;
				for (int i = 0; i < this.parameters.Count; i++)
				{
					text = text + ((i == 0) ? string.Empty : ", ") + this.parameters[i].ToString();
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
			return null;
		}

		protected override bool OnCheck()
		{
			object[] array = (from p in this.parameters
			select p.value).ToArray<object>();
			if (this.checkValue.varType == typeof(float))
			{
				return OperationTools.Compare((float)this.targetMethod.Invoke(base.agent, array), (float)this.checkValue.value, this.comparison, 0.05f);
			}
			if (this.checkValue.varType == typeof(int))
			{
				return OperationTools.Compare((int)this.targetMethod.Invoke(base.agent, array), (int)this.checkValue.value, this.comparison);
			}
			return object.Equals(this.targetMethod.Invoke(base.agent, array), this.checkValue.value);
		}
	}
}
