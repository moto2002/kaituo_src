using Assets.Tools.Script.Attributes;
using System;

namespace XQ.ProjectX.Config
{
	public class ChangeSceneElement
	{
		[InspectorStyle("AreaId", "AreaIdSelector")]
		public string AreaId = string.Empty;

		[InspectorStyle("SceneId", "GameSceneIdSelector")]
		public string SceneId = string.Empty;

		[InspectorStyle("SceneElementId", "NpcElement")]
		public string SceneElementId = string.Empty;

		public bool Visible;
	}
}
