using Assets.Scripts.Service;
using Assets.Tools.Script.Attributes;
using Assets.Tools.Script.Editortool;
using System;
using UnityEngine;

namespace Assets.Scripts.Data.Player
{
	public class ItemConfig : IEditorFilePathData, IIDData, INameData
	{
		public string ItemId = string.Empty;

		[InspectorStyle("Type", "IntEnum", new object[]
		{
			typeof(UnitType)
		})]
		public int ItemType;

		[InspectorStyle("Avatar", "GRImgNameNoPathSelector", new object[]
		{
			"Assets/GameResource/Texture/UnitAvatar"
		})]
		public string Avatar = string.Empty;

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
			return this.ItemId;
		}

		public string GetDataId()
		{
			return this.ItemId;
		}

		public void SetDataId(string id)
		{
			this.ItemId = id;
		}
	}
}
