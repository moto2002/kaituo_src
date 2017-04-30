using System;
using System.Collections.Generic;

namespace Assets.Tools.Script.Editortool
{
	public interface ITextConfigTable<TData> where TData : INameData
	{
		List<TData> GetDatas();

		void AddData(TData data);

		void RemoveData(TData data);
	}
}
