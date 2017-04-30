using Assets.Tools.Script.Attributes;
using System;

namespace Assets.Scripts.Data.Scene.Element
{
	public class ChangeRegionData : ElementData
	{
		[InspectorStyle("AreaId", "AreaIdSelector")]
		public string AreaId;

		[InspectorStyle("WaypointsId", "ChangeRegionWaypointsSelector")]
		public string WaypointsId;
	}
}
