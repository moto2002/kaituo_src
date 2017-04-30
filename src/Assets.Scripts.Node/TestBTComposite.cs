using NodeCanvas.BehaviourTrees;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Scripts.Node
{
	[Name("Text")]
	public class TestBTComposite : BTComposite
	{
		public string Text = string.Empty;

		public string Name = string.Empty;

		public Color NameColor;

		public bool ToDo;
	}
}
