using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class EventReceiver : MonoBehaviour
{
	public void MyMethod()
	{
	}

	public void PrintText(string text)
	{
		Debug.Log(text);
	}

	public void RotateSprite(float newRot)
	{
		Vector3 eulerAngles = base.transform.eulerAngles;
		eulerAngles.y = newRot;
		base.transform.eulerAngles = eulerAngles;
	}

	public void SetDestination(UnityEngine.Object target)
	{
		base.StartCoroutine(this.SetDestinationRoutine(target));
	}

	[DebuggerHidden]
	private IEnumerator SetDestinationRoutine(UnityEngine.Object target)
	{
		EventReceiver.<SetDestinationRoutine>c__Iterator22 <SetDestinationRoutine>c__Iterator = new EventReceiver.<SetDestinationRoutine>c__Iterator22();
		<SetDestinationRoutine>c__Iterator.target = target;
		<SetDestinationRoutine>c__Iterator.<$>target = target;
		<SetDestinationRoutine>c__Iterator.<>f__this = this;
		return <SetDestinationRoutine>c__Iterator;
	}

	public void ActivateForTime(UnityEngine.Object target)
	{
		base.StartCoroutine(this.ActivateForTimeRoutine(target));
	}

	[DebuggerHidden]
	private IEnumerator ActivateForTimeRoutine(UnityEngine.Object target)
	{
		EventReceiver.<ActivateForTimeRoutine>c__Iterator23 <ActivateForTimeRoutine>c__Iterator = new EventReceiver.<ActivateForTimeRoutine>c__Iterator23();
		<ActivateForTimeRoutine>c__Iterator.target = target;
		<ActivateForTimeRoutine>c__Iterator.<$>target = target;
		return <ActivateForTimeRoutine>c__Iterator;
	}
}
