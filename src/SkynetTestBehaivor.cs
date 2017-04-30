using System;
using UnityEngine;
using XQ.Framework.Network.Skynet;

public class SkynetTestBehaivor : MonoBehaviour
{
	private void Start()
	{
		SprotoStreamEx.TestSite.TestAll();
	}

	private void Update()
	{
	}
}
