using Assets.Migration.Scripts.Node.ResourceLoader.Core;
using Assets.Scripts;
using Assets.Scripts.Tool;
using NodeCanvas.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Migration.Scripts.Node.Loader
{
	public class NcrCharacterLoader : NcrLoader
	{
		private struct NcrCharacterLoadData
		{
			public string BlackboardName;

			public NcrType Type;

			public string Path;

			public bool IsActive;
		}

		private const string BlackboardCharacterMark = "_internal_character_";

		private Dictionary<int, List<NcrCharacterLoader.NcrCharacterLoadData>> willLoadUnits = new Dictionary<int, List<NcrCharacterLoader.NcrCharacterLoadData>>();

		private Dictionary<int, string> willLoadUnitPaths = new Dictionary<int, string>();

		private Dictionary<string, NcrCharacterLoader.NcrCharacterLoadData> unknowIdUnits = new Dictionary<string, NcrCharacterLoader.NcrCharacterLoadData>();

		private Dictionary<string, NcrCharacterLoader.NcrCharacterLoadData> nullUnits = new Dictionary<string, NcrCharacterLoader.NcrCharacterLoadData>();

		private Dictionary<int, RpgCharacter> loadedUnits = new Dictionary<int, RpgCharacter>();

		private int loadCount;

		public static string GetBlackboardCharacterMark(int id)
		{
			return "_internal_character_" + id;
		}

		public override void Clear()
		{
			base.Clear();
			this.willLoadUnits.Clear();
			this.willLoadUnitPaths.Clear();
			this.unknowIdUnits.Clear();
			this.nullUnits.Clear();
			this.loadCount = 0;
		}

		protected override void OnAppend(NcrData data)
		{
			if (data.CacheData != null && (data.CacheData as List<int>).Count > 0)
			{
				List<int> list = data.CacheData as List<int>;
				for (int i = 0; i < list.Count; i++)
				{
					int key = list[i];
					List<NcrCharacterLoader.NcrCharacterLoadData> list2;
					if (!this.willLoadUnits.TryGetValue(key, out list2))
					{
						list2 = new List<NcrCharacterLoader.NcrCharacterLoadData>();
						this.willLoadUnits.Add(key, list2);
						this.willLoadUnitPaths.Add(key, data.Path[i]);
					}
					list2.Add(new NcrCharacterLoader.NcrCharacterLoadData
					{
						BlackboardName = data.BlackboardName[i],
						Type = data.LoadType,
						IsActive = data.IsActive
					});
				}
			}
			else if (data.Path.Count > 0)
			{
				NcrCharacterLoader.NcrCharacterLoadData value = new NcrCharacterLoader.NcrCharacterLoadData
				{
					BlackboardName = data.BlackboardName[0],
					Type = data.LoadType,
					Path = data.Path[0],
					IsActive = data.IsActive
				};
				this.unknowIdUnits.Add(value.BlackboardName, value);
			}
			else
			{
				NcrCharacterLoader.NcrCharacterLoadData value2 = new NcrCharacterLoader.NcrCharacterLoadData
				{
					BlackboardName = data.OriginalBlackboardName,
					Type = data.LoadType,
					IsActive = data.IsActive
				};
				this.nullUnits.Add(value2.BlackboardName, value2);
			}
		}

		protected override void OnStartLoad()
		{
			this.loadCount = this.willLoadUnits.Count + this.unknowIdUnits.Count;
			if (this.loadCount == 0)
			{
				this.OnLoadCompleteSignal.Dispatch(this);
			}
			else
			{
				foreach (int current in this.willLoadUnits.Keys)
				{
					RpgCharacter rpgCharacter = null;
					string blackboardCharacterMark = NcrCharacterLoader.GetBlackboardCharacterMark(current);
					Variable variable = this.blackboard.GetVariable(blackboardCharacterMark, null);
					if (variable != null)
					{
						rpgCharacter = (variable.value as RpgCharacter);
					}
					if (rpgCharacter == null)
					{
						this.loadedUnits.TryGetValue(current, out rpgCharacter);
					}
					if (rpgCharacter != null)
					{
						this.OnLoadCharacterCompleteHandler(rpgCharacter);
					}
					else
					{
						string resPath = this.willLoadUnitPaths[current];
						CharacterModelLoader.LoadUnit(current, resPath, new Action<RpgCharacter>(this.OnLoadCharacterCompleteHandler));
					}
				}
				foreach (NcrCharacterLoader.NcrCharacterLoadData current2 in this.unknowIdUnits.Values)
				{
					CharacterModelLoader.LoadUnit(current2.BlackboardName, current2.Path, new Action<RpgCharacter>(this.OnLoadCharacterCompleteHandler));
				}
				foreach (NcrCharacterLoader.NcrCharacterLoadData current3 in this.nullUnits.Values)
				{
					this.InitCharacter(current3, null);
				}
			}
		}

		private void OnLoadCharacterCompleteHandler(RpgCharacter obj)
		{
			int instanceId = obj.InstanceId;
			if (instanceId > 0)
			{
				List<NcrCharacterLoader.NcrCharacterLoadData> list = this.willLoadUnits[instanceId];
				for (int i = 0; i < list.Count; i++)
				{
					this.InitCharacter(list[i], obj);
				}
				this.loadedUnits[obj.InstanceId] = obj;
			}
			else
			{
				this.InitCharacter(this.unknowIdUnits[obj.CharacterName], obj);
			}
			this.loadCount--;
			if (this.loadCount == 0)
			{
				this.OnLoadCompleteSignal.Dispatch(this);
			}
		}

		private void InitCharacter(NcrCharacterLoader.NcrCharacterLoadData ncrCharacterLoadData, RpgCharacter character)
		{
			if (ncrCharacterLoadData.Type == NcrType.CharacterGameObject)
			{
				if (character == null)
				{
					this.blackboard.SetOrAddValue(ncrCharacterLoadData.BlackboardName, null, typeof(GameObject));
				}
				else
				{
					this.blackboard.SetOrAddValue(ncrCharacterLoadData.BlackboardName, character.gameObject);
				}
			}
			else
			{
				this.blackboard.SetOrAddValue(ncrCharacterLoadData.BlackboardName, character, typeof(RpgCharacter));
			}
			if (character != null && character.InstanceId > 0)
			{
				this.blackboard.SetOrAddValue(NcrCharacterLoader.GetBlackboardCharacterMark(character.InstanceId), character);
			}
			if (character != null)
			{
				character.gameObject.SetActive(ncrCharacterLoadData.IsActive);
			}
		}
	}
}
