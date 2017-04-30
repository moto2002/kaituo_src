using LuaInterface;
using System;
using UnityEngine;

namespace Assets.Scripts.Tools.Event
{
	public class LuaEventAdapter : MonoBehaviour
	{
		private LuaFunction callback;

		public void AddListener(LuaFunction callback)
		{
			if (this.callback != null)
			{
				this.callback.Dispose();
			}
			this.callback = callback;
		}

		public void RemoveListener()
		{
			if (this.callback != null)
			{
				this.callback.Dispose();
			}
			this.callback = null;
		}

		public void Listener0()
		{
			if (this.callback != null)
			{
				this.callback.Call();
			}
		}

		public void Listener1<T>(T arg)
		{
			if (this.callback != null)
			{
				this.callback.CallNoRet(new object[]
				{
					arg
				});
			}
		}

		public void Listener2<T, T2>(T arg, T2 arg2)
		{
			if (this.callback != null)
			{
				this.callback.CallNoRet(new object[]
				{
					arg,
					arg2
				});
			}
		}

		public void Listener3<T, T2, T3>(T arg, T2 arg2, T3 arg3)
		{
			if (this.callback != null)
			{
				this.callback.CallNoRet(new object[]
				{
					arg,
					arg2,
					arg3
				});
			}
		}

		public void Listener4<T, T2, T3, T4>(T arg, T2 arg2, T3 arg3, T4 arg4)
		{
			if (this.callback != null)
			{
				this.callback.CallNoRet(new object[]
				{
					arg,
					arg2,
					arg3,
					arg4
				});
			}
		}

		private void OnDestroy()
		{
			if (this.callback != null)
			{
				this.callback.Dispose();
			}
			this.callback = null;
		}
	}
}
