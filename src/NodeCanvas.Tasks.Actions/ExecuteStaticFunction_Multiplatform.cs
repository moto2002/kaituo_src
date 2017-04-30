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

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Script Control/Multiplatform"), Description("Execute a static function of up to 3 parameters and optionaly save the return value"), Name("Execute Static Function (mp)")]
	public class ExecuteStaticFunction_Multiplatform : ActionTask
	{
		[SerializeField]
		private SerializedMethodInfo method;

		[SerializeField]
		private List<BBObjectParameter> parameters = new List<BBObjectParameter>();

		[BlackboardOnly, SerializeField]
		private BBObjectParameter returnValue;

		private MethodInfo targetMethod
		{
			get
			{
				return (this.method == null || this.method.Get() == null) ? null : this.method.Get();
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
				string text = (this.targetMethod.ReturnType != typeof(void)) ? (this.returnValue.ToString() + " = ") : string.Empty;
				string text2 = string.Empty;
				for (int i = 0; i < this.parameters.Count; i++)
				{
					text2 = text2 + ((i == 0) ? string.Empty : ", ") + this.parameters[i].ToString();
				}
				return string.Format("{0}{1}.{2} ({3})", new object[]
				{
					text,
					this.targetMethod.DeclaringType.FriendlyName(),
					this.targetMethod.Name,
					text2
				});
			}
		}

		protected override string OnInit()
		{
			if (this.targetMethod == null)
			{
				return "ExecuteFunction Error";
			}
			return null;
		}

		protected override void OnExecute()
		{
			object[] array = (from p in this.parameters
			select p.value).ToArray<object>();
			this.returnValue.value = this.targetMethod.Invoke(base.agent, array);
			base.EndAction();
		}
	}
}
