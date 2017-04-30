using System;
using UnityEngine;

namespace Assets.Scripts.Game
{
	public class ConfigParser : MonoBehaviour
	{
		public static ConfigParser Instance;

		public int[] Index1;

		public int[] Index2;

		private void Awake()
		{
			ConfigParser.Instance = this;
		}

		public string Encode(string text)
		{
			if (text.IsNullOrEmpty())
			{
				return text;
			}
			char[] array = text.ToCharArray();
			int length = array.Length;
			for (int i = 0; i < this.Index1.Length; i++)
			{
				array = this.Exchange(array, length, this.Index1[i], this.Index2[i]);
			}
			return new string(array);
		}

		public string Decode(string text)
		{
			if (text.IsNullOrEmpty())
			{
				return text;
			}
			char[] array = text.ToCharArray();
			int length = array.Length;
			for (int i = this.Index1.Length - 1; i >= 0; i--)
			{
				array = this.Exchange(array, length, this.Index1[i], this.Index2[i]);
			}
			return new string(array);
		}

		public char[] Exchange(char[] charArray, int length, int i1, int i2)
		{
			if (i1 >= length || i2 >= length)
			{
				return charArray;
			}
			char c = charArray[i1];
			charArray[i1] = charArray[i2];
			charArray[i2] = c;
			return charArray;
		}
	}
}
