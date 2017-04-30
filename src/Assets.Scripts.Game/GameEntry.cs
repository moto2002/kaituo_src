using System;
using System.Collections.Generic;
using UnityEngine;
using XQ.Framework.Language;

namespace Assets.Scripts.Game
{
	public class GameEntry : MonoBehaviour
	{
		public static GameEntry Instance;

		private static int currTaskIndex = -1;

		private static List<IGameEntryTask> tasks = new List<IGameEntryTask>();

		private static float totalWeight;

		private static float finishWeight;

		public GameObject SwitchRoot;

		public GameObject StartButton;

		public GameObject ProgressBar;

		public UISprite ProgressBarSprite;

		public UILabel ProgressLabel;

		public GameEntryMessageBox MessageBox;

		public static void RegisterEntryTask(IGameEntryTask task)
		{
			task.SetTaskProgress = new Action<IGameEntryTask, float, string>(GameEntry.SetTaskProgress);
			GameEntry.tasks.Add(task);
		}

		private static void SetTaskProgress(IGameEntryTask task, float progress, string label)
		{
			IGameEntryTask gameEntryTask = GameEntry.tasks[GameEntry.currTaskIndex];
			if (gameEntryTask != task)
			{
				return;
			}
			float num = (float)gameEntryTask.Weight * progress + GameEntry.finishWeight;
			GameEntry.Instance.SetProgress(num / GameEntry.totalWeight, label);
			if (progress >= 1f)
			{
				GameEntry.NextTask();
			}
		}

		private static void NextTask()
		{
			if (GameEntry.currTaskIndex >= 0)
			{
				IGameEntryTask gameEntryTask = GameEntry.tasks[GameEntry.currTaskIndex];
				GameEntry.finishWeight += (float)gameEntryTask.Weight;
			}
			GameEntry.currTaskIndex++;
			if (GameEntry.tasks.Count > GameEntry.currTaskIndex)
			{
				IGameEntryTask gameEntryTask2 = GameEntry.tasks[GameEntry.currTaskIndex];
				gameEntryTask2.StartTask();
			}
			else
			{
				GameEntry.Instance.Finish();
			}
		}

		private void Awake()
		{
			GameEntry.Instance = this;
			LanguageManager.InitLang(false);
		}

		public void Start()
		{
			base.Invoke("EntryGame", 0.1f);
		}

		private void OnDestroy()
		{
			GameEntry.Instance = null;
			GameEntry.tasks.Clear();
		}

		public void EntryGame()
		{
			this.StartButton.SetActive(false);
			this.ProgressBar.SetActive(true);
			GameEntry.totalWeight = 0f;
			GameEntry.currTaskIndex = -1;
			GameEntry.finishWeight = 0f;
			GameEntry.tasks.Sort((IGameEntryTask a, IGameEntryTask b) => b.Priority - a.Priority);
			for (int i = 0; i < GameEntry.tasks.Count; i++)
			{
				IGameEntryTask gameEntryTask = GameEntry.tasks[i];
				GameEntry.totalWeight += (float)gameEntryTask.Weight;
			}
			GameEntry.NextTask();
		}

		private void SetProgress(float progress, string label)
		{
			this.ProgressBarSprite.fillAmount = progress;
			if (!string.IsNullOrEmpty(label))
			{
				this.ProgressLabel.text = label;
			}
		}

		private void Finish()
		{
			this.ProgressBar.SetActive(false);
			if (this.SwitchRoot != null)
			{
				UnityEngine.Object.Destroy(this.SwitchRoot);
			}
		}
	}
}
