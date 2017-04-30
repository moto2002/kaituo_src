using Assets.Scripts.Game;
using Assets.Tools.Script.Caller;
using Assets.Tools.Script.Net.Downloader;
using Assets.Tools.Script.Net.Downloader.Tool;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XQ.Framework.Language;
using XQ.Framework.Lua;
using XQ.Framework.Lua.Utility;
using XQ.Framework.Utility.Debug;

namespace Assets.Scripts.Net
{
	public class ProjectXUpdater : MonoBehaviour, IGameEntryTask
	{
		public VerInfoStruct VerInfo;

		private float totalProgress;

		private float downloadProgress;

		private int updatePacksCount;

		private Queue<ZipLoader> updatePacks;

		private Dictionary<ZipLoader, bool> loadCompletePacks;

		public int Priority
		{
			get
			{
				return 490;
			}
		}

		public int Weight
		{
			get
			{
				return 30;
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

		public void Start()
		{
		}

		public void StartUpdate(string verUrl)
		{
			this.updatePacks = new Queue<ZipLoader>();
			this.loadCompletePacks = new Dictionary<ZipLoader, bool>();
			this.totalProgress = 0f;
			this.downloadProgress = 0f;
			this.updatePacksCount = 0;
			this.SetProgress(0f, LanguageManager.GetLangText("cscode_projectxupdater_checkver"));
			this.DownloadVerList(verUrl);
		}

		private void DownloadVerList(string verUrl)
		{
			TextLoader textLoader = new TextLoader(verUrl, -1);
			textLoader.onLoadComplete.AddEventListener(new Action<ILoader>(this.OnDownLoadVerComplete));
			textLoader.onLoadError.AddEventListener(new Action<ILoader>(this.OnDownloadError));
			textLoader.Load(false);
		}

		private void OnDownloadError(ILoader loader)
		{
			this.SetProgress(1f, LanguageManager.GetLangText("cscode_projectxupdater_checkdownloadend"));
		}

		private void OnDownLoadVerComplete(ILoader loader)
		{
			this.SetProgress(0.2f, LanguageManager.GetLangText("cscode_projectxupdater_startupdate"));
			TextLoader textLoader = loader as TextLoader;
			string text = textLoader.text;
			if (text == "-1")
			{
				this.OnAllPackLoadComplete();
				return;
			}
			string[] array = text.Split(new char[]
			{
				','
			});
			int num = -1;
			int num2 = 0;
			for (int i = 0; i < array.Length; i++)
			{
				string text2 = array[i];
				if (text2.StartsWith(this.VerInfo.curVer) && num == -1)
				{
					num = i + 1;
				}
				else
				{
					string text3 = this.VerInfo.FullSetupVersion(text2);
					if (text3 != null)
					{
						num2 = int.Parse(text3);
					}
				}
			}
			if (num2 != 0)
			{
				MessageTip.Tip(string.Format(LanguageManager.GetLangText("Full_Install"), ClientConfig.GetVerStr(num2)));
				return;
			}
			UrlLoadQueue urlLoadQueue = new UrlLoadQueue();
			urlLoadQueue.onTotalScheduleSignal.AddEventListener(new Action<float>(this.OnDownloadSchedule));
			if (num > -1)
			{
				for (int j = num; j < array.Length; j++)
				{
					string ver = array[j];
					ZipLoader zipLoader = new ZipLoader(this.VerInfo.GetPatchFileURL(ver), int.Parse(this.VerInfo.GetVersion(ver)));
					zipLoader.onLoadComplete.AddEventListener(new Action<ILoader>(this.OnOnePackLoadComplete));
					urlLoadQueue.Add(zipLoader);
					this.updatePacks.Enqueue(zipLoader);
					this.updatePacksCount++;
				}
			}
			if (this.updatePacksCount == 0)
			{
				this.OnAllPackLoadComplete();
			}
			else
			{
				urlLoadQueue.Load();
			}
		}

		private void OnOnePackLoadComplete(ILoader loader)
		{
			this.loadCompletePacks.Add(loader as ZipLoader, true);
			this.TryDezip();
		}

		private void TryDezip()
		{
			if (this.updatePacks.Count == 0)
			{
				this.OnAllPackLoadComplete();
			}
			else if (this.loadCompletePacks.ContainsKey(this.updatePacks.Peek()))
			{
				ILoader loader = this.updatePacks.Dequeue();
				this.Dezip(loader);
			}
		}

		private void Dezip(ILoader loader)
		{
			ZipLoader zipLoader = loader as ZipLoader;
			int[] progress = new int[1];
			int num = lzip.decompress_File(UtilHelper.DataPath(true, false, true) + zipLoader.cacheName, UtilHelper.DataPath(true, false, true), progress, null);
			zipLoader.UnloadLocal();
			if (num == -1)
			{
				MessageTip.Tip(LanguageManager.GetLangText("Zip_Init_Failed"));
				UDebug.Error("error zip file: {0}", new object[]
				{
					UtilHelper.DataPath(true, false, true) + zipLoader.cacheName
				});
				return;
			}
			if (num == -2)
			{
				MessageTip.Tip(LanguageManager.GetLangText("Zip_Init_Failed"));
				return;
			}
			if (num == -3)
			{
				MessageTip.Tip(LanguageManager.GetLangText("Zip_Failed"));
				return;
			}
			ClientConfig.Instance.Version = zipLoader.version;
			ClientConfig.Instance.Save();
			this.AddProgress(0.38f / (float)this.updatePacksCount);
			this.TryDezip();
		}

		private void OnAllPackLoadComplete()
		{
			this.SetProgress(1f, LanguageManager.GetLangText("cscode_projectxupdater_rescomplete"));
		}

		private void OnDownloadSchedule(float schedule)
		{
			this.totalProgress -= 0.38f * this.downloadProgress;
			this.downloadProgress = schedule;
			this.AddProgress(0.38f * this.downloadProgress);
		}

		private void SetProgress(float progress, string label)
		{
			this.totalProgress = progress;
			if (this.SetTaskProgress != null)
			{
				this.SetTaskProgress(this, progress, label);
			}
		}

		private void AddProgress(float addedProgress)
		{
			this.totalProgress += addedProgress;
			this.SetProgress(this.totalProgress, LanguageManager.GetLangText("cscode_projectxupdater_resupdating"));
		}

		public void StartTask()
		{
			this.SetTaskProgress(this, 0f, LanguageManager.GetLangText("cscode_projectxupdater_checkdownloadend"));
			FrameCall.DelayFrame(delegate
			{
				this.VerInfo = GameManager.VER_INFO;
				if (!this.VerInfo.noVerInfo && this.VerInfo.verUrl != ClientConfig.Instance.ResourcesUrl)
				{
					this.VerInfo.UpdateURL(ClientConfig.Instance.ResourcesUrl);
				}
				this.StartUpdate(Path.Combine(this.VerInfo.verUrl, "Ver.txt").Replace("\\", "/"));
			}, 2);
		}
	}
}
