using Assets.Tools.Script.Editortool;
using System;
using UnityEngine;

namespace XQ.ProjectX.Config
{
	public class BuildingGradeConfig : IEditorFilePathData, IIDData, INameData
	{
		public string BuildingID = string.Empty;

		public int Level;

		public int Talent;

		public int TalentMax;

		public int Capacity;

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
			return this.BuildingID + "_" + this.Level.ToString();
		}

		public string GetDataId()
		{
			return this.BuildingID + "_" + this.Level.ToString();
		}

		public void SetDataId(string id)
		{
			this.BuildingID = id;
		}
	}
}
