using Assets.Migration.Scripts.Node.Loader;
using Assets.Migration.Scripts.Node.ResourceLoader.Core;
using Assets.Migration.Scripts.Node.ResourceLoader.Parser;
using NodeCanvas;
using NodeCanvas.BehaviourTrees;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Migration.Scripts.Node
{
	[Category("obsolete/Program"), Name("NodeCanvas resource table")]
	public class NcrLoadTable : BTNode
	{
		public List<NcrData> Datas = new List<NcrData>();

		private List<NcrLoader> loaders = new List<NcrLoader>();

		private List<NcrParser> parsers = new List<NcrParser>();

		private int loadState;

		private IBlackboard blackboard;

		private int loadCount;

		public NcrLoadTable()
		{
			NcrCharacterLoader ncrCharacterLoader = new NcrCharacterLoader();
			NcrAudioLoader ncrAudioLoader = new NcrAudioLoader();
			NcrGameObjectLoader ncrGameObjectLoader = new NcrGameObjectLoader();
			NcrGameObjectLoader item = new NcrGameObjectLoader();
			NcrGameObjectLoader ncrGameObjectLoader2 = new NcrGameObjectLoader();
			NcrCharacterParser ncrCharacterParser = new NcrCharacterParser();
			NcrAudioParser ncrAudioParser = new NcrAudioParser();
			NcrGameObjectParser ncrGameObjectParser = new NcrGameObjectParser();
			NcrSkillTagGameObjectParser ncrSkillTagGameObjectParser = new NcrSkillTagGameObjectParser();
			NcrBuffTagGameObjectParser ncrBuffTagGameObjectParser = new NcrBuffTagGameObjectParser();
			ncrCharacterParser.BindingLoader(ncrCharacterLoader);
			ncrAudioParser.BindingLoader(ncrAudioLoader);
			ncrGameObjectParser.BindingLoader(ncrGameObjectLoader);
			ncrBuffTagGameObjectParser.BindingLoader(ncrGameObjectLoader2);
			this.loaders.Add(ncrCharacterLoader);
			this.loaders.Add(ncrAudioLoader);
			this.loaders.Add(ncrGameObjectLoader);
			this.loaders.Add(item);
			this.loaders.Add(ncrGameObjectLoader2);
			this.parsers.Add(ncrCharacterParser);
			this.parsers.Add(ncrBuffTagGameObjectParser);
			this.parsers.Add(ncrAudioParser);
			this.parsers.Add(ncrGameObjectParser);
			for (int i = 0; i < this.loaders.Count; i++)
			{
				NcrLoader ncrLoader = this.loaders[i];
				ncrLoader.OnLoadCompleteSignal.AddEventListener(new Action<NcrLoader>(this.OnLoadCompleteHandler));
			}
		}

		private void OnLoadCompleteHandler(NcrLoader loader)
		{
			this.loadCount--;
			if (this.loadCount <= 0)
			{
				this.loadState = 3;
			}
		}

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			if (this.loadState == 0)
			{
				this.loadState = 1;
				this.blackboard = blackboard;
				for (int i = 0; i < this.Datas.Count; i++)
				{
					NcrData loadData = this.Datas[i];
					for (int j = 0; j < this.parsers.Count; j++)
					{
						NcrParser ncrParser = this.parsers[j];
						bool flag = ncrParser.AppendToLoaderIfMatch(blackboard, loadData);
						if (flag)
						{
							break;
						}
					}
				}
			}
			if (this.loadState == 1)
			{
				this.loadState = 2;
				this.loadCount = this.loaders.Count;
				for (int k = 0; k < this.loaders.Count; k++)
				{
					NcrLoader ncrLoader = this.loaders[k];
					ncrLoader.StartLoad(this.blackboard);
				}
			}
			if (this.loadState == 3)
			{
				base.status = Status.Success;
				for (int l = 0; l < this.loaders.Count; l++)
				{
					NcrLoader ncrLoader2 = this.loaders[l];
					ncrLoader2.Clear();
				}
				this.loadState = 0;
			}
			else
			{
				base.status = Status.Running;
			}
			return base.status;
		}
	}
}
