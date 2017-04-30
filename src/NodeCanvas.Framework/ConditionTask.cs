using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

namespace NodeCanvas.Framework
{
	public abstract class ConditionTask<T> : ConditionTask where T : Component
	{
		public override Type agentType
		{
			get
			{
				return typeof(T);
			}
		}

		public new T agent
		{
			get
			{
				T result;
				try
				{
					result = (T)((object)base.agent);
				}
				catch
				{
					result = (T)((object)null);
				}
				return result;
			}
		}
	}
	public abstract class ConditionTask : Task
	{
		[SerializeField]
		private bool _invert;

		[NonSerialized]
		private int yieldReturn = -1;

		public bool invert
		{
			get
			{
				return this._invert;
			}
			set
			{
				this._invert = value;
			}
		}

		public bool CheckCondition(Component agent, IBlackboard blackboard)
		{
			if (!base.isActive)
			{
				return false;
			}
			if (!base.Set(agent, blackboard))
			{
				base.isActive = false;
				return false;
			}
			if (this.yieldReturn != -1)
			{
				bool result = (!this.invert) ? (this.yieldReturn == 1) : (this.yieldReturn != 1);
				this.yieldReturn = -1;
				return result;
			}
			return (!this.invert) ? this.OnCheck() : (!this.OnCheck());
		}

		protected virtual bool OnCheck()
		{
			return true;
		}

		protected void YieldReturn(bool value)
		{
			this.yieldReturn = ((!value) ? 0 : 1);
			base.StartCoroutine(this.Flip());
		}

		[DebuggerHidden]
		private IEnumerator Flip()
		{
			ConditionTask.<Flip>c__IteratorE <Flip>c__IteratorE = new ConditionTask.<Flip>c__IteratorE();
			<Flip>c__IteratorE.<>f__this = this;
			return <Flip>c__IteratorE;
		}
	}
}
