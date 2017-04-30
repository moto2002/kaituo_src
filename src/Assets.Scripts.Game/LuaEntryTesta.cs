using System;
using UnityEngine;

namespace Assets.Scripts.Game
{
	public class LuaEntryTesta : MonoBehaviour, IGameEntryTask
	{
		public int Priority
		{
			get
			{
				return 5;
			}
		}

		public int Weight
		{
			get
			{
				return 10;
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
		}
	}
}
