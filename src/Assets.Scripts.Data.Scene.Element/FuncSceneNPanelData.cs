using Assets.Tools.Script.Attributes;
using System;
using UnityEngine;

namespace Assets.Scripts.Data.Scene.Element
{
	public class FuncSceneNPanelData : ElementData
	{
		[InspectorStyle("SceneId", "GameSceneIdSelector")]
		public string SceneId = string.Empty;

		public Vector2 Position_1 = new Vector2(13f, -216f);

		public Vector2 Position_2 = new Vector2(-171f, -57f);

		public Vector2 Position_3 = new Vector2(184f, -25f);

		public Vector2 Position_4 = new Vector2(34f, -479f);

		public Vector2 Position_5 = new Vector2(-218f, -394f);

		public Vector2 Position_6 = new Vector2(226f, -366f);

		public float TransparentMagnification = 1f;
	}
}
