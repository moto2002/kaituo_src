using Assets.Tools.Script.Editortool;
using System;
using UnityEngine;

namespace XQ.ProjectX.Config
{
	public class TalentPathConfig : IEditorFilePathData, IIDData, INameData
	{
		public string TalentGroupID = string.Empty;

		public string FromTalentID = string.Empty;

		public string ToTalentID = string.Empty;

		public int PassLevel;

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
			return this.FromTalentID + this.ToTalentID;
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
