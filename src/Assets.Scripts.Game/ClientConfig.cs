using Assets.Tools.Script.Attributes;
using ParadoxNotion.Serialization;
using System;
using System.Collections.Generic;
using UnityEngine;
using XQ.Game.Util.File;

namespace Assets.Scripts.Game
{
	public class ClientConfig
	{
		private static ClientConfig instance;

		public int Version;

		[InspectorStyle("平台", "IntEnum", new object[]
		{
			typeof(PlatformType)
		})]
		public int Platform;

		public List<string> GameServerHost;

		public List<string> GameServerPort;

		public string ResourcesUrl;

		public List<string> FieldNames;

		public List<string> FieldValues;

		private Dictionary<string, string> fields = new Dictionary<string, string>();

		public static ClientConfig Instance
		{
			get
			{
				if (ClientConfig.instance == null)
				{
					string text = PlayerPrefs.GetString("PXClientConfig", string.Empty);
					if (text.IsNullOrEmpty())
					{
						TextAsset textAsset = Resources.Load<TextAsset>("ClientConfig");
						if (textAsset != null)
						{
							text = textAsset.text;
						}
					}
					ConfigParser configParser = ConfigParser.Instance ?? Resources.Load<GameObject>("GlobalObject").GetComponentInChildren<ConfigParser>();
					text = configParser.Decode(text);
					string sKey = string.Format("{0}a9sHnBm", FileLocker.VerCode);
					ClientConfig.instance = ((!text.IsNullOrEmpty()) ? JSON.Deserialize<ClientConfig>(text.DecryptDES(sKey), null) : new ClientConfig());
					if (ClientConfig.instance.FieldNames != null)
					{
						for (int i = 0; i < ClientConfig.instance.FieldNames.Count; i++)
						{
							string key = ClientConfig.instance.FieldNames[i];
							string value = ClientConfig.instance.FieldValues[i];
							ClientConfig.instance.fields[key] = value;
						}
					}
					DebugConsole.Log(new object[]
					{
						"ClientConfig",
						ClientConfig.instance
					});
				}
				return ClientConfig.instance;
			}
		}

		public string GetField(string fieldName)
		{
			string result;
			this.fields.TryGetValue(fieldName, out result);
			return result;
		}

		public void AddField(string fieldName, string value)
		{
			if (this.FieldNames == null)
			{
				this.FieldNames = new List<string>();
				this.FieldValues = new List<string>();
			}
			int num = this.FieldNames.IndexOf(fieldName);
			if (num < 0)
			{
				this.FieldNames.Add(fieldName);
				this.FieldValues.Add(value);
			}
			else
			{
				this.FieldValues[num] = value;
			}
			this.fields[fieldName] = value;
		}

		public void Save()
		{
			string sKey = string.Format("{0}a9sHnBm", FileLocker.VerCode);
			string key = "PXClientConfig";
			string text = JSON.Serialize<ClientConfig>(this, false, null);
			text = text.EncryptDES(sKey);
			text = ConfigParser.Instance.Encode(text);
			PlayerPrefs.SetString(key, text);
			PlayerPrefs.Save();
		}

		public static string GetVerStr(int ver)
		{
			int num = ver % 100;
			int num2 = (ver % 10000 - num) / 100;
			int num3 = (ver - num2 * 100 - num) / 10000;
			return string.Format("{0}.{1}.{2}", num3, num2, num);
		}
	}
}
