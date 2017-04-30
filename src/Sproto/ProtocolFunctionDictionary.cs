using System;
using System.Collections.Generic;

namespace Sproto
{
	public class ProtocolFunctionDictionary
	{
		public class MetaInfo
		{
			public Type ProtocolType;

			public KeyValuePair<Type, ProtocolFunctionDictionary.typeFunc> Request;

			public KeyValuePair<Type, ProtocolFunctionDictionary.typeFunc> Response;
		}

		public delegate SprotoTypeBase typeFunc(byte[] buffer, int offset);

		private Dictionary<int, ProtocolFunctionDictionary.MetaInfo> MetaDictionary;

		private Dictionary<Type, int> ProtocolDictionary;

		public ProtocolFunctionDictionary.MetaInfo this[int tag]
		{
			get
			{
				return this.MetaDictionary[tag];
			}
		}

		public int this[Type protocolType]
		{
			get
			{
				return this.ProtocolDictionary[protocolType];
			}
		}

		public ProtocolFunctionDictionary()
		{
			this.MetaDictionary = new Dictionary<int, ProtocolFunctionDictionary.MetaInfo>();
			this.ProtocolDictionary = new Dictionary<Type, int>();
		}

		private ProtocolFunctionDictionary.MetaInfo _getMeta(int tag)
		{
			ProtocolFunctionDictionary.MetaInfo metaInfo;
			if (!this.MetaDictionary.TryGetValue(tag, out metaInfo))
			{
				metaInfo = new ProtocolFunctionDictionary.MetaInfo();
				this.MetaDictionary.Add(tag, metaInfo);
			}
			return metaInfo;
		}

		public void SetProtocol<ProtocolType>(int tag)
		{
			ProtocolFunctionDictionary.MetaInfo metaInfo = this._getMeta(tag);
			metaInfo.ProtocolType = typeof(ProtocolType);
			this.ProtocolDictionary.Add(metaInfo.ProtocolType, tag);
		}

		public void SetRequest<T>(int tag) where T : SprotoTypeBase, new()
		{
			ProtocolFunctionDictionary.MetaInfo metaInfo = this._getMeta(tag);
			this._set<T>(tag, out metaInfo.Request);
		}

		public void SetResponse<T>(int tag) where T : SprotoTypeBase, new()
		{
			ProtocolFunctionDictionary.MetaInfo metaInfo = this._getMeta(tag);
			this._set<T>(tag, out metaInfo.Response);
		}

		private void _set<T>(int tag, out KeyValuePair<Type, ProtocolFunctionDictionary.typeFunc> field) where T : SprotoTypeBase, new()
		{
			ProtocolFunctionDictionary.typeFunc value = delegate(byte[] buffer, int offset)
			{
				T t = Activator.CreateInstance<T>();
				t.init(buffer, offset);
				return t;
			};
			field = new KeyValuePair<Type, ProtocolFunctionDictionary.typeFunc>(typeof(T), value);
		}

		private SprotoTypeBase _gen(KeyValuePair<Type, ProtocolFunctionDictionary.typeFunc> field, int tag, byte[] buffer, int offset = 0)
		{
			if (field.Value != null)
			{
				return field.Value(buffer, offset);
			}
			return null;
		}

		public SprotoTypeBase GenResponse(int tag, byte[] buffer, int offset = 0)
		{
			ProtocolFunctionDictionary.MetaInfo metaInfo = this.MetaDictionary[tag];
			return this._gen(metaInfo.Response, tag, buffer, offset);
		}

		public SprotoTypeBase GenRequest(int tag, byte[] buffer, int offset = 0)
		{
			ProtocolFunctionDictionary.MetaInfo metaInfo = this.MetaDictionary[tag];
			return this._gen(metaInfo.Request, tag, buffer, offset);
		}
	}
}
