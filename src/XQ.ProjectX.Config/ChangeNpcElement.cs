using Assets.Tools.Script.Attributes;
using System;

namespace XQ.ProjectX.Config
{
	public class ChangeNpcElement
	{
		[InspectorStyle("AreaId", "AreaIdSelector")]
		public string AreaId = string.Empty;

		[InspectorStyle("NpcId", "NPCIdSelector")]
		public string NpcId = string.Empty;

		[InspectorStyle("SceneElementId", "NpcElement")]
		public string SceneElementId = string.Empty;

		public bool Visible;
	}
}
