using System;
using System.Collections.Generic;
using System.Text;

namespace Sproto
{
	public class SprotoTypeDeserialize
	{
		public delegate TK gen_key_func<TK, TV>(TV v);

		private SprotoTypeReader reader;

		private int begin_data_pos;

		private int cur_field_pos;

		private int fn;

		private int tag = -1;

		private int value;

		public SprotoTypeDeserialize()
		{
		}

		public SprotoTypeDeserialize(byte[] data)
		{
			this.init(data, 0);
		}

		public SprotoTypeDeserialize(SprotoTypeReader reader)
		{
			this.init(reader);
		}

		public void init(byte[] data, int offset = 0)
		{
			this.clear();
			this.reader = new SprotoTypeReader(data, offset, data.Length);
			this.init();
		}

		public void init(SprotoTypeReader reader)
		{
			this.clear();
			this.reader = reader;
			this.init();
		}

		private void init()
		{
			this.fn = this.read_word();
			int num = SprotoTypeSize.sizeof_header + this.fn * SprotoTypeSize.sizeof_field;
			this.begin_data_pos = num;
			this.cur_field_pos = this.reader.Position;
			if (this.reader.Length < num)
			{
				SprotoTypeSize.error("invalid decode header.");
			}
			this.reader.Seek(this.begin_data_pos);
		}

		private ulong expand64(uint v)
		{
			ulong num = (ulong)v;
			if ((num & (ulong)-2147483648) != 0uL)
			{
				num |= 18446744069414584320uL;
			}
			return num;
		}

		private int read_word()
		{
			return (int)this.reader.ReadByte() | (int)this.reader.ReadByte() << 8;
		}

		private uint read_dword()
		{
			return (uint)((int)this.reader.ReadByte() | (int)this.reader.ReadByte() << 8 | (int)this.reader.ReadByte() << 16 | (int)this.reader.ReadByte() << 24);
		}

		private uint read_array_size()
		{
			if (this.value >= 0)
			{
				SprotoTypeSize.error("invalid array value.");
			}
			uint num = this.read_dword();
			if (num < 1u)
			{
				SprotoTypeSize.error("error array size(" + num + ")");
			}
			return num;
		}

		public int read_tag()
		{
			int position = this.reader.Position;
			this.reader.Seek(this.cur_field_pos);
			while (this.reader.Position < this.begin_data_pos)
			{
				this.tag++;
				int num = this.read_word();
				if ((num & 1) == 0)
				{
					this.cur_field_pos = this.reader.Position;
					this.reader.Seek(position);
					this.value = num / 2 - 1;
					return this.tag;
				}
				this.tag += num / 2;
			}
			this.reader.Seek(position);
			return -1;
		}

		public long read_integer()
		{
			if (this.value >= 0)
			{
				return (long)this.value;
			}
			uint num = this.read_dword();
			if (num == 4u)
			{
				return (long)this.expand64(this.read_dword());
			}
			if (num == 8u)
			{
				uint num2 = this.read_dword();
				uint num3 = this.read_dword();
				return (long)((ulong)num2 | (ulong)num3 << 32);
			}
			SprotoTypeSize.error("read invalid integer size (" + num + ")");
			return 0L;
		}

		public List<long> read_integer_list()
		{
			List<long> list = null;
			uint num = this.read_array_size();
			int num2 = (int)this.reader.ReadByte();
			num -= 1u;
			if (num2 == 4)
			{
				if (num % 4u != 0u)
				{
					SprotoTypeSize.error("error array size(" + num + ")@sizeof(Uint32)");
				}
				list = new List<long>();
				int num3 = 0;
				while ((long)num3 < (long)((ulong)(num / 4u)))
				{
					ulong item = this.expand64(this.read_dword());
					list.Add((long)item);
					num3++;
				}
			}
			else if (num2 == 8)
			{
				if (num % 8u != 0u)
				{
					SprotoTypeSize.error("error array size(" + num + ")@sizeof(Uint64)");
				}
				list = new List<long>();
				int num4 = 0;
				while ((long)num4 < (long)((ulong)(num / 8u)))
				{
					uint num5 = this.read_dword();
					uint num6 = this.read_dword();
					ulong item2 = (ulong)num5 | (ulong)num6 << 32;
					list.Add((long)item2);
					num4++;
				}
			}
			else
			{
				SprotoTypeSize.error("error intlen(" + num2 + ")");
			}
			return list;
		}

		public bool read_boolean()
		{
			if (this.value < 0)
			{
				SprotoTypeSize.error("read invalid boolean.");
				return false;
			}
			return this.value != 0;
		}

		public List<bool> read_boolean_list()
		{
			uint num = this.read_array_size();
			List<bool> list = new List<bool>();
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				bool item = this.reader.ReadByte() != 0;
				list.Add(item);
				num2++;
			}
			return list;
		}

		public string read_string()
		{
			uint num = this.read_dword();
			byte[] array = new byte[num];
			this.reader.Read(array, 0, array.Length);
			return Encoding.UTF8.GetString(array);
		}

		public List<string> read_string_list()
		{
			uint num = this.read_array_size();
			List<string> list = new List<string>();
			uint num2 = 0u;
			while (num > 0u)
			{
				if ((ulong)num < (ulong)((long)SprotoTypeSize.sizeof_length))
				{
					SprotoTypeSize.error("error array size.");
				}
				uint num3 = this.read_dword();
				num -= (uint)SprotoTypeSize.sizeof_length;
				if (num3 > num)
				{
					SprotoTypeSize.error("error array object.");
				}
				byte[] array = new byte[num3];
				this.reader.Read(array, 0, array.Length);
				string @string = Encoding.UTF8.GetString(array);
				list.Add(@string);
				num -= num3;
				num2 += 1u;
			}
			return list;
		}

		public T read_obj<T>() where T : SprotoTypeBase, new()
		{
			int num = (int)this.read_dword();
			SprotoTypeReader sprotoTypeReader = new SprotoTypeReader(this.reader.Buffer, this.reader.Offset, num);
			this.reader.Seek(this.reader.Position + num);
			T result = Activator.CreateInstance<T>();
			result.init(sprotoTypeReader);
			return result;
		}

		private T read_element<T>(SprotoTypeReader reader, uint sz, out uint read_size) where T : SprotoTypeBase, new()
		{
			read_size = 0u;
			if ((ulong)sz < (ulong)((long)SprotoTypeSize.sizeof_length))
			{
				SprotoTypeSize.error("error array size.");
			}
			uint num = this.read_dword();
			sz -= (uint)SprotoTypeSize.sizeof_length;
			read_size += (uint)SprotoTypeSize.sizeof_length;
			if (num > sz)
			{
				SprotoTypeSize.error("error array object.");
			}
			reader.Init(this.reader.Buffer, this.reader.Offset, (int)num);
			this.reader.Seek(this.reader.Position + (int)num);
			T result = Activator.CreateInstance<T>();
			result.init(reader);
			read_size += num;
			return result;
		}

		public List<T> read_obj_list<T>() where T : SprotoTypeBase, new()
		{
			uint num = this.read_array_size();
			List<T> list = new List<T>();
			SprotoTypeReader sprotoTypeReader = new SprotoTypeReader();
			uint num2 = 0u;
			while (num > 0u)
			{
				uint num3;
				list.Add(this.read_element<T>(sprotoTypeReader, num, out num3));
				num -= num3;
				num2 += 1u;
			}
			return list;
		}

		public Dictionary<TK, TV> read_map<TK, TV>(SprotoTypeDeserialize.gen_key_func<TK, TV> func) where TV : SprotoTypeBase, new()
		{
			uint num = this.read_array_size();
			Dictionary<TK, TV> dictionary = new Dictionary<TK, TV>();
			SprotoTypeReader sprotoTypeReader = new SprotoTypeReader();
			uint num2 = 0u;
			while (num > 0u)
			{
				uint num3;
				TV v = this.read_element<TV>(sprotoTypeReader, num, out num3);
				TK key = func(v);
				dictionary.Add(key, v);
				num -= num3;
				num2 += 1u;
			}
			return dictionary;
		}

		public void read_unknow_data()
		{
			if (this.value < 0)
			{
				int num = (int)this.read_dword();
				this.reader.Seek(num + this.reader.Position);
			}
		}

		public int size()
		{
			return this.reader.Position;
		}

		public void clear()
		{
			this.fn = 0;
			this.tag = -1;
			this.value = 0;
			if (this.reader != null)
			{
				this.reader.Seek(0);
			}
		}
	}
}
