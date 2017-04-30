using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Migration.Scripts.Action.Effect
{
	[Category("✫ GOG/Effect"), Name("Switch Material Off")]
	public class SwitchMaterialOffAction : ActionTask
	{
		public BBParameter<GameObject> TargetGameObject;

		protected override void OnExecute()
		{
			if (this.TargetGameObject.value != null)
			{
				GameObject value = this.TargetGameObject.value;
				SwitchMaterialBehavior component = value.GetComponent<SwitchMaterialBehavior>();
				if (component != null)
				{
					component.Restore();
					component.enabled = false;
				}
			}
			base.EndAction(new bool?(true));
		}
	}
}
