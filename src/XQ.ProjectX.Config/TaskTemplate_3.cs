using System;
using System.Collections.Generic;

namespace XQ.ProjectX.Config
{
	public class TaskTemplate_3 : TaskTemplateArg
	{
		public string Story_1 = string.Empty;

		public string Story_2 = string.Empty;

		public List<ActivationTask> ActivationTask = new List<ActivationTask>();

		public List<ChangeNpcElement> AccessTaskChangeElement = new List<ChangeNpcElement>();

		public List<ChangeNpcElement> WinBattleChangeElement = new List<ChangeNpcElement>();

		public List<ChangeNpcElement> CompleteTaskChangeElement = new List<ChangeNpcElement>();

		public List<ChangeSceneNpc> AccessTaskChangeSceneNpc = new List<ChangeSceneNpc>();

		public List<ChangeSceneNpc> WinBattleChangeSceneNpc = new List<ChangeSceneNpc>();

		public List<ChangeSceneNpc> CompleteTaskChangeSceneNpc = new List<ChangeSceneNpc>();

		public List<ChangeSceneElement> AccessTaskChangeSceneElement = new List<ChangeSceneElement>();

		public List<ChangeSceneElement> WinBattleChangeSceneElement = new List<ChangeSceneElement>();

		public List<ChangeSceneElement> CompleteTaskChangeSceneElement = new List<ChangeSceneElement>();

		public int BattleId_1;

		public int BattleId_2;

		public int BattleId_3;

		public int BattleId_4;

		public string EventStory_1 = string.Empty;

		public string EventStory_2 = string.Empty;

		public string EventStory_3 = string.Empty;

		public string EventStory_4 = string.Empty;

		public string BattleId_1_WinStory = string.Empty;

		public string BattleId_1_FailStory = string.Empty;

		public string BattleId_2_WinStory = string.Empty;

		public string BattleId_2_FailStory = string.Empty;

		public string BattleId_3_WinStory = string.Empty;

		public string BattleId_3_FailStory = string.Empty;

		public string BattleId_4_WinStory = string.Empty;

		public string BattleId_4_FailStory = string.Empty;

		public string BackStory = string.Empty;
	}
}
