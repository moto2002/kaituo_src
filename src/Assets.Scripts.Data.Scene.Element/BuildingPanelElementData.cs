using Assets.Tools.Script.Attributes;
using System;
using XQ.ProjectX.Service;

namespace Assets.Scripts.Data.Scene.Element
{
	public class BuildingPanelElementData : ElementData
	{
		[InspectorStyle("ElementPanel", "StringEnum", new object[]
		{
			typeof(BuildingPanelName)
		})]
		public string ElementPanel = string.Empty;

		public string ElementPart = string.Empty;
	}
}
