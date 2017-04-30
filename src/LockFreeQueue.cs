using System;
using System.Threading;

public class LockFreeQueue<T>
{
	private SingleLinkNode<T> head;

	private SingleLinkNode<T> tail;

	private int count;

	public int Count
	{
		get
		{
			return this.count;
		}
	}

	public LockFreeQueue() : this(64)
	{
	}

	public LockFreeQueue(int _count)
	{
		this.head = new SingleLinkNode<T>(default(T));
		this.tail = this.head;
		this.count = 0;
	}

	private static bool CAS(ref SingleLinkNode<T> location, SingleLinkNode<T> comparand, SingleLinkNode<T> newValue)
	{
		return comparand == Interlocked.CompareExchange<SingleLinkNode<T>>(ref location, newValue, comparand);
	}

	public void Clear()
	{
		do
		{
			this.tail = this.head;
		}
		while (!LockFreeQueue<T>.CAS(ref this.head.Next, this.tail.Next, null));
	}

	public bool IsEmpty()
	{
		return this.count <= 0;
	}

	public void Enqueue(T item)
	{
		SingleLinkNode<T> singleLinkNode = null;
		SingleLinkNode<T> newValue = new SingleLinkNode<T>(item);
		bool flag = false;
		while (!flag)
		{
			singleLinkNode = this.tail;
			SingleLinkNode<T> next = singleLinkNode.Next;
			if (this.tail == singleLinkNode)
			{
				if (next == null && LockFreeQueue<T>.CAS(ref this.tail.Next, null, newValue))
				{
					Interlocked.Increment(ref this.count);
					flag = true;
				}
				else
				{
					LockFreeQueue<T>.CAS(ref this.tail, singleLinkNode, next);
				}
			}
		}
		LockFreeQueue<T>.CAS(ref this.tail, singleLinkNode, newValue);
	}

	public T Dequeue()
	{
		T result = default(T);
		bool flag = false;
		while (!flag)
		{
			SingleLinkNode<T> singleLinkNode = this.head;
			SingleLinkNode<T> singleLinkNode2 = this.tail;
			SingleLinkNode<T> next = singleLinkNode.Next;
			if (singleLinkNode == this.head)
			{
				if (singleLinkNode == singleLinkNode2)
				{
					if (next == null)
					{
						return default(T);
					}
					LockFreeQueue<T>.CAS(ref this.tail, singleLinkNode2, next);
				}
				else
				{
					result = next.Item;
					flag = LockFreeQueue<T>.CAS(ref this.head, singleLinkNode, next);
				}
			}
		}
		Interlocked.Decrement(ref this.count);
		return result;
	}
}
