using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Input")]
	public class WaitMousePick2D : ActionTask
	{
		public enum ButtonKeys
		{
			Left,
			Right,
			Middle
		}

		public WaitMousePick2D.ButtonKeys buttonKey;

		public LayerMask mask = -1;

		[BlackboardOnly]
		public BBParameter<GameObject> saveObjectAs;

		[BlackboardOnly]
		public BBParameter<float> saveDistanceAs;

		[BlackboardOnly]
		public BBParameter<Vector3> savePositionAs;

		private int buttonID;

		private RaycastHit2D hit;

		protected override void OnUpdate()
		{
			this.buttonID = (int)this.buttonKey;
			if (Input.GetMouseButtonDown(this.buttonID))
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				this.hit = Physics2D.Raycast(ray.origin, ray.direction, float.PositiveInfinity, this.mask);
				if (this.hit.collider != null)
				{
					this.savePositionAs.value = this.hit.point;
					this.saveObjectAs.value = this.hit.collider.gameObject;
					this.saveDistanceAs.value = this.hit.distance;
					base.EndAction(new bool?(true));
				}
			}
		}
	}
}
