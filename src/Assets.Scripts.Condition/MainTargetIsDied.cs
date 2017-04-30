using Assets.Scripts.Tool;
using LitJson;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;

namespace Assets.Scripts.Condition
{
	[Category("✫ GOG/Battle"), Name("MainTarget is died")]
	public class MainTargetIsDied : ConditionTask
	{
		protected override bool OnCheck()
		{
			JsonData value = base.blackboard.GetValue<JsonData>("BattleData");
			return value != null && value.GetValue("IsMainTargetDied", false);
		}
	}
}
