using Assets.Tools.Script.Attributes;
using System;

namespace XQ.ProjectX.Config
{
	public class TaskAddSceneElementToScene
	{
		[InspectorStyle("SceneId", "GameSceneIdSelector")]
		public string SceneId = string.Empty;

		[InspectorStyle("NPCId", "SceneElementIdSelector")]
		public string ElementId = string.Empty;
	}
}
