using Assets.Script.Mvc.Pool;
using Assets.Tools.Script.Caller;
using System;
using System.Collections.Generic;

namespace XQ.Game.Util.Unity
{
	public class AnimationPlayerEndCallBack
	{
		public Action EndCallBack;

		public string Name;

		private DelayCall call;

		private List<AnimationPlayerEndCallBack> animationPlayerEndCallBacks;

		private Pool<AnimationPlayerEndCallBack> pool;

		public void DelayEnd(string name, float delay, Action onEnd, List<AnimationPlayerEndCallBack> list, Pool<AnimationPlayerEndCallBack> pool)
		{
			this.Name = name;
			this.pool = pool;
			this.EndCallBack = onEnd;
			this.animationPlayerEndCallBacks = list;
			this.animationPlayerEndCallBacks.Add(this);
			delay = ((delay < 0f) ? 0f : delay);
			this.call = DelayCall.Call(new Action(this.OnEndPlay), delay, false);
		}

		public void OnEndPlay()
		{
			Action endCallBack = this.EndCallBack;
			this.Clear(true);
			endCallBack();
		}

		public void Clear(bool ended = false)
		{
			this.EndCallBack = null;
			if (!ended)
			{
				this.call.Stop();
			}
			this.call = null;
			this.animationPlayerEndCallBacks.Remove(this);
			this.animationPlayerEndCallBacks = null;
			this.pool.ReturnInstance(this);
			this.pool = null;
		}
	}
}
