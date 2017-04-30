using System;
using System.Collections.Generic;
using UnityEngine;

public class TestEmoji : MonoBehaviour
{
	public UIEmojiGrid m_Grid;

	public List<GameObject> m_Emojis;

	public GameObject m_EmojiPrefab;

	public UIInput m_Input;

	public GameObject m_submit;

	private void Awake()
	{
		this.m_Emojis.ForEach(delegate(GameObject r)
		{
			UIEventListener.Get(r).onClick = delegate(GameObject go)
			{
				if (go == this.m_Emojis[0])
				{
					UIInput expr_1D = this.m_Input;
					expr_1D.value += "#1";
				}
				else if (go == this.m_Emojis[1])
				{
					UIInput expr_54 = this.m_Input;
					expr_54.value += "#2";
				}
				else
				{
					UIInput expr_74 = this.m_Input;
					expr_74.value += "#3";
				}
			};
		});
		UIEventListener.Get(this.m_submit).onClick = new UIEventListener.VoidDelegate(this.OnSubmit);
	}

	public void OnSubmit(GameObject go)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.m_EmojiPrefab);
		gameObject.transform.parent = this.m_Grid.transform;
		gameObject.transform.localScale = Vector3.one;
		UILabelEmoji component = gameObject.GetComponent<UILabelEmoji>();
		component.text = this.m_Input.value.Replace("#1", "[em=50,1]").Replace("#2", "[em=30,2]").Replace("#3", "[em=30,2]");
		this.m_Grid.repositionNow = true;
		this.m_Input.value = string.Empty;
	}
}
