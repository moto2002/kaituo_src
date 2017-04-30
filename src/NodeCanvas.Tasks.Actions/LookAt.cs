using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("GameObject")]
	public class LookAt : ActionTask<Transform>
	{
		[RequiredField]
		public BBParameter<GameObject> lookTarget;

		public bool repeat;

		protected override string info
		{
			get
			{
				return "LookAt " + this.lookTarget;
			}
		}

		protected override void OnExecute()
		{
			this.DoLook();
		}

		protected override void OnUpdate()
		{
			this.DoLook();
		}

		private void DoLook()
		{
			Vector3 position = this.lookTarget.value.transform.position;
			position.y = base.agent.position.y;
			base.agent.LookAt(position);
			if (!this.repeat)
			{
				base.EndAction(new bool?(true));
			}
		}
	}
}
