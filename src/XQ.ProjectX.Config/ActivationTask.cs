using Assets.Tools.Script.Attributes;
using System;

namespace XQ.ProjectX.Config
{
	public class ActivationTask
	{
		[InspectorStyle("AreaId", "AreaIdSelector")]
		public string AreaId = string.Empty;

		[InspectorStyle("TaskId", "TaskIdSelector")]
		public string TaskId = string.Empty;
	}
}
