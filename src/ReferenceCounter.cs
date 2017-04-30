using System;
using System.Collections.Generic;

public class ReferenceCounter
{
	private static Dictionary<string, Dictionary<WeakReference, string>> counts = new Dictionary<string, Dictionary<WeakReference, string>>();

	private static List<WeakReference> keys = new List<WeakReference>();

	private static Dictionary<string, int> typeCounts = new Dictionary<string, int>();

	public static void Mark(object o)
	{
	}

	public static void Mark(string name, object o, string mark)
	{
	}

	public static Dictionary<string, int> GetCurrMarkTypeCount()
	{
		return ReferenceCounter.typeCounts;
	}

	public static void PrintCurrMarkTypeCount()
	{
		Dictionary<string, int> currMarkTypeCount = ReferenceCounter.GetCurrMarkTypeCount();
		foreach (KeyValuePair<string, int> current in currMarkTypeCount)
		{
			string msg = string.Format("{0}:{1}", current.Key, current.Value);
			DebugConsole.Log(msg);
		}
	}

	public static int GetTypeCount(string type)
	{
		return 0;
	}

	public static Dictionary<WeakReference, string> GetTypeWeakReference(string type)
	{
		return null;
	}
}
