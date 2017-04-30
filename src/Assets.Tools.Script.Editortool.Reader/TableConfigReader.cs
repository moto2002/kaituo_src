using Assets.Tools.Script.File;
using ParadoxNotion.Serialization;
using System;
using System.IO;
using UnityEngine;

namespace Assets.Tools.Script.Editortool.Reader
{
	public class TableConfigReader<T, TData> : ConfigReader<T> where T : class, ITextConfigTable<TData>, new() where TData : INameData
	{
		public override T ReadFromFile(string root)
		{
			T result = Activator.CreateInstance<T>();
			string[] files = Directory.GetFiles(this.GetDirectoryPath(root));
			string[] array = files;
			for (int i = 0; i < array.Length; i++)
			{
				string path = array[i];
				string text = string.Empty;
				try
				{
					if (!(Path.GetExtension(path) == ".meta"))
					{
						text = Path.GetFileNameWithoutExtension(path);
						if (!text.IsNullOrEmpty() && !(text == "\r\n"))
						{
							string txtFilePath = this.GetTxtFilePath(text, root);
							string serializedState = ResSafeFileUtil.ReadFile(txtFilePath);
							TData data = JSON.Deserialize<TData>(serializedState, null);
							result.AddData(data);
						}
					}
				}
				catch (Exception message)
				{
					Debug.Log("Load file error at " + text);
					Debug.Log(message);
				}
			}
			return result;
		}

		protected virtual string GetTxtFilePath(string dataName, string root)
		{
			return string.Format("{0}/{1}{2}", this.GetDirectoryPath(root), dataName, ResSafeFileUtil.GetSuffix(".json"));
		}
	}
}
