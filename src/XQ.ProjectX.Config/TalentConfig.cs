using Assets.Scripts.Service;
using Assets.Tools.Script.Attributes;
using Assets.Tools.Script.Editortool;
using System;
using UnityEngine;

namespace XQ.ProjectX.Config
{
	public class TalentConfig : IEditorFilePathData, IIDData, INameData
	{
		public string TalentGroupID = string.Empty;

		public string TalentID = string.Empty;

		public int TalentLevel;

		[InspectorStyle("TalentType", "IntEnum", new object[]
		{
			typeof(TalentType)
		})]
		public int TalentType;

		public int TalentLevelPoint;

		public int PlayerLevel;

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
			return this.TalentGroupID + this.TalentID;
		}

		public string GetDataId()
		{
			return this.TalentGroupID;
		}

		public void SetDataId(string id)
		{
			this.TalentGroupID = id;
		}
	}
}
