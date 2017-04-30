using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;

namespace Assets.Scripts.Action.Scene
{
	[Category("obsolete/Scene"), Name("Apply resource binder")]
	public class ApplyPrefabResource : ActionTask
	{
		public BBParameter<string> PrefabName;

		protected override void OnExecute()
		{
			base.EndAction();
		}
	}
}
