using System;

namespace Assets.Scripts.Net
{
	[Serializable]
	public class ProjectXNotice
	{
		public int ID;

		public int Type;

		public string Body = string.Empty;

		public string Date = string.Empty;
	}
}
