using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;

namespace Assets.Scripts.FightingScene.Tool
{
	[Category("✫ GOG/Battle"), Name("Is our camp")]
	public class OurCampCondition : ConditionTask
	{
		public BBParameter<int> UnitInstanceId;

		protected override bool OnCheck()
		{
			return false;
		}
	}
}
