using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Input")]
	public class GetMouseScrollDelta : ActionTask
	{
		[BlackboardOnly]
		public BBParameter<float> saveAs;

		public bool repeat;

		protected override string info
		{
			get
			{
				return "Get Scroll Delta as " + this.saveAs;
			}
		}

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
			this.saveAs.value = Input.GetAxis("Mouse ScrollWheel");
			if (!this.repeat)
			{
				base.EndAction();
			}
		}
	}
}
