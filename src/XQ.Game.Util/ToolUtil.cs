using System;

namespace XQ.Game.Util
{
	public class ToolUtil
	{
		private static Random random = new Random();

		private static ulong id = 100uL;

		public static void ResetRandom(Random rand)
		{
			ToolUtil.random = rand;
		}

		public static int Random(int min, int max)
		{
			return ToolUtil.random.Next(min, max);
		}

		public static float Random(float min, float max)
		{
			int num = ToolUtil.random.Next(0, 100001);
			float num2 = (float)num * (max - min) / 100000f;
			return min + num2;
		}

		public static int Random100()
		{
			return ToolUtil.random.Next(1, 101);
		}

		public static ulong GetInstanceId()
		{
			ulong expr_0A = ToolUtil.id;
			ToolUtil.id = expr_0A + 1uL;
			return expr_0A;
		}

		public static ulong HoldInstanceId(ulong count)
		{
			ulong result = ToolUtil.id;
			ToolUtil.id += count;
			return result;
		}
	}
}
