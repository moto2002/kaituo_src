using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("GameObject"), Name("Target Within Distance")]
	public class CheckDistanceToGameObject : ConditionTask<Transform>
	{
		[RequiredField]
		public BBParameter<GameObject> checkTarget;

		public CompareMethod checkType = CompareMethod.LessThan;

		public BBParameter<float> distance = 10f;

		[SliderField(0f, 0.1f)]
		public float floatingPoint = 0.05f;

		protected override string info
		{
			get
			{
				return string.Concat(new object[]
				{
					"Distance",
					OperationTools.GetCompareString(this.checkType),
					this.distance,
					" to ",
					this.checkTarget
				});
			}
		}

		protected override bool OnCheck()
		{
			return OperationTools.Compare(Vector3.Distance(base.agent.position, this.checkTarget.value.transform.position), this.distance.value, this.checkType, this.floatingPoint);
		}
	}
}
