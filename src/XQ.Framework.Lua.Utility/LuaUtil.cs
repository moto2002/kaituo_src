using LuaInterface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using XQ.Framework.Language;
using XQ.Framework.Utility.Debug;

namespace XQ.Framework.Lua.Utility
{
	public static class LuaUtil
	{
		public static bool GetNetInfo()
		{
			return Application.internetReachability != NetworkReachability.NotReachable;
		}

		public static double GetSystemTime()
		{
			long ticks = DateTime.Now.Ticks;
			return (double)ticks / 10000000.0;
		}

		public static string GetAppPath(string path)
		{
			if (path.IsNullOrEmpty())
			{
				return Path.GetDirectoryName(UtilHelper.DataPath(true, false, false));
			}
			string text = UtilHelper.DataPath(true, false, false) + path;
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			return text;
		}

		public static bool DelFile(string path)
		{
			path = UtilHelper.DataPath(true, false, false) + path;
			if (File.Exists(path))
			{
				File.Delete(path);
				return true;
			}
			if (Directory.Exists(path))
			{
				Directory.Delete(path, true);
				return true;
			}
			return false;
		}

		public static void LoadScene(bool additive, string sceneName, LuaFunction callback, params object[] args)
		{
			GameManager.SceneManager.LoadScene(additive, sceneName, callback, args);
		}

		public static void LoadControl(string controlName, params object[] args)
		{
			GameManager.SceneManager.LoadControl(controlName, args);
		}

		public static void CreatePanelAsync(bool isGridItem, LuaFunction callback, string panelName, params object[] arg)
		{
			GameManager.ResManager.CreatePanelAsync(isGridItem, callback, panelName, arg);
		}

		public static LuaTable CreatePanelSync(bool isGridItem, string panelName, params object[] arg)
		{
			return GameManager.ResManager.CreatePanelSync(isGridItem, panelName, arg);
		}

		public static UnityEngine.Object LoadResource(bool instantiate, string name, GameObject useObject, LuaFunction callBack, bool lifeFollowUseObject)
		{
			return GameManager.ResManager.LoadGameResource(name, instantiate, useObject, callBack, lifeFollowUseObject, null);
		}

		public static bool IsDestroy(object obj)
		{
			return (UnityEngine.Object)obj == null;
		}

		public static void AddEventListener(LuaTable table, GameObject gameObject, string eventSuffix)
		{
			LuaMonoBehaviour.AddEvent(gameObject, table, eventSuffix);
		}

		public static LuaTable NewLuaTable(bool isGrid, string tableName, GameObject parent)
		{
			return GameManager.ResManager.NewLuaTable(isGrid, tableName, parent);
		}

		public static string[] GetDataFiles(string path, string filter, bool isLang)
		{
			ConfigResource configResource = (!isLang) ? GameManager.GetConfigResource(path, null, false) : GameManager.GetConfigResource(path, LanguageManager.GetLangKey(), true);
			string[] array = new string[configResource.ConfigFiles.Count];
			int num = 0;
			AssetBundle assetBundle = null;
			try
			{
				assetBundle = AssetBundle.LoadFromFile(UtilHelper.DataPath(configResource.UseDataDir, false, false) + configResource.PKGFile);
				foreach (KeyValuePair<string, string> current in configResource.ConfigFiles)
				{
					array[num++] = assetBundle.LoadAsset<TextAsset>(current.Value).text;
				}
			}
			catch (Exception msg)
			{
				UDebug.Error(msg);
			}
			finally
			{
				if (null != assetBundle)
				{
					assetBundle.Unload(true);
				}
			}
			return array;
		}

		public static string GetDataMonoFile(string path, string name, bool isLang = false)
		{
			ConfigResource configResource = (!isLang) ? GameManager.GetConfigResource(path, null, false) : GameManager.GetConfigResource(path, LanguageManager.GetLangKey(), true);
			name = string.Format("{0}.json", name);
			AssetBundle assetBundle = null;
			try
			{
				assetBundle = AssetBundle.LoadFromFile(UtilHelper.DataPath(configResource.UseDataDir, false, false) + configResource.PKGFile);
				return assetBundle.LoadAsset<TextAsset>(configResource.ConfigFiles[name.ToLower()]).text;
			}
			catch (Exception msg)
			{
				UDebug.Error(msg);
			}
			finally
			{
				if (null != assetBundle)
				{
					assetBundle.Unload(true);
				}
			}
			return string.Empty;
		}

		[NoToLua]
		public static string GetMonoFileContent(string path, string filename)
		{
			ConfigResource configResource = GameManager.GetConfigResource(path, null, false);
			if (!configResource.IsTNull<ConfigResource>())
			{
				AssetBundle assetBundle = null;
				string result;
				try
				{
					assetBundle = AssetBundle.LoadFromFile(UtilHelper.DataPath(configResource.UseDataDir, false, false) + configResource.PKGFile);
					result = assetBundle.LoadAsset<TextAsset>(configResource.FilePath + "/" + filename).text;
				}
				catch (Exception msg)
				{
					UDebug.Error(msg);
					result = string.Empty;
				}
				finally
				{
					if (null != assetBundle)
					{
						assetBundle.Unload(true);
					}
				}
				return result;
			}
			string text = Path.Combine(UtilHelper.DataPath(configResource.UseDataDir, false, false), path) + "/" + filename;
			if (File.Exists(text))
			{
				return File.ReadAllText(text, Encoding.UTF8);
			}
			UDebug.Warn("GetMonoFile：没有配置文件，{0}", new object[]
			{
				text
			});
			return string.Empty;
		}
	}
}
