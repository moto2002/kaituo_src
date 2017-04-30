using Assets.Scripts.Service;
using Assets.Tools.Script.Attributes;
using Assets.Tools.Script.Editortool;
using System;
using UnityEngine;

namespace XQ.ProjectX.Config
{
	public class TalentFeeConfig : IEditorFilePathData, IIDData, INameData
	{
		[InspectorStyle("TalentType", "IntEnum", new object[]
		{
			typeof(TalentType)
		})]
		public int TalentType;

		public int TalentPointFrom;

		public int TalentPointTo;

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
			return this.TalentType.ToString() + this.TalentPointFrom.ToString() + this.TalentPointTo.ToString();
		}

		public string GetDataId()
		{
			return this.TalentType.ToString() + this.TalentPointFrom.ToString() + this.TalentPointTo.ToString();
		}

		public void SetDataId(string id)
		{
		}
	}
}
