using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Input")]
	public class WaitMousePick : ActionTask
	{
		public enum ButtonKeys
		{
			Left,
			Right,
			Middle
		}

		public WaitMousePick.ButtonKeys buttonKey;

		public LayerMask mask = -1;

		[BlackboardOnly]
		public BBParameter<GameObject> saveObjectAs;

		[BlackboardOnly]
		public BBParameter<float> saveDistanceAs;

		[BlackboardOnly]
		public BBParameter<Vector3> savePositionAs;

		private int buttonID;

		private RaycastHit hit;

		protected override void OnUpdate()
		{
			this.buttonID = (int)this.buttonKey;
			if (Input.GetMouseButtonDown(this.buttonID) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out this.hit, float.PositiveInfinity, this.mask))
			{
				this.savePositionAs.value = this.hit.point;
				this.saveObjectAs.value = this.hit.collider.gameObject;
				this.saveDistanceAs.value = this.hit.distance;
				base.EndAction(new bool?(true));
			}
		}
	}
}
