using System;
using UnityEngine;
using XQ.Framework.Threading;

namespace XQ.Framework.Lua
{
	public class MainThreadExec : MonoBehaviour
	{
		private readonly ConcurrentQueue<Action> mainQueue = new ConcurrentQueue<Action>();

		private static MainThreadExec inst;

		private void Awake()
		{
			MainThreadExec.inst = this;
		}

		private void Update()
		{
			while (this.mainQueue.Count > 0)
			{
				Action action = null;
				if (this.mainQueue.TryDequeue(out action))
				{
					action();
				}
			}
		}

		public static void AddMainThread(Action action)
		{
			MainThreadExec.inst.mainQueue.Enqueue(action);
		}
	}
}
