using System;
using System.Collections.Generic;

namespace Assets.Migration.Scripts.Node.ResourceLoader.Core
{
	public class NcrData
	{
		public string OriginalParameter;

		public string OriginalPath;

		public string OriginalBlackboardName;

		public bool IsActive = true;

		public NcrType LoadType;

		public List<string> Parameter;

		public List<string> Path;

		public List<string> BlackboardName;

		public object CacheData;

		public void ClearRuntimeData()
		{
			this.Parameter = null;
			this.Path = null;
			this.BlackboardName = null;
			this.CacheData = null;
		}
	}
}
