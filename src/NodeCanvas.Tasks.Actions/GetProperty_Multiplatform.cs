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
	[Category("✫ Script Control/Multiplatform"), Description("Get a property of a script and save it to the blackboard"), Name("Get Property (mp)")]
	public class GetProperty_Multiplatform : ActionTask
	{
		[SerializeField]
		private SerializedMethodInfo method;

		[BlackboardOnly, SerializeField]
		private BBObjectParameter returnValue;

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
				return string.Format("{0} = {1}.{2}", this.returnValue.ToString(), base.agentInfo, this.targetMethod.Name);
			}
		}

		protected override string OnInit()
		{
			if (this.targetMethod == null)
			{
				return "GetProperty Error";
			}
			return null;
		}

		protected override void OnExecute()
		{
			this.returnValue.value = this.targetMethod.Invoke(base.agent, null);
			base.EndAction();
		}
	}
}
