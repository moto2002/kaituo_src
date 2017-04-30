using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using XQ.Framework.Utility.Debug;

namespace LuaFramework
{
	public class Util
	{
		private static readonly long Dt1970;

		static Util()
		{
			// 注意: 此类型已标记为 'beforefieldinit'.
			DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0);
			Util.Dt1970 = dateTime.Ticks;
		}

		public static int Int(object o)
		{
			return Convert.ToInt32(o);
		}

		public static float Float(object o)
		{
			return (float)Math.Round((double)Convert.ToSingle(o), 2);
		}

		public static long Long(object o)
		{
			return Convert.ToInt64(o);
		}

		public static int Random(int min, int max)
		{
			return UnityEngine.Random.Range(min, max);
		}

		public static float Random(float min, float max)
		{
			return UnityEngine.Random.Range(min, max);
		}

		public static string Uid(string uid)
		{
			int num = uid.LastIndexOf('_');
			return uid.Remove(0, num + 1);
		}

		public static long GetTime()
		{
			TimeSpan timeSpan = new TimeSpan(DateTime.UtcNow.Ticks - Util.Dt1970);
			return (long)timeSpan.TotalMilliseconds;
		}

		public static T Get<T>(GameObject go, string subnode) where T : Component
		{
			if (go != null)
			{
				Transform transform = go.transform.FindChild(subnode);
				if (transform != null)
				{
					return transform.GetComponent<T>();
				}
			}
			return (T)((object)null);
		}

		public static T Get<T>(Transform go, string subnode) where T : Component
		{
			if (go != null)
			{
				Transform transform = go.FindChild(subnode);
				if (transform != null)
				{
					return transform.GetComponent<T>();
				}
			}
			return (T)((object)null);
		}

		public static T Get<T>(Component go, string subnode) where T : Component
		{
			return go.transform.FindChild(subnode).GetComponent<T>();
		}

		public static T Add<T>(GameObject go) where T : Component
		{
			if (go != null)
			{
				T[] components = go.GetComponents<T>();
				for (int i = 0; i < components.Length; i++)
				{
					if (components[i] != null)
					{
						UnityEngine.Object.Destroy(components[i]);
					}
				}
				return go.gameObject.AddComponent<T>();
			}
			return (T)((object)null);
		}

		public static T Add<T>(Transform go) where T : Component
		{
			return Util.Add<T>(go.gameObject);
		}

		public static GameObject Child(GameObject go, string subnode)
		{
			return Util.Child(go.transform, subnode);
		}

		public static GameObject Child(Transform go, string subnode)
		{
			Transform transform = go.FindChild(subnode);
			if (transform == null)
			{
				return null;
			}
			return transform.gameObject;
		}

		public static GameObject Peer(GameObject go, string subnode)
		{
			return Util.Peer(go.transform, subnode);
		}

		public static GameObject Peer(Transform go, string subnode)
		{
			Transform transform = go.parent.FindChild(subnode);
			if (transform == null)
			{
				return null;
			}
			return transform.gameObject;
		}

		public static string md5(string source)
		{
			MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			byte[] bytes = Encoding.UTF8.GetBytes(source);
			byte[] array = mD5CryptoServiceProvider.ComputeHash(bytes, 0, bytes.Length);
			mD5CryptoServiceProvider.Clear();
			string text = string.Empty;
			for (int i = 0; i < array.Length; i++)
			{
				text += Convert.ToString(array[i], 16).PadLeft(2, '0');
			}
			return text.PadLeft(32, '0');
		}

		public static string md5file(string file)
		{
			string result;
			try
			{
				FileStream fileStream = new FileStream(file, FileMode.Open);
				MD5 mD = new MD5CryptoServiceProvider();
				byte[] array = mD.ComputeHash(fileStream);
				fileStream.Close();
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < array.Length; i++)
				{
					stringBuilder.Append(array[i].ToString("x2"));
				}
				result = stringBuilder.ToString();
			}
			catch (Exception ex)
			{
				throw new Exception("md5file() fail, error:" + ex.Message);
			}
			return result;
		}

		public static void ClearChild(Transform go)
		{
			if (go == null)
			{
				return;
			}
			for (int i = go.childCount - 1; i >= 0; i--)
			{
				UnityEngine.Object.Destroy(go.GetChild(i).gameObject);
			}
		}

		public static void Log(string str)
		{
			UDebug.Debug(str, new object[0]);
		}

		public static void LogWarning(string str)
		{
			Debug.LogWarning(str);
		}

		public static void LogError(string str)
		{
			Debug.LogError(str);
		}

		public static Component AddComponent(GameObject go, string assembly, string classname)
		{
			Assembly assembly2 = Assembly.Load(assembly);
			Type type = assembly2.GetType(assembly + "." + classname);
			return go.AddComponent(type);
		}

		private static int CheckRuntimeFile()
		{
			if (!Application.isEditor)
			{
				return 0;
			}
			string path = AppConst.FrameworkRoot + "/ToLua/Source/Generate/";
			if (!Directory.Exists(path))
			{
				return -2;
			}
			string[] files = Directory.GetFiles(path);
			if (files.Length == 0)
			{
				return -2;
			}
			return 0;
		}

		public static bool CheckEnvironment()
		{
			return true;
		}
	}
}
