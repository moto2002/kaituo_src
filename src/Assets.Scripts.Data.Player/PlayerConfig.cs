using Assets.Tools.Script.Editortool;
using System;
using UnityEngine;

namespace Assets.Scripts.Data.Player
{
	public class PlayerConfig : IEditorFilePathData, IIDData, INameData
	{
		public int ID;

		public string Name = string.Empty;

		public string NickName = string.Empty;

		public int Experience;

		public int Level;

		public int BuildingLevel;

		public int InventoryCapacity;

		public int Diamond;

		public int Fame;

		public int Terror;

		public int Energy;

		public int EnergyCapacity;

		public int EnergyOutput;

		public int Gold;

		public int GoldCapacity;

		public int GoldOutput;

		public int Wood;

		public int WoodCapacity;

		public int WoodOutput;

		public int Ore;

		public int OreCapacity;

		public int OreOutput;

		public int Food;

		public int FoodCapacity;

		public int FoodOutput;

		public int TaskLevel;

		public string ResUpdateTime = string.Empty;

		public string WorldPosition = string.Empty;

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
			return this.Name;
		}

		public string GetDataId()
		{
			return this.Name;
		}

		public void SetDataId(string id)
		{
			this.Name = id;
		}
	}
}
