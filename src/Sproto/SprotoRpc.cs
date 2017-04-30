using SprotoType;
using System;
using System.Collections.Generic;
using System.IO;

namespace Sproto
{
	public class SprotoRpc
	{
		public enum RpcType
		{
			REQUEST = 1,
			RESPONSE
		}

		public struct RpcInfo
		{
			public SprotoRpc.RpcType type;

			public long? session;

			public int? tag;

			public SprotoTypeBase requestObj;

			public SprotoTypeBase responseObj;

			public SprotoRpc.ResponseFunction Response;
		}

		public class RpcRequest
		{
			private Package package = new Package();

			private SprotoStream stream = new SprotoStream();

			private SprotoPack spack = new SprotoPack();

			private ProtocolFunctionDictionary protocol;

			private SprotoRpc rpc;

			public RpcRequest(ProtocolFunctionDictionary protocol, SprotoRpc rpc)
			{
				this.protocol = protocol;
				this.rpc = rpc;
			}

			public byte[] Invoke<T>(SprotoTypeBase request = null, long? session = null)
			{
				int num = this.protocol[typeof(T)];
				ProtocolFunctionDictionary.MetaInfo metaInfo = this.protocol[num];
				this.package.clear();
				this.package.type = (long)num;
				if (session.HasValue)
				{
					this.rpc.sessionDictionary.Add(session.Value, metaInfo.Response.Value);
					this.package.session = session.Value;
				}
				this.stream.Seek(0, SeekOrigin.Begin);
				int num2 = this.package.encode(this.stream);
				if (request != null)
				{
					num2 += request.encode(this.stream);
				}
				return this.spack.pack(this.stream.Buffer, num2);
			}
		}

		public delegate byte[] ResponseFunction(SprotoTypeBase response);

		private SprotoStream stream = new SprotoStream();

		private SprotoPack spack = new SprotoPack();

		private Dictionary<long, ProtocolFunctionDictionary.typeFunc> sessionDictionary = new Dictionary<long, ProtocolFunctionDictionary.typeFunc>();

		private ProtocolFunctionDictionary protocol;

		private Package package = new Package();

		public SprotoRpc(ProtocolBase protocolObj = null)
		{
			this.protocol = ((protocolObj == null) ? null : protocolObj.Protocol);
		}

		public SprotoRpc.RpcRequest Attach(ProtocolBase protocolObj = null)
		{
			ProtocolFunctionDictionary protocolFunctionDictionary = (protocolObj == null) ? null : protocolObj.Protocol;
			return new SprotoRpc.RpcRequest(protocolFunctionDictionary, this);
		}

		public SprotoRpc.RpcInfo Dispatch(byte[] buffer, int offset = 0)
		{
			buffer = this.spack.unpack(buffer, buffer.Length - offset);
			offset = this.package.init(buffer, 0);
			SprotoRpc.RpcInfo result;
			if (this.package.HasType)
			{
				int tag = (int)this.package.type;
				result.session = null;
				result.tag = new int?(tag);
				result.responseObj = null;
				result.requestObj = ((this.protocol == null) ? null : this.protocol.GenRequest(tag, buffer, offset));
				result.type = SprotoRpc.RpcType.REQUEST;
				result.Response = null;
				if (this.package.HasSession)
				{
					long session = this.package.session;
					result.Response = delegate(SprotoTypeBase response)
					{
						ProtocolFunctionDictionary.MetaInfo metaInfo = this.protocol[tag];
						this.stream.Seek(0, SeekOrigin.Begin);
						this.package.clear();
						this.package.session = session;
						this.package.encode(this.stream);
						response.encode(this.stream);
						int position = this.stream.Position;
						byte[] array = new byte[position];
						this.stream.Seek(0, SeekOrigin.Begin);
						this.stream.Read(array, 0, position);
						return this.spack.pack(array, 0);
					};
				}
			}
			else
			{
				if (!this.package.HasSession)
				{
					throw new Exception("session not found");
				}
				ProtocolFunctionDictionary.typeFunc typeFunc;
				if (!this.sessionDictionary.TryGetValue(this.package.session, out typeFunc))
				{
					throw new Exception("Unknown session: " + this.package.session);
				}
				result.tag = null;
				result.session = new long?(this.package.session);
				result.requestObj = null;
				result.Response = null;
				result.type = SprotoRpc.RpcType.RESPONSE;
				result.responseObj = ((typeFunc != null) ? typeFunc(buffer, offset) : null);
			}
			return result;
		}
	}
}
