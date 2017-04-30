using Assets.Tools.Script.Attributes;
using Assets.Tools.Script.Editortool;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace XQ.ProjectX.Config
{
	public class SceneConfig : IEditorFilePathData, IIDData, INameData
	{
		public string Id = string.Empty;

		[InspectorStyle("AreaId", "AreaIdSelector")]
		public string AreaId = string.Empty;

		public string Name = string.Empty;

		[InspectorStyle("Img", "GRImgNameSelector", new object[]
		{
			"Assets/GameResource/Texture/GameScene/SceneBk"
		})]
		public string Img = string.Empty;

		[HideInInspector]
		public string TopPanel = "Default";

		[InspectorStyle("BGM", "GRBGMNameSelector")]
		public string BGM = string.Empty;

		public bool Active;

		public bool Visible;

		[InspectorStyle("ElementList", "SceneElementList")]
		public List<string> ElementList;

		[InspectorStyle("NPCList", "NPCList")]
		public List<string> NPCList;

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
