using Assets.Scripts.Action.Core;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using XQ.Game.Util;

namespace Assets.Scripts.Action.Blackboard
{
	[Category("obsolete/Blackboard"), Name("Random variable")]
	public class RandomVariable : DevisableAction
	{
		public BBParameter<int> TargetVariable;

		public BBParameter<int> From;

		public BBParameter<int> To;

		protected override void OnExecute()
		{
			int value = ToolUtil.Random(this.From.value, this.To.value + 1);
			this.TargetVariable.value = value;
			base.EndAction();
		}
	}
}
