using System;

internal sealed class SingleLinkNode<T>
{
	public SingleLinkNode<T> Next;

	public T Item;

	public SingleLinkNode(T item)
	{
		this.Item = item;
	}
}
