using Assets.Scripts.Tool;
using LitJson;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;

namespace Assets.Scripts.Condition
{
	[Category("✫ GOG/Battle"), Name("More then one beattacker")]
	public class MoreThenOneBeattacker : ConditionTask
	{
		protected override bool OnCheck()
		{
			JsonData value = base.blackboard.GetValue<JsonData>("BattleData");
			if (value == null)
			{
				return false;
			}
			int value2 = value.GetValue("TargetCount", -1);
			return value2 > 1;
		}
	}
}
