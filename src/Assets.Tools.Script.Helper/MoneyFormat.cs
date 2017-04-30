using System;

namespace Assets.Tools.Script.Helper
{
	public static class MoneyFormat
	{
		public static string ToMoneyW(int money)
		{
			if (money >= 10000)
			{
				float num = (float)money / 10000f;
				return num + "万";
			}
			return money.ToString("N0");
		}
	}
}
