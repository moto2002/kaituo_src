using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Script Control/Common"), Description("SendMessage to the agent, optionaly with an argument")]
	public class SendMessage<T> : ActionTask<Transform>
	{
		[RequiredField]
		public BBParameter<string> methodName;

		public BBParameter<T> argument;

		protected override string info
		{
			get
			{
				return string.Format("Message {0}({1})", this.methodName, this.argument.ToString());
			}
		}

		protected override void OnExecute()
		{
			if (this.argument.isNull)
			{
				base.agent.SendMessage(this.methodName.value);
			}
			else
			{
				base.agent.SendMessage(this.methodName.value, this.argument.value);
			}
			base.EndAction();
		}
	}
}
