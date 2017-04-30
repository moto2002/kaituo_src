using Assets.Tools.Script.Attributes;
using Assets.Tools.Script.Editortool;
using System;
using UnityEngine;

namespace XQ.ProjectX.Config
{
	public class NPCRelationshipConfig : IIDData, INameData
	{
		[InspectorStyle("NPCTo", "NPCIdSelector")]
		public string NPCTo = string.Empty;

		public int Friendliness;

		[HideInInspector]
		private string PathInEditor;

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
			return this.NPCTo;
		}

		public string GetDataId()
		{
			return this.NPCTo;
		}

		public void SetDataId(string id)
		{
			this.NPCTo = id;
		}
	}
}
