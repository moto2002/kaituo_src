using System;

namespace Assets.Scripts.Game
{
	public class GameEntryTask : IGameEntryTask
	{
		private int priority;

		private int weight;

		private Action<IGameEntryTask, float, string> setTaskProgress;

		private Action OnStart;

		public int Priority
		{
			get
			{
				return this.priority;
			}
		}

		public int Weight
		{
			get
			{
				return this.weight;
			}
		}

		public Action<IGameEntryTask, float, string> SetTaskProgress
		{
			get
			{
				return this.setTaskProgress;
			}
			set
			{
				this.setTaskProgress = value;
			}
		}

		public GameEntryTask(int priority, int weight, Action onStart)
		{
			this.priority = priority;
			this.weight = weight;
			this.OnStart = onStart;
		}

		public void StartTask()
		{
			this.OnStart();
		}
	}
}
