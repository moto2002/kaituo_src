using System;
using UnityEngine;

namespace NodeCanvas.DialogueTrees
{
	[Serializable]
	public class ProxyDialogueActor : IDialogueActor
	{
		private string _name;

		private Transform _transform;

		public string name
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
				return null;
			}
		}

		public Sprite portraitSprite
		{
			get
			{
				return null;
			}
		}

		public Color dialogueColor
		{
			get
			{
				return Color.white;
			}
		}

		public Vector3 dialoguePosition
		{
			get
			{
				return Vector3.zero;
			}
		}

		public Transform transform
		{
			get
			{
				return this._transform;
			}
		}

		public string speech
		{
			get;
			set;
		}

		public ProxyDialogueActor(string name, Transform transform)
		{
			this._name = name;
			this._transform = transform;
		}
	}
}
