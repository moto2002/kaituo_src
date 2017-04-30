using LuaInterface;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Tools.Lua
{
	public class LuaTableEnumerator : IDisposable, IEnumerator<DictionaryEntry>, IEnumerator
	{
		private LuaState state;

		private DictionaryEntry current = default(DictionaryEntry);

		object IEnumerator.Current
		{
			get
			{
				return this.Current;
			}
		}

		public DictionaryEntry Current
		{
			get
			{
				return this.current;
			}
		}

		public LuaTableEnumerator(LuaTable table)
		{
			this.state = table.GetLuaState();
			this.state.Push(table);
			this.state.Push(null);
		}

		public bool MoveNext()
		{
			if (this.state.LuaNext(-2))
			{
				this.current = default(DictionaryEntry);
				this.current.Key = this.state.ToVariant(-2);
				this.current.Value = this.state.ToVariant(-1);
				this.state.LuaPop(1);
				return true;
			}
			this.current = default(DictionaryEntry);
			return false;
		}

		public Dictionary<object, object> ToHashtable()
		{
			Dictionary<object, object> dictionary = new Dictionary<object, object>();
			while (this.MoveNext())
			{
				Dictionary<object, object> arg_2A_0 = dictionary;
				DictionaryEntry dictionaryEntry = this.Current;
				object arg_2A_1 = dictionaryEntry.Key;
				DictionaryEntry dictionaryEntry2 = this.Current;
				arg_2A_0.Add(arg_2A_1, dictionaryEntry2.Value);
			}
			this.Dispose();
			return dictionary;
		}

		public void Reset()
		{
			this.current = default(DictionaryEntry);
		}

		public void Dispose()
		{
			this.state.LuaPop(1);
		}
	}
}
