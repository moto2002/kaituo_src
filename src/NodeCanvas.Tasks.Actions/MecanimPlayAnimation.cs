using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Mecanim"), Name("Play Animation")]
	public class MecanimPlayAnimation : ActionTask<Animator>
	{
		public BBParameter<int> layerIndex;

		[RequiredField]
		public BBParameter<string> stateName;

		[SliderField(0, 1)]
		public float transitTime = 0.25f;

		public bool waitUntilFinish;

		private AnimatorStateInfo stateInfo;

		private bool played;

		protected override string info
		{
			get
			{
				return "Anim '" + this.stateName.ToString() + "'";
			}
		}

		protected override void OnExecute()
		{
			this.played = false;
			AnimatorStateInfo currentAnimatorStateInfo = base.agent.GetCurrentAnimatorStateInfo(this.layerIndex.value);
			base.agent.CrossFade(this.stateName.value, this.transitTime / currentAnimatorStateInfo.length, this.layerIndex.value);
		}

		protected override void OnUpdate()
		{
			this.stateInfo = base.agent.GetCurrentAnimatorStateInfo(this.layerIndex.value);
			if (this.waitUntilFinish)
			{
				if (this.stateInfo.IsName(this.stateName.value))
				{
					this.played = true;
					if (base.elapsedTime >= this.stateInfo.length / base.agent.speed)
					{
						base.EndAction();
					}
				}
				else if (this.played)
				{
					base.EndAction();
				}
			}
			else if (base.elapsedTime >= this.transitTime)
			{
				base.EndAction();
			}
		}
	}
}
