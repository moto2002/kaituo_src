using System;
using UnityEngine;

public class AnimAndEffect : MonoBehaviour
{
	private Animation anim;

	public Transform Target;

	public GameObject Fx;

	public string AnimName;

	public float PlayTime;

	public float EffectDelay;

	private GameObject instantiateFx;

	private void Start()
	{
		this.anim = base.GetComponent<Animation>();
		this.Fx.SetActive(false);
	}

	public void OnGUI()
	{
		if (GUILayout.Button("Play", new GUILayoutOption[0]) && this.instantiateFx == null)
		{
			this.anim.Play(this.AnimName);
			base.Invoke("CreateEffect", this.EffectDelay);
		}
	}

	private void CreateEffect()
	{
		this.instantiateFx = UnityEngine.Object.Instantiate<GameObject>(this.Fx);
		this.instantiateFx.transform.position = this.Target.position + this.Fx.transform.position;
		this.instantiateFx.transform.rotation = Quaternion.Euler(this.Target.rotation.eulerAngles + this.Fx.transform.rotation.eulerAngles);
		this.instantiateFx.SetActive(true);
		if (this.PlayTime > 0f)
		{
			base.Invoke("CheckDelete", this.PlayTime);
		}
	}

	private void CheckDelete()
	{
		if (this.instantiateFx != null)
		{
			UnityEngine.Object.Destroy(this.instantiateFx);
			this.instantiateFx = null;
		}
	}
}
