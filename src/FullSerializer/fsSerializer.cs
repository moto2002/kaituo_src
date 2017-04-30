using FullSerializer.Internal;
using System;
using System.Collections.Generic;

namespace FullSerializer
{
	public class fsSerializer
	{
		internal class fsLazyCycleDefinitionWriter
		{
			private Dictionary<int, fsData> _pendingDefinitions = new Dictionary<int, fsData>();

			private HashSet<int> _references = new HashSet<int>();

			public void WriteDefinition(int id, fsData data)
			{
				if (this._references.Contains(id))
				{
					fsSerializer.EnsureDictionary(data);
					data.AsDictionary[fsSerializer.Key_ObjectDefinition] = new fsData(id.ToString());
				}
				else
				{
					this._pendingDefinitions[id] = data;
				}
			}

			public void WriteReference(int id, Dictionary<string, fsData> dict)
			{
				if (this._pendingDefinitions.ContainsKey(id))
				{
					fsData fsData = this._pendingDefinitions[id];
					fsSerializer.EnsureDictionary(fsData);
					fsData.AsDictionary[fsSerializer.Key_ObjectDefinition] = new fsData(id.ToString());
					this._pendingDefinitions.Remove(id);
				}
				else
				{
					this._references.Add(id);
				}
				dict[fsSerializer.Key_ObjectReference] = new fsData(id.ToString());
			}

			public void Clear()
			{
				this._pendingDefinitions.Clear();
				this._references.Clear();
			}
		}

		private static HashSet<string> _reservedKeywords;

		private static readonly string Key_ObjectReference;

		private static readonly string Key_ObjectDefinition;

		private static readonly string Key_InstanceType;

		private static readonly string Key_Version;

		private static readonly string Key_Content;

		private Dictionary<Type, fsBaseConverter> _cachedConverterTypeInstances;

		private Dictionary<Type, fsBaseConverter> _cachedConverters;

		private Dictionary<Type, List<fsObjectProcessor>> _cachedProcessors;

		private readonly List<fsConverter> _availableConverters;

		private readonly Dictionary<Type, fsDirectConverter> _availableDirectConverters;

		private readonly List<fsObjectProcessor> _processors;

		private readonly fsCyclicReferenceManager _references;

		private readonly fsSerializer.fsLazyCycleDefinitionWriter _lazyReferenceWriter;

		public fsContext Context;

		public fsConfig Config;

		public fsSerializer()
		{
			this._cachedConverterTypeInstances = new Dictionary<Type, fsBaseConverter>();
			this._cachedConverters = new Dictionary<Type, fsBaseConverter>();
			this._cachedProcessors = new Dictionary<Type, List<fsObjectProcessor>>();
			this._references = new fsCyclicReferenceManager();
			this._lazyReferenceWriter = new fsSerializer.fsLazyCycleDefinitionWriter();
			this._availableConverters = new List<fsConverter>
			{
				new fsNullableConverter
				{
					Serializer = this
				},
				new fsGuidConverter
				{
					Serializer = this
				},
				new fsTypeConverter
				{
					Serializer = this
				},
				new fsDateConverter
				{
					Serializer = this
				},
				new fsEnumConverter
				{
					Serializer = this
				},
				new fsPrimitiveConverter
				{
					Serializer = this
				},
				new fsArrayConverter
				{
					Serializer = this
				},
				new fsDictionaryConverter
				{
					Serializer = this
				},
				new fsIEnumerableConverter
				{
					Serializer = this
				},
				new fsKeyValuePairConverter
				{
					Serializer = this
				},
				new fsWeakReferenceConverter
				{
					Serializer = this
				},
				new fsReflectedConverter
				{
					Serializer = this
				}
			};
			this._availableDirectConverters = new Dictionary<Type, fsDirectConverter>();
			this._processors = new List<fsObjectProcessor>
			{
				new fsSerializationCallbackProcessor()
			};
			this._processors.Add(new fsSerializationCallbackReceiverProcessor());
			this.Context = new fsContext();
			this.Config = new fsConfig();
			foreach (Type current in fsConverterRegistrar.Converters)
			{
				this.AddConverter((fsBaseConverter)Activator.CreateInstance(current));
			}
		}

		static fsSerializer()
		{
			fsSerializer.Key_ObjectReference = string.Format("{0}ref", fsGlobalConfig.InternalFieldPrefix);
			fsSerializer.Key_ObjectDefinition = string.Format("{0}id", fsGlobalConfig.InternalFieldPrefix);
			fsSerializer.Key_InstanceType = string.Format("{0}type", fsGlobalConfig.InternalFieldPrefix);
			fsSerializer.Key_Version = string.Format("{0}version", fsGlobalConfig.InternalFieldPrefix);
			fsSerializer.Key_Content = string.Format("{0}content", fsGlobalConfig.InternalFieldPrefix);
			fsSerializer._reservedKeywords = new HashSet<string>
			{
				fsSerializer.Key_ObjectReference,
				fsSerializer.Key_ObjectDefinition,
				fsSerializer.Key_InstanceType,
				fsSerializer.Key_Version,
				fsSerializer.Key_Content
			};
		}

		public static bool IsReservedKeyword(string key)
		{
			return fsSerializer._reservedKeywords.Contains(key);
		}

		private static bool IsObjectReference(fsData data)
		{
			return data.IsDictionary && data.AsDictionary.ContainsKey(fsSerializer.Key_ObjectReference);
		}

		private static bool IsObjectDefinition(fsData data)
		{
			return data.IsDictionary && data.AsDictionary.ContainsKey(fsSerializer.Key_ObjectDefinition);
		}

		private static bool IsVersioned(fsData data)
		{
			return data.IsDictionary && data.AsDictionary.ContainsKey(fsSerializer.Key_Version);
		}

		private static bool IsTypeSpecified(fsData data)
		{
			return data.IsDictionary && data.AsDictionary.ContainsKey(fsSerializer.Key_InstanceType);
		}

		private static bool IsWrappedData(fsData data)
		{
			return data.IsDictionary && data.AsDictionary.ContainsKey(fsSerializer.Key_Content);
		}

		public static void StripDeserializationMetadata(ref fsData data)
		{
			if (data.IsDictionary && data.AsDictionary.ContainsKey(fsSerializer.Key_Content))
			{
				data = data.AsDictionary[fsSerializer.Key_Content];
			}
			if (data.IsDictionary)
			{
				Dictionary<string, fsData> asDictionary = data.AsDictionary;
				asDictionary.Remove(fsSerializer.Key_ObjectReference);
				asDictionary.Remove(fsSerializer.Key_ObjectDefinition);
				asDictionary.Remove(fsSerializer.Key_InstanceType);
				asDictionary.Remove(fsSerializer.Key_Version);
			}
		}

		private static void ConvertLegacyData(ref fsData data)
		{
			if (!data.IsDictionary)
			{
				return;
			}
			Dictionary<string, fsData> asDictionary = data.AsDictionary;
			if (asDictionary.Count > 2)
			{
				return;
			}
			string key = "ReferenceId";
			string key2 = "SourceId";
			string key3 = "Data";
			string key4 = "Type";
			string key5 = "Data";
			if (asDictionary.Count == 2 && asDictionary.ContainsKey(key4) && asDictionary.ContainsKey(key5))
			{
				data = asDictionary[key5];
				fsSerializer.EnsureDictionary(data);
				fsSerializer.ConvertLegacyData(ref data);
				data.AsDictionary[fsSerializer.Key_InstanceType] = asDictionary[key4];
			}
			else if (asDictionary.Count == 2 && asDictionary.ContainsKey(key2) && asDictionary.ContainsKey(key3))
			{
				data = asDictionary[key3];
				fsSerializer.EnsureDictionary(data);
				fsSerializer.ConvertLegacyData(ref data);
				data.AsDictionary[fsSerializer.Key_ObjectDefinition] = asDictionary[key2];
			}
			else if (asDictionary.Count == 1 && asDictionary.ContainsKey(key))
			{
				data = fsData.CreateDictionary();
				data.AsDictionary[fsSerializer.Key_ObjectReference] = asDictionary[key];
			}
		}

		private static void Invoke_OnBeforeSerialize(List<fsObjectProcessor> processors, Type storageType, object instance)
		{
			for (int i = 0; i < processors.Count; i++)
			{
				processors[i].OnBeforeSerialize(storageType, instance);
			}
		}

		private static void Invoke_OnAfterSerialize(List<fsObjectProcessor> processors, Type storageType, object instance, ref fsData data)
		{
			for (int i = processors.Count - 1; i >= 0; i--)
			{
				processors[i].OnAfterSerialize(storageType, instance, ref data);
			}
		}

		private static void Invoke_OnBeforeDeserialize(List<fsObjectProcessor> processors, Type storageType, ref fsData data)
		{
			for (int i = 0; i < processors.Count; i++)
			{
				processors[i].OnBeforeDeserialize(storageType, ref data);
			}
		}

		private static void Invoke_OnBeforeDeserializeAfterInstanceCreation(List<fsObjectProcessor> processors, Type storageType, object instance, ref fsData data)
		{
			for (int i = 0; i < processors.Count; i++)
			{
				processors[i].OnBeforeDeserializeAfterInstanceCreation(storageType, instance, ref data);
			}
		}

		private static void Invoke_OnAfterDeserialize(List<fsObjectProcessor> processors, Type storageType, object instance)
		{
			for (int i = processors.Count - 1; i >= 0; i--)
			{
				processors[i].OnAfterDeserialize(storageType, instance);
			}
		}

		private static void EnsureDictionary(fsData data)
		{
			if (!data.IsDictionary)
			{
				fsData value = data.Clone();
				data.BecomeDictionary();
				data.AsDictionary[fsSerializer.Key_Content] = value;
			}
		}

		public void AddProcessor(fsObjectProcessor processor)
		{
			this._processors.Add(processor);
			this._cachedProcessors = new Dictionary<Type, List<fsObjectProcessor>>();
		}

		public void RemoveProcessor<TProcessor>()
		{
			int i = 0;
			while (i < this._processors.Count)
			{
				if (this._processors[i] is TProcessor)
				{
					this._processors.RemoveAt(i);
				}
				else
				{
					i++;
				}
			}
			this._cachedProcessors = new Dictionary<Type, List<fsObjectProcessor>>();
		}

		private List<fsObjectProcessor> GetProcessors(Type type)
		{
			fsObjectAttribute attribute = fsPortableReflection.GetAttribute<fsObjectAttribute>(type);
			List<fsObjectProcessor> list;
			if (attribute != null && attribute.Processor != null)
			{
				fsObjectProcessor item = (fsObjectProcessor)Activator.CreateInstance(attribute.Processor);
				list = new List<fsObjectProcessor>();
				list.Add(item);
				this._cachedProcessors[type] = list;
			}
			else if (!this._cachedProcessors.TryGetValue(type, out list))
			{
				list = new List<fsObjectProcessor>();
				for (int i = 0; i < this._processors.Count; i++)
				{
					fsObjectProcessor fsObjectProcessor = this._processors[i];
					if (fsObjectProcessor.CanProcess(type))
					{
						list.Add(fsObjectProcessor);
					}
				}
				this._cachedProcessors[type] = list;
			}
			return list;
		}

		public void AddConverter(fsBaseConverter converter)
		{
			if (converter.Serializer != null)
			{
				throw new InvalidOperationException("Cannot add a single converter instance to multiple fsConverters -- please construct a new instance for " + converter);
			}
			if (converter is fsDirectConverter)
			{
				fsDirectConverter fsDirectConverter = (fsDirectConverter)converter;
				this._availableDirectConverters[fsDirectConverter.ModelType] = fsDirectConverter;
			}
			else
			{
				if (!(converter is fsConverter))
				{
					throw new InvalidOperationException("Unable to add converter " + converter + "; the type association strategy is unknown. Please use either fsDirectConverter or fsConverter as your base type.");
				}
				this._availableConverters.Insert(0, (fsConverter)converter);
			}
			converter.Serializer = this;
			this._cachedConverters = new Dictionary<Type, fsBaseConverter>();
		}

		private fsBaseConverter GetConverter(Type type, Type overrideConverterType)
		{
			if (overrideConverterType != null)
			{
				fsBaseConverter fsBaseConverter;
				if (!this._cachedConverterTypeInstances.TryGetValue(overrideConverterType, out fsBaseConverter))
				{
					fsBaseConverter = (fsBaseConverter)Activator.CreateInstance(overrideConverterType);
					fsBaseConverter.Serializer = this;
					this._cachedConverterTypeInstances[overrideConverterType] = fsBaseConverter;
				}
				return fsBaseConverter;
			}
			fsBaseConverter fsBaseConverter2;
			if (this._cachedConverters.TryGetValue(type, out fsBaseConverter2))
			{
				return fsBaseConverter2;
			}
			fsObjectAttribute attribute = fsPortableReflection.GetAttribute<fsObjectAttribute>(type);
			if (attribute != null && attribute.Converter != null)
			{
				fsBaseConverter2 = (fsBaseConverter)Activator.CreateInstance(attribute.Converter);
				fsBaseConverter2.Serializer = this;
				fsBaseConverter fsBaseConverter3 = fsBaseConverter2;
				this._cachedConverters[type] = fsBaseConverter3;
				return fsBaseConverter3;
			}
			fsForwardAttribute attribute2 = fsPortableReflection.GetAttribute<fsForwardAttribute>(type);
			if (attribute2 != null)
			{
				fsBaseConverter2 = new fsForwardConverter(attribute2);
				fsBaseConverter2.Serializer = this;
				fsBaseConverter fsBaseConverter3 = fsBaseConverter2;
				this._cachedConverters[type] = fsBaseConverter3;
				return fsBaseConverter3;
			}
			if (!this._cachedConverters.TryGetValue(type, out fsBaseConverter2))
			{
				if (this._availableDirectConverters.ContainsKey(type))
				{
					fsBaseConverter2 = this._availableDirectConverters[type];
					fsBaseConverter fsBaseConverter3 = fsBaseConverter2;
					this._cachedConverters[type] = fsBaseConverter3;
					return fsBaseConverter3;
				}
				for (int i = 0; i < this._availableConverters.Count; i++)
				{
					if (this._availableConverters[i].CanProcess(type))
					{
						fsBaseConverter2 = this._availableConverters[i];
						fsBaseConverter fsBaseConverter3 = fsBaseConverter2;
						this._cachedConverters[type] = fsBaseConverter3;
						return fsBaseConverter3;
					}
				}
			}
			throw new InvalidOperationException("Internal error -- could not find a converter for " + type);
		}

		public fsResult TrySerialize<T>(T instance, out fsData data)
		{
			return this.TrySerialize(typeof(T), instance, out data);
		}

		public fsResult TryDeserialize<T>(fsData data, ref T instance)
		{
			object obj = instance;
			fsResult result = this.TryDeserialize(data, typeof(T), ref obj);
			if (result.Succeeded)
			{
				instance = (T)((object)obj);
			}
			return result;
		}

		public fsResult TrySerialize(Type storageType, object instance, out fsData data)
		{
			return this.TrySerialize(storageType, null, instance, out data);
		}

		public fsResult TrySerialize(Type storageType, Type overrideConverterType, object instance, out fsData data)
		{
			List<fsObjectProcessor> processors = this.GetProcessors((instance != null) ? instance.GetType() : storageType);
			fsSerializer.Invoke_OnBeforeSerialize(processors, storageType, instance);
			if (object.ReferenceEquals(instance, null))
			{
				data = new fsData();
				fsSerializer.Invoke_OnAfterSerialize(processors, storageType, instance, ref data);
				return fsResult.Success;
			}
			fsResult result = this.InternalSerialize_1_ProcessCycles(storageType, overrideConverterType, instance, out data);
			fsSerializer.Invoke_OnAfterSerialize(processors, storageType, instance, ref data);
			return result;
		}

		private fsResult InternalSerialize_1_ProcessCycles(Type storageType, Type overrideConverterType, object instance, out fsData data)
		{
			fsResult result;
			try
			{
				this._references.Enter();
				fsBaseConverter converter = this.GetConverter(instance.GetType(), overrideConverterType);
				if (!converter.RequestCycleSupport(instance.GetType()))
				{
					result = this.InternalSerialize_2_Inheritance(storageType, overrideConverterType, instance, out data);
				}
				else if (this._references.IsReference(instance))
				{
					data = fsData.CreateDictionary();
					this._lazyReferenceWriter.WriteReference(this._references.GetReferenceId(instance), data.AsDictionary);
					result = fsResult.Success;
				}
				else
				{
					this._references.MarkSerialized(instance);
					fsResult fsResult = this.InternalSerialize_2_Inheritance(storageType, overrideConverterType, instance, out data);
					if (fsResult.Failed)
					{
						result = fsResult;
					}
					else
					{
						this._lazyReferenceWriter.WriteDefinition(this._references.GetReferenceId(instance), data);
						result = fsResult;
					}
				}
			}
			finally
			{
				if (this._references.Exit())
				{
					this._lazyReferenceWriter.Clear();
				}
			}
			return result;
		}

		private fsResult InternalSerialize_2_Inheritance(Type storageType, Type overrideConverterType, object instance, out fsData data)
		{
			fsResult result = this.InternalSerialize_3_ProcessVersioning(overrideConverterType, instance, out data);
			if (result.Failed)
			{
				return result;
			}
			if (storageType != instance.GetType() && this.GetConverter(storageType, overrideConverterType).RequestInheritanceSupport(storageType))
			{
				fsSerializer.EnsureDictionary(data);
				data.AsDictionary[fsSerializer.Key_InstanceType] = new fsData(instance.GetType().FullName);
			}
			return result;
		}

		private fsResult InternalSerialize_3_ProcessVersioning(Type overrideConverterType, object instance, out fsData data)
		{
			fsOption<fsVersionedType> versionedType = fsVersionManager.GetVersionedType(instance.GetType());
			if (!versionedType.HasValue)
			{
				return this.InternalSerialize_4_Converter(overrideConverterType, instance, out data);
			}
			fsVersionedType value = versionedType.Value;
			fsResult result = this.InternalSerialize_4_Converter(overrideConverterType, instance, out data);
			if (result.Failed)
			{
				return result;
			}
			fsSerializer.EnsureDictionary(data);
			data.AsDictionary[fsSerializer.Key_Version] = new fsData(value.VersionString);
			return result;
		}

		private fsResult InternalSerialize_4_Converter(Type overrideConverterType, object instance, out fsData data)
		{
			Type type = instance.GetType();
			return this.GetConverter(type, overrideConverterType).TrySerialize(instance, out data, type);
		}

		public fsResult TryDeserialize(fsData data, Type storageType, ref object result)
		{
			return this.TryDeserialize(data, storageType, null, ref result);
		}

		public fsResult TryDeserialize(fsData data, Type storageType, Type overrideConverterType, ref object result)
		{
			if (data.IsNull)
			{
				result = null;
				List<fsObjectProcessor> processors = this.GetProcessors(storageType);
				fsSerializer.Invoke_OnBeforeDeserialize(processors, storageType, ref data);
				fsSerializer.Invoke_OnAfterDeserialize(processors, storageType, null);
				return fsResult.Success;
			}
			fsSerializer.ConvertLegacyData(ref data);
			fsResult result2;
			try
			{
				this._references.Enter();
				List<fsObjectProcessor> processors2;
				fsResult fsResult = this.InternalDeserialize_1_CycleReference(overrideConverterType, data, storageType, ref result, out processors2);
				if (fsResult.Succeeded)
				{
					fsSerializer.Invoke_OnAfterDeserialize(processors2, storageType, result);
				}
				result2 = fsResult;
			}
			finally
			{
				this._references.Exit();
			}
			return result2;
		}

		private fsResult InternalDeserialize_1_CycleReference(Type overrideConverterType, fsData data, Type storageType, ref object result, out List<fsObjectProcessor> processors)
		{
			if (fsSerializer.IsObjectReference(data))
			{
				int id = int.Parse(data.AsDictionary[fsSerializer.Key_ObjectReference].AsString);
				result = this._references.GetReferenceObject(id);
				processors = this.GetProcessors(result.GetType());
				return fsResult.Success;
			}
			return this.InternalDeserialize_2_Version(overrideConverterType, data, storageType, ref result, out processors);
		}

		private fsResult InternalDeserialize_2_Version(Type overrideConverterType, fsData data, Type storageType, ref object result, out List<fsObjectProcessor> processors)
		{
			if (fsSerializer.IsVersioned(data))
			{
				string asString = data.AsDictionary[fsSerializer.Key_Version].AsString;
				fsOption<fsVersionedType> versionedType = fsVersionManager.GetVersionedType(storageType);
				if (versionedType.HasValue && versionedType.Value.VersionString != asString)
				{
					fsResult fsResult = fsResult.Success;
					List<fsVersionedType> list;
					fsResult += fsVersionManager.GetVersionImportPath(asString, versionedType.Value, out list);
					if (fsResult.Failed)
					{
						processors = this.GetProcessors(storageType);
						return fsResult;
					}
					fsResult += this.InternalDeserialize_3_Inheritance(overrideConverterType, data, list[0].ModelType, ref result, out processors);
					if (fsResult.Failed)
					{
						return fsResult;
					}
					for (int i = 1; i < list.Count; i++)
					{
						result = list[i].Migrate(result);
					}
					if (fsSerializer.IsObjectDefinition(data))
					{
						int id = int.Parse(data.AsDictionary[fsSerializer.Key_ObjectDefinition].AsString);
						this._references.AddReferenceWithId(id, result);
					}
					processors = this.GetProcessors(fsResult.GetType());
					return fsResult;
				}
			}
			return this.InternalDeserialize_3_Inheritance(overrideConverterType, data, storageType, ref result, out processors);
		}

		private fsResult InternalDeserialize_3_Inheritance(Type overrideConverterType, fsData data, Type storageType, ref object result, out List<fsObjectProcessor> processors)
		{
			fsResult fsResult = fsResult.Success;
			Type type = storageType;
			if (fsSerializer.IsTypeSpecified(data))
			{
				fsData fsData = data.AsDictionary[fsSerializer.Key_InstanceType];
				if (!fsData.IsString)
				{
					fsResult.AddMessage(string.Concat(new object[]
					{
						fsSerializer.Key_InstanceType,
						" value must be a string (in ",
						data,
						")"
					}));
				}
				else
				{
					string asString = fsData.AsString;
					Type type2 = fsTypeCache.GetType(asString);
					if (type2 == null)
					{
						fsResult += fsResult.Fail("Unable to locate specified type \"" + asString + "\"");
					}
					else if (!storageType.IsAssignableFrom(type2))
					{
						fsResult.AddMessage(string.Concat(new object[]
						{
							"Ignoring type specifier; a field/property of type ",
							storageType,
							" cannot hold an instance of ",
							type2
						}));
					}
					else
					{
						type = type2;
					}
				}
			}
			processors = this.GetProcessors(type);
			if (fsResult.Failed)
			{
				return fsResult;
			}
			fsSerializer.Invoke_OnBeforeDeserialize(processors, storageType, ref data);
			if (object.ReferenceEquals(result, null) || result.GetType() != type)
			{
				result = this.GetConverter(type, overrideConverterType).CreateInstance(data, type);
			}
			fsSerializer.Invoke_OnBeforeDeserializeAfterInstanceCreation(processors, storageType, result, ref data);
			return fsResult + this.InternalDeserialize_4_Cycles(overrideConverterType, data, type, ref result);
		}

		private fsResult InternalDeserialize_4_Cycles(Type overrideConverterType, fsData data, Type resultType, ref object result)
		{
			if (fsSerializer.IsObjectDefinition(data))
			{
				int id = int.Parse(data.AsDictionary[fsSerializer.Key_ObjectDefinition].AsString);
				this._references.AddReferenceWithId(id, result);
			}
			return this.InternalDeserialize_5_Converter(overrideConverterType, data, resultType, ref result);
		}

		private fsResult InternalDeserialize_5_Converter(Type overrideConverterType, fsData data, Type resultType, ref object result)
		{
			if (fsSerializer.IsWrappedData(data))
			{
				data = data.AsDictionary[fsSerializer.Key_Content];
			}
			return this.GetConverter(resultType, overrideConverterType).TryDeserialize(data, ref result, resultType);
		}
	}
}
