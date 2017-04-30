using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Scripts.Action
{
	[Category("obsolete/Camera"), Name("Change camera target")]
	public class ChangeCameraTargetAction : ActionWithEndType
	{
		public BBParameter<GameObject> Target;

		public float ChangeTargetSpeed;

		private TweenPosition _tweenPosition;

		protected override void OnExecute()
		{
			base.EndActionWithEndType();
		}

		private void OnAnimFinish()
		{
			base.EndAction();
		}

		protected override void OnEndWithAction()
		{
			if (this.ChangeTargetSpeed <= 0f)
			{
				base.EndAction();
			}
		}
	}
}
