using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Scripts.Action.Blackboard
{
	[Category("✫ GOG/Blackboard"), Name("Set GameObject position")]
	public class SetVectorWithPosition : ActionTask
	{
		public BBParameter<GameObject> From;

		public BBParameter<Vector3> To;

		protected override void OnExecute()
		{
			this.To.value = this.From.value.transform.position;
			base.EndAction();
		}
	}
}
