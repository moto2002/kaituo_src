using Assets.Scripts.Action.Core;
using Assets.Tools.Script.Caller;
using ParadoxNotion.Design;
using System;

namespace Assets.Scripts.Action
{
	[DoNotList]
	public class ActionWithEndType : DevisableAction
	{
		public ActionEndType EndType;

		public float SecondsToRun;

		protected void EndActionWithEndType()
		{
			if (this.EndType == ActionEndType.Immediately)
			{
				base.EndAction();
			}
			else if (this.EndType == ActionEndType.AppointedTime)
			{
				DelayCall.Call(new Action(base.EndAction), this.SecondsToRun, false);
			}
			else
			{
				this.OnEndWithAction();
			}
		}

		protected virtual void OnEndWithAction()
		{
		}
	}
}
