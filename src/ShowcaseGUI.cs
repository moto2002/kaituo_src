using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowcaseGUI : MonoBehaviour
{
	private static ShowcaseGUI instance;

	private int levels = 9;

	private void Start()
	{
		if (ShowcaseGUI.instance)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		ShowcaseGUI.instance = this;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		this.OnLevelWasLoaded(0);
	}

	private void OnLevelWasLoaded(int level)
	{
		this.ActivateSurroundings();
	}

	private void ActivateSurroundings()
	{
		GameObject gameObject = GameObject.Find("Floor_Tile");
		if (gameObject)
		{
			foreach (Transform transform in gameObject.transform)
			{
				transform.gameObject.SetActive(true);
			}
		}
	}

	private void OnGUI()
	{
		int width = Screen.width;
		int num = 30;
		int num2 = 40;
		Rect rect = new Rect((float)(width - num * 2 - 70), 10f, (float)num, (float)num2);
		if (SceneManager.GetActiveScene().buildIndex > 0 && GUI.Button(rect, "<"))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
		}
		else if (GUI.Button(new Rect(rect), "<"))
		{
			SceneManager.LoadScene(this.levels - 1);
		}
		GUI.Box(new Rect((float)(width - num - 70), 10f, 60f, (float)num2), string.Concat(new object[]
		{
			"Scene:\n",
			SceneManager.GetActiveScene().buildIndex + 1,
			" / ",
			this.levels
		}));
		Rect source = new Rect((float)(width - num - 10), 10f, (float)num, (float)num2);
		if (SceneManager.GetActiveScene().buildIndex < this.levels - 1 && GUI.Button(new Rect(source), ">"))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
		else if (GUI.Button(new Rect(source), ">"))
		{
			SceneManager.LoadScene(0);
		}
		GUI.Box(new Rect((float)(width - 130), 50f, 120f, 55f), "Example scenes\nmust be added\nto Build Settings.");
	}
}
