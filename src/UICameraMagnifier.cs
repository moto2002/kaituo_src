using System;
using UnityEngine;

public class UICameraMagnifier : MonoBehaviour
{
	public UITexture TargetTexture;

	public RenderTexture Rendertexture;

	public Vector2 Offset;

	public Material RemoveAlphaMaterial;

	private Camera component;

	private UIPanel panel;

	private bool withOutTexture = true;

	private void Awake()
	{
		this.component = base.GetComponent<Camera>();
		this.panel = this.TargetTexture.GetComponentInParent<UIPanel>();
		this.TargetTexture.mainTexture = this.Rendertexture;
	}

	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		if (this.withOutTexture)
		{
			Graphics.Blit(src, this.Rendertexture, this.RemoveAlphaMaterial);
			this.TargetTexture.mainTexture = this.Rendertexture;
		}
		else
		{
			Graphics.Blit(src, dest);
		}
	}

	private void Update()
	{
		this.withOutTexture = true;
		Vector3 mousePosition = Input.mousePosition;
		float num = mousePosition.x / (float)Screen.width;
		float num2 = mousePosition.y / (float)Screen.height;
		this.TargetTexture.uvRect = new Rect(num - this.Offset.x, num2 + this.Offset.y, 0.32f, 0.12f);
		if ((double)num > 0.5)
		{
			this.TargetTexture.transform.localPosition = new Vector3(-204f, -116f, 0f);
		}
		else
		{
			this.TargetTexture.transform.localPosition = new Vector3(204f, -116f, 0f);
		}
		this.TargetTexture.gameObject.SetActive(false);
		this.UpdatePanel();
		this.component.Render();
		this.withOutTexture = false;
		this.TargetTexture.gameObject.SetActive(true);
		this.UpdatePanel();
	}

	private void UpdatePanel()
	{
		this.panel.Refresh();
	}
}
