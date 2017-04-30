using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion;
using ParadoxNotion.Design;
using System;
using System.Reflection;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Script Control/Standalone Only"), Description("Calls a function that has signature of 'public Status NAME()' or 'public Status NAME(T)'. You should return Status.Success, Failure or Running within that function.")]
	public class ImplementedAction : ActionTask
	{
		[IncludeParseVariables, SerializeField]
		private ReflectedFunctionWrapper functionWrapper;

		private Status actionStatus = Status.Resting;

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
					return "No Action Selected";
				}
				if (this.targetMethod == null)
				{
					return string.Format("<color=#ff6457>* {0} *</color>", this.functionWrapper.GetMethodString());
				}
				return string.Format("[ {0}.{1}({2}) ]", base.agentInfo, this.targetMethod.Name, (this.functionWrapper.GetVariables().Length != 2) ? string.Empty : this.functionWrapper.GetVariables()[1].ToString());
			}
		}

		protected override string OnInit()
		{
			if (this.targetMethod == null)
			{
				return "ImplementedAction Error";
			}
			string result;
			try
			{
				this.functionWrapper.Init(base.agent);
				result = null;
			}
			catch
			{
				result = "ImplementedAction Error";
			}
			return result;
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
			if (this.functionWrapper == null)
			{
				base.EndAction(new bool?(false));
				return;
			}
			this.actionStatus = (Status)((int)this.functionWrapper.Call());
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
