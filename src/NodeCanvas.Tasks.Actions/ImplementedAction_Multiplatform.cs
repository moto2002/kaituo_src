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
	[Category("✫ Script Control/Multiplatform"), Description("Calls a function that has signature of 'public Status NAME()' or 'public Status NAME(T)'. You should return Status.Success, Failure or Running within that function."), Name("Implemented Action (mp)")]
	public class ImplementedAction_Multiplatform : ActionTask
	{
		[SerializeField]
		private SerializedMethodInfo method;

		[SerializeField]
		private List<BBObjectParameter> parameters = new List<BBObjectParameter>();

		private Status actionStatus = Status.Resting;

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
					return "No Action Selected";
				}
				if (this.targetMethod == null)
				{
					return string.Format("<color=#ff6457>* {0} *</color>", this.method.GetMethodString());
				}
				return string.Format("[ {0}.{1}({2}) ]", base.agentInfo, this.targetMethod.Name, (this.parameters.Count != 1) ? string.Empty : this.parameters[0].ToString());
			}
		}

		protected override string OnInit()
		{
			if (this.targetMethod == null)
			{
				return "ImplementedAction Error";
			}
			return null;
		}

		protected override void OnExecute()
		{
			this.Forward();
		}

		protected override void OnUpdate()
		{
			this.Forward();
		}

		private void Forward()
		{
			object[] array = (from p in this.parameters
			select p.value).ToArray<object>();
			this.actionStatus = (Status)((int)this.targetMethod.Invoke(base.agent, array));
			if (this.actionStatus == Status.Success)
			{
				base.EndAction(new bool?(true));
				return;
			}
			if (this.actionStatus == Status.Failure)
			{
				base.EndAction(new bool?(false));
				return;
			}
		}

		protected override void OnStop()
		{
			this.actionStatus = Status.Resting;
		}
	}
}
