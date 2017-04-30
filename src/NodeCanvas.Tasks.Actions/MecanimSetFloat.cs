using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Mecanim"), Name("Set Mecanim Float")]
	public class MecanimSetFloat : ActionTask<Animator>
	{
		[RequiredField]
		public BBParameter<string> parameter;

		public BBParameter<float> setTo;

		[SliderField(0, 1)]
		public float transitTime = 0.25f;

		private float currentValue;

		protected override string info
		{
			get
			{
				return string.Concat(new object[]
				{
					"Mec.SetFloat '",
					this.parameter,
					"' to ",
					this.setTo.ToString()
				});
			}
		}

		protected override void OnExecute()
		{
			if (this.transitTime <= 0f)
			{
				base.agent.SetFloat(this.parameter.value, this.setTo.value);
				base.EndAction();
				return;
			}
			this.currentValue = base.agent.GetFloat(this.parameter.value);
		}

		protected override void OnUpdate()
		{
			base.agent.SetFloat(this.parameter.value, Mathf.Lerp(this.currentValue, this.setTo.value, base.elapsedTime / this.transitTime));
			if (base.elapsedTime >= this.transitTime)
			{
				base.EndAction(new bool?(true));
			}
		}
	}
}
