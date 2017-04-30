using NodeCanvas.Framework;
using System;
using UnityEngine;

namespace NodeCanvas.DialogueTrees
{
	[Serializable]
	public class Statement : IStatement
	{
		[SerializeField]
		private string _text = string.Empty;

		[SerializeField]
		private AudioClip _audio;

		[SerializeField]
		private string _meta = string.Empty;

		public string text
		{
			get
			{
				return this._text;
			}
			set
			{
				this._text = value;
			}
		}

		public AudioClip audio
		{
			get
			{
				return this._audio;
			}
			set
			{
				this._audio = value;
			}
		}

		public string meta
		{
			get
			{
				return this._meta;
			}
			set
			{
				this._meta = value;
			}
		}

		public Statement()
		{
		}

		public Statement(string text)
		{
			this.text = text;
		}

		public Statement(string text, AudioClip audio)
		{
			this.text = text;
			this.audio = audio;
		}

		public Statement(string text, AudioClip audio, string meta)
		{
			this.text = text;
			this.audio = audio;
			this.meta = meta;
		}

		public Statement BlackboardReplace(IBlackboard bb)
		{
			string text = this.text;
			int num = 0;
			while ((num = text.IndexOf('[', num)) != -1)
			{
				int num2 = text.Substring(num + 1).IndexOf(']');
				string text2 = text.Substring(num + 1, num2);
				string oldValue = text.Substring(num, num2 + 2);
				object obj = null;
				if (bb != null)
				{
					obj = bb.GetValue<object>(text2);
				}
				text = text.Replace(oldValue, (obj == null) ? ("*" + text2 + "*") : obj.ToString());
				num++;
			}
			return new Statement(text, this.audio, this.meta);
		}

		public override string ToString()
		{
			return this.text;
		}
	}
}
