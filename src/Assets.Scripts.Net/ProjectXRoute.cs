using Assets.Scripts.Game;
using Assets.Scripts.Game.Global;
using Assets.Scripts.Test;
using Assets.Tools.Script.Net.Downloader;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XQ.Framework.Language;

namespace Assets.Scripts.Net
{
	public class ProjectXRoute : MonoBehaviour, IGameEntryTask
	{
		public int Priority
		{
			get
			{
				return 45;
			}
		}

		public int Weight
		{
			get
			{
				return 2;
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
			this.SetTaskProgress(this, 0f, LanguageManager.GetLangText("cscode_projectxroute_cplt"));
			string text = GlobalUniqueObject.GetStringValue("VER_CHECK_URL") ?? ClientConfig.Instance.ResourcesUrl;
			if (TestSetServerIP.SVR_IP.IsNOTNullOrEmpty())
			{
				ClientConfig.Instance.GameServerHost = new List<string>();
				ClientConfig.Instance.GameServerPort = new List<string>();
				ClientConfig.Instance.GameServerHost.Add(TestSetServerIP.SVR_IP);
				ClientConfig.Instance.GameServerPort.Add(TestSetServerIP.SVR_PORT.ToString());
				ClientConfig.Instance.Save();
				this.SetTaskProgress(this, 1f, LanguageManager.GetLangText("cscode_projectxroute_cplt"));
			}
			else if (string.IsNullOrEmpty(text))
			{
				this.SetTaskProgress(this, 1f, LanguageManager.GetLangText("cscode_projectxroute_cplt"));
			}
			else
			{
				text = Path.Combine(text, "Route.txt").Replace("\\", "/");
				TextLoader textLoader = new TextLoader(text, -1);
				textLoader.onLoadComplete.AddEventListener(new Action<ILoader>(this.OnDownLoadComplete));
				textLoader.onLoadError.AddEventListener(new Action<ILoader>(this.OnDownloadError));
				textLoader.Load(false);
			}
		}

		private void OnDownloadError(ILoader obj)
		{
			this.SetTaskProgress(this, 1f, LanguageManager.GetLangText("cscode_projectxroute_cplt"));
		}

		private void OnDownLoadComplete(ILoader obj)
		{
			TextLoader textLoader = obj as TextLoader;
			if (textLoader.text.IsNOTNullOrEmpty())
			{
				string[] array = textLoader.text.Split(new string[]
				{
					"\r\n"
				}, StringSplitOptions.None);
				ClientConfig.Instance.GameServerHost = new List<string>();
				ClientConfig.Instance.GameServerPort = new List<string>();
				for (int i = 0; i < array.Length; i += 2)
				{
					ClientConfig.Instance.GameServerHost.Add(array[i]);
					ClientConfig.Instance.GameServerPort.Add(array[i + 1]);
				}
				ClientConfig.Instance.Save();
				DebugConsole.Log(new object[]
				{
					"Route",
					array[0],
					array[1]
				});
			}
			this.SetTaskProgress(this, 1f, LanguageManager.GetLangText("cscode_projectxroute_cplt"));
		}
	}
}
