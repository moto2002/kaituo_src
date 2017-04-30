using ParadoxNotion.Design;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.ThridPartyTool.Tools.LetsLua.NodeCanvas.Builtin
{
	[Description("Please resolve the MissingTask issue by either replacing the task or importing the missing task type in the project"), DoNotList]
	public class LetsLuaMissingAction : LetsLuaActionTask
	{
		public string missingType;

		public string recoveryState;

		public override string[] EnumTypes
		{
			get
			{
				return new string[]
				{
					"Out"
				};
			}
		}

		protected override string info
		{
			get
			{
				return string.Format("<color=#ff6457>* {0} *</color>", this.missingType.Split(new char[]
				{
					'.'
				}).Last<string>());
			}
		}

		public override string ExportNodeCode(Dictionary<string, string> childrenPartCode)
		{
			return string.Empty;
		}
	}
}
