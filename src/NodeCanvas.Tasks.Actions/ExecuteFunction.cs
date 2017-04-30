using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion;
using ParadoxNotion.Design;
using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using UnityEngine;
using XQ.Framework.Utility.Debug;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Script Control/Standalone Only"), Description("Execute a function on a script, of up to 3 parameters and save the return if any. If function is an IEnumerator it will execute as a coroutine.")]
	public class ExecuteFunction : ActionTask
	{
		[IncludeParseVariables, SerializeField]
		private ReflectedWrapper functionWrapper;

		private bool routineRunning;

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
					return "No Method Selected";
				}
				if (this.targetMethod == null)
				{
					return string.Format("<color=#ff6457>* {0} *</color>", this.functionWrapper.GetMethodString());
				}
				BBParameter[] variables = this.functionWrapper.GetVariables();
				string text = string.Empty;
				string text2 = string.Empty;
				if (this.targetMethod.ReturnType == typeof(void))
				{
					for (int i = 0; i < variables.Length; i++)
					{
						text2 = text2 + ((i == 0) ? string.Empty : ", ") + variables[i].ToString();
					}
				}
				else
				{
					text = ((this.targetMethod.ReturnType != typeof(void) && this.targetMethod.ReturnType != typeof(IEnumerator) && !variables[0].isNone) ? (variables[0] + " = ") : string.Empty);
					for (int j = 1; j < variables.Length; j++)
					{
						text2 = text2 + ((j == 1) ? string.Empty : ", ") + variables[j].ToString();
					}
				}
				return string.Format("{0}{1}.{2}({3})", new object[]
				{
					text,
					base.agentInfo,
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
			string result;
			try
			{
				this.functionWrapper.Init(base.agent);
				result = null;
			}
			catch
			{
				result = "ExecuteFunction Error";
			}
			return result;
		}

		protected override void OnExecute()
		{
			if (this.targetMethod == null)
			{
				base.EndAction(new bool?(false));
				return;
			}
			try
			{
				if (this.targetMethod.ReturnType == typeof(IEnumerator))
				{
					base.StartCoroutine(this.InternalCoroutine((IEnumerator)((ReflectedFunctionWrapper)this.functionWrapper).Call()));
				}
				else
				{
					if (this.targetMethod.ReturnType == typeof(void))
					{
						((ReflectedActionWrapper)this.functionWrapper).Call();
					}
					else
					{
						((ReflectedFunctionWrapper)this.functionWrapper).Call();
					}
					base.EndAction(new bool?(true));
				}
			}
			catch (Exception ex)
			{
				UDebug.Error(string.Format("{0}\n{1}", ex.Message, ex.StackTrace), new object[0]);
				base.EndAction(new bool?(false));
			}
		}

		protected override void OnStop()
		{
			this.routineRunning = false;
		}

		[DebuggerHidden]
		private IEnumerator InternalCoroutine(IEnumerator routine)
		{
			ExecuteFunction.<InternalCoroutine>c__Iterator20 <InternalCoroutine>c__Iterator = new ExecuteFunction.<InternalCoroutine>c__Iterator20();
			<InternalCoroutine>c__Iterator.routine = routine;
			<InternalCoroutine>c__Iterator.<$>routine = routine;
			<InternalCoroutine>c__Iterator.<>f__this = this;
			return <InternalCoroutine>c__Iterator;
		}
	}
}
