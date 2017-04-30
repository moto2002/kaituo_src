using Assets.Scripts.Tool;
using LitJson;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;

namespace Assets.Scripts.Condition
{
	[Category("✫ GOG/Battle"), Name("MainTarget is own unit")]
	public class MainTargetIsSelfUnit : ConditionTask
	{
		protected override bool OnCheck()
		{
			JsonData value = base.blackboard.GetValue<JsonData>("BattleData");
			if (value == null)
			{
				return false;
			}
			int value2 = value.GetValue("UserCamp", -1);
			int value3 = value.GetValue("MainTargetCamp", -2);
			return value2 == value3;
		}
	}
}
