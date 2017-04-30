using System;
using UnityEngine;

namespace Assets.ThridPartyTool.Tools.LetsLua.NodeCanvas.Builtin
{
	public abstract class LetsLuaConditionTask : LetsLuaTask
	{
		public static Color DefaultColor = new Color(0.2823f, 0.8156f, 0.5058f);

		public abstract string ExportNodeCode();
	}
}
