using Assets.Tools.Script.File;
using System;
using System.IO;

namespace Assets.Tools.Script.Editortool.Reader
{
	public abstract class ConfigReader
	{
		public const string UseProjectPath = "UseProjectSaveGameConfig";

		public static string ProjectPath = string.Empty;
	}
	public abstract class ConfigReader<T> : ConfigReader where T : class, new()
	{
		public virtual T GetFromExternalCache(string root)
		{
			T result;
			try
			{
				T t = (T)((object)null);
				string directoryPath = this.GetDirectoryPath(root);
				if (Directory.Exists(directoryPath))
				{
					t = this.ReadFromFile(root);
				}
				result = t;
			}
			catch (Exception)
			{
				result = (T)((object)null);
			}
			return result;
		}

		public virtual T GetFromLocalCache()
		{
			T result;
			try
			{
				T t = (T)((object)null);
				string directoryPath = this.GetDirectoryPath(LoadPath.saveLoadPath);
				if (Directory.Exists(directoryPath))
				{
					t = this.ReadFromFile(LoadPath.saveLoadPath);
				}
				result = t;
			}
			catch (Exception)
			{
				result = (T)((object)null);
			}
			return result;
		}

		public virtual T GetFromProjectCache()
		{
			string directoryPath = this.GetDirectoryPath(ConfigReader.ProjectPath);
			T result;
			if (!ResSafeFileUtil.DirectoryExists(directoryPath))
			{
				result = Activator.CreateInstance<T>();
			}
			else
			{
				result = this.ReadFromFile(ConfigReader.ProjectPath);
			}
			return result;
		}

		public abstract T ReadFromFile(string root);

		public virtual string GetDirectoryPath(string root)
		{
			return string.Format("Data/{0}", typeof(T).Name);
		}
	}
}
