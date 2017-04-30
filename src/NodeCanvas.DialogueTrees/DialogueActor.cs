using System;
using UnityEngine;

namespace NodeCanvas.DialogueTrees
{
	public class DialogueActor : MonoBehaviour, IDialogueActor
	{
		[SerializeField]
		private string _name;

		[SerializeField]
		private Texture2D _portrait;

		[SerializeField]
		private Color _dialogueColor = Color.white;

		[SerializeField]
		private Vector3 _dialogueOffset;

		private Sprite _portraitSprite;

		public new string name
		{
			get
			{
				return this._name;
			}
		}

		public Texture2D portrait
		{
			get
			{
				return this._portrait;
			}
		}

		public Sprite portraitSprite
		{
			get
			{
				if (this._portraitSprite == null && this.portrait != null)
				{
					this._portraitSprite = Sprite.Create(this.portrait, new Rect(0f, 0f, (float)this.portrait.width, (float)this.portrait.height), new Vector2(0.5f, 0.5f));
				}
				return this._portraitSprite;
			}
		}

		public Color dialogueColor
		{
			get
			{
				return this._dialogueColor;
			}
		}

		public Vector3 dialoguePosition
		{
			get
			{
				return Vector3.Scale(base.transform.position + this._dialogueOffset, base.transform.localScale);
			}
		}

		public string speech
		{
			get;
			set;
		}

		virtual Transform get_transform()
		{
			return base.transform;
		}
	}
}
