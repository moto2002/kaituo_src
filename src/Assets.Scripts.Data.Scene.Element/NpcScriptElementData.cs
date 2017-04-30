using Assets.Tools.Script.Attributes;
using System;

namespace Assets.Scripts.Data.Scene.Element
{
	public class NpcScriptElementData : ElementData
	{
		[InspectorStyle("ScriptId", "LuaScriptId")]
		public string ScriptId = string.Empty;
	}
}
