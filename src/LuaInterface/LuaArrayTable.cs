using System;
using System.Collections;
using System.Collections.Generic;

namespace LuaInterface
{
	public class LuaArrayTable : IDisposable, IEnumerable, IEnumerable<object>
	{
		private class Enumerator : IDisposable, IEnumerator<object>, IEnumerator
		{
			private LuaState state;

			private int index = 1;

			private object current;

			private int top = -1;

			public object Current
			{
				get
				{
					return this.current;
				}
			}

			public Enumerator(LuaArrayTable list)
			{
				this.state = list.state;
				this.top = this.state.LuaGetTop();
				this.state.Push(list.table);
			}

			public bool MoveNext()
			{
				this.state.LuaRawGetI(-1, this.index);
				this.current = this.state.ToVariant(-1);
				this.state.LuaPop(1);
				this.index++;
				return this.current != null;
			}

			public void Reset()
			{
				this.index = 1;
				this.current = null;
			}

			public void Dispose()
			{
				if (this.state != null)
				{
					this.state.LuaSetTop(this.top);
					this.state = null;
				}
			}
		}

		private LuaTable table;

		private readonly LuaState state;

		public int Length
		{
			get
			{
				return this.table.Length;
			}
		}

		public object this[int key]
		{
			get
			{
				return this.table[key];
			}
			set
			{
				this.table[key] = value;
			}
		}

		public LuaArrayTable(LuaTable table)
		{
			table.AddRef();
			this.table = table;
			this.state = table.GetLuaState();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public void Dispose()
		{
			if (this.table != null)
			{
				this.table.Dispose();
				this.table = null;
			}
		}

		public void ForEach(Action<object> action)
		{
			using (IEnumerator<object> enumerator = this.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					action(enumerator.Current);
				}
			}
		}

		public IEnumerator<object> GetEnumerator()
		{
			return new LuaArrayTable.Enumerator(this);
		}
	}
}
