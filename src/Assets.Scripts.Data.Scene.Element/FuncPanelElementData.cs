using Assets.Tools.Script.Attributes;
using System;
using XQ.ProjectX.Config;

namespace Assets.Scripts.Data.Scene.Element
{
	public class FuncPanelElementData : ElementData
	{
		[InspectorStyle("PanelName", "StringEnum", new object[]
		{
			typeof(SceneElementFuncPanelType)
		})]
		public string PanelName = string.Empty;

		[InspectorStyle("SceneId", "GameSceneIdSelector")]
		public string SceneId = string.Empty;
	}
}
