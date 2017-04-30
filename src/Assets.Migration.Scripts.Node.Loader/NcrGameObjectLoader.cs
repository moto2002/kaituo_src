using Assets.Migration.Scripts.Node.ResourceLoader.Core;
using System;
using System.Collections.Generic;

namespace Assets.Migration.Scripts.Node.Loader
{
	public class NcrGameObjectLoader : NcrLoader
	{
		private List<NcrData> loadDatas = new List<NcrData>();

		public override void Clear()
		{
			this.loadDatas.Clear();
			base.Clear();
		}

		protected override void OnAppend(NcrData data)
		{
			this.loadDatas.Add(data);
		}

		protected override void OnStartLoad()
		{
			this.OnLoadCompleteSignal.Dispatch(this);
		}
	}
}
