using Assets.Scripts.Game;
using Assets.Scripts.Platform.Android;
using LuaInterface;
using System;
using System.IO;
using UnityEngine;

namespace XQ.Framework.Lua.Utility
{
	public static class UtilHelper
	{
		public static string AssetBundleKey;

		public static bool UseAssetBundle;

		public static readonly AndroidJavaClass helper;

		static UtilHelper()
		{
			UtilHelper.AssetBundleKey = "__AB";
			UtilHelper.UseAssetBundle = PlayerPrefs.HasKey(UtilHelper.AssetBundleKey);
			UtilHelper.helper = ((!Application.isPlaying) ? null : AndroidBridge.InitU3DActivityToStatic("xq.game.helper.Unity3dHelper", "init"));
		}

		public static void CopyAssets(string path, string zipVer)
		{
			UtilHelper.helper.CallStatic("copyAssets", new object[]
			{
				path,
				zipVer
			});
		}

		public static string GetZipVer(int linenunber, string file)
		{
			return UtilHelper.helper.CallStatic<string>("getZipVer", new object[]
			{
				linenunber,
				file
			});
		}

		public static string[] GetAssetExtFiles(string assetPath = "", string ext = ".pkg")
		{
			return UtilHelper.helper.CallStatic<string[]>("getExtFiles", new object[]
			{
				assetPath,
				ext
			});
		}

		public static string[] ReadFileLines(string file)
		{
			return UtilHelper.helper.CallStatic<string[]>("readFileLines", new object[]
			{
				file
			});
		}

		public static string ReadAllText(string file)
		{
			return UtilHelper.helper.CallStatic<string>("readFileAllText", new object[]
			{
				file
			});
		}

		public static string DataPath(bool userDataDir = false, bool editorDir = false, bool updateZip = false)
		{
			if (!userDataDir)
			{
				return Application.dataPath + "!assets/";
			}
			return Application.persistentDataPath + "/";
		}

		public static void DestroyLua(LuaBaseRef lua)
		{
			if (null != lua)
			{
				lua.Dispose();
				lua = null;
			}
		}

		public static void ProcManifestFileInfo(string path, bool isManifest, Action<string> readAssetsCallback, bool disableIgnore = false)
		{
			string path2 = (!isManifest) ? (path + ".manifest") : path;
			if (!File.Exists(path2))
			{
				return;
			}
			string[] array = File.ReadAllLines(path2);
			for (int i = array.Length - 1; i >= 0; i--)
			{
				if (array[i] == "Assets:")
				{
					bool flag = false;
					int num = array.Length;
					for (int j = i + 1; j < num; j++)
					{
						if (flag)
						{
							break;
						}
						string text = array[j];
						if (text.Length != 0 && (!disableIgnore || !text.EndsWith("ignore")))
						{
							string text2 = array[j + 1];
							if (text2[0] != '-')
							{
								if (!text2.StartsWith("Dependencies:"))
								{
									text += text2;
									j++;
								}
								else
								{
									flag = true;
								}
							}
							if (readAssetsCallback != null)
							{
								readAssetsCallback(text);
							}
						}
					}
					break;
				}
			}
		}

		public static long GetManifestCRC(string path)
		{
			if (!File.Exists(path))
			{
				return 0L;
			}
			string[] array = File.ReadAllLines(path);
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].StartsWith("CRC:"))
				{
					return long.Parse(array[i].Substring(array[i].IndexOf(":") + 1).TrimStart(new char[0]));
				}
			}
			return 0L;
		}

		public static string[] GetFiles(string path, string extFilter = "*.*")
		{
			return Directory.GetFiles(path, extFilter, SearchOption.AllDirectories);
		}

		public static int CalculateTextureSizeBytes(Texture tTexture)
		{
			int num = tTexture.width;
			int num2 = tTexture.height;
			if (tTexture is Texture2D)
			{
				Texture2D texture2D = tTexture as Texture2D;
				int bitsPerPixel = UtilHelper.GetBitsPerPixel(texture2D.format);
				int mipmapCount = texture2D.mipmapCount;
				int i = 1;
				int num3 = 0;
				while (i <= mipmapCount)
				{
					num3 += num * num2 * bitsPerPixel >> 3;
					num >>= 1;
					num2 >>= 1;
					i++;
				}
				return num3;
			}
			if (tTexture is Cubemap)
			{
				Cubemap cubemap = tTexture as Cubemap;
				int bitsPerPixel2 = UtilHelper.GetBitsPerPixel(cubemap.format);
				return num * num2 * 6 * bitsPerPixel2 >> 3;
			}
			return 0;
		}

		private static int GetBitsPerPixel(TextureFormat format)
		{
			switch (format)
			{
			case TextureFormat.DXT1Crunched:
			case TextureFormat.PVRTC_RGB4:
			case TextureFormat.PVRTC_RGBA4:
			case TextureFormat.ETC_RGB4:
			case TextureFormat.ATC_RGB4:
			case TextureFormat.ETC2_RGB:
			case TextureFormat.ETC2_RGBA1:
				return 4;
			case TextureFormat.DXT5Crunched:
			case TextureFormat.ATC_RGBA8:
			case TextureFormat.ETC2_RGBA8:
				return 8;
			case TextureFormat.PVRTC_RGB2:
			case TextureFormat.PVRTC_RGBA2:
				return 2;
			case (TextureFormat)37:
			case (TextureFormat)38:
			case (TextureFormat)39:
			case (TextureFormat)40:
			case TextureFormat.EAC_R:
			case TextureFormat.EAC_R_SIGNED:
			case TextureFormat.EAC_RG:
			case TextureFormat.EAC_RG_SIGNED:
				IL_5B:
				switch (format)
				{
				case TextureFormat.Alpha8:
				case TextureFormat.DXT5:
					return 8;
				case TextureFormat.ARGB4444:
				case TextureFormat.RGB565:
				case TextureFormat.RGBA4444:
					return 16;
				case TextureFormat.RGB24:
					return 24;
				case TextureFormat.RGBA32:
				case TextureFormat.ARGB32:
				case TextureFormat.BGRA32:
					return 32;
				case TextureFormat.DXT1:
					return 4;
				}
				return 0;
			}
			goto IL_5B;
		}

		public static bool IsTexture(this string ext, bool isext = false)
		{
			if (!isext)
			{
				ext = Path.GetExtension(ext);
			}
			ext = ext.ToLower();
			return ext == ".png" || ext == ".jpg" || ext == ".jpeg";
		}

		public static bool IsTxt(this string ext, bool isext = false)
		{
			if (!isext)
			{
				ext = Path.GetExtension(ext);
			}
			ext = ext.ToLower();
			return ext == ".json" || ext == ".txt" || ext == ".cfg";
		}

		public static bool IsAudio(this string ext, bool isext = false)
		{
			if (!isext)
			{
				ext = Path.GetExtension(ext);
			}
			ext = ext.ToLower();
			return ext == ".mp3" || ext == ".wav" || ext == ".ogg";
		}

		public static bool IsShader(this string ext, bool isext = false)
		{
			if (!isext)
			{
				ext = Path.GetExtension(ext);
			}
			ext = ext.ToLower();
			return ext == ".shader";
		}

		public static bool IsLanguage(this string ext, bool isext = false)
		{
			if (!isext)
			{
				ext = Path.GetExtension(ext);
			}
			ext = ext.ToLower();
			return ext == ".lang";
		}

		public static bool IsPrefab(this string ext, bool isext = false)
		{
			if (!isext)
			{
				ext = Path.GetExtension(ext);
			}
			ext = ext.ToLower();
			return ext == ".prefab";
		}

		public static VerInfoStruct GetVerInfo()
		{
			VerInfoStruct verInfoStruct = VerInfoStruct.New(false);
			string[] array = File.ReadAllLines(UtilHelper.DataPath(true, false, false) + "version.cfg");
			if (array != null)
			{
				int num = VerInfoStruct.VER_POS - 1;
				verInfoStruct.curVer = ClientConfig.Instance.Version.ToString();
				num = VerInfoStruct.URL_POS - 1;
				if (array[num].IsNOTNullOrEmpty())
				{
					verInfoStruct.verUrl = array[num].Substring(0, array[num].Length - 2);
					verInfoStruct.patchUrl = Path.Combine(verInfoStruct.verUrl, "patch").Replace("\\", "/");
					verInfoStruct.editorNoUpdate = (array[num].Substring(array[num].Length - 1) == "1");
				}
				else
				{
					verInfoStruct.editorNoUpdate = true;
				}
				num = VerInfoStruct.FILE_VER_POS - 1;
				if (array[num].IsNOTNullOrEmpty())
				{
					verInfoStruct.patchFileVer = long.Parse(array[num].Trim());
				}
				verInfoStruct.zipFileVer = array[num];
			}
			else
			{
				verInfoStruct.editorNoUpdate = true;
				verInfoStruct.noVerInfo = true;
			}
			return verInfoStruct;
		}
	}
}
