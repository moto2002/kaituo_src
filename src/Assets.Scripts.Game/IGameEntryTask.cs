using System;

namespace Assets.Scripts.Game
{
	public interface IGameEntryTask
	{
		int Priority
		{
			get;
		}

		int Weight
		{
			get;
		}

		Action<IGameEntryTask, float, string> SetTaskProgress
		{
			get;
			set;
		}

		void StartTask();
	}
}
