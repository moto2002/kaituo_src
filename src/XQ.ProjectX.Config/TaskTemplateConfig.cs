using Assets.Tools.Script.Attributes;
using Assets.Tools.Script.Editortool;
using System;
using UnityEngine;

namespace XQ.ProjectX.Config
{
	public class TaskTemplateConfig : IEditorFilePathData, IIDData, INameData
	{
		public string TaskConfigId = string.Empty;

		[InspectorStyle("ScriptName", "LuaScriptId")]
		public string ScriptName = string.Empty;

		public string LLGraphName = string.Empty;

		public TaskTemplateArg Blackboard = new TaskTemplateArg();

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
			return this.TaskConfigId;
		}

		public string GetDataId()
		{
			return this.TaskConfigId;
		}

		public void SetDataId(string id)
		{
			this.TaskConfigId = id;
		}
	}
}
