using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using System;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Utility")]
	public class Wait : ActionTask
	{
		public BBParameter<float> waitTime = new BBParameter<float>
		{
			value = 1f
		};

		public CompactStatus finishStatus = CompactStatus.Success;

		protected override string info
		{
			get
			{
				return "Wait " + this.waitTime + " sec.";
			}
		}

		protected override void OnUpdate()
		{
			if (base.elapsedTime >= this.waitTime.value)
			{
				base.EndAction(new bool?(this.finishStatus == CompactStatus.Success));
			}
		}
	}
}
