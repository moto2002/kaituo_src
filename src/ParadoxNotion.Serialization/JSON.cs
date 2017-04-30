using FullSerializer;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ParadoxNotion.Serialization
{
	public static class JSON
	{
		private static readonly fsSerializer serializer = new fsSerializer
		{
			Config = 
			{
				SerializeEnumsAsInteger = true
			}
		};

		private static bool init;

		public static string Serialize(Type type, object value, bool pretyJson = false, List<UnityEngine.Object> objectReferences = null)
		{
			if (!JSON.init)
			{
				JSON.serializer.AddConverter(new fsUnityObjectConverter());
				JSON.init = true;
			}
			if (objectReferences != null)
			{
				JSON.serializer.Context.Set<List<UnityEngine.Object>>(objectReferences);
			}
			fsData data;
			JSON.serializer.TrySerialize(type, value, out data).AssertSuccess();
			if (pretyJson)
			{
				return fsJsonPrinter.PrettyJson(data);
			}
			return fsJsonPrinter.CompressedJson(data);
		}

		public static string Serialize<T>(object value, bool pretyJson = false, List<UnityEngine.Object> objectReferences = null)
		{
			return JSON.Serialize(typeof(T), value, pretyJson, objectReferences);
		}

		public static T Deserialize<T>(string serializedState, List<UnityEngine.Object> objectReferences = null)
		{
			return (T)((object)JSON.Deserialize(typeof(T), serializedState, objectReferences));
		}

		public static object Deserialize(Type type, string serializedState, List<UnityEngine.Object> objectReferences = null)
		{
			if (!JSON.init)
			{
				JSON.serializer.AddConverter(new fsUnityObjectConverter());
				JSON.init = true;
			}
			if (objectReferences != null)
			{
				JSON.serializer.Context.Set<List<UnityEngine.Object>>(objectReferences);
			}
			fsData data = fsJsonParser.Parse(serializedState);
			object result = null;
			JSON.serializer.TryDeserialize(data, type, ref result).AssertSuccess();
			return result;
		}
	}
}
