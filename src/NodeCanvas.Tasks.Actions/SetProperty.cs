using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion;
using ParadoxNotion.Design;
using System;
using System.Reflection;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Script Control/Standalone Only"), Description("Set a property on a script")]
	public class SetProperty : ActionTask
	{
		[IncludeParseVariables, SerializeField]
		private ReflectedActionWrapper functionWrapper;

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
				return string.Format("{0}.{1} = {2}", base.agentInfo, this.targetMethod.Name, this.functionWrapper.GetVariables()[0]);
			}
		}

		protected override string OnInit()
		{
			if (this.targetMethod == null)
			{
				return "SetProperty Error";
			}
			string result;
			try
			{
				this.functionWrapper.Init(base.agent);
				result = null;
			}
			catch
			{
				result = "SetProperty Error";
			}
			return result;
		}

		protected override void OnExecute()
		{
			if (this.functionWrapper == null)
			{
				base.EndAction(new bool?(false));
				return;
			}
			this.functionWrapper.Call();
			base.EndAction();
		}
	}
}
