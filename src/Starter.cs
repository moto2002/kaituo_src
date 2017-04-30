using System;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
	public int DelayMillSecound;

	private bool isStart;

	private DateTime end;

	public bool StartOnStart;

	[HideInInspector]
	public List<EventDelegate> onAwake = new List<EventDelegate>();

	[HideInInspector]
	public List<EventDelegate> onStart = new List<EventDelegate>();

	[HideInInspector]
	public List<EventDelegate> onStartDelay = new List<EventDelegate>();

	private void Start()
	{
		if (this.StartOnStart)
		{
			if (this.DelayMillSecound < 0)
			{
				this.OnStart();
			}
			else
			{
				this.OnStartDelay();
				this.start();
			}
		}
	}

	private void Awake()
	{
		this.OnAwake();
	}

	[ContextMenu("Start")]
	public void start()
	{
		this.end = DateTime.Now + TimeSpan.FromMilliseconds((double)this.DelayMillSecound);
		this.isStart = true;
	}

	private void Update()
	{
		if (this.isStart && this.end < DateTime.Now)
		{
			this.OnStart();
			this.isStart = false;
		}
	}

	public void OnAwake()
	{
		EventDelegate.Execute(this.onAwake);
	}

	public void OnStart()
	{
		EventDelegate.Execute(this.onStart);
		base.enabled = false;
	}

	public void OnStartDelay()
	{
		EventDelegate.Execute(this.onStartDelay);
	}
}
