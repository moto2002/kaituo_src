using Assets.Tools.Script.Editortool.Reader;
using System;
using System.Collections.Generic;

namespace Assets.Tools.Script.Editortool
{
	public class TextConfigTable<TTable, TData, TReader> : TextDataConfig<TTable, TReader>, ITextConfigTable<TData> where TTable : TextConfigTable<TTable, TData, TReader>, new() where TData : INameData where TReader : ConfigReader<TTable>, new()
	{
		[NonSerialized]
		public List<TData> Datas = new List<TData>();

		public List<TData> GetDatas()
		{
			return this.Datas;
		}

		public void AddData(TData data)
		{
			this.Datas.Add(data);
		}

		public void RemoveData(TData data)
		{
			this.Datas.Remove(data);
		}
	}
}
