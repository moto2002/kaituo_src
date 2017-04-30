using LuaInterface;
using System;
using UnityEngine;

public class UIClickButton : UIButton
{
	public UILabel tweenLabel;

	public Color pressedFont = new Color(0.7176471f, 0.6392157f, 0.482352942f, 1f);

	public Color disabledFont = Color.grey;

	public bool defaultClick;

	private Color mDefaultFontColor = Color.white;

	private bool disabled;

	public new Color defaultColor
	{
		get
		{
			return this.mDefaultFontColor;
		}
	}

	protected override void OnInit()
	{
		base.OnInit();
		if (this.tweenLabel)
		{
			this.mDefaultFontColor = this.tweenLabel.color;
		}
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		if (this.defaultClick)
		{
			this.OnClick();
		}
	}

	public void DelegateActive()
	{
		if (this.disabled)
		{
			return;
		}
		if (this.tweenLabel)
		{
			this.tweenLabel.color = this.pressedFont;
		}
		base.SetSprite(this.pressedSprite);
	}

	public override void SetState(UIButtonColor.State _state, bool immediate)
	{
	}

	public void SetNormal()
	{
		this.disabled = false;
		if (!this.mInitDone)
		{
			this.OnInit();
		}
		if (this.tweenLabel)
		{
			this.tweenLabel.color = this.mDefaultFontColor;
		}
		base.SetSprite(base.normalSprite);
	}

	public void SetActive()
	{
		this.disabled = false;
		if (!this.mInitDone)
		{
			this.OnInit();
		}
		this.DelegateActive();
	}

	public void SetDisable()
	{
		this.disabled = true;
		if (!this.mInitDone)
		{
			this.OnInit();
		}
		this.tweenLabel.color = this.disabledFont;
		base.SetSprite(this.disabledSprite);
	}

	[NoToLua]
	public void SetNormalFontColor(Color c)
	{
		this.tweenLabel.color = c;
	}

	[NoToLua]
	public void SetDisableFontColor(Color c)
	{
		this.tweenLabel.color = c;
	}

	public void SetClick()
	{
		this.OnClick();
	}
}
