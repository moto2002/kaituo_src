using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Input")]
	public class GetMousePosition : ActionTask
	{
		[BlackboardOnly]
		public BBParameter<Vector3> saveAs;

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
			this.saveAs.value = Input.mousePosition;
			if (!this.repeat)
			{
				base.EndAction();
			}
		}
	}
}
