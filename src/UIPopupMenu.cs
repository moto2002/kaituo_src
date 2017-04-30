using System;
using System.Collections.Generic;
using UnityEngine;

public class UIPopupMenu : MonoBehaviour
{
	public delegate void OnPopupItemClick(int idx);

	public GameObject tweenTarget;

	public UILabel tweenLabel;

	public GameObject popupTarget;

	public Color pressedFont = new Color(0.7176471f, 0.6392157f, 0.482352942f, 1f);

	public Color disabledFont = Color.grey;

	public bool noPopupList;

	public bool pixelSnap;

	public string clickSprite;

	public TweenScale tweener;

	public Transform selectTarget;

	public List<Transform> popuplist = new List<Transform>();

	public List<EventDelegate> onClick = new List<EventDelegate>();

	public UIPopupMenu.OnPopupItemClick onPopupItemClick;

	private Color mDefaultFontColor = Color.white;

	private bool mInit;

	private string mNormalSprite;

	private int selectIdx;

	private UISprite sprite;

	private Vector3 tweenFrom;

	private Vector3 tweenTo;

	private GameObject mSelection;

	private Collider tweenCollider;

	private readonly Dictionary<string, int> popuplistDic = new Dictionary<string, int>();

	private void Awake()
	{
		this.OnInit();
	}

	private void OnEnable()
	{
		this.OnInit();
	}

	public void SelectItem(int idx)
	{
		if (!this.noPopupList)
		{
			this.selectTarget.localPosition = this.popuplist[idx].localPosition;
		}
		this.selectIdx = idx;
	}

	private void OnClick()
	{
		this.PopupClick();
	}

	private void PopupClick()
	{
		if (this.mSelection)
		{
			return;
		}
		this.SelectItem(this.selectIdx);
		this.sprite.spriteName = this.clickSprite;
		this.mSelection = UICamera.selectedObject;
		this.tweener.from = this.tweenFrom;
		this.tweener.to = this.tweenTo;
		this.tweener.ResetToBeginning();
		this.tweener.enabled = true;
		if (this.tweenCollider)
		{
			this.tweenCollider.enabled = true;
		}
		base.InvokeRepeating("checkClose", 0f, 0.1f);
	}

	private void onItemClick(GameObject go, bool isPress)
	{
		if (!isPress)
		{
			return;
		}
		int num = this.popuplistDic[go.name];
		if (this.selectIdx == num)
		{
			return;
		}
		this.selectIdx = num;
		if (this.onPopupItemClick != null)
		{
			this.onPopupItemClick(this.selectIdx);
		}
		this.closeSelf();
	}

	private void closeSelf()
	{
		this.tweener.from = this.tweenTo;
		this.tweener.to = this.tweenFrom;
		this.tweener.ResetToBeginning();
		this.tweener.enabled = true;
		this.sprite.spriteName = this.mNormalSprite;
		this.mSelection = null;
		if (this.tweenCollider)
		{
			this.tweenCollider.enabled = false;
		}
		base.CancelInvoke("checkClose");
	}

	private void checkClose()
	{
		if (UICamera.selectedObject != this.mSelection)
		{
			this.closeSelf();
		}
	}

	private void OnInit()
	{
		if (this.mInit)
		{
			return;
		}
		this.mInit = true;
		this.sprite = this.tweenTarget.GetComponent<UISprite>();
		this.mNormalSprite = this.sprite.spriteName;
		Transform transform = this.tweener.transform;
		this.tweenFrom = this.tweener.from;
		this.tweenTo = this.tweener.to;
		this.tweener.enabled = false;
		this.tweener.method = UITweener.Method.EaseOut;
		Vector3 localScale = transform.localScale;
		localScale.y = 0f;
		transform.localScale = localScale;
		this.tweenCollider = this.tweener.GetComponent<Collider>();
		if (this.tweenCollider)
		{
			this.tweenCollider.enabled = false;
		}
		for (int i = 0; i < this.popuplist.Count; i++)
		{
			GameObject gameObject = this.popuplist[i].gameObject;
			if (gameObject.GetComponent<Collider>())
			{
				UIEventListener.Get(gameObject).onPress = new UIEventListener.BoolDelegate(this.onItemClick);
				this.popuplistDic[gameObject.name] = i;
			}
		}
	}
}
