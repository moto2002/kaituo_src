using Assets.ThridPartyTool.Tools.LetsLua.NodeCanvas.Builtin;
using FullSerializer;
using ParadoxNotion;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NodeCanvas.Framework.Internal
{
	public class fsTaskProcessor : fsObjectProcessor
	{
		public override bool CanProcess(Type type)
		{
			return typeof(Task).RTIsAssignableFrom(type);
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
					Type type2 = null;
					if (storageType == typeof(ActionTask))
					{
						type2 = typeof(MissingAction);
					}
					if (storageType == typeof(ConditionTask))
					{
						type2 = typeof(MissingCondition);
					}
					if (storageType == typeof(LetsLuaConditionTask))
					{
						type2 = typeof(LetsLuaMissingCondition);
					}
					if (storageType == typeof(LetsLuaActionTask))
					{
						type2 = typeof(LetsLuaMissingAction);
					}
					if (type2 == null)
					{
						Debug.LogError("Can't resolve missing Task type " + storageType.ToString());
						return;
					}
					json["$type"] = new fsData(type2.FullName);
				}
				if (type == typeof(MissingAction) || type == typeof(MissingCondition))
				{
					Type type3 = ReflectionTools.GetType(json["missingType"].AsString);
					if (type3 != null)
					{
						string asString = json["recoveryState"].AsString;
						Dictionary<string, fsData> asDictionary = fsJsonParser.Parse(asString).AsDictionary;
						json = json.Concat(from kvp in asDictionary
						where !json.ContainsKey(kvp.Key)
						select kvp).ToDictionary((KeyValuePair<string, fsData> c) => c.Key, (KeyValuePair<string, fsData> c) => c.Value);
						json["$type"] = new fsData(type3.FullName);
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
