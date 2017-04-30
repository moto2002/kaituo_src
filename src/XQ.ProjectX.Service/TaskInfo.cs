using System;
using System.Collections.Generic;

namespace XQ.ProjectX.Service
{
	public class TaskInfo
	{
		public string TaskId;

		public string AreaId = string.Empty;

		public int Type;

		public int Status;

		public List<int> AwardClaim;

		public string CDStartTime;

		public Dictionary<string, string> Blackboard;
	}
}
