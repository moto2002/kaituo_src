using Assets.Scripts.Data.Scene.Element;
using System;
using UnityEngine;
using XQ.Game.Data.Attr;

namespace XQ.ProjectX.Config
{
	public class SceneElementType
	{
		[ElementData(typeof(SwitchSceneElementData))]
		public const string SwitchScene = "SwitchScene";

		[HideInInspector]
		public const string Npc = "Npc";

		public const string Back = "Back";

		public const string SceneAcceptTask = "SceneAcceptTask";

		[ElementData(typeof(ChangeRegionData))]
		public const string ChangeRegion = "ChangeRegion";

		[ElementData(typeof(FightingData))]
		public const string Fighting = "Fighting";

		[ElementData(typeof(NpcScriptElementData))]
		public const string NpcTalkScript = "NpcTalkScript";

		[ElementData(typeof(FuncSceneNPanelData))]
		public const string FuncSceneNPanel = "FuncSceneNPanel";

		public const string NpcTask = "NpcTask";

		[ElementData(typeof(TaskPanelElementData))]
		public const string TaskPanel = "TaskPanel";

		[ElementData(typeof(BuildingPanelElementData))]
		public const string SceneElementPanel = "SceneElementPanel";

		[ElementData(typeof(TeamIndexElementData))]
		public const string TeamIndex = "TeamIndex";

		[ElementData(typeof(TeamTypeElementData))]
		public const string TeamType = "TeamType";

		[ElementData(typeof(StoreData))]
		public const string Store = "Store";

		[ElementData(typeof(MercearyGuildData))]
		public const string MercearyGuild = "MercearyGuild";
	}
}
