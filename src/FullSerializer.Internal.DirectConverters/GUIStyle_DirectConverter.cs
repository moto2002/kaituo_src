using System;
using System.Collections.Generic;
using UnityEngine;

namespace FullSerializer.Internal.DirectConverters
{
	public class GUIStyle_DirectConverter : fsDirectConverter<GUIStyle>
	{
		protected override fsResult DoSerialize(GUIStyle model, Dictionary<string, fsData> serialized)
		{
			fsResult a = fsResult.Success;
			a += base.SerializeMember<GUIStyleState>(serialized, null, "active", model.active);
			a += base.SerializeMember<TextAnchor>(serialized, null, "alignment", model.alignment);
			a += base.SerializeMember<RectOffset>(serialized, null, "border", model.border);
			a += base.SerializeMember<TextClipping>(serialized, null, "clipping", model.clipping);
			a += base.SerializeMember<Vector2>(serialized, null, "contentOffset", model.contentOffset);
			a += base.SerializeMember<float>(serialized, null, "fixedHeight", model.fixedHeight);
			a += base.SerializeMember<float>(serialized, null, "fixedWidth", model.fixedWidth);
			a += base.SerializeMember<GUIStyleState>(serialized, null, "focused", model.focused);
			a += base.SerializeMember<Font>(serialized, null, "font", model.font);
			a += base.SerializeMember<int>(serialized, null, "fontSize", model.fontSize);
			a += base.SerializeMember<FontStyle>(serialized, null, "fontStyle", model.fontStyle);
			a += base.SerializeMember<GUIStyleState>(serialized, null, "hover", model.hover);
			a += base.SerializeMember<ImagePosition>(serialized, null, "imagePosition", model.imagePosition);
			a += base.SerializeMember<RectOffset>(serialized, null, "margin", model.margin);
			a += base.SerializeMember<string>(serialized, null, "name", model.name);
			a += base.SerializeMember<GUIStyleState>(serialized, null, "normal", model.normal);
			a += base.SerializeMember<GUIStyleState>(serialized, null, "onActive", model.onActive);
			a += base.SerializeMember<GUIStyleState>(serialized, null, "onFocused", model.onFocused);
			a += base.SerializeMember<GUIStyleState>(serialized, null, "onHover", model.onHover);
			a += base.SerializeMember<GUIStyleState>(serialized, null, "onNormal", model.onNormal);
			a += base.SerializeMember<RectOffset>(serialized, null, "overflow", model.overflow);
			a += base.SerializeMember<RectOffset>(serialized, null, "padding", model.padding);
			a += base.SerializeMember<bool>(serialized, null, "richText", model.richText);
			a += base.SerializeMember<bool>(serialized, null, "stretchHeight", model.stretchHeight);
			a += base.SerializeMember<bool>(serialized, null, "stretchWidth", model.stretchWidth);
			return a + base.SerializeMember<bool>(serialized, null, "wordWrap", model.wordWrap);
		}

		protected override fsResult DoDeserialize(Dictionary<string, fsData> data, ref GUIStyle model)
		{
			fsResult fsResult = fsResult.Success;
			GUIStyleState active = model.active;
			fsResult += base.DeserializeMember<GUIStyleState>(data, null, "active", out active);
			model.active = active;
			TextAnchor alignment = model.alignment;
			fsResult += base.DeserializeMember<TextAnchor>(data, null, "alignment", out alignment);
			model.alignment = alignment;
			RectOffset border = model.border;
			fsResult += base.DeserializeMember<RectOffset>(data, null, "border", out border);
			model.border = border;
			TextClipping clipping = model.clipping;
			fsResult += base.DeserializeMember<TextClipping>(data, null, "clipping", out clipping);
			model.clipping = clipping;
			Vector2 contentOffset = model.contentOffset;
			fsResult += base.DeserializeMember<Vector2>(data, null, "contentOffset", out contentOffset);
			model.contentOffset = contentOffset;
			float fixedHeight = model.fixedHeight;
			fsResult += base.DeserializeMember<float>(data, null, "fixedHeight", out fixedHeight);
			model.fixedHeight = fixedHeight;
			float fixedWidth = model.fixedWidth;
			fsResult += base.DeserializeMember<float>(data, null, "fixedWidth", out fixedWidth);
			model.fixedWidth = fixedWidth;
			GUIStyleState focused = model.focused;
			fsResult += base.DeserializeMember<GUIStyleState>(data, null, "focused", out focused);
			model.focused = focused;
			Font font = model.font;
			fsResult += base.DeserializeMember<Font>(data, null, "font", out font);
			model.font = font;
			int fontSize = model.fontSize;
			fsResult += base.DeserializeMember<int>(data, null, "fontSize", out fontSize);
			model.fontSize = fontSize;
			FontStyle fontStyle = model.fontStyle;
			fsResult += base.DeserializeMember<FontStyle>(data, null, "fontStyle", out fontStyle);
			model.fontStyle = fontStyle;
			GUIStyleState hover = model.hover;
			fsResult += base.DeserializeMember<GUIStyleState>(data, null, "hover", out hover);
			model.hover = hover;
			ImagePosition imagePosition = model.imagePosition;
			fsResult += base.DeserializeMember<ImagePosition>(data, null, "imagePosition", out imagePosition);
			model.imagePosition = imagePosition;
			RectOffset margin = model.margin;
			fsResult += base.DeserializeMember<RectOffset>(data, null, "margin", out margin);
			model.margin = margin;
			string name = model.name;
			fsResult += base.DeserializeMember<string>(data, null, "name", out name);
			model.name = name;
			GUIStyleState normal = model.normal;
			fsResult += base.DeserializeMember<GUIStyleState>(data, null, "normal", out normal);
			model.normal = normal;
			GUIStyleState onActive = model.onActive;
			fsResult += base.DeserializeMember<GUIStyleState>(data, null, "onActive", out onActive);
			model.onActive = onActive;
			GUIStyleState onFocused = model.onFocused;
			fsResult += base.DeserializeMember<GUIStyleState>(data, null, "onFocused", out onFocused);
			model.onFocused = onFocused;
			GUIStyleState onHover = model.onHover;
			fsResult += base.DeserializeMember<GUIStyleState>(data, null, "onHover", out onHover);
			model.onHover = onHover;
			GUIStyleState onNormal = model.onNormal;
			fsResult += base.DeserializeMember<GUIStyleState>(data, null, "onNormal", out onNormal);
			model.onNormal = onNormal;
			RectOffset overflow = model.overflow;
			fsResult += base.DeserializeMember<RectOffset>(data, null, "overflow", out overflow);
			model.overflow = overflow;
			RectOffset padding = model.padding;
			fsResult += base.DeserializeMember<RectOffset>(data, null, "padding", out padding);
			model.padding = padding;
			bool richText = model.richText;
			fsResult += base.DeserializeMember<bool>(data, null, "richText", out richText);
			model.richText = richText;
			bool stretchHeight = model.stretchHeight;
			fsResult += base.DeserializeMember<bool>(data, null, "stretchHeight", out stretchHeight);
			model.stretchHeight = stretchHeight;
			bool stretchWidth = model.stretchWidth;
			fsResult += base.DeserializeMember<bool>(data, null, "stretchWidth", out stretchWidth);
			model.stretchWidth = stretchWidth;
			bool wordWrap = model.wordWrap;
			fsResult += base.DeserializeMember<bool>(data, null, "wordWrap", out wordWrap);
			model.wordWrap = wordWrap;
			return fsResult;
		}

		public override object CreateInstance(fsData data, Type storageType)
		{
			return new GUIStyle();
		}
	}
}
