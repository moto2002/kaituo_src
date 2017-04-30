using ParadoxNotion.Design;
using System;
using System.Linq;

namespace NodeCanvas.Framework.Internal
{
	[Description("Please resolve the MissingTask issue by either replacing the task or importing the missing task type in the project"), DoNotList]
	public class MissingCondition : ConditionTask
	{
		public string missingType;

		public string recoveryState;

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
	}
}
