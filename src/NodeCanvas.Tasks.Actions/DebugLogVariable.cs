using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Utility"), Description("Logs the value of a variable in the console")]
	public class DebugLogVariable : ActionTask
	{
		[BlackboardOnly]
		public BBParameter<object> log;

		public float secondsToRun = 1f;

		public CompactStatus finishStatus = CompactStatus.Success;

		protected override string info
		{
			get
			{
				return string.Concat(new object[]
				{
					"Log '",
					this.log,
					"'",
					(this.secondsToRun <= 0f) ? string.Empty : (" for " + this.secondsToRun + " sec.")
				});
			}
		}

		protected override void OnExecute()
		{
			Debug.Log(string.Format("<b>Var '{0}' = </b> {1}", this.log.name, this.log.value));
		}

		protected override void OnUpdate()
		{
			if (base.elapsedTime >= this.secondsToRun)
			{
				base.EndAction(new bool?(this.finishStatus == CompactStatus.Success));
			}
		}
	}
}
