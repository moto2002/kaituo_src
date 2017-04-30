using Assets.Script.Mvc.Pool;
using System;

namespace Assets.Extends.EXTools.Debug.Console
{
	public class NameableObject : IPoolable
	{
		public string Name;

		public object Value;

		public IPool Pool
		{
			get;
			set;
		}

		public void Restore()
		{
			this.Name = null;
			this.Value = null;
		}
	}
}
