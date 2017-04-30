using System;
using UnityEngine;
using XQ.Framework.Lua;

namespace XQ.Framework.Loading
{
	public class ProgressCallbackImpl : AndroidJavaProxy
	{
		public Action<int, float, string> progressCB;

		public ProgressCallbackImpl() : base("xq.game.helper.IProgressCallback")
		{
		}

		private void Progress(int length, float progress, string err)
		{
			this.progressCB(length, progress, err);
		}

		private void SetZipVer(string ver)
		{
			GameManager.SetGameInfo(ver, true);
		}
	}
}
