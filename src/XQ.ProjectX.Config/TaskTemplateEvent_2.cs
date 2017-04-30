using Assets.Tools.Script.Attributes;
using System;

namespace XQ.ProjectX.Config
{
	public class TaskTemplateEvent_2 : TaskTemplateArg
	{
		[InspectorStyle("SceneId", "GameSceneIdSelector")]
		public string SceneId = string.Empty;

		public int BattleId;

		public string Story_1 = string.Empty;

		public string Select = string.Empty;

		public string BattleId_1_WinStory = string.Empty;

		public string BattleId_1_FailStory = string.Empty;
	}
}
