using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Utility"), Description("Plays a 'Beep' in editor only")]
	public class DebugBeep : ActionTask
	{
		protected override void OnExecute()
		{
			base.EndAction();
		}
	}
}
