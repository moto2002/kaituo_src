using Assets.Migration.Scripts.Node.ResourceLoader.Core;
using System;
using System.Collections.Generic;

namespace Assets.Migration.Scripts.Node.Loader
{
	public class NcrAudioLoader : NcrLoader
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
			for (int i = 0; i < this.loadDatas.Count; i++)
			{
				NcrData ncrData = this.loadDatas[i];
				for (int j = 0; j < ncrData.Path.Count; j++)
				{
					string text = ncrData.Path[j];
					string text2 = ncrData.BlackboardName[j];
				}
			}
			this.OnLoadCompleteSignal.Dispatch(this);
		}
	}
}
