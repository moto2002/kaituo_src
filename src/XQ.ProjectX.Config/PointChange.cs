using Assets.Tools.Script.Attributes;
using System;

namespace XQ.ProjectX.Config
{
	public class PointChange
	{
		[InspectorStyle("AreaId", "AreaIdSelector")]
		public string AreaId = string.Empty;

		[InspectorStyle("MapPointId", "WaypointsIdSelector")]
		public string MapPointId = string.Empty;

		public bool Active;

		public bool Visible;
	}
}
