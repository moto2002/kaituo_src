using Assets.Tools.Script.Attributes;
using System;

namespace Assets.Scripts.Data.Scene.Element
{
	public class SwitchSceneElementData : ElementData
	{
		[InspectorStyle("SceneId", "GameSceneIdSelector")]
		public string SceneId = string.Empty;
	}
}
