using ParadoxNotion.Serialization;
using System;

namespace Assets.Tools.Serialization
{
	public static class fsJsonHelper
	{
		public static object JsonClone(this object obj)
		{
			Type type = obj.GetType();
			string serializedState = JSON.Serialize(type, obj, false, null);
			return JSON.Deserialize(type, serializedState, null);
		}

		public static T JsonClone<T>(this T obj)
		{
			Type typeFromHandle = typeof(T);
			string serializedState = JSON.Serialize(typeFromHandle, obj, false, null);
			return JSON.Deserialize<T>(serializedState, null);
		}
	}
}
