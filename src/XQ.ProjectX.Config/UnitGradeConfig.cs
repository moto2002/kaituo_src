using Assets.Tools.Script.Attributes;
using Assets.Tools.Script.Editortool;
using System;
using UnityEngine;

namespace XQ.ProjectX.Config
{
	public class UnitGradeConfig : IEditorFilePathData, IIDData, INameData
	{
		[InspectorStyle("UnitID", "UnitCardIdSelector")]
		public string UnitID = string.Empty;

		public int UnitLevel;

		public string TalentID;

		public int TalentLevel;

		public int ExperienceFrom;

		public int ExperienceTo;

		public int Talent;

		public int TalentMax;

		public int Health;

		public int Attack;

		public int Speed;

		public int Move;

		public int ChargingMax;

		public int Cost;

		public int MoraleCost;

		public int CostOnKill;

		public int MoraleCostOnKill;

		public int ControlRange;

		public string AI = string.Empty;

		public string ActiveSkill = string.Empty;

		public string PassiveSkill1 = string.Empty;

		public string PassiveSkill2 = string.Empty;

		public string PassiveSkill3 = string.Empty;

		public string PassiveSkill4 = string.Empty;

		public string CommanderPassiveSkill = string.Empty;

		public string CommanderSkill1 = string.Empty;

		public int CommanderSkill1Level;

		public string CommanderSkill2 = string.Empty;

		public int CommanderSkill2Level;

		public string CommanderSkill3 = string.Empty;

		public int CommanderSkill3Level;

		public string CommanderSkill4 = string.Empty;

		public int CommanderSkill4Level;

		public string CommanderSkill5 = string.Empty;

		public int CommanderSkill5Level;

		public int UnitCostLimit;

		public int SpellCostLimit;

		public int EquipmentCostLimit;

		[InspectorStyle("Description", "TextArea", new object[]
		{
			-1,
			50
		})]
		public string Description = string.Empty;

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
			return this.UnitID + this.UnitLevel.ToString();
		}

		public string GetDataId()
		{
			return this.UnitID + this.UnitLevel.ToString();
		}

		public void SetDataId(string id)
		{
			this.UnitID = id;
		}
	}
}
