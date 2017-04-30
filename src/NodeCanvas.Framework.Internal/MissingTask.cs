using ParadoxNotion.Design;
using System;
using System.Linq;

namespace NodeCanvas.Framework.Internal
{
	[DoNotList]
	public class MissingTask : Task
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
