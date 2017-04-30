using LitJson;
using System;
using XQ.Framework.Utility.Debug;

namespace Assets.Scripts.Performance
{
	public class Battle3DPerformance
	{
		public static void Play(string jsonData)
		{
			JsonData jsonData2 = JsonMapper.ToObject(jsonData);
			UDebug.Debug((string)jsonData2["AttackerType"], new object[0]);
			UDebug.Debug(jsonData2["Attacker"]);
			UDebug.Debug((int)jsonData2["Attacker"]["InstId"]);
		}
	}
}
