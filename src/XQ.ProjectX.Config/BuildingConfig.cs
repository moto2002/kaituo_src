using Assets.Tools.Script.Attributes;
using Assets.Tools.Script.Editortool;
using System;
using UnityEngine;
using XQ.ProjectX.Service;

namespace XQ.ProjectX.Config
{
	public class BuildingConfig : IEditorFilePathData, IIDData, INameData
	{
		public string BuildingID = string.Empty;

		public string Name = string.Empty;

		[InspectorStyle("Nationality", "IntEnum", new object[]
		{
			typeof(NationalityType)
		})]
		public int Nationality;

		public int Level;

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
			return this.BuildingID;
		}

		public string GetDataId()
		{
			return this.BuildingID;
		}

		public void SetDataId(string id)
		{
			this.BuildingID = id;
		}
	}
}
