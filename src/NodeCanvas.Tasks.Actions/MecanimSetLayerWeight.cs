using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Mecanim"), Name("Set Layer Weight")]
	public class MecanimSetLayerWeight : ActionTask<Animator>
	{
		public BBParameter<int> layerIndex;

		[SliderField(0, 1)]
		public BBParameter<float> layerWeight;

		[SliderField(0, 1)]
		public float transitTime;

		private float currentValue;

		protected override string info
		{
			get
			{
				return string.Concat(new object[]
				{
					"Set Layer ",
					this.layerIndex,
					", weight ",
					this.layerWeight
				});
			}
		}

		protected override void OnExecute()
		{
			this.currentValue = base.agent.GetLayerWeight(this.layerIndex.value);
		}

		protected override void OnUpdate()
		{
			base.agent.SetLayerWeight(this.layerIndex.value, Mathf.Lerp(this.currentValue, this.layerWeight.value, base.elapsedTime / this.transitTime));
			if (base.elapsedTime >= this.transitTime)
			{
				base.EndAction(new bool?(true));
			}
		}
	}
}
