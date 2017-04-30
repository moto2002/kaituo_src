using Assets.Scripts.Service;
using Assets.Tools.Script.Attributes;
using Assets.Tools.Script.Editortool;
using System;
using UnityEngine;
using XQ.ProjectX.Service;

namespace XQ.ProjectX.Config
{
	public class TaskConfig : IEditorFilePathData, IIDData, INameData
	{
		public string TaskConfigId = string.Empty;

		public string Name = string.Empty;

		public int LevelBegin;

		public int LevelEnd;

		[InspectorStyle("AreaId", "AreaIdSelector")]
		public string AreaId = string.Empty;

		[InspectorStyle("Icon", "GRImgNameSelector", new object[]
		{
			"Assets/GameResource/Texture/HeadPortrait",
			"Assets/GameResource/Texture/GameScene/Element"
		})]
		public string Icon = string.Empty;

		[InspectorStyle("Type", "IntEnum", new object[]
		{
			typeof(TaskType)
		})]
		public int Type;

		public string Category = string.Empty;

		public bool IsEvent;

		[InspectorStyle("ReceiveFromType", "IntEnum", new object[]
		{
			typeof(TaskAddressType)
		})]
		public int ReceiveFromType;

		[InspectorStyle("ReceiveFrom", "AddressReceiveFrom")]
		public string ReceiveFrom = string.Empty;

		[InspectorStyle("SubmitToType", "IntEnum", new object[]
		{
			typeof(TaskAddressType)
		})]
		public int SubmitToType;

		[InspectorStyle("SubmitTo", "AddressSubmitTo")]
		public string SubmitTo = string.Empty;

		public string BattleId = string.Empty;

		public int CDMinutes;

		public int ExpAward;

		public int FameAward;

		public int TerrorAward;

		public int GoldAward;

		public int WoodAward;

		public int OreAward;

		public int FoodAward;

		public int ItemAwardCount;

		public string ItemAward1 = string.Empty;

		public int ItemAwardCount1;

		public string ItemAward2 = string.Empty;

		public int ItemAwardCount2;

		public string ItemAward3 = string.Empty;

		public int ItemAwardCount3;

		public string ItemAward4 = string.Empty;

		public int ItemAwardCount4;

		public string TaskFollow = string.Empty;

		public string TargetMainDesc = string.Empty;

		public string Target1Desc = string.Empty;

		public string Target2Desc = string.Empty;

		public string Target3Desc = string.Empty;

		public string Target4Desc = string.Empty;

		[InspectorStyle("ScriptName", "LuaScriptId")]
		public string ScriptName = string.Empty;

		public string LLGraphName = string.Empty;

		public TaskTemplateArg Blackboard = new TaskTemplateArg();

		[HideInInspector]
		public string PathInEditor;

		public string EditorFilePath
		{
			get
			{
				if (this.PathInEditor == null)
				{
					this.PathInEditor = this.GetDataName();
				}
				return this.PathInEditor;
			}
			set
			{
				this.PathInEditor = value;
			}
		}

		public string GetDataName()
		{
			return this.TaskConfigId;
		}

		public string GetDataId()
		{
			return this.TaskConfigId;
		}

		public void SetDataId(string id)
		{
			this.TaskConfigId = id;
		}
	}
}
