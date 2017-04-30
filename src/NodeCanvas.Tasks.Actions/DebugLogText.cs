using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using ParadoxNotion.Services;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Utility"), Description("Display a UI label on the agent's position if seconds to run is not 0, else simply logs the message")]
	public class DebugLogText : ActionTask<Transform>
	{
		[RequiredField]
		public BBParameter<string> log = "Hello World";

		public float labelYOffset;

		public float secondsToRun = 1f;

		public CompactStatus finishStatus = CompactStatus.Success;

		private Texture2D _tex;

		protected override string info
		{
			get
			{
				return "Log " + this.log.ToString() + ((this.secondsToRun <= 0f) ? string.Empty : (" for " + this.secondsToRun + " sec."));
			}
		}

		private Texture2D tex
		{
			get
			{
				if (this._tex == null)
				{
					this._tex = new Texture2D(1, 1);
					this._tex.SetPixel(0, 0, Color.white);
					this._tex.Apply();
				}
				return this._tex;
			}
		}

		protected override void OnExecute()
		{
			Debug.Log(this.log.value);
			if (this.secondsToRun > 0f)
			{
				MonoManager.AddGUIMethod(new Action(this.OnGUI));
			}
		}

		protected override void OnStop()
		{
			if (this.secondsToRun > 0f)
			{
				MonoManager.RemoveGUIMethod(new Action(this.OnGUI));
			}
		}

		protected override void OnUpdate()
		{
			if (base.elapsedTime >= this.secondsToRun)
			{
				base.EndAction(new bool?(this.finishStatus == CompactStatus.Success));
			}
		}

		private void OnGUI()
		{
			if (Camera.main == null)
			{
				return;
			}
			Vector3 vector = Camera.main.WorldToScreenPoint(base.agent.position + new Vector3(0f, this.labelYOffset, 0f));
			Vector2 vector2 = new GUIStyle("label").CalcSize(new GUIContent(this.log.value));
			Rect position = new Rect(vector.x - vector2.x / 2f, (float)Screen.height - vector.y, vector2.x + 10f, vector2.y);
			GUI.color = new Color(1f, 1f, 1f, 0.5f);
			GUI.DrawTexture(position, this.tex);
			GUI.color = new Color(0.2f, 0.2f, 0.2f, 1f);
			position.x += 4f;
			GUI.Label(position, this.log.value);
			GUI.color = Color.white;
		}
	}
}
