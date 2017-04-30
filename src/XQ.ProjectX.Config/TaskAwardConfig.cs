using Assets.Tools.Script.Attributes;
using System;

namespace XQ.ProjectX.Config
{
	public class TaskAwardConfig
	{
		[InspectorStyle("AwardType", "IntEnum", new object[]
		{
			typeof(TaskAwardType)
		})]
		public int AwardType;

		[InspectorStyle("AwardId", "AwardItemIdSelector")]
		public string AwardId = string.Empty;

		public string AwardCount = string.Empty;
	}
}
