using Assets.Tools.Script.Attributes;
using System;
using System.Collections.Generic;

namespace XQ.ProjectX.Config
{
	public class TaskNpcElementListChange
	{
		public enum AddOrCutData
		{
			Add,
			Cut
		}

		public TaskNpcElementListChange.AddOrCutData AddorCutData;

		[InspectorStyle("NPCId", "NPCIdSelector")]
		public string NPCId = string.Empty;

		[InspectorStyle("ElementList", "NPCElementList")]
		public List<string> ElementList = new List<string>();
	}
}
