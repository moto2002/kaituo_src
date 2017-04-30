using Assets.Scripts.Game;
using Assets.Scripts.Game.Global;
using Assets.Tools.Script.Net.Downloader;
using ParadoxNotion.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XQ.Framework.Language;

namespace Assets.Scripts.Net
{
	public class ProjectXNoticeLoader : MonoBehaviour, IGameEntryTask
	{
		public int Priority
		{
			get
			{
				return 50;
			}
		}

		public int Weight
		{
			get
			{
				return 5;
			}
		}

		public Action<IGameEntryTask, float, string> SetTaskProgress
		{
			get;
			set;
		}

		private void Awake()
		{
			GameEntry.RegisterEntryTask(this);
		}

		public void StartTask()
		{
			this.SetTaskProgress(this, 0f, LanguageManager.GetLangText("cscode_projectxnoticeloader_cplt"));
			string text = GlobalUniqueObject.GetStringValue("VER_CHECK_URL") ?? ClientConfig.Instance.ResourcesUrl;
			if (string.IsNullOrEmpty(text))
			{
				this.SetTaskProgress(this, 1f, LanguageManager.GetLangText("cscode_projectxnoticeloader_cplt"));
			}
			else
			{
				text = Path.Combine(text, "Notice.txt").Replace("\\", "/");
				TextLoader textLoader = new TextLoader(text, -1);
				textLoader.onLoadComplete.AddEventListener(new Action<ILoader>(this.OnDownLoadComplete));
				textLoader.onLoadError.AddEventListener(new Action<ILoader>(this.OnDownloadError));
				textLoader.Load(false);
			}
		}

		private void OnDownloadError(ILoader obj)
		{
			GlobalUniqueObject.AddVariable("PX_NOTICE", "{}");
			this.SetTaskProgress(this, 1f, LanguageManager.GetLangText("cscode_projectxnoticeloader_cplt"));
		}

		private void OnDownLoadComplete(ILoader obj)
		{
			TextLoader textLoader = obj as TextLoader;
			List<ProjectXNotice> list = JSON.Deserialize<List<ProjectXNotice>>(textLoader.text, null);
			bool flag = false;
			for (int i = 0; i < list.Count; i++)
			{
				ProjectXNotice projectXNotice = list[i];
				if (projectXNotice.Type == 1 && (projectXNotice.Date.IsNullOrEmpty() || DateTime.Parse(projectXNotice.Date) <= DateTime.Now))
				{
					GameEntry.Instance.MessageBox.ShowWithPassword(projectXNotice.Body, delegate
					{
						this.SetTaskProgress(this, 1f, LanguageManager.GetLangText("cscode_projectxnoticeloader_cplt"));
					});
					flag = true;
				}
			}
			if (!flag)
			{
				GlobalUniqueObject.AddVariable("PX_NOTICE", textLoader.text);
				this.SetTaskProgress(this, 1f, LanguageManager.GetLangText("cscode_projectxnoticeloader_cplt"));
			}
		}
	}
}
