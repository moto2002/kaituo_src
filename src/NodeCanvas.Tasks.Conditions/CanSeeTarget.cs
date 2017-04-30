using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("GameObject"), Description("A combination of line of sight and view angle check")]
	public class CanSeeTarget : ConditionTask<Transform>
	{
		[RequiredField]
		public BBParameter<GameObject> target;

		public BBParameter<float> maxDistance = 50f;

		[SliderField(1, 180)]
		public BBParameter<float> viewAngle = 70f;

		public Vector3 offset;

		private RaycastHit hit;

		protected override string info
		{
			get
			{
				return "Can See " + this.target.ToString();
			}
		}

		protected override bool OnCheck()
		{
			Transform transform = this.target.value.transform;
			return (base.agent.position - transform.position).magnitude <= this.maxDistance.value && (!Physics.Linecast(base.agent.position + this.offset, transform.position + this.offset, out this.hit) || !(this.hit.collider != transform.GetComponent<Collider>())) && Vector3.Angle(transform.position - base.agent.position, base.agent.forward) < this.viewAngle.value;
		}
	}
}
