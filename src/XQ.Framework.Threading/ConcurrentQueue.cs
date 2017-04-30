using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Threading;

namespace XQ.Framework.Threading
{
	public class ConcurrentQueue<T> : IEnumerable, ICollection, IEnumerable<T>, ISerializable, IDeserializationCallback
	{
		private class Node
		{
			public T Value;

			public ConcurrentQueue<T>.Node Next;
		}

		private ConcurrentQueue<T>.Node head = new ConcurrentQueue<T>.Node();

		private ConcurrentQueue<T>.Node tail;

		private int count;

		private readonly object syncRoot = new object();

		bool ICollection.IsSynchronized
		{
			get
			{
				return true;
			}
		}

		object ICollection.SyncRoot
		{
			get
			{
				return this.syncRoot;
			}
		}

		public int Count
		{
			get
			{
				return this.count;
			}
		}

		public bool IsEmpty
		{
			get
			{
				return this.count == 0;
			}
		}

		public ConcurrentQueue()
		{
			this.tail = this.head;
		}

		public ConcurrentQueue(IEnumerable<T> enumerable) : this()
		{
			foreach (T current in enumerable)
			{
				this.Enqueue(current);
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.InternalGetEnumerator();
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return this.InternalGetEnumerator();
		}

		void ICollection.CopyTo(Array array, int index)
		{
			T[] array2 = array as T[];
			if (array2 == null)
			{
				return;
			}
			this.CopyTo(array2, index);
		}

		public void Enqueue(T item)
		{
			ConcurrentQueue<T>.Node value = new ConcurrentQueue<T>.Node
			{
				Value = item
			};
			ConcurrentQueue<T>.Node node = null;
			bool flag = false;
			while (!flag)
			{
				node = this.tail;
				ConcurrentQueue<T>.Node next = node.Next;
				if (this.tail == node)
				{
					if (next == null)
					{
						flag = (Interlocked.CompareExchange<ConcurrentQueue<T>.Node>(ref this.tail.Next, value, null) == null);
					}
					else
					{
						Interlocked.CompareExchange<ConcurrentQueue<T>.Node>(ref this.tail, next, node);
					}
				}
			}
			Interlocked.CompareExchange<ConcurrentQueue<T>.Node>(ref this.tail, value, node);
			Interlocked.Increment(ref this.count);
		}

		protected virtual bool Add(T item)
		{
			this.Enqueue(item);
			return true;
		}

		public bool TryDequeue(out T value)
		{
			value = default(T);
			bool flag = false;
			while (!flag)
			{
				ConcurrentQueue<T>.Node node = this.head;
				ConcurrentQueue<T>.Node node2 = this.tail;
				ConcurrentQueue<T>.Node next = node.Next;
				if (node == this.head)
				{
					if (node == node2)
					{
						if (next != null)
						{
							Interlocked.CompareExchange<ConcurrentQueue<T>.Node>(ref this.tail, next, node2);
						}
						value = default(T);
						return false;
					}
					value = next.Value;
					flag = (Interlocked.CompareExchange<ConcurrentQueue<T>.Node>(ref this.head, next, node) == node);
				}
			}
			Interlocked.Decrement(ref this.count);
			return true;
		}

		public bool TryPeek(out T value)
		{
			if (this.IsEmpty)
			{
				value = default(T);
				return false;
			}
			ConcurrentQueue<T>.Node next = this.head.Next;
			value = next.Value;
			return true;
		}

		public void Clear()
		{
			this.count = 0;
			this.tail = (this.head = new ConcurrentQueue<T>.Node());
		}

		public IEnumerator<T> GetEnumerator()
		{
			return this.InternalGetEnumerator();
		}

		[DebuggerHidden]
		private IEnumerator<T> InternalGetEnumerator()
		{
			ConcurrentQueue<T>.<InternalGetEnumerator>c__Iterator9 <InternalGetEnumerator>c__Iterator = new ConcurrentQueue<T>.<InternalGetEnumerator>c__Iterator9();
			<InternalGetEnumerator>c__Iterator.<>f__this = this;
			return <InternalGetEnumerator>c__Iterator;
		}

		public void CopyTo(T[] dest, int index)
		{
			IEnumerator<T> enumerator = this.InternalGetEnumerator();
			int num = index;
			while (enumerator.MoveNext())
			{
				dest[num++] = enumerator.Current;
			}
		}

		public T[] ToArray()
		{
			T[] array = new T[this.count];
			this.CopyTo(array, 0);
			return array;
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			throw new NotImplementedException();
		}

		public void OnDeserialization(object sender)
		{
			throw new NotImplementedException();
		}

		protected virtual bool Remove(out T item)
		{
			return this.TryDequeue(out item);
		}
	}
}
