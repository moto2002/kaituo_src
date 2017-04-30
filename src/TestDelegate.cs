using System;
using UnityEngine;

public class TestDelegate : MonoBehaviour
{
	public UILabel LoadOldUnitCfg;

	private void Start()
	{
		if (PlayerPrefs.GetInt("debugbattle", 0) != 2)
		{
			this.LoadOldUnitCfg.gameObject.SetActive(false);
		}
	}
}
