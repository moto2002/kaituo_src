using System;
using System.Threading;

namespace XQ.Game.Framework.Concurrent
{
	public class AtomicInteger
	{
		private int value;

		public int Value
		{
			get
			{
				return this.value;
			}
		}

		public AtomicInteger() : this(0)
		{
		}

		public AtomicInteger(int initValue)
		{
			this.value = initValue;
		}

		public int Increment()
		{
			return Interlocked.Increment(ref this.value);
		}

		public int Decrement()
		{
			return Interlocked.Decrement(ref this.value);
		}

		public bool CompareAndSet(int expectedValue, int newValue)
		{
			int num = Interlocked.CompareExchange(ref this.value, newValue, expectedValue);
			return num == expectedValue;
		}

		public void Set(int newValue)
		{
			Interlocked.Exchange(ref this.value, newValue);
		}
	}
}
