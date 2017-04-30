using System;
using System.Collections.Generic;

namespace XQ.ProjectX.Config
{
	public class TaskTemplate_2 : TaskTemplateArg
	{
		public string Story_1 = string.Empty;

		public string Story_2 = string.Empty;

		public List<ChangeNpcElement> AccessTaskChangeElement = new List<ChangeNpcElement>();

		public List<ChangeNpcElement> CompleteTaskChangeElement = new List<ChangeNpcElement>();

		public List<ChangeSceneNpc> AccessTaskChangeSceneNpc = new List<ChangeSceneNpc>();

		public List<ChangeSceneNpc> CompleteTaskChangeSceneNpc = new List<ChangeSceneNpc>();

		public List<ChangeSceneElement> AccessTaskChangeSceneElement = new List<ChangeSceneElement>();

		public List<ChangeSceneElement> CompleteTaskChangeSceneElement = new List<ChangeSceneElement>();

		public string BackStory = string.Empty;
	}
}
