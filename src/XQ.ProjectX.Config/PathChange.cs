using Assets.Tools.Script.Attributes;
using System;

namespace XQ.ProjectX.Config
{
	public class PathChange
	{
		[InspectorStyle("AreaId", "AreaIdSelector")]
		public string AreaId = string.Empty;

		[InspectorStyle("MapPathId", "WayIdSelector")]
		public string MapPathId = string.Empty;

		public bool Active;

		public bool Visible;
	}
}
