using Assets.Scripts.Data.Scene.Element;
using Assets.Tools.Script.Attributes;
using Assets.Tools.Script.Editortool;
using System;
using UnityEngine;

namespace XQ.ProjectX.Config
{
	public class SceneElementConfig : IEditorFilePathData, IIDData, INameData
	{
		public string Id = string.Empty;

		[InspectorStyle("AreaId", "AreaIdSelector")]
		public string AreaId = string.Empty;

		public string Name = string.Empty;

		[InspectorStyle("Type", "StringEnum", new object[]
		{
			typeof(SceneElementType)
		})]
		public string Type = string.Empty;

		[InspectorStyle("ViewType", "StringEnum", new object[]
		{
			typeof(SceneElementViewType)
		})]
		public string ViewType = string.Empty;

		[InspectorStyle("Img", "GRImgNameSelector", new object[]
		{
			"Assets/GameResource/Texture/GameScene/Element",
			"Assets/GameResource/Texture/UnitAvatar"
		})]
		public string Img = string.Empty;

		public string LabelName = string.Empty;

		public int SortIndex;

		public bool Active;

		public bool Visible;

		[HideInInspector]
		public bool IsDefault;

		public ElementData Data;

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
			return this.Id;
		}

		public string GetDataId()
		{
			return this.Id;
		}

		public void SetDataId(string id)
		{
			this.Id = id;
		}
	}
}
