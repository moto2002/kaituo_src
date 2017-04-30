using System;

namespace Assets.Script.Mvc.Pool
{
	public interface IPool
	{
		int MaxCount
		{
			get;
			set;
		}

		object GetInstance();

		bool ReturnInstance(object obj);

		void Clear();
	}
}
