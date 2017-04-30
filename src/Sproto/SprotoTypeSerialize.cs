using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sproto
{
	public class SprotoTypeSerialize
	{
		private delegate void write_func();

		private int header_idx;

		private int header_sz;

		private int header_cap = SprotoTypeSize.sizeof_header;

		private SprotoStream data;

		private int data_idx;

		private int lasttag = -1;

		private int index;

		public SprotoTypeSerialize(int max_field_count)
		{
			this.header_sz = SprotoTypeSize.sizeof_header + max_field_count * SprotoTypeSize.sizeof_field;
		}

		private void set_header_fn(int fn)
		{
			this.data[this.header_idx - 2] = (byte)(fn & 255);
			this.data[this.header_idx - 1] = (byte)(fn >> 8 & 255);
		}

		private void write_header_record(int record)
		{
			this.data[this.header_idx + this.header_cap - 2] = (byte)(record & 255);
			this.data[this.header_idx + this.header_cap - 1] = (byte)(record >> 8 & 255);
			this.header_cap += 2;
			this.index++;
		}

		private void write_uint32_to_uint64_sign(bool is_negative)
		{
			byte v = (!is_negative) ? 0 : 255;
			this.data.WriteByte(v);
			this.data.WriteByte(v);
			this.data.WriteByte(v);
			this.data.WriteByte(v);
		}

		private void write_tag(int tag, int value)
		{
			int num = tag - this.lasttag - 1;
			if (num > 0)
			{
				num = (num - 1) * 2 + 1;
				if (num > 65535)
				{
					SprotoTypeSize.error("tag is too big.");
				}
				this.write_header_record(num);
			}
			this.write_header_record(value);
			this.lasttag = tag;
		}

		private void write_uint32(uint v)
		{
			this.data.WriteByte((byte)(v & 255u));
			this.data.WriteByte((byte)(v >> 8 & 255u));
			this.data.WriteByte((byte)(v >> 16 & 255u));
			this.data.WriteByte((byte)(v >> 24 & 255u));
		}

		private void write_uint64(ulong v)
		{
			this.data.WriteByte((byte)(v & 255uL));
			this.data.WriteByte((byte)(v >> 8 & 255uL));
			this.data.WriteByte((byte)(v >> 16 & 255uL));
			this.data.WriteByte((byte)(v >> 24 & 255uL));
			this.data.WriteByte((byte)(v >> 32 & 255uL));
			this.data.WriteByte((byte)(v >> 40 & 255uL));
			this.data.WriteByte((byte)(v >> 48 & 255uL));
			this.data.WriteByte((byte)(v >> 56 & 255uL));
		}

		private void fill_size(int sz)
		{
			if (sz < 0)
			{
				SprotoTypeSize.error("fill invaild size.");
			}
			this.write_uint32((uint)sz);
		}

		private int encode_integer(uint v)
		{
			this.fill_size(4);
			this.write_uint32(v);
			return SprotoTypeSize.sizeof_length + 4;
		}

		private int encode_uint64(ulong v)
		{
			this.fill_size(8);
			this.write_uint64(v);
			return SprotoTypeSize.sizeof_length + 8;
		}

		private int encode_string(string str)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(str);
			this.fill_size(bytes.Length);
			this.data.Write(bytes, 0, bytes.Length);
			return SprotoTypeSize.sizeof_length + bytes.Length;
		}

		private int encode_struct(SprotoTypeBase obj)
		{
			int position = this.data.Position;
			this.data.Seek(SprotoTypeSize.sizeof_length, SeekOrigin.Current);
			int num = obj.encode(this.data);
			int position2 = this.data.Position;
			this.data.Seek(position, SeekOrigin.Begin);
			this.fill_size(num);
			this.data.Seek(position2, SeekOrigin.Begin);
			return SprotoTypeSize.sizeof_length + num;
		}

		private void clear()
		{
			this.index = 0;
			this.header_idx = 2;
			this.lasttag = -1;
			this.data = null;
			this.header_cap = SprotoTypeSize.sizeof_header;
		}

		public void write_integer(long integer, int tag)
		{
			long num = integer >> 31;
			int num2 = (num != 0L && num != -1L) ? 8 : 4;
			int value = 0;
			if (num2 == 4)
			{
				uint num3 = (uint)integer;
				if (num3 < 32767u)
				{
					value = (int)((num3 + 1u) * 2u);
				}
				else
				{
					num2 = this.encode_integer(num3);
				}
			}
			else if (num2 == 8)
			{
				num2 = this.encode_uint64((ulong)integer);
			}
			else
			{
				SprotoTypeSize.error("invaild integer size.");
			}
			this.write_tag(tag, value);
		}

		public void write_integer(List<long> integer_list, int tag)
		{
			if (integer_list == null || integer_list.Count <= 0)
			{
				return;
			}
			int position = this.data.Position;
			this.data.Seek(position + SprotoTypeSize.sizeof_length, SeekOrigin.Begin);
			int position2 = this.data.Position;
			int num = 4;
			this.data.Seek(position2 + 1, SeekOrigin.Begin);
			for (int i = 0; i < integer_list.Count; i++)
			{
				long num2 = integer_list[i];
				long num3 = num2 >> 31;
				int num4 = (num3 != 0L && num3 != -1L) ? 8 : 4;
				if (num4 == 4)
				{
					this.write_uint32((uint)num2);
					if (num == 8)
					{
						bool is_negative = (num2 & (long)((ulong)-2147483648)) != 0L;
						this.write_uint32_to_uint64_sign(is_negative);
					}
				}
				else if (num4 == 8)
				{
					if (num == 4)
					{
						this.data.Seek(position2 + 1, SeekOrigin.Begin);
						for (int j = 0; j < i; j++)
						{
							ulong v = (ulong)integer_list[j];
							this.write_uint64(v);
						}
						num = 8;
					}
					this.write_uint64((ulong)num2);
				}
				else
				{
					SprotoTypeSize.error("invalid integer size(" + num4 + ")");
				}
			}
			int position3 = this.data.Position;
			this.data.Seek(position2, SeekOrigin.Begin);
			this.data.WriteByte((byte)num);
			int sz = position3 - position2;
			this.data.Seek(position, SeekOrigin.Begin);
			this.fill_size(sz);
			this.data.Seek(position3, SeekOrigin.Begin);
			this.write_tag(tag, 0);
		}

		public void write_boolean(bool b, int tag)
		{
			long integer = (!b) ? 0L : 1L;
			this.write_integer(integer, tag);
		}

		public void write_boolean(List<bool> b_list, int tag)
		{
			if (b_list == null || b_list.Count <= 0)
			{
				return;
			}
			this.fill_size(b_list.Count);
			for (int i = 0; i < b_list.Count; i++)
			{
				byte v = (!b_list[i]) ? 0 : 1;
				this.data.WriteByte(v);
			}
			this.write_tag(tag, 0);
		}

		public void write_string(string str, int tag)
		{
			this.encode_string(str);
			this.write_tag(tag, 0);
		}

		public void write_string(List<string> str_list, int tag)
		{
			if (str_list == null || str_list.Count <= 0)
			{
				return;
			}
			int num = 0;
			foreach (string current in str_list)
			{
				num += SprotoTypeSize.sizeof_length + Encoding.UTF8.GetByteCount(current);
			}
			this.fill_size(num);
			foreach (string current2 in str_list)
			{
				this.encode_string(current2);
			}
			this.write_tag(tag, 0);
		}

		public void write_obj(SprotoTypeBase obj, int tag)
		{
			this.encode_struct(obj);
			this.write_tag(tag, 0);
		}

		private void write_set(SprotoTypeSerialize.write_func func, int tag)
		{
			int position = this.data.Position;
			this.data.Seek(SprotoTypeSize.sizeof_length, SeekOrigin.Current);
			func();
			int position2 = this.data.Position;
			int sz = position2 - position - SprotoTypeSize.sizeof_length;
			this.data.Seek(position, SeekOrigin.Begin);
			this.fill_size(sz);
			this.data.Seek(position2, SeekOrigin.Begin);
			this.write_tag(tag, 0);
		}

		public void write_obj<T>(List<T> obj_list, int tag) where T : SprotoTypeBase
		{
			if (obj_list == null || obj_list.Count <= 0)
			{
				return;
			}
			SprotoTypeSerialize.write_func func = delegate
			{
				foreach (SprotoTypeBase obj in obj_list)
				{
					this.encode_struct(obj);
				}
			};
			this.write_set(func, tag);
		}

		public void write_obj<TK, TV>(Dictionary<TK, TV> map, int tag) where TV : SprotoTypeBase
		{
			if (map == null || map.Count <= 0)
			{
				return;
			}
			SprotoTypeSerialize.write_func func = delegate
			{
				foreach (KeyValuePair<TK, TV> current in map)
				{
					this.encode_struct(current.Value);
				}
			};
			this.write_set(func, tag);
		}

		public void open(SprotoStream stream)
		{
			this.clear();
			this.data = stream;
			this.header_idx = stream.Position + this.header_cap;
			this.data_idx = this.data.Seek(this.header_sz, SeekOrigin.Current);
		}

		public int close()
		{
			this.set_header_fn(this.index);
			int up_count = this.header_sz - this.header_cap;
			this.data.MoveUp(this.data_idx, up_count);
			int result = this.data.Position - this.header_idx + SprotoTypeSize.sizeof_header;
			this.clear();
			return result;
		}
	}
}
