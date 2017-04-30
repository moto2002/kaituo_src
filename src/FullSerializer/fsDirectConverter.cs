using System;
using System.Collections.Generic;

namespace FullSerializer
{
	public abstract class fsDirectConverter : fsBaseConverter
	{
		public abstract Type ModelType
		{
			get;
		}
	}
	public abstract class fsDirectConverter<TModel> : fsDirectConverter
	{
		public override Type ModelType
		{
			get
			{
				return typeof(TModel);
			}
		}

		public sealed override fsResult TrySerialize(object instance, out fsData serialized, Type storageType)
		{
			Dictionary<string, fsData> dictionary = new Dictionary<string, fsData>();
			fsResult result = this.DoSerialize((TModel)((object)instance), dictionary);
			serialized = new fsData(dictionary);
			return result;
		}

		public sealed override fsResult TryDeserialize(fsData data, ref object instance, Type storageType)
		{
			fsResult fsResult = fsResult.Success;
			fsResult fsResult2;
			fsResult = (fsResult2 = fsResult + base.CheckType(data, fsDataType.Object));
			if (fsResult2.Failed)
			{
				return fsResult;
			}
			TModel tModel = (TModel)((object)instance);
			fsResult += this.DoDeserialize(data.AsDictionary, ref tModel);
			instance = tModel;
			return fsResult;
		}

		protected abstract fsResult DoSerialize(TModel model, Dictionary<string, fsData> serialized);

		protected abstract fsResult DoDeserialize(Dictionary<string, fsData> data, ref TModel model);
	}
}
