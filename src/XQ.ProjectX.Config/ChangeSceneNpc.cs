using Assets.Tools.Script.Attributes;
using System;

namespace XQ.ProjectX.Config
{
	public class ChangeSceneNpc
	{
		[InspectorStyle("AreaId", "AreaIdSelector")]
		public string AreaId = string.Empty;

		[InspectorStyle("SceneId", "GameSceneIdSelector")]
		public string SceneId = string.Empty;

		[InspectorStyle("NpcId", "NPCIdSelector")]
		public string NpcId = string.Empty;

		public bool Visible;
	}
}
