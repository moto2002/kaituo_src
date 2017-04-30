using Assets.Tools.Script.Attributes;
using System;
using XQ.ProjectX.Service;

namespace Assets.Scripts.Data.Scene.Element
{
	public class TaskPanelElementData : ElementData
	{
		[InspectorStyle("TaskType", "IntEnum", new object[]
		{
			typeof(TaskType)
		})]
		public int TaskType = -1;
	}
}
