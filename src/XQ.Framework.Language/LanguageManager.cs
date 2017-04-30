using LuaInterface;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XQ.Framework.Data;
using XQ.Framework.Lua;
using XQ.Framework.Lua.Utility;
using XQ.Framework.Utility.Debug;
using XQ.Game.Util.Unity;

namespace XQ.Framework.Language
{
	public static class LanguageManager
	{
		private static readonly string lang_key = string.Format("{0}.{1}.{2}", Application.productName, Application.platform.GetType().Name, "lang");

		private static readonly Dictionary<string, Dictionary<string, string>> LangGameText = new Dictionary<string, Dictionary<string, string>>();

		private static string curLang;

		public static List<LangInfo> LanguageInfo;

		[NoToLua]
		public static Dictionary<string, LangInfo> LanguageInfoDic = new Dictionary<string, LangInfo>();

		[NoToLua]
		public static readonly string DEFAULT_LANG_STR = "chs";

		[NoToLua]
		public static void InitLang(bool reinit = false)
		{
			if (LanguageManager.LanguageInfo != null && !reinit)
			{
				return;
			}
			if (reinit)
			{
				LanguageManager.LangGameText.Clear();
			}
			LanguageManager.LanguageInfo = new List<LangInfo>();
			LanguageManager.LanguageInfoDic.Clear();
			string path = string.Format("{0}{1}", UtilHelper.DataPath(true, false, false), "LanguageText/language.lang");
			string[] array;
			if (File.Exists(path))
			{
				array = File.ReadAllLines(path);
			}
			else
			{
				array = UtilHelper.ReadFileLines("LanguageText/language.lang");
				if (array == null)
				{
					UDebug.Error("{0}下没有{1}语言文件", new object[]
					{
						"GameResource/LanguageText",
						"language.lang"
					});
					return;
				}
			}
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string text = array2[i];
				if (text[0] != '#')
				{
					int num = text.IndexOf('=');
					if (num != -1)
					{
						LangInfo langInfo = new LangInfo
						{
							LangKey = text.Substring(0, num).Trim(),
							LangValue = text.Substring(num + 1).Trim()
						};
						LanguageManager.LanguageInfo.Add(langInfo);
						LanguageManager.LanguageInfoDic.Add(langInfo.LangKey, langInfo);
					}
				}
			}
			string path2 = string.Format("{0}LanguageText/langtext.json", UtilHelper.DataPath(true, false, false));
			string[] allLines;
			if (File.Exists(path2))
			{
				allLines = File.ReadAllLines(path2);
			}
			else
			{
				allLines = UtilHelper.ReadFileLines("LanguageText/langtext.json");
			}
			List<Dictionary<string, string>> list = DocTable.Decode(allLines);
			for (int j = 0; j < list.Count; j++)
			{
				Dictionary<string, string> dictionary = list[j];
				string text2 = dictionary["LangKey"];
				if (LanguageManager.LangGameText.ContainsKey(text2))
				{
					UDebug.Error("有重复的文本键值：{0}", new object[]
					{
						text2
					});
				}
				else
				{
					Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
					LanguageManager.LangGameText.Add(text2, dictionary2);
					foreach (LangInfo current in LanguageManager.LanguageInfo)
					{
						string text3 = dictionary["LangValue_" + current.LangKey];
						if (text3 != null)
						{
							dictionary2.Add(current.LangKey, text3);
						}
					}
				}
			}
		}

		public static bool IsChsLanguage(string lang = "chs")
		{
			if (lang.IsNullOrEmpty())
			{
				lang = LanguageManager.DEFAULT_LANG_STR;
			}
			return LanguageManager.DEFAULT_LANG_STR == lang && LanguageManager.GetLangKey() == lang;
		}

		public static void SetLangKey(string language)
		{
			PlayerPrefs.SetString(LanguageManager.lang_key, language);
			LanguageManager.curLang = language;
		}

		public static string GetLangKey()
		{
			string arg_21_0;
			if ((arg_21_0 = LanguageManager.curLang) == null)
			{
				arg_21_0 = (LanguageManager.curLang = PlayerPrefs.GetString(LanguageManager.lang_key, "chs"));
			}
			return arg_21_0;
		}

		public static string GetLangText(string textKey)
		{
			string langKey = LanguageManager.GetLangKey();
			string result;
			try
			{
				result = LanguageManager.LangGameText[textKey][langKey];
			}
			catch
			{
				UDebug.Error("没有对应的语言版本内容，lang：{0}，Key：{1}", new object[]
				{
					langKey,
					textKey
				});
				result = textKey;
			}
			return result;
		}

		[NoToLua]
		public static T MultiResource<T>(string atlasName) where T : UnityEngine.Object
		{
			if (LanguageManager.IsChsLanguage("chs"))
			{
				return (T)((object)null);
			}
			if (GameManager.HasLangRes(atlasName, LanguageManager.GetLangKey()))
			{
				GameObject gameObject = GameManager.ResManager.LoadGameResource(atlasName, false, null, null, false, LanguageManager.curLang) as GameObject;
				return gameObject.GetComponent<T>();
			}
			return (T)((object)null);
		}

		[NoToLua]
		public static T UpdateMutilResource<T>(string atlasName) where T : UnityEngine.Object
		{
			ABManifest resRef = GameManager.GetResRef(atlasName, LanguageManager.GetLangKey(), false);
			if (resRef != null && resRef.IsPacth)
			{
				GameObject gameObject = GameManager.ResManager.LoadGameResource(atlasName, false, null, null, false, LanguageManager.curLang) as GameObject;
				return gameObject.GetComponent<T>();
			}
			return (T)((object)null);
		}
	}
}
