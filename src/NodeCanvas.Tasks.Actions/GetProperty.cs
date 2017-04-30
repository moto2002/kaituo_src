using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion;
using ParadoxNotion.Design;
using System;
using System.Reflection;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Script Control/Standalone Only"), Description("Get a property of a script and save it to the blackboard")]
	public class GetProperty : ActionTask
	{
		[IncludeParseVariables, SerializeField]
		private ReflectedFunctionWrapper functionWrapper;

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
				return string.Format("{0} = {1}.{2}", this.functionWrapper.GetVariables()[0], base.agentInfo, this.targetMethod.Name);
			}
		}

		protected override string OnInit()
		{
			if (this.targetMethod == null)
			{
				return "GetProperty Error";
			}
			string result;
			try
			{
				this.functionWrapper.Init(base.agent);
				result = null;
			}
			catch
			{
				result = "GetProperty Error";
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
