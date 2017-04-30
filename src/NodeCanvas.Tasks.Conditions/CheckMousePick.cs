using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("Input")]
	public class CheckMousePick : ConditionTask
	{
		public ButtonKeys buttonKey;

		[LayerField]
		public int layer;

		[BlackboardOnly]
		public BBParameter<GameObject> saveGoAs;

		[BlackboardOnly]
		public BBParameter<float> saveDistanceAs;

		[BlackboardOnly]
		public BBParameter<Vector3> savePosAs;

		private RaycastHit hit;

		protected override string info
		{
			get
			{
				string text = this.buttonKey.ToString() + " Click";
				if (!string.IsNullOrEmpty(this.savePosAs.name))
				{
					text += string.Format("\n<i>(SavePos As {0})</i>", this.savePosAs);
				}
				if (!string.IsNullOrEmpty(this.saveGoAs.name))
				{
					text += string.Format("\n<i>(SaveGo As {0})</i>", this.saveGoAs);
				}
				return text;
			}
		}

		protected override bool OnCheck()
		{
			if (Input.GetMouseButtonDown((int)this.buttonKey) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out this.hit, float.PositiveInfinity, 1 << this.layer))
			{
				this.saveGoAs.value = this.hit.collider.gameObject;
				this.saveDistanceAs.value = this.hit.distance;
				this.savePosAs.value = this.hit.point;
				return true;
			}
			return false;
		}
	}
}
