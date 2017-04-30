using Assets.Tools.Script.Editortool.Reader;
using System;

namespace Assets.Tools.Script.Editortool
{
	public abstract class TextDataConfig<T, TReader> where T : class, new() where TReader : ConfigReader<T>, new()
	{
		private static T instance;

		private static ConfigReader<T> reader;

		public static T Instance
		{
			get
			{
				if (TextDataConfig<T, TReader>.instance != null)
				{
					return TextDataConfig<T, TReader>.instance;
				}
				TextDataConfig<T, TReader>.instance = TextDataConfig<T, TReader>.Reader.GetFromProjectCache();
				return TextDataConfig<T, TReader>.instance;
			}
			set
			{
				TextDataConfig<T, TReader>.instance = value;
			}
		}

		public static ConfigReader<T> Reader
		{
			get
			{
				if (TextDataConfig<T, TReader>.reader == null)
				{
					TextDataConfig<T, TReader>.reader = Activator.CreateInstance<TReader>();
				}
				return TextDataConfig<T, TReader>.reader;
			}
		}
	}
}
