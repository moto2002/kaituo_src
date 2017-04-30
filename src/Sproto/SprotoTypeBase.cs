using System;
using System.IO;

namespace Sproto
{
	public abstract class SprotoTypeBase
	{
		protected SprotoTypeFieldOP has_field;

		protected SprotoTypeSerialize serialize;

		protected SprotoTypeDeserialize deserialize;

		public SprotoTypeBase(int max_field_count)
		{
			this.has_field = new SprotoTypeFieldOP(max_field_count);
			this.serialize = new SprotoTypeSerialize(max_field_count);
			this.deserialize = new SprotoTypeDeserialize();
		}

		public SprotoTypeBase(int max_field_count, byte[] buffer)
		{
			this.has_field = new SprotoTypeFieldOP(max_field_count);
			this.serialize = new SprotoTypeSerialize(max_field_count);
			this.deserialize = new SprotoTypeDeserialize(buffer);
		}

		public int init(byte[] buffer, int offset = 0)
		{
			this.clear();
			this.deserialize.init(buffer, offset);
			this.decode();
			return this.deserialize.size();
		}

		public long init(SprotoTypeReader reader)
		{
			this.clear();
			this.deserialize.init(reader);
			this.decode();
			return (long)this.deserialize.size();
		}

		public abstract int encode(SprotoStream stream);

		public byte[] encode()
		{
			SprotoStream sprotoStream = new SprotoStream();
			this.encode(sprotoStream);
			int position = sprotoStream.Position;
			byte[] array = new byte[position];
			sprotoStream.Seek(0, SeekOrigin.Begin);
			sprotoStream.Read(array, 0, position);
			return array;
		}

		protected abstract void decode();

		public void clear()
		{
			this.has_field.clear_field();
			this.deserialize.clear();
		}
	}
}
