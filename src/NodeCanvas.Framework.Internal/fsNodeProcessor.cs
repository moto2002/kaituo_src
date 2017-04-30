using FullSerializer;
using ParadoxNotion;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NodeCanvas.Framework.Internal
{
	public class fsNodeProcessor : fsObjectProcessor
	{
		public override bool CanProcess(Type type)
		{
			return typeof(Node).RTIsAssignableFrom(type);
		}

		public override void OnBeforeSerialize(Type storageType, object instance)
		{
		}

		public override void OnAfterSerialize(Type storageType, object instance, ref fsData data)
		{
		}

		public override void OnBeforeDeserialize(Type storageType, ref fsData data)
		{
			if (data.IsNull)
			{
				return;
			}
			Dictionary<string, fsData> json = data.AsDictionary;
			if (json.ContainsKey("$type"))
			{
				Type type = ReflectionTools.GetType(json["$type"].AsString);
				if (type == null)
				{
					json["recoveryState"] = new fsData(data.ToString());
					json["missingType"] = new fsData(json["$type"].AsString);
					json["$type"] = new fsData(typeof(MissingNode).FullName);
				}
				if (type == typeof(MissingNode))
				{
					Type type2 = ReflectionTools.GetType(json["missingType"].AsString);
					if (type2 != null)
					{
						string asString = json["recoveryState"].AsString;
						Dictionary<string, fsData> asDictionary = fsJsonParser.Parse(asString).AsDictionary;
						json = json.Concat(from kvp in asDictionary
						where !json.ContainsKey(kvp.Key)
						select kvp).ToDictionary((KeyValuePair<string, fsData> c) => c.Key, (KeyValuePair<string, fsData> c) => c.Value);
						json["$type"] = new fsData(type2.FullName);
						data = new fsData(json);
					}
				}
			}
		}

		public override void OnAfterDeserialize(Type storageType, object instance)
		{
		}
	}
}
