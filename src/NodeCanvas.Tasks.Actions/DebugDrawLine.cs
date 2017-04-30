using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Utility")]
	public class DebugDrawLine : ActionTask
	{
		public BBParameter<Vector3> from;

		public BBParameter<Vector3> to;

		public Color color = Color.white;

		public float timeToShow = 0.1f;

		protected override void OnExecute()
		{
			Debug.DrawLine(this.from.value, this.to.value, this.color, this.timeToShow);
			base.EndAction(new bool?(true));
		}
	}
}
