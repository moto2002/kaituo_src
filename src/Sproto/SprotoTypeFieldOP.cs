using System;

namespace Sproto
{
	public class SprotoTypeFieldOP
	{
		private static readonly int slot_bits_size = 32;

		public uint[] has_bits;

		public SprotoTypeFieldOP(int max_field_count)
		{
			int num = max_field_count / SprotoTypeFieldOP.slot_bits_size;
			if (max_field_count % SprotoTypeFieldOP.slot_bits_size > 0)
			{
				num++;
			}
			this.has_bits = new uint[num];
		}

		private int _get_array_idx(int bit_idx)
		{
			int num = this.has_bits.Length;
			return bit_idx / SprotoTypeFieldOP.slot_bits_size;
		}

		private int _get_slotbit_idx(int bit_idx)
		{
			int num = this.has_bits.Length;
			return bit_idx % SprotoTypeFieldOP.slot_bits_size;
		}

		public bool has_field(int field_idx)
		{
			int num = this._get_array_idx(field_idx);
			int num2 = this._get_slotbit_idx(field_idx);
			uint num3 = this.has_bits[num];
			uint num4 = 1u << num2;
			return Convert.ToBoolean(num3 & num4);
		}

		public void set_field(int field_idx, bool is_has)
		{
			int num = this._get_array_idx(field_idx);
			int num2 = this._get_slotbit_idx(field_idx);
			uint num3 = this.has_bits[num];
			if (is_has)
			{
				uint num4 = 1u << num2;
				this.has_bits[num] = (num3 | num4);
			}
			else
			{
				uint num5 = ~(1u << num2);
				this.has_bits[num] = (num3 & num5);
			}
		}

		public void clear_field()
		{
			for (int i = 0; i < this.has_bits.Length; i++)
			{
				this.has_bits[i] = 0u;
			}
		}
	}
}
