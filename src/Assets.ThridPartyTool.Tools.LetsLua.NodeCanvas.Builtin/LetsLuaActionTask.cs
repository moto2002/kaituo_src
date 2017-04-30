using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.ThridPartyTool.Tools.LetsLua.NodeCanvas.Builtin
{
	public abstract class LetsLuaActionTask : LetsLuaTask
	{
		public static Color DefaultColor = new Color(0.572549045f, 0.572549045f, 0.807843149f);

		public abstract string[] EnumTypes
		{
			get;
		}

		public abstract string ExportNodeCode(Dictionary<string, string> childrenPartCode);
	}
}
