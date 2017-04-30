using System;

namespace XQ.ProjectX.Config
{
	[Serializable]
	public class MapPathConfig
	{
		public string AreaId = string.Empty;

		public string MapPathId = string.Empty;

		public float SpeedMagnification = 1f;

		public string From = string.Empty;

		public string To = string.Empty;

		public bool Visible;

		public bool Active;
	}
}
