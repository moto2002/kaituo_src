using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("Input")]
	public class CheckMousePick2D : ConditionTask
	{
		public ButtonKeys buttonKey;

		public LayerMask mask = -1;

		[BlackboardOnly]
		public BBParameter<GameObject> saveGoAs;

		[BlackboardOnly]
		public BBParameter<float> saveDistanceAs;

		[BlackboardOnly]
		public BBParameter<Vector3> savePosAs;

		private int buttonID;

		private RaycastHit2D hit;

		protected override string info
		{
			get
			{
				string text = this.buttonKey.ToString() + " Click";
				if (!this.savePosAs.isNone)
				{
					text = text + "\nSavePos As " + this.savePosAs;
				}
				if (!this.saveGoAs.isNone)
				{
					text = text + "\nSaveGo As " + this.saveGoAs;
				}
				return text;
			}
		}

		protected override bool OnCheck()
		{
			this.buttonID = (int)this.buttonKey;
			if (Input.GetMouseButtonDown(this.buttonID))
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				this.hit = Physics2D.Raycast(ray.origin, ray.direction, float.PositiveInfinity, this.mask);
				if (this.hit.collider != null)
				{
					this.savePosAs.value = this.hit.point;
					this.saveGoAs.value = this.hit.collider.gameObject;
					this.saveDistanceAs.value = this.hit.distance;
					return true;
				}
			}
			return false;
		}
	}
}
