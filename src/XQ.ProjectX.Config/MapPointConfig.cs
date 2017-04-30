using System;

namespace XQ.ProjectX.Config
{
	[Serializable]
	public class MapPointConfig
	{
		public string AreaId = string.Empty;

		public string MapPointId = string.Empty;

		public string SceneId = string.Empty;

		public bool Active;

		public bool Visible;
	}
}
