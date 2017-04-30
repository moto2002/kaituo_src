using System;

namespace Assets.Scripts.Game
{
	public class PlatformType
	{
		public const int XQAndroid = 0;

		public const int AppStore = 1;

		public const int Tencent = 2;

		public const int TaptapAndroid = 3;

		public const int TaptapIOS = 4;

		public const int Testflight = 5;

		public const int UCAndroid = 6;

		public static string GetName(int platform)
		{
			switch (platform)
			{
			case 0:
				return "安卓官服";
			case 1:
				return "苹果应用商店";
			case 2:
				return "腾讯应用宝";
			case 3:
				return "Taptap安卓";
			case 4:
				return "Taptap苹果";
			case 5:
				return "苹果Testflight";
			case 6:
				return "UC";
			default:
				return "未知";
			}
		}

		public static string GetNameEng(int platform)
		{
			switch (platform)
			{
			case 0:
				return "xq";
			case 1:
				return "appstore";
			case 2:
				return "tencent";
			case 3:
				return "taptap";
			case 4:
				return "taptapios";
			case 5:
				return "testflight";
			case 6:
				return "uc";
			default:
				return "unknow";
			}
		}
	}
}
