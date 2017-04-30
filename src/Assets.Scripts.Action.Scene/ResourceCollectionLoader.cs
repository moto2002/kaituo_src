using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Action.Scene
{
	[Category("obsolete/Scene"), Name("Resource auto loader")]
	public class ResourceCollectionLoader : ActionTask
	{
		private int loadingCharacterCount;

		private Dictionary<int, int> toLoadUnit = new Dictionary<int, int>();

		protected override void OnExecute()
		{
		}
	}
}
