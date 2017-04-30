using Assets.Tools.Script.Caller;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;

namespace Assets.Scripts.Action
{
	[Category("✫ GOG/Process"), Name("Wait time")]
	public class WaitTimeAction : ActionTask
	{
		public float WaitTime;

		public bool ignoreTimeScale;

		protected override void OnExecute()
		{
			DelayCall.Call(new Action(base.EndAction), this.WaitTime, this.ignoreTimeScale);
		}
	}
}
