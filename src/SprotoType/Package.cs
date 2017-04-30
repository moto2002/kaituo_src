using Sproto;
using System;

namespace SprotoType
{
	public class Package : SprotoTypeBase
	{
		private static int max_field_count = 2;

		private long _type;

		private long _session;

		public long type
		{
			get
			{
				return this._type;
			}
			set
			{
				this.has_field.set_field(0, true);
				this._type = value;
			}
		}

		public bool HasType
		{
			get
			{
				return this.has_field.has_field(0);
			}
		}

		public long session
		{
			get
			{
				return this._session;
			}
			set
			{
				this.has_field.set_field(1, true);
				this._session = value;
			}
		}

		public bool HasSession
		{
			get
			{
				return this.has_field.has_field(1);
			}
		}

		public Package() : base(Package.max_field_count)
		{
		}

		public Package(byte[] buffer) : base(Package.max_field_count, buffer)
		{
			this.decode();
		}

		protected override void decode()
		{
			int num;
			while ((num = this.deserialize.read_tag()) != -1)
			{
				int num2 = num;
				if (num2 != 0)
				{
					if (num2 != 1)
					{
						this.deserialize.read_unknow_data();
					}
					else
					{
						this.session = this.deserialize.read_integer();
					}
				}
				else
				{
					this.type = this.deserialize.read_integer();
				}
			}
		}

		public override int encode(SprotoStream stream)
		{
			this.serialize.open(stream);
			if (this.has_field.has_field(0))
			{
				this.serialize.write_integer(this.type, 0);
			}
			if (this.has_field.has_field(1))
			{
				this.serialize.write_integer(this.session, 1);
			}
			return this.serialize.close();
		}
	}
}
