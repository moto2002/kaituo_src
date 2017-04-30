using System;
using System.Collections.Generic;

namespace XQ.ProjectX.Config
{
	public class TaskTemplate_5 : TaskTemplateArg
	{
		public string Story_1 = string.Empty;

		public string Story_3 = string.Empty;

		public string Story_4 = string.Empty;

		public string Story_5 = string.Empty;

		public string Story_6 = string.Empty;

		public int BattleId;

		public List<ChangeNpcElement> AccessTaskChangeElement = new List<ChangeNpcElement>();

		public List<ChangeNpcElement> WinBattleChangeElement = new List<ChangeNpcElement>();

		public List<ChangeNpcElement> CompleteTaskChangeElement = new List<ChangeNpcElement>();

		public List<ChangeSceneNpc> AccessTaskChangeSceneNpc = new List<ChangeSceneNpc>();

		public List<ChangeSceneNpc> WinBattleChangeSceneNpc = new List<ChangeSceneNpc>();

		public List<ChangeSceneNpc> CompleteTaskChangeSceneNpc = new List<ChangeSceneNpc>();

		public List<ChangeSceneElement> AccessTaskChangeSceneElement = new List<ChangeSceneElement>();

		public List<ChangeSceneElement> WinBattleChangeSceneElement = new List<ChangeSceneElement>();

		public List<ChangeSceneElement> CompleteTaskChangeSceneElement = new List<ChangeSceneElement>();

		public List<PointChange> AccessPointChange = new List<PointChange>();

		public List<PointChange> CompletePointChange = new List<PointChange>();

		public List<PathChange> AccessPathChange = new List<PathChange>();

		public List<PathChange> CompletePathChange = new List<PathChange>();

		public string BackStory = string.Empty;
	}
}
