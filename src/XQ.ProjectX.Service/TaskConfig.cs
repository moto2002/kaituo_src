using System;
using System.Collections.Generic;

namespace XQ.ProjectX.Service
{
	public class TaskConfig
	{
		public string TaskConfigId = string.Empty;

		public string Name = string.Empty;

		public int LevelBegin;

		public int LevelEnd;

		public string AreaId = string.Empty;

		public int Energy;

		public string Icon = string.Empty;

		public int Type;

		public string Category = string.Empty;

		public bool IsEvent;

		public int ReceiveFromType;

		public string ReceiveFrom = string.Empty;

		public int SubmitToType;

		public string SubmitTo = string.Empty;

		public string BattleId = string.Empty;

		public int CDMinutes;

		public int ExpAward;

		public int FameAward;

		public int TerrorAward;

		public int GoldAward;

		public int WoodAward;

		public int OreAward;

		public int FoodAward;

		public int ItemAwardCount;

		public string ItemAward1;

		public int ItemAwardCount1;

		public string ItemAward2;

		public int ItemAwardCount2;

		public string ItemAward3;

		public int ItemAwardCount3;

		public string ItemAward4;

		public int ItemAwardCount4;

		public string TaskFollow = string.Empty;

		public string ScriptName = string.Empty;

		public string Description = string.Empty;

		public Dictionary<string, string> Blackboard;
	}
}
