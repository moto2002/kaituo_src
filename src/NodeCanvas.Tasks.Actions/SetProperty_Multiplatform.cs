using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization;
using System;
using System.Reflection;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Script Control/Multiplatform"), Description("Set a property on a script"), Name("Set Property (mp)")]
	public class SetProperty_Multiplatform : ActionTask
	{
		[SerializeField]
		private SerializedMethodInfo method;

		[SerializeField]
		private BBObjectParameter parameter;

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
				return string.Format("{0}.{1} = {2}", base.agentInfo, this.targetMethod.Name, this.parameter.ToString());
			}
		}

		protected override string OnInit()
		{
			if (this.targetMethod == null)
			{
				return "SetProperty Error";
			}
			return null;
		}

		protected override void OnExecute()
		{
			this.targetMethod.Invoke(base.agent, new object[]
			{
				this.parameter.value
			});
			base.EndAction();
		}
	}
}
