using DG.Tweening;
using SWS;
using System;
using UnityEngine;

public class CameraInputDemo : MonoBehaviour
{
	public string infoText = "Welcome to this customized input example";

	private splineMove myMove;

	private void Start()
	{
		this.myMove = base.gameObject.GetComponent<splineMove>();
		this.myMove.StartMove();
		this.myMove.Pause(0f);
	}

	private void Update()
	{
		if (this.myMove.tween == null || this.myMove.tween.IsPlaying())
		{
			return;
		}
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			this.myMove.Resume();
		}
	}

	private void OnGUI()
	{
		if (this.myMove.tween != null && this.myMove.tween.IsPlaying())
		{
			return;
		}
		GUI.Box(new Rect((float)(Screen.width - 150), (float)(Screen.height / 2), 150f, 100f), string.Empty);
		Rect position = new Rect((float)(Screen.width - 130), (float)(Screen.height / 2 + 10), 110f, 90f);
		GUI.Label(position, this.infoText);
	}

	public void ShowInformation(string text)
	{
		this.infoText = text;
	}
}
