using LuaInterface;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using XQ.Framework.Lua;

namespace Assets.Scripts.Map.Tool
{
	public static class LuaToCTool
	{
		private static List<GameObject> objects;

		private static List<string> dialoguedata = new List<string>();

		public static void SetFlip(UIBasicSprite basicSprite, int to)
		{
			switch (to)
			{
			case 0:
				basicSprite.flip = UIBasicSprite.Flip.Nothing;
				break;
			case 1:
				basicSprite.flip = UIBasicSprite.Flip.Horizontally;
				break;
			case 2:
				basicSprite.flip = UIBasicSprite.Flip.Vertically;
				break;
			case 3:
				basicSprite.flip = UIBasicSprite.Flip.Both;
				break;
			}
		}

		public static List<GameObject> GetChildNode(GameObject obj)
		{
			LuaToCTool.objects = new List<GameObject>();
			foreach (Transform transform in obj.transform)
			{
				if (transform.name.StartsWith("city"))
				{
					LuaToCTool.objects.Add(transform.gameObject);
				}
			}
			return LuaToCTool.objects;
		}

		public static List<GameObject> GetChildPath(GameObject obj)
		{
			LuaToCTool.objects = new List<GameObject>();
			foreach (Transform transform in obj.transform)
			{
				if (transform.name.StartsWith("route"))
				{
					LuaToCTool.objects.Add(transform.gameObject);
				}
			}
			return LuaToCTool.objects;
		}

		public static List<GameObject> GetChildFog(GameObject obj)
		{
			LuaToCTool.objects = new List<GameObject>();
			foreach (Transform transform in obj.transform)
			{
				if (transform.name.StartsWith("Fog"))
				{
					LuaToCTool.objects.Add(transform.gameObject);
				}
			}
			return LuaToCTool.objects;
		}

		public static object Conversation(string data)
		{
			data = data.Replace("[red]", "[FF4C33]");
			data = data.Replace("[yellow]", "[F8DE00]");
			data = data.Replace("[blue]", "[00AAF8]");
			data = data.Replace("[green]", "[10FFBB]");
			MatchCollection matchCollection = Regex.Matches(data, "\\$[^\\$]*\\$");
			LuaToCTool.dialoguedata.Clear();
			LuaTable luaTable = GameManager.LuaManager.GetTable("_G", true)["Story"] as LuaTable;
			luaTable = (luaTable["Context"] as LuaTable);
			if (matchCollection.Count > 0)
			{
				for (int i = 0; i < matchCollection.Count; i++)
				{
					string str = matchCollection[i].ToString().Replace("$", string.Empty);
					data = data.Replace(matchCollection[i].ToString(), luaTable[str + "Name"].ToString());
				}
			}
			data = data.Replace("\\n", "\r\n");
			string[] array = data.Split(new string[]
			{
				"\\\\p",
				"\\\\P",
				"\\p",
				"\\P"
			}, StringSplitOptions.None);
			for (int j = 0; j < array.Length; j++)
			{
				LuaToCTool.dialoguedata.Add(array[j]);
			}
			return LuaToCTool.dialoguedata;
		}

		public static void ColorResolve(UISprite s, string data)
		{
			string[] array = data.Split(new char[]
			{
				','
			});
			s.color = new Color(Convert.ToSingle(array[0]), Convert.ToSingle(array[1]), Convert.ToSingle(array[2]), Convert.ToSingle(array[3]));
		}

		public static void UITextureColorResolve(UITexture s, string data)
		{
			string[] array = data.Split(new char[]
			{
				','
			});
			s.color = new Color(Convert.ToSingle(array[0]), Convert.ToSingle(array[1]), Convert.ToSingle(array[2]), Convert.ToSingle(array[3]));
		}

		public static void ScreenJitter()
		{
			UICamera component = UIRoot.list[0].GetComponent<UICamera>();
		}
	}
}
