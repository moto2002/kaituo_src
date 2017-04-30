using Assets.Tools.Script.Debug.Console;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Extends.EXTools.Debug
{
	public class ShowFPS : MonoBehaviour
	{
		public float f_UpdateInterval = 0.5f;

		private float f_LastInterval;

		private int i_Frames;

		public float CurrFps;

		private Dictionary<int, int> distribution = new Dictionary<int, int>();

		private void Start()
		{
			this.f_LastInterval = Time.realtimeSinceStartup;
			this.i_Frames = 0;
			this.distribution.Add(0, 0);
			this.distribution.Add(10, 0);
			this.distribution.Add(30, 0);
			this.distribution.Add(60, 0);
			this.distribution.Add(100, 0);
		}

		private void Update()
		{
			this.i_Frames++;
			if (Time.realtimeSinceStartup > this.f_LastInterval + this.f_UpdateInterval)
			{
				this.CurrFps = (float)this.i_Frames / (Time.realtimeSinceStartup - this.f_LastInterval);
				this.i_Frames = 0;
				this.f_LastInterval = Time.realtimeSinceStartup;
			}
			DebugConsole.AddTopString("FPS", string.Format("FPS:{0}", this.CurrFps.ToString("f2")));
			if (DebugConsole.consoleImpl is EmptyDebugConsole)
			{
				UnityEngine.Object.Destroy(this);
			}
		}
	}
}
