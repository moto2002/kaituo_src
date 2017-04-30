using Assets.Tools.Script.Caller;
using LuaFramework;
using LuaInterface;
using ParadoxNotion.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XQ.Framework.Data;
using XQ.Framework.Language;
using XQ.Framework.Lua.Utility;
using XQ.Framework.Utility;
using XQ.Framework.Utility.Debug;
using XQ.Game.Util.File;

namespace XQ.Framework.Lua
{
	internal static class GameManager
	{
		public struct ProgressInfo
		{
			public float progress;

			public string tip;
		}

		public static GameManager.ProgressInfo Progress;

		public static VerInfoStruct VER_INFO;

		public static bool ExitGame;

		public static ResourceManager ResManager;

		public static SceneManager SceneManager;

		internal static Dictionary<string, string> LuaScripts;

		internal static Dictionary<string, Dictionary<string, ResourceRef>> resFileRef;

		private static readonly Dictionary<string, Dictionary<string, ConfigResource>> configResources;

		public static readonly LuaGameObject lua;

		private static bool mobileInit;

		private static bool init
		{
			get;
			set;
		}

		public static LuaManager LuaManager
		{
			get;
			set;
		}

		static GameManager()
		{
			GameManager.Progress = new GameManager.ProgressInfo
			{
				progress = 0f,
				tip = string.Empty
			};
			GameManager.VER_INFO = VerInfoStruct.New(true);
			GameManager.LuaScripts = new Dictionary<string, string>();
			GameManager.resFileRef = new Dictionary<string, Dictionary<string, ResourceRef>>();
			GameManager.configResources = new Dictionary<string, Dictionary<string, ConfigResource>>();
			GameManager.lua = new GameObject("_lua").AddComponent<LuaGameObject>();
		}

		public static void GC(bool gc_system = false)
		{
			if (null != GameManager.LuaManager)
			{
				GameManager.LuaManager.LuaGC(gc_system);
			}
			else if (gc_system)
			{
				System.GC.Collect();
			}
		}

		public static void ClearOldSceneLuaData()
		{
			if (null != GameManager.LuaManager)
			{
				GameManager.LuaManager.ClearOldSceneLuaData();
			}
		}

		public static void SendMessageToLua(string msgKey, params object[] args)
		{
			LuaFunction function = GameManager.LuaManager.GetFunction("luaEventBrocast", true);
			if (null != function)
			{
				object[] array = new object[args.Length + 1];
				array[0] = msgKey;
				if (args.Length > 0)
				{
					Array.Copy(args, 0, array, 1, args.Length);
				}
				function.CallNoRet(array);
			}
		}

		public static Action InitFileCopy(Action<int, float, string> progressCB)
		{
			if (GameManager.init)
			{
				GameManager.Progress = new GameManager.ProgressInfo
				{
					progress = 1f,
					tip = LanguageManager.GetLangText("Loading_Copy")
				};
				return null;
			}
			GameManager.Progress = new GameManager.ProgressInfo
			{
				progress = 0f,
				tip = LanguageManager.GetLangText("Loading_Copy")
			};
			FrameCall.DelayFrame(delegate
			{
				GameManager.CopyAssetBundles(progressCB, 1f);
			}, 1);
			return delegate
			{
				GameManager.UnzipScripts();
				GameManager.Progress = new GameManager.ProgressInfo
				{
					progress = 1f,
					tip = LanguageManager.GetLangText("Loading_Copy")
				};
			};
		}

		public static Action InitAssets(Action cb)
		{
			if (GameManager.init)
			{
				GameManager.Progress = new GameManager.ProgressInfo
				{
					progress = 1f,
					tip = LanguageManager.GetLangText("Loading_Res")
				};
				return null;
			}
			FrameCall.DelayFrame(delegate
			{
				GameManager.Progress = new GameManager.ProgressInfo
				{
					progress = 0.2f,
					tip = LanguageManager.GetLangText("Loading_Res")
				};
			}, 1);
			FrameCall.DelayFrame(delegate
			{
				GameManager.LoadMobileRes();
				GameManager.Progress = new GameManager.ProgressInfo
				{
					progress = 0.8f,
					tip = LanguageManager.GetLangText("Loading_Res")
				};
				GameManager.LoadLuaFiles();
				GameManager.mobileInit = true;
				GameManager.SetGameInfo(null, true);
				cb();
			}, 3);
			return delegate
			{
				GameManager.Progress = new GameManager.ProgressInfo
				{
					progress = 1f,
					tip = LanguageManager.GetLangText("Loading_Res")
				};
			};
		}

		public static void InitEnd(bool first = false)
		{
			if (!GameManager.init)
			{
				if (!GameManager.mobileInit)
				{
					UDebug.Error("初始化不完整，无法进行游戏！！", new object[0]);
					return;
				}
				GameManager.init = true;
				GameManager.LoadSceneManager();
				GameManager.lua.InitLuaSystemFile();
				GameManager.SetGameInfo(null, true);
			}
		}

		public static ABManifest GetResRef(string fileName, string langstr = null, bool showErr = true)
		{
			if (langstr == null)
			{
				langstr = LanguageManager.DEFAULT_LANG_STR;
			}
			fileName = fileName.ToLower();
			Dictionary<string, ResourceRef> dictionary;
			if (GameManager.resFileRef.TryGetValue(fileName, out dictionary))
			{
				ResourceRef resourceRef = null;
				if (!dictionary.TryGetValue(LanguageManager.GetLangKey(), out resourceRef))
				{
					dictionary.TryGetValue(langstr, out resourceRef);
				}
				return resourceRef as ABManifest;
			}
			if (showErr)
			{
				UDebug.Error("no resource file, name: '{0}'", new object[]
				{
					fileName
				});
			}
			return null;
		}

		public static bool HasLangRes(string fileName, string langstr)
		{
			fileName = fileName.ToLower();
			Dictionary<string, ResourceRef> dictionary = null;
			return GameManager.resFileRef.TryGetValue(fileName, out dictionary) && dictionary.ContainsKey(langstr);
		}

		public static string GetLuaScript(string luaName, bool printError = true)
		{
			string text = luaName.CRCHash(true, 1012).ToString();
			string str;
			if (GameManager.LuaScripts.TryGetValue(text, out str))
			{
				return str + text;
			}
			if (printError)
			{
				UDebug.Error("no lua file, name: '{0}'", new object[]
				{
					luaName
				});
			}
			return null;
		}

		public static List<RegMessage> GetLuaRegMsg(string msgName)
		{
			return null;
		}

		public static List<string> GetSceneRefLogicFiles(string sceneName)
		{
			return null;
		}

		public static ConfigResource GetConfigResource(string path, string langstr = null, bool otherLang = false)
		{
			if (langstr == null)
			{
				langstr = LanguageManager.DEFAULT_LANG_STR;
			}
			else if (otherLang && LanguageManager.IsChsLanguage(langstr))
			{
				return null;
			}
			path = path.ToLower();
			Dictionary<string, ConfigResource> dictionary = null;
			if (!GameManager.configResources.TryGetValue(path, out dictionary))
			{
				return null;
			}
			ConfigResource result;
			if (dictionary.TryGetValue(langstr, out result))
			{
				return result;
			}
			return null;
		}

		public static void SetGameInfo(string value, bool initLang = false)
		{
			GameManager.VER_INFO = UtilHelper.GetVerInfo();
			if (value != null)
			{
				PlayerPrefs.SetString("_zipver", value);
				initLang = true;
			}
			if (initLang)
			{
				LanguageManager.InitLang(true);
			}
		}

		public static void UnzipScripts()
		{
			string text = UtilHelper.DataPath(true, false, false) + "scripts.zip";
			if (File.Exists(text))
			{
				lzip.decompress_File(text, UtilHelper.DataPath(true, false, false), new int[1], null);
				File.Delete(text);
			}
		}

		private static void CopyAssetBundles(Action<int, float, string> progressCB, float allocProgress = 0f)
		{
			string text = UtilHelper.DataPath(true, false, false);
			string @string = PlayerPrefs.GetString("_zipver", string.Empty);
			string zipVer = UtilHelper.GetZipVer(VerInfoStruct.FILE_VER_POS, "version.cfg");
			if (@string != zipVer)
			{
				if (Directory.Exists(text + "Lua"))
				{
					Directory.Delete(text + "Lua", true);
				}
				UtilHelper.CopyAssets(text, zipVer);
			}
			else
			{
				GameManager.SetGameInfo(null, false);
				progressCB(1, 1f, null);
			}
		}

		private static void LoadMobileRes()
		{
			SetLuaGlobal.RegLuaVariable.Add(delegate(LuaState lstate)
			{
				LuaDLL.lua_pushboolean(lstate.L, true);
				LuaDLL.lua_setglobal(lstate.L, "mobilemode");
			});
			string path = UtilHelper.DataPath(true, false, false);
			if (File.Exists(path + "del.lst"))
			{
				string[] array = File.ReadAllLines(path + "del.lst");
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					string str = array2[i];
					try
					{
						File.Delete(path + str);
					}
					catch
					{
					}
				}
				File.Delete(path + "del.lst");
			}
			try
			{
				Dictionary<string, List<ABManifest.DependRef>> deplistDic = new Dictionary<string, List<ABManifest.DependRef>>();
				Dictionary<string, ABManifest.DependRef> depRefNameDic = new Dictionary<string, ABManifest.DependRef>();
				if (File.Exists(path + "deplist.lst"))
				{
					List<string> list = JSON.Deserialize<List<string>>(File.ReadAllText(path + "deplist.lst").DecryptDES("ab_asset"), null);
					foreach (string current in list)
					{
						string[] array3 = current.Split(new char[]
						{
							','
						});
						List<ABManifest.DependRef> list2;
						if (!deplistDic.TryGetValue(array3[1], out list2))
						{
							list2 = new List<ABManifest.DependRef>();
							deplistDic.Add(array3[1], list2);
						}
						ABManifest.DependRef dependRef = new ABManifest.DependRef
						{
							PKGFile = array3[0],
							DependName = array3[2]
						};
						list2.Add(dependRef);
						string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(array3[2]);
						if (!depRefNameDic.ContainsKey(fileNameWithoutExtension))
						{
							depRefNameDic.Add(fileNameWithoutExtension, dependRef);
						}
					}
				}
				UDebug.Debug("=====begin load assets=====", new object[0]);
				Action action = delegate
				{
					List<string> list3 = Directory.GetFiles(path, "*.pkg").ToList<string>();
					List<string> list4 = Directory.GetFiles(path, "*.upk").ToList<string>();
					if (list4.Count > 0)
					{
						list4.Sort((string l1, string l2) => long.Parse(Path.GetFileNameWithoutExtension(l1)).CompareTo(long.Parse(Path.GetFileNameWithoutExtension(l2))));
						long num = -1L;
						long.TryParse(PlayerPrefs.GetString("_zipver", string.Empty), out num);
						for (int j = list4.Count - 1; j >= 0; j--)
						{
							long num2 = 0L;
							if (long.TryParse(Path.GetFileNameWithoutExtension(list4[j]), out num2) && num2 <= num)
							{
								File.Delete(list4[j]);
								list4.RemoveAt(j);
							}
						}
						Dictionary<string, int> dictionary = new Dictionary<string, int>();
						Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
						for (int k = 0; k < list4.Count; k++)
						{
							AssetBundle assetBundle = AssetBundle.LoadFromFile(list4[k]);
							string[] allAssetNames = assetBundle.GetAllAssetNames();
							assetBundle.Unload(true);
							string text = list4[k];
							dictionary.Add(text, 0);
							string[] array4 = allAssetNames;
							for (int l = 0; l < array4.Length; l++)
							{
								string key = array4[l];
								dictionary[text]++;
								if (dictionary2.ContainsKey(key))
								{
									string key2 = dictionary2[key];
									dictionary[key2]--;
									dictionary2[key] = text;
								}
								else
								{
									dictionary2.Add(key, text);
								}
							}
						}
						foreach (KeyValuePair<string, int> current2 in dictionary)
						{
							if (current2.Value <= 0)
							{
								File.Delete(current2.Key);
								list4.Remove(current2.Key);
							}
						}
						list3.AddRange(list4);
					}
					string[] array5 = list3.ToArray();
					string pkgfile = null;
					string assetfile = null;
					string shortfile = null;
					string langstr = LanguageManager.DEFAULT_LANG_STR;
					ResourceRef.ResFormat fmt = ResourceRef.ResFormat.None;
					Action<bool> action2 = delegate(bool isPatch)
					{
						bool flag2 = fmt == ResourceRef.ResFormat.Prefab;
						shortfile = shortfile.Substring(0, shortfile.LastIndexOf('.'));
						shortfile = ((!flag2) ? shortfile : Path.GetFileName(shortfile));
						Dictionary<string, ResourceRef> dictionary4 = null;
						ResourceRef resourceRef = null;
						if (!flag2 && langstr != LanguageManager.DEFAULT_LANG_STR)
						{
							shortfile = shortfile.Replace(string.Format("{0}/", langstr), string.Empty);
						}
						if (GameManager.resFileRef.TryGetValue(shortfile, out dictionary4))
						{
							if (isPatch)
							{
								dictionary4.TryGetValue(langstr, out resourceRef);
							}
						}
						else
						{
							dictionary4 = new Dictionary<string, ResourceRef>();
							GameManager.resFileRef.Add(shortfile, dictionary4);
						}
						if (resourceRef != null)
						{
							ABManifest aBManifest = (ABManifest)resourceRef;
							aBManifest.PKGFile = pkgfile;
							aBManifest.FullFileName = assetfile;
							aBManifest.ResType = fmt;
							aBManifest.UseDataDir = true;
							aBManifest.IsPacth = true;
							ABManifest.DependRef dependRef2 = null;
							if (depRefNameDic.TryGetValue(shortfile, out dependRef2))
							{
								dependRef2.PKGFile = pkgfile;
							}
						}
						else
						{
							if (dictionary4.ContainsKey(langstr))
							{
								UDebug.Error("same prefab file: {0}, lang: {1}", new object[]
								{
									shortfile,
									langstr
								});
								return;
							}
							ABManifest aBManifest2 = new ABManifest
							{
								FullFileName = assetfile,
								PKGFile = pkgfile,
								ResType = fmt,
								UseDataDir = true
							};
							List<ABManifest.DependRef> dependRefList;
							deplistDic.TryGetValue(shortfile, out dependRefList);
							aBManifest2.DependRefList = dependRefList;
							dictionary4.Add(langstr, aBManifest2);
						}
					};
					string[] array6 = array5;
					for (int m = 0; m < array6.Length; m++)
					{
						string text2 = array6[m];
						if (text2.EndsWith("res_shader.pkg"))
						{
							AssetBundle assetBundle2 = AssetBundle.LoadFromFile(text2);
							Shader[] array7 = assetBundle2.LoadAllAssets<Shader>();
							Shader.WarmupAllShaders();
							Shader[] array8 = array7;
							for (int n = 0; n < array8.Length; n++)
							{
								Shader shader = array8[n];
								ShaderHelper.SetShader(shader);
							}
							break;
						}
					}
					Dictionary<string, LangInfo>.KeyCollection keys = LanguageManager.LanguageInfoDic.Keys;
					for (int num3 = 0; num3 < array5.Length; num3++)
					{
						pkgfile = Path.GetFileName(array5[num3]);
						if (!(pkgfile == "res_shader.pkg"))
						{
							bool flag = Path.GetExtension(pkgfile).Equals(".upk", StringComparison.OrdinalIgnoreCase);
							AssetBundle assetBundle3 = AssetBundle.LoadFromFile(array5[num3]);
							string[] allAssetNames2 = assetBundle3.GetAllAssetNames();
							assetBundle3.Unload(true);
							for (int num4 = 0; num4 < allAssetNames2.Length; num4++)
							{
								assetfile = allAssetNames2[num4];
								string ext = Path.GetExtension(assetfile).ToLower();
								shortfile = assetfile;
								int num5 = assetfile.IndexOf("GameResource", StringComparison.OrdinalIgnoreCase);
								if (num5 != -1)
								{
									shortfile = assetfile.Substring(num5 + "GameResource/".Length).ToLower();
								}
								string text3 = Path.GetDirectoryName(shortfile);
								if (keys.Count > 1)
								{
									langstr = LanguageManager.DEFAULT_LANG_STR;
									foreach (string current3 in keys)
									{
										if (text3.EndsWith(string.Format("/{0}", current3)))
										{
											langstr = current3;
											break;
										}
									}
								}
								if (ext.IsTxt(true))
								{
									if (langstr != LanguageManager.DEFAULT_LANG_STR)
									{
										text3 = text3.Replace(string.Format("{0}/", langstr), string.Empty);
									}
									Dictionary<string, ConfigResource> dictionary3;
									if (!GameManager.configResources.TryGetValue(text3, out dictionary3))
									{
										dictionary3 = new Dictionary<string, ConfigResource>();
										GameManager.configResources.Add(text3, dictionary3);
									}
									ConfigResource configResource;
									if (!dictionary3.TryGetValue(langstr, out configResource))
									{
										configResource = ConfigResource.New();
										configResource.PKGFile = pkgfile;
										configResource.FilePath = Path.GetDirectoryName(assetfile);
										dictionary3.Add(langstr, configResource);
									}
									string fileName = Path.GetFileName(assetfile);
									if (!configResource.ConfigFiles.ContainsKey(fileName))
									{
										configResource.ConfigFiles.Add(fileName, assetfile);
									}
									if (flag)
									{
										configResource.PKGFile = pkgfile;
									}
									configResource.IsPatch = flag;
									configResource.UseDataDir = true;
								}
								else if (ext.IsTexture(true))
								{
									fmt = ResourceRef.ResFormat.Texture;
									action2(flag);
								}
								else if (ext.IsAudio(true))
								{
									fmt = ResourceRef.ResFormat.None;
									action2(flag);
								}
								else
								{
									fmt = ((!ext.IsPrefab(false)) ? ResourceRef.ResFormat.None : ResourceRef.ResFormat.Prefab);
									action2(flag);
								}
							}
						}
					}
				};
				action();
			}
			catch (Exception ex)
			{
				UDebug.Error("{0}", new object[]
				{
					ex.Message
				});
			}
			finally
			{
				GameManager.GC(true);
			}
		}

		private static void LoadLuaFiles()
		{
			string path = UtilHelper.DataPath(true, true, false) + "Lua/User";
			string[] files = UtilHelper.GetFiles(path, "*.lua");
			string[] array = files;
			for (int i = 0; i < array.Length; i++)
			{
				string path2 = array[i];
				string text = Path.GetDirectoryName(path2);
				text = text.Substring(text.IndexOf("/Lua/") + "Lua".Length + 2);
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path2);
				if (GameManager.LuaScripts.ContainsKey(fileNameWithoutExtension))
				{
					Debug.LogErrorFormat("Lua文件名重复：{0}", new object[]
					{
						fileNameWithoutExtension
					});
					return;
				}
				GameManager.LuaScripts.Add(fileNameWithoutExtension, text + "/");
			}
		}

		private static void LoadSceneManager()
		{
		}
	}
}
