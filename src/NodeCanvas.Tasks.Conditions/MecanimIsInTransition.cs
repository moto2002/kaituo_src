using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("Mecanim"), Name("Is In Transition")]
	public class MecanimIsInTransition : ConditionTask<Animator>
	{
		public BBParameter<int> layerIndex;

		protected override string info
		{
			get
			{
				return "Mec.Is In Transition";
			}
		}

		protected override bool OnCheck()
		{
			return base.agent.IsInTransition(this.layerIndex.value);
		}
	}
}
