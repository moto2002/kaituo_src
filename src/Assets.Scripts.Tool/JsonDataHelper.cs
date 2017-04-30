using LitJson;
using System;

namespace Assets.Scripts.Tool
{
	public static class JsonDataHelper
	{
		public static int GetValue(this JsonData data, string valueName, int defaultValue)
		{
			if (valueName == null)
			{
				return defaultValue;
			}
			int result;
			try
			{
				JsonData jsonData = data[valueName];
				if (jsonData.IsInt)
				{
					result = Convert.ToInt32(jsonData.ToString());
				}
				else
				{
					result = defaultValue;
				}
			}
			catch (Exception var_1_38)
			{
				result = defaultValue;
			}
			return result;
		}

		public static bool GetValue(this JsonData data, string valueName, bool defaultValue)
		{
			if (valueName == null)
			{
				return defaultValue;
			}
			bool result;
			try
			{
				JsonData jsonData = data[valueName];
				if (jsonData.IsBoolean)
				{
					result = Convert.ToBoolean(jsonData.ToString());
				}
				else
				{
					result = defaultValue;
				}
			}
			catch (Exception var_1_38)
			{
				result = defaultValue;
			}
			return result;
		}

		public static string GetValue(this JsonData data, string valueName, string defaultValue)
		{
			if (valueName == null)
			{
				return defaultValue;
			}
			string result;
			try
			{
				JsonData jsonData = data[valueName];
				result = jsonData.ToString();
			}
			catch (Exception var_1_21)
			{
				result = defaultValue;
			}
			return result;
		}
	}
}
