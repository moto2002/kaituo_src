using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class UILabelEmoji : UILabel
{
	private static readonly Dictionary<string, float> FONT_MIN_WIDTH = new Dictionary<string, float>();

	[HideInInspector, SerializeField]
	private UIAtlas mEmojiAtlas;

	[HideInInspector, SerializeField]
	private int mGapSet;

	[HideInInspector]
	[NonSerialized]
	public List<EmojiInfo> emojiList = new List<EmojiInfo>();

	[HideInInspector]
	[NonSerialized]
	public List<UIEmojiSprite> emojiSprite = new List<UIEmojiSprite>();

	[HideInInspector]
	[NonSerialized]
	public Dictionary<int, float> emojiLineHeightOffset = new Dictionary<int, float>();

	[HideInInspector]
	[NonSerialized]
	public float offsetWidth;

	[HideInInspector]
	[NonSerialized]
	public int totalLine;

	public UIAtlas emojiAtlas
	{
		get
		{
			return this.mEmojiAtlas;
		}
	}

	public int gapSet
	{
		get
		{
			return this.mGapSet << 1;
		}
	}

	public float finalTotalHeight
	{
		get
		{
			float num = (float)NGUIText.fontSize * NGUIText.fontScale * (float)(this.totalLine + 1);
			if (this.emojiLineHeightOffset.Count > 0)
			{
				foreach (KeyValuePair<int, float> current in this.emojiLineHeightOffset)
				{
					num += current.Value;
				}
			}
			return num;
		}
	}

	protected void LateUpdate()
	{
		if (base.transform.childCount > this.emojiList.Count)
		{
			for (int i = base.transform.childCount - this.emojiList.Count - 1; i >= 0; i--)
			{
				NGUITools.Destroy(base.transform.GetChild(i));
				if (this.emojiSprite.Count > this.emojiList.Count)
				{
					this.emojiSprite.RemoveAt(i);
				}
			}
		}
	}

	private void Clear()
	{
		this.totalLine = 0;
		this.emojiList.Clear();
		this.emojiLineHeightOffset.Clear();
	}

	public override void ProcessText()
	{
		this.ProcessText(false, true);
	}

	private void ProcessText(bool legacyMode, bool full)
	{
		if (!base.labelIsValid)
		{
			return;
		}
		if (!UILabelEmoji.FONT_MIN_WIDTH.ContainsKey(base.trueTypeFont.name))
		{
			UILabelEmoji.FONT_MIN_WIDTH.Add(base.trueTypeFont.name, NGUITextExt.NativeDyncFontWidth('.', base.trueTypeFont));
			this.offsetWidth = 0f;
		}
		if (this.offsetWidth == 0f)
		{
			this.offsetWidth = UILabelEmoji.FONT_MIN_WIDTH[base.trueTypeFont.name];
		}
		this.Clear();
		NGUITextExt.curEmojiAtlas = this.mEmojiAtlas;
		this.mChanged = true;
		base.shouldBeProcessed = false;
		float num = this.mDrawRegion.z - this.mDrawRegion.x;
		float num2 = this.mDrawRegion.w - this.mDrawRegion.y;
		NGUIText.rectWidth = ((!legacyMode) ? base.width : ((this.mMaxLineWidth == 0) ? 1000000 : this.mMaxLineWidth));
		NGUIText.rectHeight = ((!legacyMode) ? base.height : ((this.mMaxLineHeight == 0) ? 1000000 : this.mMaxLineHeight));
		NGUIText.regionWidth = ((num == 1f) ? NGUIText.rectWidth : Mathf.RoundToInt((float)NGUIText.rectWidth * num));
		NGUIText.regionHeight = ((num2 == 1f) ? NGUIText.rectHeight : Mathf.RoundToInt((float)NGUIText.rectHeight * num2));
		this.mFinalFontSize = Mathf.Abs((!legacyMode) ? base.defaultFontSize : Mathf.RoundToInt(base.cachedTransform.localScale.x));
		this.mScale = 1f;
		if (NGUIText.regionWidth < 1 || NGUIText.regionHeight < 0)
		{
			this.mProcessedText = string.Empty;
			return;
		}
		bool flag = base.trueTypeFont != null;
		if (flag && base.keepCrisp)
		{
			UIRoot root = base.root;
			if (root != null)
			{
				this.mDensity = ((!(root != null)) ? 1f : root.pixelSizeAdjustment);
			}
		}
		else
		{
			this.mDensity = 1f;
		}
		if (full)
		{
			base.UpdateNGUIText();
		}
		if (base.overflowMethod == UILabel.Overflow.ResizeFreely)
		{
			NGUIText.rectWidth = 1000000;
			NGUIText.regionWidth = 1000000;
			if (base.overflowWidth > 0)
			{
				NGUIText.rectWidth = Mathf.Min(NGUIText.rectWidth, base.overflowWidth);
				NGUIText.regionWidth = Mathf.Min(NGUIText.regionWidth, base.overflowWidth);
			}
		}
		if (base.overflowMethod == UILabel.Overflow.ResizeFreely || base.overflowMethod == UILabel.Overflow.ResizeHeight)
		{
			NGUIText.rectHeight = 1000000;
			NGUIText.regionHeight = 1000000;
		}
		if (this.mFinalFontSize > 0)
		{
			bool keepCrisp = base.keepCrisp;
			for (int i = this.mFinalFontSize; i > 0; i--)
			{
				if (keepCrisp)
				{
					this.mFinalFontSize = i;
					NGUIText.fontSize = this.mFinalFontSize;
				}
				else
				{
					this.mScale = (float)i / (float)this.mFinalFontSize;
					NGUIText.fontScale = ((!flag) ? ((float)base.fontSize / (float)base.bitmapFont.defaultSize * this.mScale) : this.mScale);
				}
				NGUIText.Update(false);
				bool flag2 = NGUITextExt.WrapText(base.printedText, out this.mProcessedText, false, false, base.overflowEllipsis && base.overflowMethod == UILabel.Overflow.ClampContent, this);
				if (base.overflowMethod != UILabel.Overflow.ShrinkContent || flag2)
				{
					if (base.overflowMethod == UILabel.Overflow.ResizeFreely)
					{
						this.mCalculatedSize = NGUITextExt.CalculatePrintedSize(this.mProcessedText, this.offsetWidth);
						int num3 = Mathf.Max(this.minWidth, Mathf.RoundToInt(this.mCalculatedSize.x));
						if (num != 1f)
						{
							num3 = Mathf.RoundToInt((float)num3 / num);
						}
						int num4 = Mathf.Max(this.minHeight, Mathf.RoundToInt(this.mCalculatedSize.y));
						if (num2 != 1f)
						{
							num4 = Mathf.RoundToInt((float)num4 / num2);
						}
						if ((num3 & 1) == 1)
						{
							num3++;
						}
						if ((num4 & 1) == 1)
						{
							num4++;
						}
						if (this.mWidth != num3 || this.mHeight != num4)
						{
							this.mWidth = num3;
							this.mHeight = num4;
							if (this.onChange != null)
							{
								this.onChange();
							}
						}
					}
					else if (base.overflowMethod == UILabel.Overflow.ResizeHeight)
					{
						this.mCalculatedSize = NGUITextExt.CalculatePrintedSize(this.mProcessedText, this.offsetWidth);
						int num5 = Mathf.Max(this.minHeight, Mathf.RoundToInt(this.mCalculatedSize.y));
						if (num2 != 1f)
						{
							num5 = Mathf.RoundToInt((float)num5 / num2);
						}
						if ((num5 & 1) == 1)
						{
							num5++;
						}
						if (this.mHeight != num5)
						{
							this.mHeight = num5;
							if (this.onChange != null)
							{
								this.onChange();
							}
						}
					}
					else
					{
						this.mCalculatedSize = NGUITextExt.CalculatePrintedSize(this.mProcessedText, this.offsetWidth);
					}
					if (legacyMode)
					{
						base.width = Mathf.RoundToInt(this.mCalculatedSize.x);
						base.height = Mathf.RoundToInt(this.mCalculatedSize.y);
						base.cachedTransform.localScale = Vector3.one;
					}
					break;
				}
				this.Clear();
				if (--i <= 1)
				{
					break;
				}
			}
		}
		else
		{
			base.cachedTransform.localScale = Vector3.one;
			this.mProcessedText = string.Empty;
			this.mScale = 1f;
		}
		if (full)
		{
			NGUIText.bitmapFont = null;
			NGUIText.dynamicFont = null;
		}
		NGUITextExt.curEmojiAtlas = null;
	}

	public override void OnFill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color> cols)
	{
		if (!base.isValid)
		{
			return;
		}
		int num = verts.size;
		Color color = base.color;
		color.a = this.finalAlpha;
		if (base.bitmapFont != null && base.bitmapFont.premultipliedAlphaShader)
		{
			color = NGUITools.ApplyPMA(color);
		}
		string processedText = base.processedText;
		int size = verts.size;
		base.UpdateNGUIText();
		NGUIText.regionWidth += this.gapSet * this.emojiList.Count;
		if (this.emojiList.Count - this.emojiSprite.Count > 0)
		{
			int i = 0;
			int num2 = this.emojiList.Count - this.emojiSprite.Count;
			while (i < num2)
			{
				this.emojiSprite.Add(base.gameObject.AddEmojiSprite(this.emojiAtlas, this.emojiList[i].emojiName, base.depth + 1));
				i++;
			}
		}
		NGUIText.tint = color;
		NGUITextExt.Print(processedText, verts, uvs, cols, this);
		NGUIText.bitmapFont = null;
		NGUIText.dynamicFont = null;
		Vector2 vector = base.ApplyOffset(verts, size);
		int j = this.emojiList.Count - 1;
		int num3 = 0;
		while (j >= 0)
		{
			EmojiInfo emojiInfo = this.emojiList[j];
			UIEmojiSprite uIEmojiSprite = this.emojiSprite[num3];
			if (uIEmojiSprite)
			{
				uIEmojiSprite.Verts = verts[emojiInfo.vertIdx];
				UIEmojiSprite expr_189_cp_0 = uIEmojiSprite;
				expr_189_cp_0.Verts.x = expr_189_cp_0.Verts.x + (float)(this.mGapSet - emojiInfo.finalSize);
				if (emojiInfo.size > NGUIText.fontSize)
				{
					UIEmojiSprite expr_1BC_cp_0 = uIEmojiSprite;
					expr_1BC_cp_0.Verts.y = expr_1BC_cp_0.Verts.y + emojiInfo.newLineOffset;
				}
				else if (emojiInfo.size < NGUIText.fontSize)
				{
					UIEmojiSprite expr_1EC_cp_0 = uIEmojiSprite;
					expr_1EC_cp_0.Verts.y = expr_1EC_cp_0.Verts.y - (float)(NGUIText.fontSize - emojiInfo.size) * ((float)emojiInfo.size * 1f / (float)NGUIText.fontSize);
				}
				uIEmojiSprite.spriteName = emojiInfo.emojiName;
				uIEmojiSprite.width = emojiInfo.finalSize;
				uIEmojiSprite.height = emojiInfo.finalSize;
				uIEmojiSprite.pivot = UIWidget.Pivot.TopLeft;
				uIEmojiSprite.transform.parent = base.transform;
				uIEmojiSprite.transform.localPosition = Vector3.zero;
				uIEmojiSprite.transform.localScale = Vector3.one;
				if (emojiInfo.isAnimation)
				{
					UIEmojiSpriteAnimation uIEmojiSpriteAnimation = uIEmojiSprite.gameObject.AddComponent<UIEmojiSpriteAnimation>();
					uIEmojiSpriteAnimation.namePrefix = emojiInfo.emojiName.Substring(0, emojiInfo.emojiName.LastIndexOf('_') + 1);
				}
			}
			verts.RemoveAt(emojiInfo.vertIdx);
			j--;
			num3++;
		}
		if (base.bitmapFont != null && base.bitmapFont.packedFontShader)
		{
			return;
		}
		if (base.effectStyle != UILabel.Effect.None)
		{
			int size2 = verts.size;
			vector.x = base.effectDistance.x;
			vector.y = base.effectDistance.y;
			base.ApplyShadow(verts, uvs, cols, num, size2, vector.x, -vector.y);
			if (base.effectStyle == UILabel.Effect.Outline || base.effectStyle == UILabel.Effect.Outline8)
			{
				num = size2;
				size2 = verts.size;
				base.ApplyShadow(verts, uvs, cols, num, size2, -vector.x, vector.y);
				num = size2;
				size2 = verts.size;
				base.ApplyShadow(verts, uvs, cols, num, size2, vector.x, vector.y);
				num = size2;
				size2 = verts.size;
				base.ApplyShadow(verts, uvs, cols, num, size2, -vector.x, -vector.y);
				if (base.effectStyle == UILabel.Effect.Outline8)
				{
					num = size2;
					size2 = verts.size;
					base.ApplyShadow(verts, uvs, cols, num, size2, -vector.x, 0f);
					num = size2;
					size2 = verts.size;
					base.ApplyShadow(verts, uvs, cols, num, size2, vector.x, 0f);
					num = size2;
					size2 = verts.size;
					base.ApplyShadow(verts, uvs, cols, num, size2, 0f, vector.y);
					num = size2;
					size2 = verts.size;
					base.ApplyShadow(verts, uvs, cols, num, size2, 0f, -vector.y);
				}
			}
		}
		if (this.onPostFill != null)
		{
			this.onPostFill(this, num, verts, uvs, cols);
		}
	}
}
