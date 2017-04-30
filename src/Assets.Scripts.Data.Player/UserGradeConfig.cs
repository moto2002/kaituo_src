using Assets.Tools.Script.Editortool;
using System;
using UnityEngine;

namespace Assets.Scripts.Data.Player
{
	public class UserGradeConfig : IEditorFilePathData, IIDData, INameData
	{
		public int Level;

		public int ExperienceFrom;

		public int ExperienceTo;

		public int TaskLevel;

		public int BuildingLevel;

		public int InventoryCapacity;

		public int EnergyCapacity;

		public int EnergyOutput;

		public int GoldCapacity;

		public int GoldOutput;

		public int WoodCapacity;

		public int WoodOutput;

		public int OreCapacity;

		public int OreOutput;

		public int FoodCapacity;

		public int FoodOutput;

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
			return this.Level.ToString();
		}

		public string GetDataId()
		{
			return this.Level.ToString();
		}

		public void SetDataId(string id)
		{
		}
	}
}
