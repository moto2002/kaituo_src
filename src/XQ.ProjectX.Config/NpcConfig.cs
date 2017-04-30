using Assets.Tools.Script.Attributes;
using Assets.Tools.Script.Editortool;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace XQ.ProjectX.Config
{
	public class NpcConfig : IEditorFilePathData, IIDData, INameData
	{
		public string Id = string.Empty;

		[InspectorStyle("AreaId", "AreaIdSelector")]
		public string AreaId = string.Empty;

		public string Name = string.Empty;

		[InspectorStyle("Avatar", "GRImgNameNoPathSelector", new object[]
		{
			"Assets/GameResource/Texture/UnitAvatar"
		})]
		public string Avatar = string.Empty;

		public bool Active;

		public bool Visible;

		public int Friendliness;

		[InspectorStyle("WelcomeDialog", "TextArea", new object[]
		{
			-1,
			50
		})]
		public string WelcomeDialog = string.Empty;

		public Vector2 ViewPosition;

		[InspectorStyle("ElementList", "NPCElementList")]
		public List<string> ElementList;

		public List<NPCRelationshipConfig> Relationship;

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
