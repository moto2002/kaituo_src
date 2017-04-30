using Assets.Scripts.Service;
using Assets.Tools.Script.Attributes;
using Assets.Tools.Script.Editortool;
using System;
using System.Collections.Generic;
using UnityEngine;
using XQ.ProjectX.Service;

namespace XQ.ProjectX.Config
{
	public class UnitConfig : IEditorFilePathData, IIDData, INameData
	{
		public string UnitID;

		public string Name;

		[InspectorStyle("Nationality", "IntEnum", new object[]
		{
			typeof(NationalityType)
		})]
		public int Nationality;

		[InspectorStyle("Type", "IntEnum", new object[]
		{
			typeof(UnitType)
		})]
		public int Type;

		[InspectorStyle("Class", "IntEnum", new object[]
		{
			typeof(UnitClass)
		})]
		public int Class;

		[InspectorStyle("Avatar", "GRImgNameNoPathSelector", new object[]
		{
			"Assets/GameResource/Texture/UnitAvatar"
		})]
		public string Avatar;

		public int NationalityFameMin;

		public int NationalityFameMax;

		public int FameMin;

		public int FameMax;

		public int TerrorMin;

		public int TerrorMax;

		public string DeadSE;

		public string SkillTags = string.Empty;

		public string TaskTags = string.Empty;

		[InspectorStyle("Description", "TextArea", new object[]
		{
			-1,
			50
		})]
		public string Description = string.Empty;

		public List<UnitCommandConfig> UnitCommandConfig;

		[HideInInspector]
		public string PathInEditor;

		public string CommandSkills;

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
			return this.UnitID;
		}

		public string GetDataId()
		{
			return this.UnitID;
		}

		public void SetDataId(string id)
		{
			this.UnitID = id;
		}
	}
}
