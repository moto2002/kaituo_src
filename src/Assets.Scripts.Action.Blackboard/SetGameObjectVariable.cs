using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Scripts.Action.Blackboard
{
	[Category("obsolete/Blackboard"), Name("Set GameObject from compoment")]
	public class SetGameObjectVariable : ActionTask
	{
		public BBParameter<Component> Compoment;

		public BBParameter<GameObject> Target;

		protected override void OnExecute()
		{
			if (this.Compoment == null || this.Compoment.value == null)
			{
				base.blackboard.AddVariable(this.Target.name, typeof(GameObject));
			}
			else
			{
				this.Target.value = this.Compoment.value.gameObject;
			}
			base.EndAction();
		}
	}
}
