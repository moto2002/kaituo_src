using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Script Control/Multiplatform"), Description("Execute a function on a script, of up to 3 parameters and save the return if any. If function is an IEnumerator it will execute as a coroutine."), Name("Execute Function (mp)")]
	public class ExecuteFunction_Multiplatform : ActionTask
	{
		[SerializeField]
		private SerializedMethodInfo method;

		[SerializeField]
		private List<BBObjectParameter> parameters = new List<BBObjectParameter>();

		[BlackboardOnly, SerializeField]
		private BBObjectParameter returnValue;

		private bool routineRunning;

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
				string text = (this.targetMethod.ReturnType != typeof(void) && this.targetMethod.ReturnType != typeof(IEnumerator)) ? (this.returnValue.ToString() + " = ") : string.Empty;
				string text2 = string.Empty;
				for (int i = 0; i < this.parameters.Count; i++)
				{
					text2 = text2 + ((i == 0) ? string.Empty : ", ") + this.parameters[i].ToString();
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
			return null;
		}

		protected override void OnExecute()
		{
			object[] array = (from p in this.parameters
			select p.value).ToArray<object>();
			if (this.targetMethod.ReturnType == typeof(IEnumerator))
			{
				base.StartCoroutine(this.InternalCoroutine((IEnumerator)this.targetMethod.Invoke(base.agent, array)));
				return;
			}
			this.returnValue.value = this.targetMethod.Invoke(base.agent, array);
			base.EndAction();
		}

		protected override void OnStop()
		{
			this.routineRunning = false;
		}

		[DebuggerHidden]
		private IEnumerator InternalCoroutine(IEnumerator routine)
		{
			ExecuteFunction_Multiplatform.<InternalCoroutine>c__Iterator21 <InternalCoroutine>c__Iterator = new ExecuteFunction_Multiplatform.<InternalCoroutine>c__Iterator21();
			<InternalCoroutine>c__Iterator.routine = routine;
			<InternalCoroutine>c__Iterator.<$>routine = routine;
			<InternalCoroutine>c__Iterator.<>f__this = this;
			return <InternalCoroutine>c__Iterator;
		}
	}
}
