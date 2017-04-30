using Assets.Scripts.Tool;
using LitJson;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;

namespace Assets.Scripts.Condition
{
	[Category("✫ GOG/Battle"), Name("Attacker is red unit")]
	public class AttackerIsRedUnit : ConditionTask
	{
		protected override bool OnCheck()
		{
			JsonData value = base.blackboard.GetValue<JsonData>("BattleData");
			if (value == null)
			{
				return false;
			}
			int value2 = value.GetValue("AttackerCamp", -1);
			return 1 == value2;
		}
	}
}
