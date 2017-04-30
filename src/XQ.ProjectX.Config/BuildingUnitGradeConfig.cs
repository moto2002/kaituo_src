using Assets.Tools.Script.Attributes;
using Assets.Tools.Script.Editortool;
using System;
using UnityEngine;

namespace XQ.ProjectX.Config
{
	public class BuildingUnitGradeConfig : IEditorFilePathData, IIDData, INameData
	{
		public string BuildingID = string.Empty;

		public int BuildingLevel;

		public string TalentID;

		public int TalentLevel;

		[InspectorStyle("UnitID", "UnitCardIdSelector")]
		public string UnitID = string.Empty;

		public int UnitLevel;

		public int UnitCapacity;

		public int UnitOutput;

		public int Gold;

		public int Wood;

		public int Ore;

		public int Food;

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
			return string.Concat(new object[]
			{
				this.BuildingID,
				"_",
				this.UnitID,
				"_",
				this.BuildingLevel.ToString(),
				"_",
				this.UnitLevel,
				"_",
				this.UnitCapacity,
				"_",
				this.UnitOutput,
				"_",
				this.Gold,
				"_",
				this.Wood,
				"_",
				this.Ore,
				"_",
				this.Food,
				"_",
				this.TalentID,
				"_",
				this.TalentLevel
			});
		}

		public string GetDataId()
		{
			return string.Concat(new object[]
			{
				this.BuildingID,
				"_",
				this.UnitID,
				"_",
				this.BuildingLevel.ToString(),
				"_",
				this.UnitLevel,
				"_",
				this.UnitCapacity,
				"_",
				this.UnitOutput,
				"_",
				this.Gold,
				"_",
				this.Wood,
				"_",
				this.Ore,
				"_",
				this.Food,
				"_",
				this.TalentID,
				"_",
				this.TalentLevel
			});
		}

		public void SetDataId(string id)
		{
			this.UnitID = id;
		}
	}
}
