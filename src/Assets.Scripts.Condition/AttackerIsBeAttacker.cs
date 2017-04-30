using Assets.Scripts.Tool;
using LitJson;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;

namespace Assets.Scripts.Condition
{
	[Category("✫ GOG/Battle"), Name("Attacker is Beattacker")]
	public class AttackerIsBeAttacker : ConditionTask
	{
		protected override bool OnCheck()
		{
			JsonData value = base.blackboard.GetValue<JsonData>("BattleData");
			return value != null && value.GetValue("AttackerInstId", -1) == value.GetValue("MainTargetInstId", -2);
		}
	}
}
