using System;

namespace Assets.Script.Mvc.Pool
{
	public interface IPoolable
	{
		IPool Pool
		{
			get;
			set;
		}

		void Restore();
	}
}
