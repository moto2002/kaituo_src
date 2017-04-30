using System;
using UnityEngine;

public class MessageTip : MonoBehaviour
{
	public UILabel m_tipLabel;

	public GameObject m_tipNode;

	private static MessageTip tipInst;

	private void Awake()
	{
		MessageTip.tipInst = this;
	}

	public void Close()
	{
		this.m_tipNode.SetActive(false);
	}

	public static void Tip(string msg)
	{
		MessageTip.tipInst.m_tipLabel.text = msg;
		MessageTip.tipInst.m_tipNode.SetActive(true);
	}
}
