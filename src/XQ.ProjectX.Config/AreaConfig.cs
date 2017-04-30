using Assets.Tools.Script.Editortool;
using System;
using UnityEngine;

namespace XQ.ProjectX.Config
{
	public class AreaConfig : IEditorFilePathData, IIDData, INameData
	{
		public string AreaId = string.Empty;

		public string Name = string.Empty;

		public string SceneId = string.Empty;

		[HideInInspector]
		public string PathInEditor = string.Empty;

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
			return this.AreaId;
		}

		public string GetDataId()
		{
			return this.AreaId;
		}

		public void SetDataId(string id)
		{
			this.AreaId = id;
		}
	}
}
