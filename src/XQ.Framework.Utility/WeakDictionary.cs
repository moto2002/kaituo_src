using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace XQ.Framework.Utility
{
	public class WeakDictionary<TKey, TValue> : IEnumerable, IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>> where TValue : class
	{
		private const int MinRehashInterval = 500;

		private readonly Dictionary<TKey, WeakReference<TValue>> _dict = new Dictionary<TKey, WeakReference<TValue>>();

		private int _version;

		private int _cleanVersion;

		private int _cleanGeneration;

		public ICollection<TKey> Keys
		{
			get
			{
				return this._dict.Keys;
			}
		}

		public ICollection<TValue> Values
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public TValue this[TKey key]
		{
			get
			{
				return this._dict[key].Target;
			}
			set
			{
				this._dict[key] = new WeakReference<TValue>(value);
			}
		}

		public int Count
		{
			get
			{
				return this._dict.Count;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public bool ContainsKey(TKey key)
		{
			this.AutoCleanup(1);
			WeakReference<TValue> weakReference;
			return this._dict.TryGetValue(key, out weakReference) && weakReference.IsAlive;
		}

		public void Add(TKey key, TValue value)
		{
			this.AutoCleanup(2);
			WeakReference<TValue> weakReference;
			if (this._dict.TryGetValue(key, out weakReference))
			{
				if (weakReference.IsAlive)
				{
					throw new ArgumentException("An element with the same key already exists in this WeakValueDictionary");
				}
				weakReference.Target = value;
			}
			else
			{
				this._dict.Add(key, new WeakReference<TValue>(value));
			}
		}

		public bool Remove(TKey key)
		{
			this.AutoCleanup(1);
			WeakReference<TValue> weakReference;
			if (!this._dict.TryGetValue(key, out weakReference))
			{
				return false;
			}
			this._dict.Remove(key);
			return weakReference.IsAlive;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			this.AutoCleanup(1);
			WeakReference<TValue> weakReference;
			if (this._dict.TryGetValue(key, out weakReference))
			{
				value = weakReference.Target;
			}
			else
			{
				value = (TValue)((object)null);
			}
			return value != null;
		}

		private void AutoCleanup(int incVersion)
		{
			this._version += incVersion;
			long num = (long)(this._version - this._cleanVersion);
			if (num > (long)(500 + this._dict.Count))
			{
				int num2 = GC.CollectionCount(0);
				if (this._cleanGeneration != num2)
				{
					this._cleanGeneration = num2;
					this.Cleanup();
					this._cleanVersion = this._version;
				}
				else
				{
					this._cleanVersion += 500;
				}
			}
		}

		private void Cleanup()
		{
			List<TKey> list = new List<TKey>();
			foreach (KeyValuePair<TKey, WeakReference<TValue>> current in this._dict)
			{
				if (!current.Value.IsAlive)
				{
					list.Add(current.Key);
				}
			}
			foreach (TKey current2 in list)
			{
				bool flag = this._dict.Remove(current2);
			}
		}

		public void Add(KeyValuePair<TKey, TValue> item)
		{
			this.Add(item.Key, item.Value);
		}

		public void Clear()
		{
			this._dict.Clear();
			this._version = (this._cleanVersion = 0);
			this._cleanGeneration = 0;
		}

		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		[DebuggerHidden]
		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			WeakDictionary<TKey, TValue>.<GetEnumerator>c__IteratorA <GetEnumerator>c__IteratorA = new WeakDictionary<TKey, TValue>.<GetEnumerator>c__IteratorA();
			<GetEnumerator>c__IteratorA.<>f__this = this;
			return <GetEnumerator>c__IteratorA;
		}
	}
}
