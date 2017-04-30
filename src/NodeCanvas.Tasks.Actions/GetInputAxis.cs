using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Input")]
	public class GetInputAxis : ActionTask
	{
		public BBParameter<string> xAxisName = "Horizontal";

		public BBParameter<string> yAxisName;

		public BBParameter<string> zAxisName = "Vertical";

		public BBParameter<float> multiplier = 1f;

		[BlackboardOnly]
		public BBParameter<Vector3> saveAs;

		[BlackboardOnly]
		public BBParameter<float> saveXAs;

		[BlackboardOnly]
		public BBParameter<float> saveYAs;

		[BlackboardOnly]
		public BBParameter<float> saveZAs;

		public bool repeat;

		protected override void OnExecute()
		{
			this.Do();
		}

		protected override void OnUpdate()
		{
			this.Do();
		}

		private void Do()
		{
			float num = (!string.IsNullOrEmpty(this.xAxisName.value)) ? Input.GetAxis(this.xAxisName.value) : 0f;
			float num2 = (!string.IsNullOrEmpty(this.yAxisName.value)) ? Input.GetAxis(this.yAxisName.value) : 0f;
			float num3 = (!string.IsNullOrEmpty(this.zAxisName.value)) ? Input.GetAxis(this.zAxisName.value) : 0f;
			this.saveXAs.value = num * this.multiplier.value;
			this.saveYAs.value = num2 * this.multiplier.value;
			this.saveZAs.value = num3 * this.multiplier.value;
			this.saveAs.value = new Vector3(num, num2, num3) * this.multiplier.value;
			if (!this.repeat)
			{
				base.EndAction();
			}
		}
	}
}
